using System;
using System.Linq;

namespace MontyHallProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runAgain;
            int switchOption, doorShown, answer, guess, finalGuess, q;
            string switchChoice = "y";
            int correct = 0;
            int wrong = 0;


            Print("\nWould you like to play the game ('p') to test the odds ('t')?\n");
            string playOrTest = Console.ReadLine().ToLower();

            do
            {
                if (playOrTest == "t")
                {
                    correct = 0;
                    wrong = 0;
                    //Who many times you would like to run the program
                    Print("\nHow many times would you like to run the test? (enter 0 to exit)\n");
                    q = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    q = 1;
                }

                if (q == 0)
                    runAgain = false;
                else
                {
                    runAgain = true;
                    if (playOrTest == "t")
                    {
                        //Asks the user if they want to test switching or staying
                        Print("\nAre you going to switch? ('y' or 'n')\n");
                        switchChoice = Console.ReadLine();
                    }

                    for (int i = 0; i < q; i++)
                    {
                        // Sets a random answer 
                        Random r = new Random();
                        answer = r.Next(3);

                        // if playing User is prompted to input a guess, if test pick a random number 0-2
                        if (playOrTest == "t")
                        {
                            Random r2 = new Random();
                            guess = r2.Next(3);
                        }
                        else
                        {

                            Print("\nWe have Doors 0, 1, or 2.\nBehind one of them is a new car, and the other two have a goat behind them.\nWhat number door would you like to choose?\n");
                            guess = Convert.ToInt32(Console.ReadLine());
                        }

                        //Determining what door to show them
                        if (guess == answer)
                        {
                            //if a == g: then remove either one of them from the pool of potential choices (we remove their guess from the array then remove whatever is now indexed at 0 in the array that left to determine whcih door to show them)

                            int[] choices = { 0, 1, 2 };
                            choices = choices.Where((val, idx) => idx != answer).ToArray();
                            doorShown = choices[0];

                            if (playOrTest == "p") Console.WriteLine("\nDoor {0} had a goat behind it!", doorShown);

                        }
                        else
                        {
                            //if a != g then we remove the answer from the array as well as remove their guess from the array and we are left which door to show them
                            int[] choices = { 0, 1, 2 };


                            choices = choices.Where((val) => val != answer && val != guess).ToArray();

                            doorShown = choices[0];

                            if (playOrTest == "p") Console.WriteLine("\nDoor {0} had a goat behind it!\n", doorShown);

                        }

                        //Create a switch option by removing the guess and the doorShown from a choices array
                        int[] finalChoices = { 0, 1, 2 };

                        finalChoices = finalChoices.Where((val) => val != doorShown && val != guess).ToArray();
                        switchOption = finalChoices[0];

                        //Now we want to ask the user if they would like to switch to the other option or keep the door they have
                        if (playOrTest == "p")
                        {
                            Console.WriteLine("\nWould you like to switch to Door {0}? (y or n)\n", switchOption);
                            switchChoice = Console.ReadLine();
                        }

                        //You can manually set this value to test the percantage outcome of switching or not.
                        //switchChoice = "n";

                        if (switchChoice == "y")
                            finalGuess = switchOption;
                        else
                            finalGuess = guess;

                        //If they got it right tell them!
                        if (answer == finalGuess)
                        {
                            if (playOrTest == "p") Print("\nYou've won a new car!");
                            correct++;
                        }
                        else
                        {
                            if (playOrTest == "p") Print("\nYou've won a goat!");
                            wrong++;
                        }

                    }

                    Console.WriteLine("\nCorrect: {0}      Wrong: {1}\n", correct, wrong);

                    if (playOrTest == "p")
                    {
                        Print("would you like to play again? ('y' or 'n')\n");
                        var playAgainChoice = Console.ReadLine();
                        if (playAgainChoice == "n") runAgain = false;
                    }
                }
            } while (runAgain);
        }

        public static void Print(string val)
        {
            Console.WriteLine(val);
        }
    }
}