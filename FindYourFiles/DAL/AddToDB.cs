using System.Data.SqlClient;
namespace DAL
{
    public class AddToDB 
    {
        #region SqlConnection
        /// <getSqlConnection>
        /// do not get parameter
        /// and returns string SqlConnection
        /// </summary>
        /// <returns>connectionString</returns>
        public static string getSqlConnection()
        {
           
            string str = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("\\FindYourFiles\\bin\\Debug", "\\DAL").Replace("file:\\", "");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=\"" + str + "\\DATARESULT.MDF\"; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return connectionString;
        }
#endregion


        /// <ExecDb>
        /// get one parameter and return void
        /// open connection to the db and Execute the query with ExecuteNonQuery
        /// </summary>
        /// <param name="command"></param>
        public static void ExecDb(string command)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(getSqlConnection()))
                {

                    sql.Open();

                    SqlCommand query = new SqlCommand(command, sql);

                    query.ExecuteNonQuery();

                }
            }
            catch{}

        }
    }
}
