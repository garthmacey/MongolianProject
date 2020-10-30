using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ViewImplementation.Models
{
    public class StartOrder : OrderCommand
    {
        public StartOrder(ObservableCollection<FoodItems> curr, ObservableCollection<FoodItems> next)
        {
            base.currProg = curr;
            base.nextProg = next;
        }
        public override void execute()
        {
            if (currProg.Count() > 0)
            {
                nextProg.Add(currProg[0]);
                currProg.RemoveAt(0);
            }
        }
        public override void unexecute()
        {
            if (nextProg.Count() > 0)
            {
                currProg.Insert(0, nextProg[0]);
                nextProg.RemoveAt(0);
            }
        }
    }
}
