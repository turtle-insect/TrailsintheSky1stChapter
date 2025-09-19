using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrailsintheSky1stChapter
{
	internal class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		public Info Info { get; init; } = Info.Instance();

		public SaveData.PlatForm[] PlatForms { get; init; } = [
			SaveData.PlatForm.STEAM, SaveData.PlatForm.Switch,
		];
		public int PlatFormIndex { get; set; } = 0;

		public ICommand OpenFileCommand { get; init; }
		public ICommand SaveFileCommand { get; init; }
		public ICommand ImportFileCommand { get; init; }
		public ICommand ExportFileCommand { get; init; }
		public ICommand ChoicePartyCommand { get; init; }

		public General General { get; init; } = new();
		public ObservableCollection<Item> Items { get; init; } = new();
		public ObservableCollection<Character> Characters { get; init; } = new();
		public ObservableCollection<NumberValue> Party { get; init; } = new();
		public ObservableCollection<Monster> Monsters { get; init; } = new();

		public ViewModel()
		{
			OpenFileCommand = new CommandAction(OpenFile);
			SaveFileCommand = new CommandAction(SaveFile);
			ImportFileCommand = new CommandAction(ImportFile);
			ExportFileCommand = new CommandAction(ExportFile);
			ChoicePartyCommand = new CommandAction(ChoiceParty);
		}

		private void Initialize()
		{
			Characters.Clear();
			for (uint index = 0; index < 8; index++)
			{
				Characters.Add(new Character(0x102588 + index * 664));
			}

			Party.Clear();
			for (uint index = 0; index < 10; index++)
			{
				Party.Add(new NumberValue(0x41454 + index * 2, 2));
			}

			Monsters.Clear();
			for (uint index = 0; index < Info.Monster.Count; index++)
			{
				var monster = new Monster(0x1F262C + index * 4);
				monster.ID = index;
				Monsters.Add(monster);
			}

			Items.Clear();
			for (uint index = 0; index < Info.Item.Count; index++)
			{
				var id = Info.Item[(int)index].Value;
				var item = new Item(0x116720 + id * 4);
				item.ID = id;
				Items.Add(item);
			}

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(General)));
		}

		private void OpenFile(object? parameter)
		{
			var dlg = new OpenFileDialog();
			if (PlatForms[PlatFormIndex] == SaveData.PlatForm.STEAM)
			{
				var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
					@"Saved Games\Falcom\Trails in the Sky 1st Chapter\savedata");

				if (!System.IO.Directory.Exists(path)) return;
				dlg.Filter = "user.dat|user.dat";
				dlg.InitialDirectory = path;
			}
			else
			{
				dlg.Filter = "data.dat|data.dat";
			}

			if (dlg.ShowDialog() == false) return;
			if (!SaveData.Instance().Open(dlg.FileName, false, PlatForms[PlatFormIndex])) return;

			Initialize();
		}

		private void SaveFile(object? parameter)
		{
			SaveData.Instance().Save();
		}

		private void ImportFile(object? parameter)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Import(dlg.FileName);
			Initialize();
		}

		private void ExportFile(object? parameter)
		{
			var dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Export(dlg.FileName);
		}

		private void ChoiceParty(object? parameter)
		{
			var number = parameter as NumberValue;
			if (number == null) return;

			var dlg = new ChoiceWindow();
			dlg.Type = ChoiceWindow.ChoiceType.Chara;
			dlg.ID = number.Value;
			dlg.ShowDialog();

			number.Value = dlg.ID;
		}
	}
}
