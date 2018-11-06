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
                errorMessage = MissingInput();
                return false;
            } else
            {
                errorMessage = "";
                return true;
            }
        }

        public static bool ValidURL(string url, out string errorMessage)
        {
            // Confirm that the user input (in this case the URL string) is not empty
            if (url.Length == 0)
            {
                errorMessage = MissingInput();
                return false;
            }
            // The input string is valid
            if (rgxUrl.IsMatch(url))
            {
                errorMessage = "";
                return true;
            }
            else
            {                   
                errorMessage = "The URL have to start with eiter 'https' 'http'.";
                return false;
            }
        }

        public static bool CountSelections(int i,out string errorMessage) {

            if (i == 1) {
                errorMessage = "";
                return true;
            }
            else if (i > 1) {
                errorMessage = "Please select one category only";
                return false;
            }
            else {
                errorMessage = "Please select a category";
                return false;
            }
        }
        private static string MissingInput() {
            string message = "Missing Input.";
            return message;
        }
    }
}
