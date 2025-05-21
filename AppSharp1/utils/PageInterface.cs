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
        Main = 66,
        Clients = 0,
        Products = 1,
        Orders = 2,
        Report = 3
    }
}
