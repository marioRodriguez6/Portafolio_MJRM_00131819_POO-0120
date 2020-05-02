using System;

namespace BuyGames
{
    public class EmptyInputException: Exception
    {
        public EmptyInputException(string message) : base(message)
        {
        }
    }
}