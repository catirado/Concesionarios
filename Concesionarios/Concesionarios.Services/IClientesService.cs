using Concesionarios.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services
{
    public interface IClientesService
    {
        void AddCliente(ClienteDTO cliente);
    }
}
