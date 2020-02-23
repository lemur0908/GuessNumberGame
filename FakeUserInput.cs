using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumberGame
{
    public class FakeUserInput : IUserInput
    {
        private string _input;
        public string Input
        {
            get => _input;
            set => _input = value;
        }
        public FakeUserInput(string input)
        {
            this._input = input;
        }
        public string GetInput()
        {
            return Input;
        }
    }
}
