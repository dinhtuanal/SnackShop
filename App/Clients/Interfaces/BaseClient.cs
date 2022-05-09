using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public class BaseClient
    {
        protected HttpClient httpClient = null;
        public BaseClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44332/");
        }
    }
}
