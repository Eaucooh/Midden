namespace John.Game.RandomNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        /// <summary>
        /// Model - Result
        /// </summary>
        public class Result
        {
            public int Index { get; set; }
            public bool Flag { get; set; }
        }

        /// <summary>
        /// Main Method
        /// </summary>
        static void Main()
        {
            Program game = new Program();
            game.Run();
        }

        /// <summary>
        /// Method to run the program
        /// </summary>
        void Run()
        {
            // initialize the number of attempts
            int numberOfAttempts = 5;

            Console.WriteLine("\nWelcome to Random Number Guessing Game.");
            Console.WriteLine("\nGuess the 4 digit random number XXXX.");
            Console.WriteLine("For each digit, the number is chosen from 1 to 5  \nNumbers can repeat.");
            Console.WriteLine(string.Format("\nYou have {0} attempts to win the game.", numberOfAttempts));

            // Call the method to Generate the Random Number
            string randomNumber = GenerateRandomNumber();

            for (int i = 1; i <= numberOfAttempts; i++)
            {
                // Call the method to get the user input
                string userInput = GetUserInput(i);

                // Get the result - Collection containing the result of all 4 digits
                List<Result> result = GetResult(randomNumber, userInput);

                // Guess the count of number of digits that are correct
                int flagCount = result.Where(f => f.Flag == true).Count();

                // Get the place(s)/index of digits that are correct
                string digitsCorrect = string.Join(",", result.Where(f => f.Flag == true)
                    .Select(c => (++c.Index).ToString()));

                // check the flag count and display appropriate message
                if (flagCount == 4)
                {
                    Console.WriteLine("Random Number:{0} , Your Input:{1}", randomNumber, userInput);
                    Console.WriteLine("You guessed it correct! You won the game..hurray...:)");
                    break;
                }
                else if (i == numberOfAttempts)
                {
                    Console.WriteLine("sorry, You missed it! You lost the game..:(");
                    Console.WriteLine("Random Number is {0}", randomNumber);
                }
                else
                {
                    digitsCorrect = flagCount == 0 ? "none" : digitsCorrect;
                    Console.WriteLine(string.Format("Digit(s) in place {0} correct", digitsCorrect));
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Method to compare the random number and user input.
        /// </summary>
        /// <param name="randomNumber">Random Number</param>
        /// <param name="userInput">User Input</param>
        /// <returns>Result List</returns>
        public List<Result> GetResult(string randomNumber, string userInput)
        {
            char[] splitRandomNumber = randomNumber.ToCharArray();
            char[] splitUserInput = userInput.ToCharArray();

            List<Result> results = new List<Result>();
            for (int index = 0; index < randomNumber.Length; index++)
            {
                Result result = new Result();
                result.Index = index;
                result.Flag = splitRandomNumber[index] == splitUserInput[index];
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Method to get the user input
        /// </summary>
        /// <param name="attempt">user attempt</param>
        /// <returns>Input number in string format</returns>
        public string GetUserInput(int attempt)
        {
            int inputNumber;
            Console.WriteLine(string.Format("\nGuess the number. Attempt:{0}", attempt));
            Console.WriteLine("Input a 4 digit number");

            if (int.TryParse(Console.ReadLine(), out inputNumber)
                && inputNumber.ToString().Length == 4)
            {
                return inputNumber.ToString();
            }
            else
            {
                Console.WriteLine("You have entered a invalid input.");
                return "0000";
            }
        }

        /// <summary>
        /// Step 1: Method to generate a random number
        /// </summary>
        /// <returns>Random number in string format</returns>
        public string GenerateRandomNumber()
        {
            Random random = new Random();
            string number = string.Empty;
            int length = 4;

            for (int i = 0; i < length; i++)
            {
                number += random.Next(1, 6);
            }

            return number;
        }
    }
}
