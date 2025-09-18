using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailsintheSky1stChapter
{
	internal class Character
	{
		private readonly uint mAddress;

		public Character(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get => SaveData.Instance().ReadNumber(mAddress, 1);
		}

		public uint Lv
		{
			get => SaveData.Instance().ReadNumber(mAddress + 4, 1);
		}

		public uint Exp
		{
			get => SaveData.Instance().ReadNumber(mAddress + 8, 4);
			set => SaveData.Instance().WriteNumber(mAddress + 8, 4, value);
		}

		public uint HP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 12, 4);
			set => SaveData.Instance().WriteNumber(mAddress + 12, 4, value);
		}

		public uint MaxHP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 16, 4);
			set => SaveData.Instance().WriteNumber(mAddress + 16, 4, value);
		}

		public uint EP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 20, 4);
			set => SaveData.Instance().WriteNumber(mAddress + 20, 4, value);
		}

		public uint MaxEP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 24, 4);
			set => SaveData.Instance().WriteNumber(mAddress + 24, 4, value);
		}
	}
}
