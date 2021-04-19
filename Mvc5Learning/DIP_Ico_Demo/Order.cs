using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_Ico_Demo
{
    class Order
    {
        private IDataAccess da;

        [Inject]
        public Order(IDataAccess _da)
        {
            da = _da;
        }

        public void AddOrder()
        {
            da.Add();
        }
    }
}
