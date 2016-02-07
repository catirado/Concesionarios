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
    public class VehiculoRepository : ADORepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(IDBConfiguration configuration) : base(configuration) { }

        public void Add(Vehiculo entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Vehiculos(Marca, Modelo, Potencia) "
                                          + "OUTPUT INSERTED.Id "
                                          + "VALUES(@marca,@modelo,@potencia)";

                    command.Parameters.AddWithValue("@marca", entity.Marca);
                    command.Parameters.AddWithValue("@modelo", entity.Modelo);
                    command.Parameters.AddWithValue("@potencia", entity.Potencia);

                    int id = (int)command.ExecuteScalar();
                    entity.ChangeCurrentIdentity(id);
                }
            }
        }

        public void Remove(Vehiculo entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Vehiculos WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vehiculo entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Vehiculos SET Marca = @marca, Modelo = @modelo,  "
                                          + "Potencia = @potencia WHERE Id = @id";
                    command.Parameters.AddWithValue("@marca", entity.Marca);
                    command.Parameters.AddWithValue("@modelo", entity.Modelo);
                    command.Parameters.AddWithValue("@potencia", entity.Potencia);
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Vehiculo Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Vehiculos WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    return ToList(command).FirstOrDefault();
                }
            }
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Vehiculos";
                    return ToList(command);
                }
            }
        }

        protected override Vehiculo Map(System.Data.IDataRecord record)
        {
            var vehiculo = new Vehiculo(
               (string)record["Marca"],
               (string)record["Modelo"],
               (int)record["Potencia"]);

            vehiculo.ChangeCurrentIdentity((int)record["Id"]);
            return vehiculo;
        }
    }
}
