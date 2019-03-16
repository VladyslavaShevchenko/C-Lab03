using System;
using System.Runtime.Serialization;

namespace Lab2.ViewModels
{
    [Serializable]
    public class PersonNullException : Exception
    {

        public PersonNullException() : base("Attempting to access the property of Person object when it is null")
        {
        }

        protected PersonNullException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}