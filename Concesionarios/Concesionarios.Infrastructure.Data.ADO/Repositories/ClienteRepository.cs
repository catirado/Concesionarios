using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO.Repositories
{
    //http://blog.gauffin.org/2013/01/04/ado-net-the-right-way/
    public class ClienteRepository : ADORepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IDBConfiguration configuration) : base(configuration) { }

        public void Add(Cliente entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Clientes(Nombre, Apellidos, Telefono, Vip) "
                                          + "OUTPUT INSERTED.Id "
                                          + "VALUES(@nombre,@apellidos,@telefono,@vip)";

                    command.Parameters.AddWithValue("@nombre", entity.Nombre);
                    command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@telefono", entity.Telefono);
                    command.Parameters.AddWithValue("@vip", entity.Vip);

                    int id = (int)command.ExecuteScalar();
                    entity.Id = id;
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
                    command.CommandText = "UPDATE Clientes SET Nombre = @nombre, Apellidos = @apellidos, ) "
                                          + "Telefono = @telefono, Vip=@vip)";
                    command.Parameters.AddWithValue("@nombre", entity.Nombre);
                    command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@telefono", entity.Telefono);
                    command.Parameters.AddWithValue("@vip", entity.Vip);
                    command.ExecuteNonQuery();
                }
            }
        }

        //refactor to better implementation
        public Cliente Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Clientes WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    return ToList(command).FirstOrDefault();
                }
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Clientes";
                    return ToList(command);
                }
            }
        }

        public IList<Presupuesto> FindAllPresupuestosForCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        protected override void Map(IDataRecord record, Cliente user)
        {
            user.Id = (int)record["Id"];
            user.Apellidos = (string)record["Apellidos"];
            user.Nombre = (string)record["Nombre"];
            user.Telefono = (string)record["Telefono"];
            user.Vip = (bool)record["Vip"];
        }
    }
}
