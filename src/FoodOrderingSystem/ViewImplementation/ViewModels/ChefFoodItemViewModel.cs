using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ViewImplementation.Models;
using System.Diagnostics.CodeAnalysis;

namespace ViewImplementation.ViewModels
{
    [ExcludeFromCodeCoverage]
    class ChefFoodItemViewModel : BindableBase, INavigationAware
    {
        private int _pageViews;
        private ObservableCollection<Dictionary<string,bool>> orderInfo;
        private Dictionary<string, bool> Map;
        bool Steak = true;
        bool Chicken = true;
        bool Tofu = true;
        bool Seafood = true;
        bool Soy = true;
        bool Garlic = true;
        bool Mongo = true;
        bool Chili = true;
        bool Teriyaki = true;
        bool ChickenStock = true;
        bool Onion = true;
        bool Pepper = true;
        bool GOnion = true;
        bool Brocc = true;
        bool Carrot = true;
        bool Mush = true;
        bool Egg = true;
        bool Rice = true;


        public ChefFoodItemViewModel()
        {
            UpdateFoodItem = new DelegateCommand<string>(AddFoodItem);
            UpdateFoodTopping = new DelegateCommand<string>(AddTopping);
            PlaceOrderCommand = new DelegateCommand(PlaceOrder);
            foodItem = new FoodItems("No Meat");
            Map = new Dictionary<string, bool>()
            {
                { "Steak", Steak},
                { "Chicken", Chicken},
                { "Tofu", Tofu},
                { "Seafood", Seafood},
                { "Soy Sauce", Soy},
                { "Garlic Sauce", Garlic},
                { "Mongolian BBQ", Mongo},
                { "Chili Sauce", Chili},
                { "Teriyaki Sauce", Teriyaki},
                { "Chicken Stock", ChickenStock},
                { "Onions", Onion},
                { "Green Pepper", Pepper},
                { "Green Onions", GOnion},
                { "Broccoli", Brocc},
                { "Carrots", Carrot},
                { "Mushrooms", Mush},
                { "Egg", Egg },
                { "Rice", Rice }
            };
            OrderInfo = new ObservableCollection<Dictionary<string, bool>>()
            {
                Map
            };
            EventSystem.Subscribe<string>(SendEnabled);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigation = navigationContext;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        public ObservableCollection<Dictionary<string, bool>> OrderInfo
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

        public DelegateCommand<string> UpdateFoodItem { get; private set; }
        public DelegateCommand<string> UpdateFoodTopping { get; private set; }
        public DelegateCommand PlaceOrderCommand { get; private set; }

        FoodItems foodItem;
        private NavigationContext navigation;

        private void AddFoodItem(string item)
        {
            OrderInfo.Remove(Map);
            Map[item] = !Map[item];
            OrderInfo.Add(Map);
        }

        private void AddTopping(string topping)
        {
            OrderInfo.Remove(Map);
            Map[topping] = !Map[topping];
            OrderInfo.Add(Map);
        }
        private void PlaceOrder()
        { 
            
            EventSystem.Publish(Map);
            navigation.NavigationService.RequestNavigate("ChefStatusView");
        }
        private void SendEnabled(string message)
        {
            if (message == "SendEnabled")
            {
                EventSystem.Publish(Map);
            }
        }
    }
}
