using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation.Models
{
    public class PhoneHistory
    {
        public string do_command(Command new_cmd)
        {
            return new_cmd.execute();
        }
    }
}
