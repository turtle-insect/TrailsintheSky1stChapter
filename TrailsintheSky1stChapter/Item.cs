using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailsintheSky1stChapter
{
	internal class Item
	{
		private readonly uint mAddress;

		public Item(uint address)
		{
			mAddress = address;
		}

		public uint ID { get; set; }

		public uint Count
		{
			get => SaveData.Instance().ReadNumber(mAddress, 2);
			set => Util.WriteNumber(mAddress, 2, value, 0, 99);
		}

		public bool New
		{
			get => SaveData.Instance().ReadBit(mAddress + 2, 0);
			set => SaveData.Instance().WriteBit(mAddress + 2, 0, value);
		}

		public bool HasHistory
		{
			get => SaveData.Instance().ReadBit(mAddress + 2,1);
			set => SaveData.Instance().WriteBit(mAddress + 2, 1, value);
		}
	}
}
