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
    public class PresupuestoRepository : ADORepository<Presupuesto>, IPresupuestoRepository
    {
        public PresupuestoRepository(IDBConfiguration configuration) : base(configuration) { }

        public void Add(Presupuesto entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Presupuestos(ClienteId, VehiculoId, Estado, Importe) "
                                          + "OUTPUT INSERTED.Id "
                                          + "VALUES(@clienteId,@vehiculoId,@estado,@importe)";

                    command.Parameters.AddWithValue("@clienteId", entity.Cliente.Id);
                    command.Parameters.AddWithValue("@vehiculoId", entity.Vehiculo.Id);
                    command.Parameters.AddWithValue("@estado", entity.Estado);
                    command.Parameters.AddWithValue("@importe", entity.Importe);

                    int id = (int)command.ExecuteScalar();
                    entity.ChangeCurrentIdentity(id);
                }
            }
        }

        public void Remove(Presupuesto entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Presupuestos WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Presupuesto entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Presupuestos SET ClienteId = @clienteId, VehiculoId = @vehiculoId,  "
                                          + "Estado = @estado, Importe=@importe WHERE Id = @id";
                    command.Parameters.AddWithValue("@clienteId", entity.Cliente.Id);
                    command.Parameters.AddWithValue("@vehiculoId", entity.Vehiculo.Id);
                    command.Parameters.AddWithValue("@estado", entity.Estado);
                    command.Parameters.AddWithValue("@importe", entity.Importe);
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Presupuesto Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Presupuestos p LEFT JOIN Clientes c ON p.ClienteId = c.Id "
                                           + "LEFT JOIN Vehiculos v ON p.VehiculoId = v.Id WHERE p.Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    return ToList(command).FirstOrDefault();
                }
            }
        }

        public IEnumerable<Presupuesto> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Presupuestos p LEFT JOIN Clientes c ON p.ClienteId = c.Id "
                                           + "LEFT JOIN Vehiculos v ON p.VehiculoId = v.Id";
                    return ToList(command);
                }
            }
        }

        public IList<Presupuesto> FindAllPresupuestosByCliente(Cliente cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Presupuestos p LEFT JOIN Clientes c ON p.ClienteId = c.Id "
                                           + "LEFT JOIN Vehiculos v ON p.VehiculoId = v.Id WHERE ClienteId = @clienteId";
                    command.Parameters.AddWithValue("@clienteId", cliente.Id);
                    return ToList(command).ToList();
                }
            }
        }

        public IList<Presupuesto> FindAllPresupuestosByVehiculo(Vehiculo vehiculo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Presupuestos p LEFT JOIN Clientes c ON p.ClienteId = c.Id "
                                           + "LEFT JOIN Vehiculos v ON p.VehiculoId = v.Id WHERE VehiculoId = @vehiculoId";
                    command.Parameters.AddWithValue("@vehiculoId", vehiculo.Id);
                    return ToList(command).ToList();
                }
            }
        }

        protected override Presupuesto Map(IDataRecord record)
        {
            var cliente = new Cliente(
               (string)record["Nombre"],
               (string)record["Apellidos"],
               (string)record["Telefono"],
               (bool)record["Vip"]);

            cliente.ChangeCurrentIdentity((int)record["ClienteId"]);

            var vehiculo = new Vehiculo(
               (string)record["Marca"],
               (string)record["Modelo"],
               (int)record["Potencia"]);

            vehiculo.ChangeCurrentIdentity((int)record["VehiculoId"]);

            var presupuesto = new Presupuesto(cliente,
                                              vehiculo,
                                              Convert.ToDecimal((double)record["Importe"]),
                                              (Presupuesto.PresupuestoEstado)Enum.ToObject(typeof(Presupuesto.PresupuestoEstado), Convert.ToInt32((string)record["Estado"])));

            presupuesto.ChangeCurrentIdentity((int)record["Id"]);
            return presupuesto;
        }
    }
}
