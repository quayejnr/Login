using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Login
{
    //MySql Connetion
    class DB
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=donor_db");

        //Function to Open Connection

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //Function to Close Connection

        public void DBopenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        //Function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }

        internal void closeConnction()
        {
            //throw new NotImplementedException();
        }
    }
}
