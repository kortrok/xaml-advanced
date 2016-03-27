using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            this.AddMenuItemCommand = new DelegateCommand(AddMenuItemExecute);
            this.SubmitOrderCommand = new DelegateCommand(SubmitOrderExecute);
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private List<MenuItem> _MenuItems;
        public List<MenuItem> MenuItems
        {
            get { return _MenuItems; }
            set
            {
                if (value != _MenuItems)
                {
                    _MenuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private MenuItem _SelectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return _SelectedMenuItem; }
            set
            {
                if (value != _SelectedMenuItem)
                {
                    _SelectedMenuItem = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> _CurrentlySelectedMenuItems;
        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _CurrentlySelectedMenuItems; }
            set
            {
                if (value != _CurrentlySelectedMenuItems)
                {
                    _CurrentlySelectedMenuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand AddMenuItemCommand { get; private set; }
        private void AddMenuItemExecute()
        {
            if (SelectedMenuItem != null && CurrentlySelectedMenuItems != null)
                CurrentlySelectedMenuItems.Add(SelectedMenuItem);
        }

        public DelegateCommand SubmitOrderCommand { get; private set; }
        private void SubmitOrderExecute()
        {
            if (Repository != null && CurrentlySelectedMenuItems != null && CurrentlySelectedMenuItems.Count != 0)
            {
                Repository.Orders.Add(new Order { Table = Repository.Tables.First(), Items = CurrentlySelectedMenuItems.ToList() });
                CurrentlySelectedMenuItems.Clear();
            }
        }
    }
}
