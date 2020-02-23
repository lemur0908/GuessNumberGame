using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumberGame
{
    public class ActualUserInput : IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}
