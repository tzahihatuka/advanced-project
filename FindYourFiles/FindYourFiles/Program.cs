using BLL;
using System;
using BOL;
namespace FindYourFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateUserSelection.userChoice1Actions += new UserChoiceHandler(UserChoice1);
            ValidateUserSelection.userChoice2Actions += new UserChoiceHandler(UserChoice2);
            ValidateUserSelection.userChoice3Actions += new UserChoiceHandler(UserChoice3);
            ValidateUserSelection.wrongInputActions += new UserChoiceHandler(WrongInput);
            Validate_Correct_Folder_Input.wrongFolderInput += new UserChoiceHandler(wrongFolderInput);
            GetFiles.showFoundPathAndFileActions += new FoundPathAndFileHandler(ShowFoundPathAndFile);
            Console.WriteLine(GetTime.SendWelcome());
            StartApp();
        }
        #region print to console
        /// <ShowFoundPathAndFile>
        /// get one parameter and returns void
        ///print the finding to the user
        /// and activated by an event
        /// </summary>
        /// <param name="path"></param>
        private static void ShowFoundPathAndFile(string path)
        {
            if (path.Length>248) {
                Console.WriteLine(path.Substring(0, 248));
                Console.WriteLine(path.Substring(248));
            }
            Console.WriteLine(path);
        }


        private static void StartApp()
        {
            Console.WriteLine("\n1. Enter file name to search.");
            Console.WriteLine("2. Enter File name to search + Directory to search in.");
            Console.WriteLine("3. Exit.");
            Console.Write("\nEnter your choice: ");
            ValidateUserSelection.Validata(Console.ReadLine());
        }
        #endregion
        #region correct input
        private static void UserChoice1()
        {
            Console.Write("Enter file name to search:  ");
            InputStringToserch StringToserch = new InputStringToserch();
            StringToserch.StringToserch = Console.ReadLine();
            GetFiles getFile = new GetFiles(StringToserch);
            Console.WriteLine("\nStart Searching ...");
            getFile.SearchFileAndFolder();
        }

        private static void UserChoice2()
        {

            Console.Write("Enter file name to search:  ");
            InputStringToserch StringToserch = new InputStringToserch();
            StringToserch.StringToserch = Console.ReadLine();
            Console.Write("Enter folder path to search:  ");
            StringToserch.FolderToserch = Validate_Correct_Folder_Input.Correct_Folder_Input(Console.ReadLine(), StringToserch.Driver);
            GetFiles getFile = new GetFiles(StringToserch);
            Console.WriteLine("\nStart Searching ...");

            getFile.SearchFileAndFolder(StringToserch.FolderToserch);
        }

        private static void UserChoice3()
        {
            Console.WriteLine("Good Bay");
        }
        #endregion
        #region wrong input
        private static void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WRONG INPUT!!!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please try again ");
            StartApp();
        }
        private static void wrongFolderInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WRONG Folder INPUT!!!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("for exempel C:\\Folder Name ");
            UserChoice2();
        }
        #endregion
    }
}
