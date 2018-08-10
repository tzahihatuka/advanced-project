using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{/// <GetDataFromDB>
 /// get data from the db by parameter
 /// and return number
 /// if the parameter returned is 0 the parameter is not exists
 /// </summary>
    public class GetDataFromDB
    {
# region send qurey
        public int GetUserInputId(string userInput)
        {
           return GetQueryRequest.SelectDb($" SELECT DISTINCT dbo.GetUserIDUserInput(N'{userInput}') FROM UserInput");
        }
        public int GetSearchResultId(string SearchResult)
        {
            return GetQueryRequest.SelectDb($" SELECT DISTINCT dbo.GetSearchResult(N'{SearchResult}')  FROM SearchResult");
        }
        public static List<PreventDuplicates> GetSearchResultList(string userInput)
        {
            return GetQueryRequest.GetList($" SELECT FolderAndFile,searchInput  FROM linkedTables AS f " +
                $"JOIN SearchResult AS d ON d.Id = f.SearchResultId " +
                $"JOIN UserInput AS c ON c.Id = f.InputDataId " +
                $"WHERE c.searchInput = 'N{userInput}';");
        }

        public int GetUserFolderInputId(string folderToserch)
        {
            return GetQueryRequest.SelectDb($" SELECT DISTINCT dbo.GetUserIDUserFolderInput('{folderToserch}') FROM UserInput");
        }
#endregion
    }
}
