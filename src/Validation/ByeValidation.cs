﻿using System;
using Abstractions.Contracts;

namespace EchantionChallenge.Validation
{

    public class ByeValidation : IValidationRules
    {
        private static readonly string _name = "Bye";
        public bool IsValid(string input)
        {
            return input.Equals(_name, StringComparison.InvariantCultureIgnoreCase);
        }

        public string toString()
        {
            return _name;
        }
    }
}
