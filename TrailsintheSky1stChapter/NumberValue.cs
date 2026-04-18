using System.ComponentModel;

namespace TrailsintheSky1stChapter
{
    class NumberValue : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler? PropertyChanged;

		private readonly uint mAddress;
        private readonly uint mSize;

        public NumberValue(uint address, uint size)
        {
            mAddress = address;
            mSize = size;
        }

        public uint Value
        {
            get => SaveData.Instance().ReadNumber(mAddress, mSize);
            set
            {
                SaveData.Instance().WriteNumber(mAddress, mSize, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
			}
        }
	}
}
