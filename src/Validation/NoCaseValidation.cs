using Abstractions.Contracts;
using System;

namespace EchantionChallenge.Validation
{
    public class NoCaseValidation : IValidationRules
    {
        public bool IsValid(string input)
        {
            return false;
        }

        public string toString()
        {
            throw new InvalidOperationException("not a valid case");
        }
    }
}
