﻿namespace WA.Pizza.Core.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() { }

        public ItemNotFoundException(string message) : base(message) { }
    }
}
