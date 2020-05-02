using System;

namespace BuyGames
{
    public class NotExistingCardException: Exception
    {
        public NotExistingCardException(string msg) : base(msg)
        {
        }
    }
}