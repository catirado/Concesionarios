﻿using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IList<Presupuesto> FindAllPresupuestosForCliente(Cliente cliente);
    }
}
