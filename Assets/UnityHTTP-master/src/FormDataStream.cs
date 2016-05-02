using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assets.src
{
	public class FormPart
	{
		private readonly Stream _contents;
		private byte[] _header;
		private int _position;

		public FormPart(string fieldName, string mimeType, string boundary, Stream contents, string fileName = null)
		{
			var filenameheader = "";
			if (fileName != null)
			{
				filenameheader = "; filename=\"" + fileName + "\"";
			}
			_header = Encoding.ASCII.GetBytes(
				"\r\n--" + boundary + "\r\n" +
				"Content-Type: " + mimeType + "\r\n" +
				"Content-disposition: form-data; name=\"" + fieldName + "\"" + filenameheader + "\r\n\r\n"
				);
			this._contents = contents;
		}

		public long Length
		{
			get { return _header.Length + _contents.Length; }
		}

		public int Read(byte[] buffer, int offset, int size)
		{
			var writed = 0;
			int bytesToWrite;
			if (_position < _header.Length)
			{
				bytesToWrite = _header.Length - _position > size ? size : _header.Length - _position;
				Array.Copy(
					_header, // from header
					_position, // started from position
					buffer, // to buffer
					offset, // started with offset
					bytesToWrite
					);
				writed += bytesToWrite;
				_position += bytesToWrite;
			}
			if (writed >= size)
			{
				return writed;
			}
			bytesToWrite = _contents.Read(buffer, writed + offset, size - writed);
			writed += bytesToWrite;
			_position += bytesToWrite;
			return writed;
		}

		public void Dispose()
		{
			_header = null;
			_contents.Close();
		}
	}

	public class FormDataStream : Stream
	{
		private readonly string _boundary;
		private readonly byte[] _footer;
		private readonly List<FormPart> _parts = new List<FormPart>();
		private bool _dirty;
		private long _position;

		public FormDataStream(string boundary)
		{
			this._boundary = boundary;
			_footer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanTimeout
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override int ReadTimeout
		{
			get { return 0; }
			set { }
		}

		public override int WriteTimeout
		{
			get { return 0; }
			set { }
		}

		public override long Position
		{
			get { return _position; }
			set { throw new NotImplementedException("FormDataStream is non-seekable stream"); }
		}

		public override long Length
		{
			get
			{
				if (_parts.Count == 0)
				{
					return 0;
				}
				_dirty = true;
				long len = 0;
				foreach (var part in _parts)
				{
					len += part.Length;
				}
				return len + _footer.Length;
			}
		}

		public override void Flush()
		{
			throw new NotImplementedException("FormDataStream is readonly stream");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			_dirty = true;
			var writed = 0;
			var bytesToWrite = 0;

			// write parts
			long partsSize = 0;
			foreach (var part in _parts)
			{
				partsSize += part.Length;
				if (_position > partsSize)
				{
					continue;
				}
				bytesToWrite = part.Read(buffer, writed + offset, count - writed);
				writed += bytesToWrite;
				_position += bytesToWrite;
				if (writed >= count)
				{
					return count;
				}
			}


			// write footer
			bytesToWrite = count - writed > _footer.Length ? _footer.Length : count - writed;
			Array.Copy(_footer, 0, buffer, writed + offset, bytesToWrite);
			_position += bytesToWrite;
			writed += bytesToWrite;
			return writed;
		}

		public override long Seek(long amount, SeekOrigin origin)
		{
			throw new NotImplementedException("FormDataStream is non-seekable stream");
		}

		public override void SetLength(long len)
		{
			throw new NotImplementedException("FormDataStream is readonly stream");
		}

		public override void Write(byte[] source, int offset, int count)
		{
			throw new NotImplementedException("FormDataStream is readonly stream");
		}

		public void AddPart(string fieldName, string mimeType, Stream contents, string fileName = null)
		{
			if (_dirty)
			{
				throw new InvalidOperationException("You can't change form data, form already readed");
			}
			_parts.Add(new FormPart(fieldName, mimeType, _boundary, contents, fileName));
		}

		public void AddPart(FormPart part)
		{
			if (_dirty)
			{
				throw new InvalidOperationException("You can't change form data, form already readed");
			}
			_parts.Add(part);
		}

		public override void Close()
		{
			foreach (var part in _parts)
			{
				part.Dispose();
			}
			base.Close();
		}
	}
}