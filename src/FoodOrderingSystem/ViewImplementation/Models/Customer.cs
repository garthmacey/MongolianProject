using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation.Models
{
    public class Customer 
    {
      private List<Order> orders = new List<Order>();
        private String phoneNumber;
      private PaymentType paymentType;
      private int currentOrder = 0;

        public List<Order> Orders { get => orders; set => orders = value; }

        public Customer()
      {
            
      }

      public Customer(string phoneNumber, PaymentType paymentType)
      {
         this.phoneNumber = phoneNumber;
         this.paymentType = paymentType;
      }

      public void setPhoneNumber(string p)
      {
         phoneNumber = p;
      }

      public string getPhoneNumber()
      {
         return phoneNumber;
      }

      public void setPay(PaymentType type)
      {
         paymentType = type;
      }

      public PaymentType getPaymentType()
      {
         return paymentType;
      }

      public void setOrder(FoodItems order, int id)
      {
         Orders.Clear();
         Orders.Add(new Order(order, id));
      }

      public FoodItems getOrder()
      {
         return Orders[currentOrder].getOrder();
      }

      public OrderStatus checkStatus()
      {
         return Orders[currentOrder].checkStatus();
      }
   }
}
