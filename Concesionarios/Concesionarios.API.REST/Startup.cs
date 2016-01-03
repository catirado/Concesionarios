using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Concesionarios.API.REST.Startup))]

namespace Concesionarios.API.REST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
