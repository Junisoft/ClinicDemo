using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDemo.Infrastructure.Repositories
{
    public class DoctorRepository : Repository, IDoctorRepository
    {
        public DoctorRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public async Task<IEnumerable<Doctor>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var command = CreateCommand("[dbo].[sp_GetAllDoctors]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@PageNumber", pageNumber));
            command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            var response = new List<Doctor>();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(MapToValue(reader));
                }
            }

            return response;
        }

        public async Task<Doctor> GetById(int id)
        {
            var command = CreateCommand("[dbo].[sp_GetDoctorById]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", id));
            Doctor response = null;

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response = MapToValue(reader);
                }
            }

            return response;
        }

        public async Task Add(Doctor doctor)
        {
            var command = CreateCommand("[dbo].[sp_InsertDoctor]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Firstname", doctor.Firstname));
            command.Parameters.Add(new SqlParameter("@Lastname", doctor.Lastname));
            command.Parameters.Add(new SqlParameter("@Email", doctor.Email));
            command.Parameters.Add(new SqlParameter("@SpecialtyId", doctor.SpecialtyId));
            await command.ExecuteNonQueryAsync();
        }

        public async Task Update(Doctor doctor)
        {
            var command = CreateCommand("[dbo].[sp_UpdateDoctor]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@DoctorId", doctor.Id));
            command.Parameters.Add(new SqlParameter("@Firstname", doctor.Firstname));
            command.Parameters.Add(new SqlParameter("@Lastname", doctor.Lastname));
            command.Parameters.Add(new SqlParameter("@Email", doctor.Email));
            command.Parameters.Add(new SqlParameter("@SpecialtyId", doctor.SpecialtyId));
            await command.ExecuteNonQueryAsync();
        }

        public async Task Delete(int Id)
        {
            var command = CreateCommand("[dbo].[sp_DeleteDoctor]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", Id));
            await command.ExecuteNonQueryAsync();
        }

        private Doctor MapToValue(SqlDataReader reader)
        {
            return new Doctor()
            {
                Id = (int)reader["DoctorId"],
                Firstname = reader["Firstname"].ToString(),
                Lastname = reader["Lastname"].ToString(),
                Email = reader["Email"].ToString()
            };
        }

        public async Task EnableDisableDoctor(int id, bool isActive)
        {
            var command = CreateCommand("[dbo].[sp_EnableDisableDoctor]");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@DoctorId", id));
            command.Parameters.Add(new SqlParameter("@IsActive", isActive));
            await command.ExecuteNonQueryAsync();
        }
    }
}
