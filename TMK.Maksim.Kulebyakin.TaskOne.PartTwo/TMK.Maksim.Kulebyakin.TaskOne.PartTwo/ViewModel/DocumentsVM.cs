using Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TMK.Maksim.Kulebyakin.TaskOne.PartTwo.ViewModel
{
    public class DocumentsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<DisplayedDocument> Documents { get; set; }

        public void OnPropertyChanged([CallerMemberName] string porp = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porp));
        }
    }
}
