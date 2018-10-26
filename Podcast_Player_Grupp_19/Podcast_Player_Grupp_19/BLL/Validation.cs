using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL
{
    class Validation
    {
        public bool ValidUserInput(string userInput, out string errorMessage)
        {
            //Regex to check if string starts with http or https
            Regex rgxUrl = new Regex(@"^(http|https|www)://.*$");

            // Confirm that the user input string is not empty.
            if (userInput.Length == 0)
            {
                errorMessage = "Inmatning saknas.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "email address must be valid email address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        public bool ValidURL(string url, out string errorMessage)
        {
            if (url.Length == 0)
            {
                errorMessage = "Inmatning saknas.";
                return false;
            }

            if (!url.StartsWith)
            {

            }
        }
    }
}
