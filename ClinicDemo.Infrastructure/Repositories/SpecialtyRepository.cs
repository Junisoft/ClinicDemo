using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicDemo.Infrastructure.Repositories
{
    public class SpecialtyRepository : Repository, ISpecialtyRepository
    {
        public SpecialtyRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public async Task Add(Specialty entity)
        {
            var command = CreateCommand("[dbo].[sp_InsertSpecialty]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", entity.Name));
            command.Parameters.Add(new SqlParameter("@Description", entity.Description));
            await command.ExecuteNonQueryAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Specialty>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var command = CreateCommand("[dbo].[sp_GetAllSpecialties]");
            command.CommandType = CommandType.StoredProcedure;
            var response = new List<Specialty>();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(MapToValue(reader));
                }
            }

            return response;
        }

        public Task<Specialty> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Specialty entity)
        {
            throw new NotImplementedException();
        }

        private Specialty MapToValue(SqlDataReader reader)
        {
            return new Specialty()
            {
                Id = (int)reader["SpecialtyId"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString()
            };
        }
    }
}
