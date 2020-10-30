using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ViewImplementation.Models
{
    public class OrderHandler
    {
        protected OrderHistory history = new OrderHistory();
        public void startOrder(ObservableCollection<FoodItems> curr, ObservableCollection<FoodItems> next)
        {
            history.do_command(new StartOrder(curr, next));
        }
        public void undo()
        {
            history.undo();
        }
        public void redo()
        {
            history.redo();
        }
        public void finishOrder(ObservableCollection<FoodItems> curr, ObservableCollection<FoodItems> next)
        {
            history.do_command(new FinishOrder(curr, next));
        }
    }
}
