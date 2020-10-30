using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation.Models
{
    public class OrderHistory
    {
        // done_cmds:   those commands that are currently executed
        // undone_cmds: commands which were undone
        protected Stack<OrderCommand> done_cmds = new Stack<OrderCommand>();
        protected Stack<OrderCommand> undone_cmds = new Stack<OrderCommand>();
    
        // execute command and store it on the done commands list;
        //   old undone commands are permanently deleted
        public void do_command(OrderCommand new_cmd)
        {
            new_cmd.execute();
            undone_cmds.Clear();
            done_cmds.Push(new_cmd);
        }
        // undoes last executed command; precondition: at least one command to undo
        public void undo()
        {
            if (done_cmds.Count > 0)
            {
                OrderCommand to_undo = done_cmds.Pop();
                to_undo.unexecute();
                undone_cmds.Push(to_undo);
            }
        }
        // redoes last undone command; precondition: at least one command to redo
        public void redo()
        {
            if (undone_cmds.Count > 0) {
                OrderCommand todo = undone_cmds.Pop();
                todo.execute();
                done_cmds.Push(todo);
            }
        }
    }
}
