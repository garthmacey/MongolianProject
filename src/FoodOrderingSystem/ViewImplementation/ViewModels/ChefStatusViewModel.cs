using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ViewImplementation.Models;
using Prism.Commands;
using System.Diagnostics.CodeAnalysis;

namespace ViewImplementation.ViewModels
{
    [ExcludeFromCodeCoverage]
    class ChefStatusViewModel : BindableBase, INavigationAware
    {
        private NavigationContext navigation;
        private FoodItems foodItem;
        private OrderHandler handler = new OrderHandler();
        public ChefStatusViewModel()
        {
            inQueue = new ObservableCollection<FoodItems>()
            { };
            inProg = new ObservableCollection<FoodItems>()
            { };
            Finished = new ObservableCollection<FoodItems>()
            { };
            EventSystem.Subscribe<Customer>(UpdateOrder);
            markOrderStart = new DelegateCommand(startOrder);
            markOrderFinish = new DelegateCommand(finishOrder);
            undoComm = new DelegateCommand(undo);
            redoComm = new DelegateCommand(redo);
            NavigateCommand = new DelegateCommand(NavigatePage);
        }

        private void NavigatePage()
        {
            navigation.NavigationService.RequestNavigate("ChefFoodItemView");
        }

        public DelegateCommand markOrderStart { get; private set; }
        public DelegateCommand markOrderFinish { get; private set; }
        public DelegateCommand undoComm { get; private set; }
        public DelegateCommand redoComm { get; private set; }
        public DelegateCommand NavigateCommand { get; private set; }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigation = navigationContext;
        }
        private void OrderComplete(Order order)
        {
            if (order.checkStatus() == OrderStatus.INPROGRESS)
                order.updateStatus();
        }

        public void startOrder()
        {
            handler.startOrder(inQueue, inProg);
        }
        public void finishOrder()
        {
            handler.finishOrder(inProg, Finished);
        }
        public void undo()
        {
            handler.undo();
        }
        public void redo()
        {
            handler.redo();
        }
        private ObservableCollection<FoodItems> QueuedOrders;
        public ObservableCollection<FoodItems> inQueue
        {
            get
            {
                return QueuedOrders;
            }
            set
            {
                SetProperty(ref QueuedOrders, value);
            }
        }
        private ObservableCollection<FoodItems> InProgressOrders;
        public ObservableCollection<FoodItems> inProg
        {
            get
            {
                return InProgressOrders;
            }
            set
            {
                SetProperty(ref InProgressOrders, value);
            }
        }
        private ObservableCollection<FoodItems> finishedOrders;
        public ObservableCollection<FoodItems> Finished
        {
            get
            {
                return finishedOrders;
            }
            set
            {
                SetProperty(ref finishedOrders, value);
            }
        }
        private void UpdateOrder(Customer customer)
        {

                if (customer.checkStatus() == OrderStatus.ORDERED)
                {
                    inQueue.Add(customer.getOrder());
                }
                else
                {
                    inProg.Add(customer.getOrder());
                }
            
        }
    }
}