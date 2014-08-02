using JobsNet.JobSearch.Sites;
using JobsNet.Web;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet
{
    public class JobNetBindings : StandardKernel
    {
        public static JobNetBindings Instance = new JobNetBindings();

        private JobNetBindings()
        {
            this.Bind<IDataRequest>().To<WebRequest>();
        }
    }
}
