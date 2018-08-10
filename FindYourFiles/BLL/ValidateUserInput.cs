using BOL;
using System.Collections.Generic;

namespace BLL
{

    public class IsThisUserInputInDB: GetDataFromDB
    {
        private static List<PreventDuplicates> listOfFullPath;
        /// <PreventDuplicates>
        /// this metoda privant Duplicate data in the data base
        /// get 3 parameters and returned bool
        /// </summary>
        /// <param name="input"></param>
        /// <param name="FullPath"></param>
        /// <param name="stringToserch"></param>
        /// <returns></returns>
        public static bool PreventDuplicates(string input,string FullPath, InputStringToserch stringToserch)
        {
            listOfFullPath = GetSearchResultList(stringToserch.StringToserch);
            foreach (PreventDuplicates item in listOfFullPath)
            {
                if(item.Input== input&&item.FullPathResult== FullPath)
                {
                    return false;
                }
            }
            return true;
        }
     

    }

}
