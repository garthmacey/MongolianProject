using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation.Models
{
    public class Order
    {
        private FoodItems order;
        private OrderStatus status;
        private int Id;

        public Order(FoodItems o, int Id)
        {
            order = o;
            this.Id = Id;
            status = OrderStatus.ORDERED;
        }

        public void updateStatus()
        {
            if (status == OrderStatus.ORDERED)
                status = OrderStatus.INPROGRESS;
            else if (status == OrderStatus.INPROGRESS)
                status = OrderStatus.DONE;
        }

        public void reverseUpdate()
        {
            if (status == OrderStatus.DONE)
                status = OrderStatus.INPROGRESS;
            else if (status == OrderStatus.INPROGRESS)
                status = OrderStatus.ORDERED;
        }
        public OrderStatus checkStatus()
        {
            return status;
        }

        public FoodItems getOrder()
        {
            return order;
        }
    }
}
