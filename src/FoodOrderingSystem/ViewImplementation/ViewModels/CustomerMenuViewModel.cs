using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using ViewImplementation.Models;
using System.Diagnostics.CodeAnalysis;

namespace ViewImplementation.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class CustomerMenuViewModel : BindableBase, INavigationAware
    {
        private NavigationContext navigation;
        private ObservableCollection<FoodItems> orderInfo;
        private Dictionary<String, Boolean> Map;
        public Dictionary<String, Boolean> IsEnabledMap
        {
            get { return Map; }
            set { SetProperty(ref Map, value); }
        }
        private bool steak = true;
        public bool Steak
        {
            get { return steak; }
            set { SetProperty(ref steak, value); }
        }
        private bool chicken = true;
        public bool Chicken
        {
            get { return chicken; }
            set { SetProperty(ref chicken, value); }
        }
        bool tofu = true;
        public bool Tofu
        {
            get { return tofu; }
            set { SetProperty(ref tofu, value); }
        }
        bool seafood = true;
        public bool Seafood
        {
            get { return seafood; }
            set { SetProperty(ref seafood, value); }
        }
        bool soy = true;
        public bool Soy
        {
            get { return soy; }
            set { SetProperty(ref soy, value); }
        }
        bool garlic = true;
        public bool Garlic
        {
            get { return garlic; }
            set { SetProperty(ref garlic, value); }
        }
        bool mongo = true;
        public bool Mongo
        {
            get { return mongo; }
            set { SetProperty(ref mongo, value); }
        }
        bool chili = true;
        public bool Chili
        {
            get { return chili; }
            set { SetProperty(ref chili, value); }
        }
        bool teriyaki = true;
        public bool Teriyaki
        {
            get { return teriyaki; }
            set { SetProperty(ref teriyaki, value); }
        }
        bool chickenStock = true;
        public bool ChickenStock
        {
            get { return chickenStock; }
            set { SetProperty(ref chickenStock, value); }
        }
        bool onion = true;
        public bool Onion
        {
            get { return onion; }
            set { SetProperty(ref onion, value); }
        }
        bool pepper = true;
        public bool Pepper
        {
            get { return pepper; }
            set { SetProperty(ref pepper, value); }
        }
        bool gOnion = true;
        public bool GOnion
        {
            get { return gOnion; }
            set { SetProperty(ref gOnion, value); }
        }
        bool brocc = true;
        public bool Brocc
        {
            get { return brocc; }
            set { SetProperty(ref brocc, value); }
        }
        bool carrot = true;
        public bool Carrot
        {
            get { return carrot; }
            set { SetProperty(ref carrot, value); }
        }
        bool mush = true;
        public bool Mush
        {
            get { return mush; }
            set { SetProperty(ref mush, value); }
        }
        bool egg = true;
        public bool Egg
        {
            get { return egg; }
            set { SetProperty(ref egg, value); }
        }
        bool rice = true;
        public bool Rice
        {
            get { return rice; }
            set { SetProperty(ref rice, value); }
        }
        private int _pageViews;
        public int OrderCount
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public CustomerMenuViewModel()
        {
            UpdateFoodItem = new DelegateCommand<string>(AddFoodItem);
            UpdateFoodTopping = new DelegateCommand<string>(AddTopping);
            PlaceOrderCommand = new DelegateCommand(PlaceOrder);
            foodItem = new FoodItems("No Meat");
            OrderCount = 1;
            OrderInfo = new ObservableCollection<FoodItems>()
            {
                foodItem
            };
            EventSystem.Subscribe<Dictionary<string, bool>>(UpdateMenu);
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

            EventSystem.Subscribe<string>(SendOrder);
        }

        private void SendOrder(string e)
        {
            if (e == "SendOrder")
            {
                Order order = new Order(foodItem, OrderCount);
                EventSystem.Publish(order);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigation = navigationContext;
            EventSystem.Publish("SendEnabled");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
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
        public DelegateCommand<string> UpdateFoodItem { get; private set; }
        public DelegateCommand<string> UpdateFoodTopping { get; private set; }
        public DelegateCommand PlaceOrderCommand { get; private set; }

        FoodItems foodItem;
        private void AddFoodItem(string item)
        {
            OrderInfo.Remove(foodItem);
            foodItem.FoodItem = item;
            OrderInfo.Add(foodItem);
            Order order = new Order(foodItem, OrderCount);
            EventSystem.Publish(order);
        }

        private void AddTopping(string topping)
        {
            OrderInfo.Remove(foodItem);
            foodItem.addTopping(topping);
            OrderInfo.Add(foodItem);
            Order order = new Order(foodItem, OrderCount);
            EventSystem.Publish(order);
        }
        private void PlaceOrder()
        {
            OrderCount++;
            navigation.NavigationService.RequestNavigate("CustomerPaymentView");
        }

        private void UpdateMenu(Dictionary<string, bool> m)
        {
            foreach (String x in m.Keys)
            {
                Map[x] = m[x];
            }
            Steak = Map["Steak"];
            Chicken = Map["Chicken"];
            Tofu = Map["Tofu"];
            Seafood = Map["Seafood"];
            Soy = Map["Soy Sauce"];
            Garlic = Map["Garlic Sauce"];
            Mongo = Map["Mongolian BBQ"];
            Chili = Map["Chili Sauce"];
            Teriyaki = Map["Teriyaki Sauce"];
            ChickenStock = Map["Chicken Stock"];
            Onion = Map["Onions"];
            Pepper = Map["Green Pepper"];
            GOnion = Map["Green Onions"];
            Brocc = Map["Broccoli"];
            Carrot = Map["Carrots"];
            Mush = Map["Mushrooms"];
            Egg = Map["Egg"];
            Rice = Map["Rice"];
        }
    }
}
