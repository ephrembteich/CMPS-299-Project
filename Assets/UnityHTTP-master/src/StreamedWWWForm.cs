using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Assets.src
{
	public class StreamedWwwForm
	{
		private readonly string _boundary;
		public FormDataStream Stream;

		public StreamedWwwForm()
		{
			var bytes = new byte[40];
			var random = new Random();
			for (var i = 0; i < 40; i++)
			{
				bytes[i] = (byte) (48 + random.Next(62));
				if (bytes[i] > 57)
				{
					bytes[i] += 7;
				}
				if (bytes[i] > 90)
				{
					bytes[i] += 6;
				}
			}
			_boundary = Encoding.ASCII.GetString(bytes);
			Stream = new FormDataStream(_boundary);
		}

		public Hashtable Headers
		{
			get
			{
				return new Hashtable
				{
					{"Content-Type", "multipart/form-data; boundary=\"" + _boundary + "\""}
				};
			}
		}

		public void AddField(string fieldName, string fieldValue)
		{
			var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(fieldValue));
			Stream.AddPart(fieldName, "text/plain; charset=\"utf-8\"", contentStream);
		}

		public void AddBinaryData(string fieldName, byte[] contents = null, string mimeType = null)
		{
			var contentStream = new MemoryStream(contents);
			if (mimeType == null)
			{
				mimeType = "application/octet-stream";
			}
			Stream.AddPart(fieldName, mimeType, contentStream, fieldName + ".dat");
		}

		public void AddBinaryData(string fieldName, Stream contents = null, string mimeType = null)
		{
			if (mimeType == null)
			{
				mimeType = "application/octet-stream";
			}
			Stream.AddPart(fieldName, mimeType, contents, fieldName + ".dat");
		}

		public void AddFile(string fieldName, string path, string mimeType = null)
		{
			if (mimeType == null)
			{
				mimeType = "application/octet-stream";
			}
			var contents = new FileInfo(path).Open(FileMode.Open);
			Stream.AddPart(fieldName, mimeType, contents, fieldName + ".dat");
		}
	}
}