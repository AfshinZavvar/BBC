using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC.SCExtensions.DI
{
    public class ContainerManager
    {
        private static readonly Container container = new Container();

        public Container Container
        {
            get
            {
                return container;
            }
        }
    }
}
