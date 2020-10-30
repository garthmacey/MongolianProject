using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ViewImplementation.Models
{
    public abstract class OrderCommand
    {
        protected Order o;
        protected ObservableCollection<FoodItems> currProg;
        protected ObservableCollection<FoodItems> nextProg;
        public abstract void execute(); // executing the command
        public abstract void unexecute(); // undoing the command
    }
}
