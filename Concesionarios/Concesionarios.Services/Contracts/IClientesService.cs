using Concesionarios.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services.Contracts
{
    public interface IClientesService
    {
        ClienteDTO AltaCliente(ClienteDTO cliente);
        void BajaCliente(ClienteDTO cliente);
        ActualizarDatosDTO ActualizarDatosCliente(ActualizarDatosDTO cliente);
        IList<ClienteDTO> ListadoClientes();

    }
}
