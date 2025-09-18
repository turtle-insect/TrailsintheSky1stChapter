using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailsintheSky1stChapter
{
	internal class General
	{
		// Sepith
		public uint Earth
		{
			get => SaveData.Instance().ReadNumber(0x1F38D8, 4);
			set => Util.WriteNumber(0x1F38D8, 4, value, 0, 9999);
		}

		public uint Water
		{
			get => SaveData.Instance().ReadNumber(0x1F38DC, 4);
			set => Util.WriteNumber(0x1F38DC, 4, value, 0, 9999);
		}

		public uint Fire
		{
			get => SaveData.Instance().ReadNumber(0x1F38E0, 4);
			set => Util.WriteNumber(0x1F38E0, 4, value, 0, 9999);
		}

		public uint Wind
		{
			get => SaveData.Instance().ReadNumber(0x1F38E4, 4);
			set => Util.WriteNumber(0x1F38E4, 4, value, 0, 9999);
		}

		public uint Time
		{
			get => SaveData.Instance().ReadNumber(0x1F38E8, 4);
			set => Util.WriteNumber(0x1F38E8, 4, value, 0, 9999);
		}

		public uint Space
		{
			get => SaveData.Instance().ReadNumber(0x1F38EC, 4);
			set => Util.WriteNumber(0x1F38EC, 4, value, 0, 9999);
		}

		public uint Mirage
		{
			get => SaveData.Instance().ReadNumber(0x1F38F0, 4);
			set => Util.WriteNumber(0x1F38F0, 4, value, 0, 9999);
		}

		public uint Mass
		{
			get => SaveData.Instance().ReadNumber(0x1F38F4, 4);
			set => Util.WriteNumber(0x1F38F4, 4, value, 0, 9999);
		}

		public uint Money
		{
			get => SaveData.Instance().ReadNumber(0x1F38F8, 4);
			set => Util.WriteNumber(0x1F38F8, 4, value, 0, 9999999);
		}
	}
}
