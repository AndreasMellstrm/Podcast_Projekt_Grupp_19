using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL {
    static class Validation {
        //Regex to check if string starts with http or https
        static Regex rgxUrl = new Regex("^(http|https)");

        public static bool ValidUserInput(string userInput, out string errorMessage) {
            // Confirm that the user input string is not empty.
            if (userInput.Length == 0) {
                errorMessage = "Please enter a valid name";
                return false;
            }
            else {
                errorMessage = "";
                return true;
            }
        }

        public static bool ValidURL(string url, out string errorMessage) {
            // Returns false if no URL has been entered.
            if (url.Length == 0) {
                errorMessage = "Please enter a valid URL";
                return false;
            }
            // Returns true if the URL matches the RegEx string.
            else if (rgxUrl.IsMatch(url)) {
                errorMessage = "";
                return true;
            }
            // Returns false if the URL does not start with either https or http.
            else {
                errorMessage = "The URL have to start with eiter 'https' 'http'.";
                return false;
            }
        }

        // Validates the amount of items selected
        public static bool CountSelections(int i, out string errorMessage) {

            // Returns true if only one item is selected.
            if (i == 1) {
                errorMessage = "";
                return true;
            }
            // Returns false if more than one item is selected.
            else if (i > 1) {
                errorMessage = "Please select one category only";
                return false;
            }

            // Returns false if no item is selected.
            else {
                errorMessage = "Please select a category";
                return false;
            }
        }
    }
}
