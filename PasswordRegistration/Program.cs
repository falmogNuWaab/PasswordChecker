using System;
using System.Collections.Generic;

namespace PasswordRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare global variables
            int index = 0;
            bool isValid = false;
            
            //List housing usernames
            List<string> uNames = new List<string>();
            uNames.Add("thndrBndt1");
            uNames.Add("TheGreat1");
            uNames.Add("Y0l0Swggnz");

            //List housing passwords
            List<string> uPass = new List<string>();
            uPass.Add("giGlep!g$");
            uPass.Add("nSlckUn!f0rm");
            uPass.Add("iJustn3ed#");

            //Array of banned usernames
            List<string> noNoWords = new List<string>();
            noNoWords.Add("nklebkfan");
            noNoWords.Add("nickleback");
            noNoWords.Add("fart");
            noNoWords.Add("coldplay");
            noNoWords.Add("bleep");
            

            //Have the user pick the password before the username. It's a new best practice, get with the program.

            while (!isValid)
            {
                //Declare variables local to the current loop
                bool minLength = true;
                bool maxLength = true;
                bool upperCase = false;
                bool lowerCase = false;
                bool specialChars = false;
                bool hasNums = false;
                string errorPrompt = "\nPassword did not meet minimum requirements: ";
                string password = GetUserInput("Please choose a password: ");
                char[] pArray = password.ToCharArray();
                
                //Check to make sure it's at least 7 characters long
                if(pArray.Length < 7)
                {
                    minLength = false;
                }
                else
                {
                    minLength = true;
                }
                //Check to make sure it's not longer than 12 characters
                if(pArray.Length > 12)
                {
                    maxLength = false;
                }
                else
                {
                    maxLength = true;
                }
                //Check for upper case letters, lower case letters, numbers, and special characters
                upperCase = CheckUppers(password);
                lowerCase = CheckLower(password);
                specialChars = CheckSpecs(password);
                hasNums = CheckNums(password);

                //Set the error message based on the results of the above methods
                if (!minLength)
                {
                    errorPrompt = errorPrompt + "\nPassword must contain at least 7 characters!";
                }
                if (!maxLength)
                {
                    errorPrompt = errorPrompt + "\nPassword cannot be longer than 12 characters!";
                }
                if (!upperCase)
                {
                    errorPrompt = errorPrompt + "\nPassword must contain an upper case character!";

                }
                if (!lowerCase)
                {
                    errorPrompt = errorPrompt + "\nPassword must contain a lower case character!";
                }
                if (!specialChars)
                {
                    errorPrompt = errorPrompt + "\nPassword must contain 1 of the following special characters:! @ # $ % ^ & *";
                }
                if (!hasNums)
                {
                    errorPrompt = errorPrompt + "\nPassword must contain a number";
                }

                //Last check to make sure we are good to go
                if (minLength && maxLength && upperCase && lowerCase && specialChars && hasNums)
                {
                    uPass.Add(password);
                    index = uPass.IndexOf(password);
                    isValid = true;
                    Console.WriteLine("Password added to index: " + index);
                }
                else
                {
                    //If we aren't good to go, tell the user what is wrong
                    Console.WriteLine(errorPrompt);
                }
            }
            
            //Time for a new loop!
            isValid = false;
            while (!isValid)
            {
                //Declare variables local to this loop only
                bool minLength = true;
                bool maxLength = true;
                bool isItAvail = false;
                bool hasNums = false;
                bool enoughLetters = false;
                bool permittedName = true;

                //have the user pick their username
                string username = GetUserInput("Please choose a username: ");
                char[] uArray = username.ToCharArray();
                string errorPrompt = "Username did not meet requirements:";
                if (uArray.Length < 7)
                {
                    errorPrompt = errorPrompt + "\nUsername must contain at least 7 characters!";
                    minLength = false;
                }

                if (uArray.Length > 12)
                {
                    errorPrompt = errorPrompt + "\nUsername cannot contain more than 12 characters!";
                    maxLength = false;
                }


                hasNums = CheckNums(username);
                if (!hasNums)
                {
                    errorPrompt = errorPrompt + "\nUsername must contain a number";
                }
                enoughLetters = CheckNumberOfLetters(username);
                if (!enoughLetters)
                {
                    errorPrompt = errorPrompt + "\nUsername must contain at least 5 letters";
                }

                permittedName = BannedList(username,noNoWords);
                if (!permittedName)
                {
                    errorPrompt = errorPrompt + "\nUsername contained a banned word, please try something else!";
                }

                isItAvail = BannedList(username, uNames);
                if (!isItAvail)
                {
                    errorPrompt = errorPrompt + "\nUsername is not available, please try something else!";
                }


                if (minLength && maxLength && hasNums && enoughLetters && permittedName && isItAvail)
                {
                    
                    isValid = true;                    
                    uNames.Add(username);
                    index = uNames.IndexOf(username);
                    Console.WriteLine("Username added to index: " + index);
                }
                else
                {
                    Console.WriteLine(errorPrompt);
                }

            }

        }

        public static string GetUserInput(string prompt)
        {
            //send the user a prompt and return the response
            Console.WriteLine(prompt);
            string response = Console.ReadLine();

            return response;
        }

        public static bool CheckUppers(string testString) 
        {
            //user's username or password is sent to this through the testString parameter
            //it will then be broken down into an array of characters then each character will be evaluated.
            char[] testChar = testString.ToCharArray();
            foreach (char acter in testChar)
            {
                if (char.IsUpper(acter))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public static bool CheckLower(string testString)
        {
            char[] testChar = testString.ToCharArray();
            foreach (char acter in testChar)
            {
                if (char.IsLower(acter))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public static bool CheckSpecs(string testString)
        {
            char[] testChar = testString.ToCharArray();
            char[] mustHaves = new char[8];
            mustHaves[0] = '!';
            mustHaves[1] = '@';
            mustHaves[2] = '#';
            mustHaves[3] = '$';
            mustHaves[4] = '%';
            mustHaves[5] = '^';
            mustHaves[6] = '&';
            mustHaves[7] = '*';

            foreach (char acter in testChar)
            {
                for (int i = 0; i < mustHaves.Length; i++)
                {
                    
                    if (mustHaves[i] == acter)
                    {
                        
                        return true;
                    }
                    else
                    {
                        
                        continue;
                    }
                }
            }
            return false;            
        }

        public static bool CheckNums(string testString)
        {
            char[] charArray = testString.ToCharArray();
            foreach (char testChar in charArray)
            {
                if (char.IsNumber(testChar) == true)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public static bool CheckNumberOfLetters(string testString)
        {
            char[] charArray = testString.ToCharArray();
            int letterCount = 0;
            foreach(char testChar in charArray)
            {
                if(char.IsLetter(testChar))
                {
                    letterCount++;
                }
                else
                {
                    continue;
                }
            }
            if (letterCount >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool BannedList(string testString, List<string> testArray)
        {
            for (int i = 0; i < testArray.Count; i++)
            {
                string testVar = testArray[i].ToLower();
                //Console.WriteLine($"List Element: {testVar}, \nUser Input: {testString}");
                if (testString.ToLower().Contains(testVar.ToLower()) || testString.ToLower() == testVar.ToLower())
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return true;

        }
    }
}
