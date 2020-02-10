using System;
using System.Linq;

namespace MontyHallProblem
{
  class Program
  {
    static void Main(string[] args)
    {
      bool runAgain;
      int switchOption;
      int doorShown;
      int answer;
      int guess;
      string switchChoice;
      int finalGuess;

      do
      {

        int correct = 0;
        int wrong = 0;
        
        //Who many times you would like to run the program
        Console.WriteLine("How many times would you like to run the test? (enter 0 to exit)");
        int q = Convert.ToInt32(Console.ReadLine());
        if (q == 0)
          runAgain = false;
        else
        {
          runAgain = true;




          //Asks the user if they want to test 
          Console.WriteLine("Are you going to switch? ('y' or 'n')");
          switchChoice = Console.ReadLine();
        

        for (int i = 0; i < q; i++)
        {
          // Sets a random answer 
          Random r = new Random();
          answer = r.Next(3);

          //User is prompted to input a guess
          //Console.WriteLine("We have Doors 0, 1, or 2.  Behind one of them is a new car, and the other two have a goat behind them. What number door would you like to choose?");
          //guess = Convert.ToInt32(Console.ReadLine());
          Random r2 = new Random();
          guess = r2.Next(3);






          //Determining what door to show them
          if (guess == answer)
          {
            //if a == g: then remove either one of them from the pool of potential choices (we remove their guess from the array then remove whatever is now indexed at 0 in the array that left to determine whcih door to show them)
            int[] choices = { 0, 1, 2 };

            int numIndex = Array.IndexOf(choices, answer);
            choices = choices.Where((val, idx) => idx != numIndex).ToArray();

            choices = choices.Skip(1).ToArray();

            doorShown = choices[0];

            //Console.WriteLine("Door {0} had a goat behind it!", doorShown);


          }
          else
          {
            //if a != g then we remove the answer from the array as well as remove their guess from the array and we are left which door to show them
            int[] choices = { 0, 1, 2 };

            int numIndex = Array.IndexOf(choices, answer);
            choices = choices.Where((val, idx) => idx != numIndex).ToArray();

            int numIndex2 = Array.IndexOf(choices, guess);
            choices = choices.Where((val, idx) => idx != numIndex2).ToArray();

            doorShown = choices[0];

            //Console.WriteLine("Door {0} had a goat behind it!", doorShown);


          }


          //Create a switch option by removing the guess and the doorShown from a choices array
          int[] finalChoices = { 0, 1, 2 };

          int numIndex3 = Array.IndexOf(finalChoices, doorShown);
          finalChoices = finalChoices.Where((val, idx) => idx != numIndex3).ToArray();

          int numIndex4 = Array.IndexOf(finalChoices, guess);
          finalChoices = finalChoices.Where((val, idx) => idx != numIndex4).ToArray();

          switchOption = finalChoices[0];




          //Now we want to ask the user if they would like to switch to the other option or keep the door they have
          //Console.WriteLine("Would you like to switch to Door {0}? (y or n)", switchOption);
          //switchChoice = Console.ReadLine();


          //You can manually set this value to test the percantage outcome of switching or not.
          //switchChoice = "n";

          if (switchChoice == "y")
            finalGuess = switchOption;
          else
            finalGuess = guess;


          //If they got it right tell them!
          if (answer == finalGuess)
          {
            //Console.WriteLine("You've won a new car!");
            correct++;
          }
          else
          {
            //Console.WriteLine("You've won a goat!");
            wrong++;
          }

        
        }

        Console.WriteLine("Correct: {0}      Wrong: {1}", correct, wrong);
        Console.WriteLine("");
        }
      } while (runAgain);
    }
  }
}
