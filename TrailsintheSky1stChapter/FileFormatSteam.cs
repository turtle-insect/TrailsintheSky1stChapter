namespace TrailsintheSky1stChapter
{
	internal class FileFormatSteam : IFileFormat
	{
		public byte[] Load(string filename)
		{
			Byte[] buffer = [];
			using (var decompressor = new ZstdNet.Decompressor())
			{
				try
				{
					buffer = decompressor.Unwrap(System.IO.File.ReadAllBytes(filename));
				}
				catch { }
			}

			return buffer;
		}

		public void Save(string filename, byte[] buffer)
		{
			using (var compressor = new ZstdNet.Compressor())
			{
				buffer = compressor.Wrap(buffer);
			}

			System.IO.File.WriteAllBytes(filename, buffer);
		}
	}
}
