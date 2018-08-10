using System;
using System.IO;
using BOL;

namespace BLL
{
    // Summary:
    //     delegate the get one parameter and return void
    public delegate void FoundPathAndFileHandler(string showFoundFilePath);

    public class GetFiles : InputStringToserch
    {
        public static event FoundPathAndFileHandler showFoundPathAndFileActions;
        private InputStringToserch _stringToserch;
        private int _userInputId;
        private string _lestFileFolder;
        private UpdateData updateData;
        private DriveInfo[] driver;

        public GetFiles(InputStringToserch stringToserch)
        {
            updateData = new UpdateData();
            _stringToserch = stringToserch;
            updateData.UpdateUserInput(_stringToserch);
            _userInputId = updateData.GetUserInputId(_stringToserch.StringToserch);
        }


        #region SearchFileAndFolder
        /// <SearchFileAndFolder>
        /// can tack one parameter that represents a path
        /// and search for files in it
        /// if there is no path parameter will use the root driver
        /// </summary>
        /// <param name="sDir"></param>
        public void SearchFileAndFolder(string sDir = "")
        {
           
            if (sDir == "")
            {
                driver = DriveInfo.GetDrives();
                foreach (DriveInfo item in driver)
                {
                    
                    if (item.DriveType.ToString() == "Fixed")
                    {
                        Console.WriteLine("  Drive type: {0}", item.DriveType);
                        sDir = item.ToString();
                        getFile(sDir);
                    }
                }
            }
            else
            {
                getFile(sDir);
            }
        }
#endregion
        #region getFile

        private void getFile(string sDir)
        {

            SearchResult result = new SearchResult();
            result.Folder = sDir;
            if (Directory.GetDirectories(sDir).Length == 0)
            {

                try
                {
                    findspacificFinle(sDir, result);
                }
                catch{ }
            }

            foreach (string item in Directory.GetDirectories(sDir))
            {
                try
                {
                    findspacificFinle(sDir,result);
                    foreach (string file in Directory.GetFiles(item, "*.*"))
                    {
                        string files = Path.GetFileName(file);

                        if (files.Split('.')[0].IndexOf(_stringToserch.StringToserch, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            if (_lestFileFolder != $"{item}\\{files}")
                            {
                                result.Files = files;
                                result.FolderAndFile = ($"{item}\\{files}");
                                if (IsThisUserInputInDB.PreventDuplicates(_stringToserch.StringToserch, result.FolderAndFile, _stringToserch))
                                {
                                    updateData.InsertFileAndFolder(result);
                                    updateData.Updata_ID_To_LinkedTables(updateData.GetSearchResultId(result.FolderAndFile), _userInputId);
                                }
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                ClearCurrentConsoleLine();
                                showFoundPathAndFileActions($"{item}\\{files}");
                                Console.WriteLine("\nSearching ...");
                                _lestFileFolder = $"{item}\\{files}";
                            }
                        }

                    }

                    getFile(item);
                }
                catch{}
            }

        }
        #endregion
        #region findspacificFinle
        private void findspacificFinle(string sDir, SearchResult result)
        {
            foreach (string file in Directory.GetFiles(sDir, "*.*"))
            {
                string files = Path.GetFileName(file);

                if (files.Split('.')[0].IndexOf(_stringToserch.StringToserch, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (_lestFileFolder != $"{sDir}\\{files}")
                    {
                        result.Files = files;
                        result.FolderAndFile = ($"{sDir}\\{files}");
                        if (IsThisUserInputInDB.PreventDuplicates(_stringToserch.StringToserch, result.FolderAndFile, _stringToserch))
                        {
                            updateData.InsertFileAndFolder(result);
                            updateData.Updata_ID_To_LinkedTables(updateData.GetSearchResultId(result.FolderAndFile), _userInputId);
                        }
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                        showFoundPathAndFileActions($"{sDir}\\{files}");
                        Console.WriteLine("\nSearching ...");
                        _lestFileFolder = $"{sDir}\\{files}";
                    }
                }

            }
        }

        #endregion
        #region ClearCurrentConsoleLine
        /// <ClearCurrentConsoleLine>
        /// delete the lest console line 
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
#endregion
    }
}
