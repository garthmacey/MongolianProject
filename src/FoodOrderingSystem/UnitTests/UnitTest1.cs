using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewImplementation.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void customerTest()
        {
            String name = "Steve";
            String phone = "111-1111";
            PaymentType pay = PaymentType.CASH;
            var customer = new Customer("111-1111", PaymentType.CASH);
            String actual;
            actual = customer.getPhoneNumber();
            Assert.AreEqual(phone, actual);
            PaymentType actuall = customer.getPaymentType();
            Assert.AreEqual(pay, actuall);
        }

        [TestMethod]
        public void setOrderTest()
        {
            FoodItems order1 = new FoodItems("Chicken with rice");
            int id = 0;
            Order order = new Order(order1, id);
            var customer = new Customer("111-1111", PaymentType.CASH);
            customer.setOrder(order1, id);
            Assert.AreEqual(customer.getOrder(), order1);
        }

        [TestMethod]
        public void getOrderTest()
        {
            FoodItems order1 = new FoodItems("Chicken with rice");
            int id = 0;
            var order = new Order(order1, id);
            Assert.AreEqual(order.getOrder(), order1);
        }

        [TestMethod]
        public void checkStatueTest()
        {
            FoodItems order1 = new FoodItems("Chicken with rice");
            int id = 0;
            var order = new Order(order1, id);
            OrderStatus actual = OrderStatus.ORDERED;
            Assert.AreEqual(order.checkStatus(), actual);
        }

        [TestMethod]
        public void updateStatueTest()
        {
            FoodItems order1;
            order1 = new FoodItems("Chicken");
            int id = 0;
            var order = new Order(order1, id);
            OrderStatus actual = OrderStatus.ORDERED;
            Assert.AreEqual(order.checkStatus(), actual);
            order.updateStatus();
            actual = OrderStatus.INPROGRESS;
            Assert.AreEqual(order.checkStatus(), actual);
            order.updateStatus();
            actual = OrderStatus.DONE;
            Assert.AreEqual(order.checkStatus(), actual);
            order.updateStatus();
            actual = OrderStatus.DONE;
            Assert.AreEqual(order.checkStatus(), actual);
        }

        [TestMethod]
        public void handleTest()
        {
            Handle handle = new Handle();
            handle.setNum("(111)-111-1111");
            String actual = handle.removeNum();
            Assert.AreNotEqual(actual, "(111)-111-1111");
            actual = handle.undoRemove();
            Assert.AreEqual(actual, "(111)-111-1111");
            Assert.AreEqual("", handle.undoRemove());
            handle.clearStack();
            Assert.AreEqual("", handle.undoRemove());
        }

        [TestMethod]
        public void removeCommandTest()
        {
            Handle handle = new Handle();
            handle.setNum("(111)-111-1");
            Assert.AreNotEqual("(111)-111-1",handle.removeNum());
            handle.setNum("(111)-1");
            Assert.AreNotEqual("(111)-1",handle.removeNum());
            handle.setNum("(1");
            Assert.AreNotEqual("(1", handle.removeNum());
        }

        [TestMethod]
        public void customerTest2()
        {
            Customer customer = new Customer();
            customer.setPhoneNumber("111-1111");
            customer.setPay(PaymentType.CASH);
            customer.setOrder( new FoodItems("Chicken with rice"), 0);
            OrderStatus status = customer.checkStatus();
            Assert.AreEqual(status, OrderStatus.ORDERED);
            Assert.AreEqual("111-1111", customer.getPhoneNumber());
            Assert.AreEqual(PaymentType.CASH, customer.getPaymentType());
            customer.Orders = new List<Order>();
        }

        [TestMethod]
        public void foodToppingTest()
        {
            FoodToppings toppings = new FoodToppings("Sauce");
            String exspected = "Sauce";
            String actual = toppings.FoodTopping;
            Assert.AreEqual(exspected, actual);
            toppings.FoodTopping = "Noodle";
            Assert.AreNotEqual(exspected, toppings.FoodTopping);
        }

        [TestMethod]
        public void orderTest()
        {
            Order order = new Order(new FoodItems("Sauce"), 0);
            order.updateStatus();
            Assert.AreEqual(OrderStatus.INPROGRESS, order.checkStatus());
            order.reverseUpdate();
            Assert.AreNotEqual(OrderStatus.INPROGRESS, order.checkStatus());
            order.updateStatus();
            order.updateStatus();
            Assert.AreEqual(OrderStatus.DONE, order.checkStatus());
            order.reverseUpdate();
            Assert.AreNotEqual(OrderStatus.DONE, order.checkStatus());
        }

        [TestMethod]
        public void foodItemTest()
        {
            ObservableCollection<FoodToppings> list = new ObservableCollection<FoodToppings>();
            FoodItems items = new FoodItems("Chicken");
            Assert.AreEqual("Chicken", items.FoodItem);
            items.FoodItem = "Sea Food";
            Assert.AreNotEqual("Chicken", items.FoodItem);
            items.Toppings = list;
            list = items.Toppings;
            Assert.AreEqual(0, list.Count);
            items.addTopping("Tofu");
            items.addTopping("Cheese");
            Assert.AreEqual(2, list.Count);
            list = items.Toppings;
            items.addTopping("Cheese");
            list = items.Toppings;
            Assert.AreEqual(1, list.Count);
        }

       
        [TestMethod]
        public void orderHandleTest()
        {
            ObservableCollection<FoodItems> current = new ObservableCollection<FoodItems>();
            ObservableCollection<FoodItems> next = new ObservableCollection<FoodItems>();
            current.Add(new FoodItems("Steak"));
            next.Add(new FoodItems("SeaFood"));
            OrderHandler handle = new OrderHandler();
            handle.startOrder(current, next);
            Assert.AreEqual(0, current.Count);
            Assert.AreEqual(2, next.Count);
            handle.undo();
            Assert.AreEqual(1, current.Count);
            Assert.AreNotEqual(2, next.Count);
            handle.finishOrder(current, next);
            Assert.AreEqual(0, current.Count);
            Assert.AreEqual(2, next.Count);
            handle.undo();
            Assert.AreEqual(1, current.Count);
            Assert.AreNotEqual(2, next.Count);
            handle.redo();
            Assert.AreEqual(0, current.Count);
            Assert.AreEqual(2, next.Count);
      }
    }
}
