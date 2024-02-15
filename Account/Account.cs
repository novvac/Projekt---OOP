using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    abstract class Account
    {
        protected int selectedOption;

        public abstract void Login();
        protected abstract void Welcome();
    }
}
