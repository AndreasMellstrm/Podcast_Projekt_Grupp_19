using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL
{
    static class Validation
    {
        //Regex to check if string starts with http or https
        static Regex rgxUrl = new Regex("^(http|https)");

        public static bool ValidUserInput(string userInput, out string errorMessage)
        {
            // Confirm that the user input string is not empty.
            if (userInput.Length == 0)
            {
                errorMessage = "Inmatning saknas.";
                return false;
            } else
            {
                errorMessage = "";
                return true;
            }
        }

        public static bool ValidURL(string url, out string errorMessage)
        {
            if (url.Length == 0)
            {
                errorMessage = "Inmatning saknas.";
                return false;
            }

            if (rgxUrl.IsMatch(url))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = "Url:n måste börja med antingen 'https://', 'http://'";
                return false;
            }
        }
    }
}
