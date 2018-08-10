using BOL;
using DAL;

namespace BLL
{
    public class UpdateData : GetDataFromDB
    {
        private int FileID { get; set; }
        private int FolderID { get; set; }

        /// <UpdateUserInput>
        /// get InputStringToserch class parmeter
        /// and returned void
        /// check if the user input exists in the db
        /// </summary>
        /// <param name="stringToserch"></param>
        /// 
        public void UpdateUserInput(InputStringToserch stringToserch)
        {
            FileID = GetUserInputId(stringToserch.StringToserch);
            FolderID = GetUserFolderInputId(stringToserch.FolderToserch);
            if (!(FileID == FolderID) || FileID == 0)
            {
                InsertUserInput(stringToserch);
            }
        }

        #region InsertFileAndFolder
        /// <InsertFileAndFolder>
        /// get class parameter
        /// and returns void
        /// send the stored procedures query to the db connction
        /// </summary>
        /// <param name="newfileAndFolder"></param>
        public void InsertFileAndFolder(SearchResult newfileAndFolder)
        {
            AddToDB.ExecDb($"EXECUTE AddFileAndFolder N'{newfileAndFolder.Files}',N'{newfileAndFolder.Folder}',N'{newfileAndFolder.FolderAndFile}'");
        }
        public void InsertUserInput(InputStringToserch newInput)
        {
            AddToDB.ExecDb($"EXECUTE AddUserInput N'{newInput.StringToserch}',N'{newInput.FolderToserch}'");
        }
        public void Updata_ID_To_LinkedTables(int searchID, int UserInputID)
        {
            AddToDB.ExecDb($"EXECUTE AddFK_Ids_To_LinkedTables '{searchID}','{UserInputID}'");
        }

#endregion
    }
}
