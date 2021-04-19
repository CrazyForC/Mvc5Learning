using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_Ico_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 没用依赖注入的方式
            IDataAccess msSqlDal = new MsSqlDal();
            Order order1 = new Order(msSqlDal);
            order1.AddOrder();
            #endregion

            IKernel kernel = new StandardKernel(new DataModule());
            Order sqlite = new Order(kernel.Get<SqliteDal>());
            sqlite.AddOrder();
            Order mysql = new Order(kernel.Get<MySqlDal>());
            mysql.AddOrder();
            Order oracle = new Order(kernel.Get<OracleDal>());
            oracle.AddOrder();
            Console.ReadLine();
        }
    }
}
