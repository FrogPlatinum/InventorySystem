using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Items { get; set; }
        public ObservableCollection<Item> AllItems { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> FilteredItems { get; set; } = new ObservableCollection<Item>();

        private readonly IItemRepo _itemRepo;

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                FilterItems();
            }
        }

        //Dont understand this (inside ctor, and parameter ctor)
        public MainViewModel(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;

            Items = new ObservableCollection<string> { "All", "Books", "Live Equipment", "Board Games" };
            SelectedItem = "All";

            AllItems = new ObservableCollection<Item>(_itemRepo.GetAll());
            FilteredItems = new ObservableCollection<Item>();

            FilterItems();
        }

        //Dont understand this
        private void FilterItems()
        {
            FilteredItems.Clear();

            foreach (Item item in AllItems)
            {
                if(SelectedItem == "All" ||  SelectedItem == "Books" && item is Book || SelectedItem == "Live Equipment" && item is LiveEquipment || SelectedItem == "Board Games" && item is BoardGame)
                {
                    FilteredItems.Add(item);
                }
            }
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
