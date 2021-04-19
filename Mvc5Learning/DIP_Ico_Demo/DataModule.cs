using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_Ico_Demo
{
    class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataAccess>().To<MsSqlDal>();
            Bind<IDataAccess>().To<MySqlDal>();
            Bind<IDataAccess>().To<SqliteDal>();
            Bind<IDataAccess>().To<OracleDal>();
        }
    }
}
