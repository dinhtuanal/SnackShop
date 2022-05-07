using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Commons
{
    public class SnackShopException : Exception
    {
        public SnackShopException(string message) : base(message)
        {

        }
        public SnackShopException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
