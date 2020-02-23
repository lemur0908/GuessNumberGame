using System;
using System.Windows.Input;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            ActualUserInput userInput = new ActualUserInput();
            game.Start(userInput);           
        }
    }
}
