using BlazorSignalR.Shared.Dtos;
using blazorSource.Server.Ado;
//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Threading.Tasks;

namespace blazorSource.Server.Repository
{
    public class userRepopsitoryADO : IuserRepopsitoryADO
    {
        private readonly AdoSettings setting;

        public userRepopsitoryADO(AdoSettings setting)
        {
            this.setting = setting;
        }
        public Task<string> Create(UserDto user)
        {
            throw new NotImplementedException();
        }

        
        public async Task<UserDto> GetUser(string username, string password)

        {
            string ProcedureName = "GetUser";
            setting.Connect();

			Microsoft.Data.SqlClient.SqlCommand cmd = new  Microsoft.Data.SqlClient.SqlCommand();
            cmd.Connection = setting.Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcedureName;
            Microsoft.Data.SqlClient.SqlParameter param_username= new Microsoft.Data.SqlClient.SqlParameter("@email",SqlDbType.NVarChar);
            param_username.Value = username;
            Microsoft.Data.SqlClient.SqlParameter param_password = new Microsoft.Data.SqlClient.SqlParameter("@pass", SqlDbType.NVarChar);
            param_password.Value = password;
            cmd.Parameters.Add(param_username);
            cmd.Parameters.Add(param_password);
            Microsoft.Data.SqlClient.SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
            DataTable dt = new DataTable();
            UserDto user = new UserDto();
            while (sqlDataReader.Read())
            {
                user.Email = sqlDataReader[0].ToString();
                user.Password = sqlDataReader[1].ToString();
                user.Name = sqlDataReader[2].ToString();
                user.LastName = sqlDataReader[3].ToString();
            }
            setting.DisConnect();
            setting.Dispose();
            return user;
        }
    }
}
