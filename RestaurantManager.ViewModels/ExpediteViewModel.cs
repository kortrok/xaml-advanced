using RestaurantManager.Models;
using System.Collections.Generic;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            OrderItems = Repository.Orders;
        }

        private List<Order> _OrderItems;
        public List<Order> OrderItems
        {
            get { return _OrderItems; }
            set
            {
                if (value != _OrderItems)
                {
                    _OrderItems = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
