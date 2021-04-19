using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_Ico_Demo
{
    class MsSqlDal : IDataAccess
    {
        public void Add()
        {
            Console.WriteLine("向MsSql数据库添加一条数据...");
        }
    }

    class SqliteDal : IDataAccess
    {
        public void Add()
        {
            Console.WriteLine("向Sqlite数据库添加一条数据...");
        }
    }

    class MySqlDal : IDataAccess
    {
        public void Add()
        {
            Console.WriteLine("向MySql数据库添加一条数据...");
        }
    }

    class OracleDal : IDataAccess
    {
        public void Add()
        {
            Console.WriteLine("向Oracle数据库添加一条数据...");
        }
    }
}
