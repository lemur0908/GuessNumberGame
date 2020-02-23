using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumberGame
{
    public class Game
    {
        private int _numberToBeGuessed;
        private int _inputRangeMin = 0;
        private int _inputRangeMax = 100;
        private int _inputNumber;
        private int _numberOfTrials = 5;
        private bool _gameFinishedSuccessfully = false;

        public bool GameFinishedSuccessfully
        {
            get => _gameFinishedSuccessfully;
            set => _gameFinishedSuccessfully = value;
        }
        public int InputNumber
        {
            get => _inputNumber;
            set => _inputNumber = value;
        }
        public int NumberToBeGuessed
        {
            get => _numberToBeGuessed;
            set => _numberToBeGuessed = value;
        }
        public int InputRangeMin
        {
            get => _inputRangeMin;
            set => _inputRangeMin = value;
        }
        public int InputRangeMax
        {
            get => _inputRangeMax;
            set => _inputRangeMax = value;
        }
        public int NumberOfTrials
        {
            get => _numberOfTrials;
            set => _numberOfTrials = value;
        }

        public bool Start(IUserInput userInput)
        {
            if (!CreateNumberToBeGuessed()) return false;

            while (!NumberToBeGuessedEqualsInputNumber() && TrialsLeft())
            {
                if(!ReceiveInputNumber(userInput)) return false;
            }

            return true;

        }
        private bool CreateNumberToBeGuessed()
        {
            Random random = new Random();
            NumberToBeGuessed = random.Next(InputRangeMin, InputRangeMax + 1);
            if(NumberToBeGuessed >= InputRangeMin && NumberToBeGuessed <= InputRangeMax)
            {
                return true;
            }
            return false;
        }
        private bool TrialsLeft()
        {
            if (NumberOfTrials > 0)
            {
                NumberOfTrials--;
                return true;
            }
            Console.WriteLine($"Sorry you tried 5 times, the number was {NumberToBeGuessed}");
            return false;
        }
        private bool ReceiveInputNumber(IUserInput userInput)
        {
            int falseInput = 0;
            string input;
            do
            {
                GiveGuidance();
                input = userInput.GetInput();
                falseInput++;
                if(falseInput > 5)
                {
                    return false;
                }
            } while (!IsValidInput(input));

            return true;
        }
        private void GiveGuidance()
        {
            //Console.Clear();
            Console.WriteLine("Please guess the number, the game has generated.");
            Console.WriteLine("It has to be a whole number between 0 and 100");
            Console.WriteLine($"This is your {5 - NumberOfTrials}. trial.");
        }
        public bool IsValidInput(string input)
        {
            int temporaryStorageInput;
            bool inputNumberIsValidInt = int.TryParse(input, out temporaryStorageInput);
            if (inputNumberIsValidInt) return InputIsInValidRange(temporaryStorageInput);
            return false;
        }
        private bool InputIsInValidRange(int temporaryStorageInput)
        {
            if (temporaryStorageInput >= InputRangeMin && temporaryStorageInput <= InputRangeMax)
            {
                InputNumber = temporaryStorageInput;
                return true;
            }   
            return false;
        }
        private bool NumberToBeGuessedEqualsInputNumber()
        {
            if (InputNumber == NumberToBeGuessed)
            {
                Console.WriteLine("You picked the right number.");
                Console.WriteLine($"Your number was: {InputNumber} and the Game's number was: {NumberToBeGuessed}.");
                return true;
            }
            else
            {
                if (NumberOfTrials < 5 && NumberOfTrials > 1)
                {
                    GiveHint();
                    System.Threading.Thread.Sleep(1500);
                }
            }
            return false;
        }
        private void GiveHint()
        {
            if (InputNumber < NumberToBeGuessed)
            {
                Console.WriteLine("The Game's number is bigger");
            }
            else
            {
                Console.WriteLine("The Game's number is smaller");
            }
            Console.WriteLine("Press any key to continue");
        }
    }

    

    

    
}
