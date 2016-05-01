using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Based on node-cookiejar (https://github.com/bmeck/node-cookiejar)

namespace Assets.src
{
	public class CookieAccessInfo
	{
		public string Domain;
		public string Path;
		public bool ScriptAccessible = true;
		public bool Secure;

		public CookieAccessInfo(string domain, string path)
		{
			this.Domain = domain;
			this.Path = path;
		}

		public CookieAccessInfo(string domain, string path, bool secure)
		{
			this.Domain = domain;
			this.Path = path;
			this.Secure = secure;
		}

		public CookieAccessInfo(string domain, string path, bool secure, bool scriptAccessible)
		{
			this.Domain = domain;
			this.Path = path;
			this.Secure = secure;
			this.ScriptAccessible = scriptAccessible;
		}

		public CookieAccessInfo(Cookie cookie)
		{
			Domain = cookie.Domain;
			Path = cookie.Path;
			Secure = cookie.Secure;
			ScriptAccessible = cookie.ScriptAccessible;
		}
	}

	public class Cookie
	{
		private static readonly string CookiePattern = "\\s*([^=]+)(?:=((?:.|\\n)*))?";
		public string Domain;
		public DateTime ExpirationDate = DateTime.MaxValue;
		public string Name;
		public string Path;
		public bool ScriptAccessible = true;
		public bool Secure;
		public string Value;

		public Cookie(string cookieString)
		{
			var parts = cookieString.Split(';');
			foreach (var part in parts)
			{
				var match = Regex.Match(part, CookiePattern);

				if (!match.Success)
				{
					throw new Exception("Could not parse cookie string: " + cookieString);
				}

				if (Name == null)
				{
					Name = match.Groups[1].Value;
					Value = match.Groups[2].Value;
					continue;
				}

				switch (match.Groups[1].Value.ToLower())
				{
					case "httponly":
						ScriptAccessible = false;
						break;
					case "expires":
						ExpirationDate = DateTime.Parse(match.Groups[2].Value);
						break;
					case "path":
						Path = match.Groups[2].Value;
						break;
					case "domain":
						Domain = match.Groups[2].Value;
						break;
					case "secure":
						Secure = true;
						break;
					default:
						// TODO: warn of unknown cookie setting?
						break;
				}
			}
		}

		public bool Matches(CookieAccessInfo accessInfo)
		{
			if (Secure != accessInfo.Secure
			    || !CollidesWith(accessInfo))
			{
				return false;
			}

			return true;
		}

		public bool CollidesWith(CookieAccessInfo accessInfo)
		{
			if ((Path != null && accessInfo.Path == null) || (Domain != null && accessInfo.Domain == null))
			{
				return false;
			}

			if (Path != null && accessInfo.Path != null && accessInfo.Path.IndexOf(Path) != 0)
			{
				return false;
			}

			if (Domain == accessInfo.Domain)
			{
				return true;
			}
			if (Domain != null && Domain.Length >= 1 && Domain[0] == '.')
			{
				var wildcard = accessInfo.Domain.IndexOf(Domain.Substring(1));
				if (wildcard == -1 || wildcard != accessInfo.Domain.Length - Domain.Length + 1)
				{
					return false;
				}
			}
			else if (Domain != null)
			{
				return false;
			}

			return true;
		}

		public string ToValueString()
		{
			return Name + "=" + Value;
		}

		public override string ToString()
		{
			var elements = new List<string>();
			elements.Add(Name + "=" + Value);

			if (ExpirationDate != DateTime.MaxValue)
			{
				elements.Add("expires=" + ExpirationDate);
			}

			if (Domain != null)
			{
				elements.Add("domain=" + Domain);
			}

			if (Path != null)
			{
				elements.Add("path=" + Path);
			}

			if (Secure)
			{
				elements.Add("secure");
			}

			if (ScriptAccessible == false)
			{
				elements.Add("httponly");
			}

			return String.Join("; ", elements.ToArray());
		}
	}

	public delegate void ContentsChangedDelegate();

	public class CookieJar
	{
		private static readonly string Version = "v2";
		private static CookieJar _instance;
		private static readonly string CookiesStringPattern = "[:](?=\\s*[a-zA-Z0-9_\\-]+\\s*[=])";
		private static readonly string Boundary = "\n!!::!!\n";
		private readonly object _cookieJarLock = new object();
		public ContentsChangedDelegate ContentsChanged;
		public Dictionary<string, List<Cookie>> Cookies;

		public CookieJar()
		{
			Clear();
		}

		public static CookieJar Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CookieJar();
				}
				return _instance;
			}
		}

		public void Clear()
		{
			lock (_cookieJarLock)
			{
				Cookies = new Dictionary<string, List<Cookie>>();
				if (ContentsChanged != null)
				{
					ContentsChanged();
				}
			}
		}

		public bool SetCookie(Cookie cookie)
		{
			lock (_cookieJarLock)
			{
				var expired = cookie.ExpirationDate < DateTime.Now;

				if (Cookies.ContainsKey(cookie.Name))
				{
					for (var index = 0; index < Cookies[cookie.Name].Count; ++index)
					{
						var collidableCookie = Cookies[cookie.Name][index];
						if (collidableCookie.CollidesWith(new CookieAccessInfo(cookie)))
						{
							if (expired)
							{
								Cookies[cookie.Name].RemoveAt(index);
								if (Cookies[cookie.Name].Count == 0)
								{
									Cookies.Remove(cookie.Name);
									if (ContentsChanged != null)
									{
										ContentsChanged();
									}
								}

								return false;
							}
							Cookies[cookie.Name][index] = cookie;
							if (ContentsChanged != null)
							{
								ContentsChanged();
							}
							return true;
						}
					}

					if (expired)
					{
						return false;
					}

					Cookies[cookie.Name].Add(cookie);
					if (ContentsChanged != null)
					{
						ContentsChanged();
					}
					return true;
				}

				if (expired)
				{
					return false;
				}

				Cookies[cookie.Name] = new List<Cookie>();
				Cookies[cookie.Name].Add(cookie);
				if (ContentsChanged != null)
				{
					ContentsChanged();
				}
				return true;
			}
		}

		// TODO: figure out a way to respect the scriptAccessible flag and supress cookies being
		//       returned that should not be.  The issue is that at some point, within this
		//       library, we need to send all the correct cookies back in the request.  Right now
		//       there's no way to add all cookies (regardless of script accessibility) to the
		//       request without exposing cookies that should not be script accessible.

		public Cookie GetCookie(string name, CookieAccessInfo accessInfo)
		{
			if (!Cookies.ContainsKey(name))
			{
				return null;
			}

			for (var index = 0; index < Cookies[name].Count; ++index)
			{
				var cookie = Cookies[name][index];
				if (cookie.ExpirationDate > DateTime.Now && cookie.Matches(accessInfo))
				{
					return cookie;
				}
			}

			return null;
		}

		public List<Cookie> GetCookies(CookieAccessInfo accessInfo)
		{
			var result = new List<Cookie>();
			foreach (var cookieName in Cookies.Keys)
			{
				var cookie = GetCookie(cookieName, accessInfo);
				if (cookie != null)
				{
					result.Add(cookie);
				}
			}

			return result;
		}

		public void SetCookies(Cookie[] cookieObjects)
		{
			for (var index = 0; index < cookieObjects.Length; ++index)
			{
				SetCookie(cookieObjects[index]);
			}
		}

		public void SetCookies(string cookiesString)
		{
			var match = Regex.Match(cookiesString, CookiesStringPattern);

			if (!match.Success)
			{
				throw new Exception("Could not parse cookies string: " + cookiesString);
			}

			for (var index = 0; index < match.Groups.Count; ++index)
			{
				SetCookie(new Cookie(match.Groups[index].Value));
			}
		}

		public string Serialize()
		{
			var result = Version + Boundary;

			lock (_cookieJarLock)
			{
				foreach (var key in Cookies.Keys)
				{
					for (var index = 0; index < Cookies[key].Count; ++index)
					{
						result += Cookies[key][index] + Boundary;
					}
				}
			}

			return result;
		}

		public void Deserialize(string cookieJarString, bool clear)
		{
			if (clear)
			{
				Clear();
			}

			var regex = new Regex(Boundary);
			var cookieStrings = regex.Split(cookieJarString);
			var readVersion = false;
			foreach (var cookieString in cookieStrings)
			{
				if (!readVersion)
				{
					if (cookieString.IndexOf(Version) != 0)
					{
						return;
					}
					readVersion = true;
					continue;
				}

				if (cookieString.Length > 0)
				{
					SetCookie(new Cookie(cookieString));
				}
			}
		}
	}
}