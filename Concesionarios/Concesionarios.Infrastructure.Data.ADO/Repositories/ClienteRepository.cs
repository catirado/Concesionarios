using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO.Repositories
{
    //http://blog.gauffin.org/2013/01/04/ado-net-the-right-way/
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IDBConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
        }

        public void Add(Cliente entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Clientes(Nombre, Apellidos, Telefono, Vip) "
                                          +"VALUES(@nombre,@apellidos,@telefono,@vip)";
                    command.Parameters.AddWithValue("@nombre", entity.Nombre);
                    command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@telefono", entity.Telefono);
                    command.Parameters.AddWithValue("@vip", entity.Vip);
                    command.ExecuteNonQuery();
                }
            }
        }

        //this can be refactored
        public void Remove(Cliente entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Clientes WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Cliente entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Clientes(Nombre, Apellidos, Telefono, Vip) "
                                          + "VALUES(@nombre,@apellidos,@telefono,@vip)";
                    command.Parameters.AddWithValue("@nombre", entity.Nombre);
                    command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@telefono", entity.Telefono);
                    command.Parameters.AddWithValue("@vip", entity.Vip);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Cliente Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Presupuesto> FindAllPresupuestosForCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
