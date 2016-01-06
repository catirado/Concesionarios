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
        ClienteDTO BuscarCliente(int id);
        ClienteDTO AltaCliente(ClienteDTO cliente);
        void ActualizarDatosCliente(ClienteDTO cliente);
        void BajaCliente(int id);
        IList<ClienteListDTO> ListadoClientes();
    }
}
