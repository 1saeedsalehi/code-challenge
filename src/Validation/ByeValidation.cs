using System;
using Abstractions.Contracts;

namespace Server.Validation
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
