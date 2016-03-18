using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
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
                    OnPropertyChanged();
                }
            }
        }
    }
}
