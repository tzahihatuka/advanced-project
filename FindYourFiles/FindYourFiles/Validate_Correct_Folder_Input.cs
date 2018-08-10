using System.IO;

namespace FindYourFiles
{
     class Validate_Correct_Folder_Input
    {
       
        public static event UserChoiceHandler wrongFolderInput;

        /// <Correct_Folder_Input>
        /// check correct folder input from the user
        /// gets two parameters and returns string
        /// if the path correct return the path
        /// else invoke wrongFolderInput event
        /// </summary>
        /// <param name="FolderPath"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static string Correct_Folder_Input(string FolderPath, DriveInfo[] driver)
        {

            string pathRoot=  Path.GetPathRoot(FolderPath);
             driver = DriveInfo.GetDrives();
            
            foreach (DriveInfo item in driver)
            {
                if (item.DriveType.ToString() == "Fixed")
                {
                    if (item.ToString() == pathRoot.ToUpper())
                    {
                        return FolderPath;

                    }
                }
            }
            wrongFolderInput();
            return "";
        }
    }
}