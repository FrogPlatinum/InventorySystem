using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Items { get; set; }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<string> { "All", "Books", "Live Equipment", "Board Games" };
            SelectedItem = "All";
        }

        //Update UI on property changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged
        ([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke
            (this, new PropertyChangedEventArgs(name));
        }
    }
}
