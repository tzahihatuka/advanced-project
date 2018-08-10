using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourFiles
{
    public delegate void UserChoiceHandler();

    class ValidateUserSelection
    {
        public static event UserChoiceHandler userChoice1Actions;
        public static event UserChoiceHandler userChoice2Actions;
        public static event UserChoiceHandler userChoice3Actions;
        public static event UserChoiceHandler wrongInputActions;
        #region Validata
        /// <Validata>
        ///check correct input from the user
        /// gets one parameters and returns void
        /// and invoke relevant event the path
        /// </summary>
        /// <param name="input"></param>
        public static void Validata(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1": userChoice1Actions(); break;
                case "2": userChoice2Actions(); break;
                case "3": userChoice3Actions(); break;
                default: wrongInputActions(); break;
            }
        }
#endregion
    }
}
