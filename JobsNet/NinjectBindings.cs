using JobsNet.Web;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataRequest>().To<WebRequest>();
        }
    }
}
