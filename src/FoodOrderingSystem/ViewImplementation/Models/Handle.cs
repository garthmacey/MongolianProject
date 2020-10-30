using System;
using System.Collections;

namespace ViewImplementation.Models
{
    public class Handle
    {
        protected PhoneHistory history;
        protected String phonenumber;
        protected Stack undoStack = new Stack();
        public Handle()
        {
            history = new PhoneHistory();
        }

        public string removeNum()
        {
            undoStack.Push(phonenumber);
            return history.do_command(new RemoveCommand(phonenumber));
        }

        public string undoRemove()
        {
            if (undoStack.Count > 0)
                return (String)undoStack.Pop();
            else
                return "";
        }

        public void setNum(string num)
        {
            phonenumber = num;
        }

        public void clearStack()
        {
            undoStack.Clear();
        }
    }
}
