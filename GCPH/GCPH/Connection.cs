using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCPH
{
    internal class Connection
    {
        public SqlConnection con;//object for sql connection
        public SqlCommand cmd;//object for sql commands
        public SqlDataAdapter sda;//object for sql adapter
        public string error;

        public void connection()//method for sql connection
        {
            //creating a connection to the database
            con = new SqlConnection(@"Data Source=(localdb)\Local;Initial Catalog=GCP;Integrated Security=True");
            con.Open();//opens the connection to the database
        }

        public void dataSend(string SQL)//a method that has s string parameter for getting query
        {
            try
            {
                connection();//calling the method connection to open the sql connection
                cmd = new SqlCommand(SQL, con);//creates an instnance of sql command
                cmd.ExecuteNonQuery();//this is use for insert, update, and delete operation
                error = "";//if the operation is successful this will make the string empty
            }
            catch(Exception)
            {
                error = "Please check your entered details";// if not it will set the string to an error message
            }
            con.Close();
        }

        public void dataGet(string SQL)
        {
            try
            {
                connection();
                sda = new SqlDataAdapter(SQL, con);//used retrieved data from the database and fill the dataTable 
            }

            catch (Exception)
            {

            }
        }

        
    }
}
