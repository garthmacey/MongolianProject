using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewImplementation
{
    public abstract class Command
    {
        protected String phoneNum;
        public abstract string execute();
    }
}
