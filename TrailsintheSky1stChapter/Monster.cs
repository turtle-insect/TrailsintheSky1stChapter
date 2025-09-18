using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailsintheSky1stChapter
{
    class Monster
    {
        private readonly uint mAddress;

        public Monster(uint address)
        {
            mAddress = address;
        }

        public uint ID { get; set; }

        public bool Visible
        {
            get => SaveData.Instance().ReadNumber(mAddress, 1) == 1;
            set => SaveData.Instance().WriteNumber(mAddress, 1, value ? 1 : 0U);
        }

		public uint Lv
		{
            get => SaveData.Instance().ReadNumber(mAddress + 2, 1);
            set => SaveData.Instance().WriteNumber(mAddress + 2, 1, value);
		}
	}
}
