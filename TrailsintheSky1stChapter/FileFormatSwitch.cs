using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailsintheSky1stChapter
{
	internal class FileFormatSwitch : IFileFormat
	{
		private Byte[] mHeader = [];
		private Byte[] mFooter = [];
		public byte[] Load(string filename)
		{
			Byte[] buffer = System.IO.File.ReadAllBytes(filename);
			var headerSize = BitConverter.ToInt32(buffer, 0);
			mHeader = buffer[0..headerSize];
			var footerPos = BitConverter.ToInt32(buffer, 4);
			mFooter = buffer[footerPos..];
			return buffer[headerSize..footerPos];
		}

		public void Save(string filename, byte[] buffer)
		{
			var totalSize = mHeader.Length + buffer.Length + mFooter.Length;
			Byte[] tmp = new Byte[totalSize];
			Array.Copy(mHeader, tmp, mHeader.Length);
			Array.Copy(buffer, 0, tmp, mHeader.Length, buffer.Length);
			Array.Copy(mFooter, 0, tmp, mHeader.Length + buffer.Length, mFooter.Length);

			System.IO.File.WriteAllBytes(filename, tmp);
		}
	}
}
