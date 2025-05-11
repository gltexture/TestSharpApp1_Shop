using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSharp1
{
    internal interface PageInterface
    {
        Page getPage();
    }

    public enum Page
    {
        Main = 0,
        Clients = 1,
        Products = 2,
        Orders = 3,
        Report = 4
    }
}
