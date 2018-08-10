using System;

namespace BLL
{
    public class GetTime
    {
        /// <SendWelcome>
        /// get no parameter and return string
        /// check the time of the day and return relevant welcome
        /// </summary>
        /// <returns>string welcome</returns>
        
        public static string SendWelcome()
        {
           string Text = DateTime.Now.ToString("HH");
          int Hour= Convert.ToInt32(Text);
            if (Hour > 0 && Hour < 12)
                return "Good Morning";
            else if (Hour >= 12 && Hour <= 18)
                return "Good Afternoon";
            else
            {
                return "Good Evening";
            }

        }
    }

}
