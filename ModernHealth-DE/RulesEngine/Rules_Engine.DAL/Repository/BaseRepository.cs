using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Rules_Engine.DAL.Repository
{
  public  class BaseRepository : IDisposable
    {
        private readonly IConfiguration configuration;
        public static string _strConnection = null;

        protected IDbConnection con;
        protected IDbConnection con_nhub;
        protected NpgsqlConnection conn;
        public BaseRepository(IConfiguration config)
        {
            this.configuration = config;

        }

        public void Dispose()
        {
            //throw new NotImplementedException();  
        }
        public NpgsqlConnection pgOpenConnection()
        {
            try
            {
                _strConnection = this.configuration.GetConnectionString("DefaultConnection");

                if (_strConnection != "")
                {
                    conn = new NpgsqlConnection(_strConnection);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return conn;
        }

        public void pgCloseConnection()
        {
            if (con != null)
                con.Close();
        }
    }
}
