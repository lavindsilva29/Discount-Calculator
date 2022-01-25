using System;

namespace JeweleryApp
{
    public class UserInvalidException : Exception
    {
        public UserInvalidException() { }
        public UserInvalidException(string message) : base(message)
        {
        }

    }
}
