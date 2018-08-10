using BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
   
    public class GetQueryRequest
    {
        #region ExecuteScalar
        /// <SelectDb>
        /// get one parameter (query)
        /// return number
        /// </summary>
        /// <param name="command"></param>
        /// <returns>ExecuteScalar</returns>
        public static int SelectDb(string command)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(AddToDB.getSqlConnection()))
                {

                    sql.Open();

                    SqlCommand query = new SqlCommand(command, sql);

                    return (int)query.ExecuteScalar();

                }
            }
            catch
            {
                return 0;
            }
        }
#endregion
        #region dataReader
        /// <GetList>
        /// open connection to the db dataReader
        /// to get list
        /// get one perameter string (query)
        /// return list class PreventDuplicates  
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static List<PreventDuplicates> GetList(string command)
        {
            List<PreventDuplicates> ListFileAndFolder = new List<PreventDuplicates>();

            try
            {
                using (SqlConnection sql = new SqlConnection(AddToDB.getSqlConnection()))
                {

                    sql.Open();

                    SqlCommand query = new SqlCommand(command, sql);

                    SqlDataReader dataReader = query.ExecuteReader();
                    PreventDuplicates fileAndFolderList = new PreventDuplicates();
                    while (dataReader.Read())
                    {
                        ListFileAndFolder.Add(new PreventDuplicates
                        {
                            FullPathResult = (string)dataReader[0],
                            Input = (string)dataReader[1]
                        });
                        
                    }
                    return ListFileAndFolder;
                }
            }
            catch
            {
                return ListFileAndFolder;
            }

        }
#endregion
    }
}
