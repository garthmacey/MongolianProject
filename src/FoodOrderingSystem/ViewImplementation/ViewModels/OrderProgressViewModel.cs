using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ViewImplementation.Models;
using System.Diagnostics.CodeAnalysis;

namespace ViewImplementation.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class OrderProgressViewModel : BindableBase, INavigationAware
    {


        private NavigationContext navigation;
        private FoodItems foodItem;
        public OrderProgressViewModel()
        {
            foodItem = new FoodItems("No Meat");
            OrderInfo = new ObservableCollection<FoodItems>()
            { };
            EventSystem.Subscribe<Order>(UpdateOrder);


        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigation = navigationContext;
            EventSystem.Publish("SendOrder");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        private ObservableCollection<FoodItems> orderInfo;


        public ObservableCollection<FoodItems> OrderInfo
        {
            get
            {
                return orderInfo;
            }
            set
            {
                SetProperty(ref orderInfo, value);
            }
        }
        private void UpdateOrder(Order orderItem)
        {
            OrderInfo.Clear();
            OrderInfo.Add(orderItem.getOrder());
        }

    }
}
