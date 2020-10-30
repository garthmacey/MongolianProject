using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using ViewImplementation.Models;
using System.Diagnostics.CodeAnalysis;

namespace ViewImplementation.ViewModels
{
    [ExcludeFromCodeCoverage]
    class CustomerPaymentViewModel : BindableBase, INavigationAware
    {
      private Customer customer;
      private string payment;
      private Handle handle;
      public string paymentTypeD
      {
         get { return payment; }
         set { SetProperty(ref payment, value); }
      }
      private string num;
      public string phoneNumber
      {
         get { return num; }
         set { SetProperty(ref num, value); }
      }
      private NavigationContext navigation;
      public bool IsNavigationTarget(NavigationContext navigationContext)
      {
         return false;
      }

      public string getPayType()
      {
         return paymentTypeD;
      }
      public void OnNavigatedFrom(NavigationContext navigationContext)
      {
            
      }

      public void OnNavigatedTo(NavigationContext navigationContext)
      {
         navigation = navigationContext;
         EventSystem.Publish("SendOrder");

      }
      public CustomerPaymentViewModel()
      {
         handle = new Handle();
         customer = new Customer();
         phoneNumber = "";
         OrderInfo = new ObservableCollection<FoodItems>() { };
         foodItem = new FoodItems("No Meat");
         EventSystem.Subscribe<Order>(UpdateOrder);
         UpdatePaymentTypeCommand = new DelegateCommand<string>(UpdatePaymentType);
         UpdatePhoneNumCommand = new DelegateCommand<string>(UpdatePhoneNum);
         ChangeScreenCommand = new DelegateCommand(ChangeScreen);
         UndoPhoneCommand = new DelegateCommand(UndoPhone);
         RedoPhoneCommand = new DelegateCommand(RedoPhone);
      }

      private ObservableCollection<FoodItems> orderInfo;
      FoodItems foodItem;
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
            customer.setOrder(orderItem.getOrder(), 0);
      }
      public void UpdatePaymentType(string paymentType)
      {
         paymentTypeD = paymentType;
         this.paymentType = paymentType;
         switch (paymentType)
         {
            case "Cash":
               customer.setPay(PaymentType.CASH);
               break;
            case "Student ID":
               customer.setPay(PaymentType.STUDENTID);
               break;
            case "Credit Card":
               customer.setPay(PaymentType.CREDITCARD);
               break;
            default:
               customer.setPay(PaymentType.CASH);
               break;
         }
      }

      public void UpdatePhoneNum(string phoneNum)
      {

            if (phoneNumber.Length != 14)
            {
                if (phoneNumber.Length == 0)
                    phoneNumber += "(";
                if (phoneNumber.Length == 5)
                    phoneNumber += "-";
                if (phoneNumber.Length == 4)
                    phoneNumber += ")-";
                if (phoneNumber.Length == 9)
                    phoneNumber += "-";
                phoneNumber += phoneNum;
                handle.clearStack();
                if (phoneNumber.Length == 14)
                {
                    customer.setPhoneNumber(phoneNumber);
                }
            }
      }

      public void RedoPhone()
      {
            if(phoneNumber.Length != 14)
            {
                string temp = phoneNumber;
                phoneNumber = handle.undoRemove();
                if (phoneNumber == "")
                    phoneNumber = temp;
            }
      }

      public void UndoPhone()
      {
            if (phoneNumber.Length != 0)
            {
                handle.setNum(phoneNumber);
                phoneNumber = handle.removeNum();
            }
      }

      public void ChangeScreen()
      {
        if(phoneNumber.Length == 14 && paymentTypeD != null)
            {
                EventSystem.Publish(customer);
                navigation.NavigationService.RequestNavigate("CustomerMenuView");
            }

      }
      private string paymentType = null;
      public DelegateCommand<string> UpdatePaymentTypeCommand { get; private set; }

      public DelegateCommand<string> UpdatePhoneNumCommand { get; private set; }

      public DelegateCommand ChangeScreenCommand { get; private set; }

      public DelegateCommand UndoPhoneCommand { get; private set; }
      public DelegateCommand RedoPhoneCommand { get; private set; }
    }
}
