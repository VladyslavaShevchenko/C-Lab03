using System;
//using System.ComponentModel.DataAnnotations;
using System.Windows;
using Lab2.Models;

namespace Lab2.ViewModels
{
    /// <summary>
    /// VM that corresponds to window showing all the properties of the person
    /// </summary>
    class PersonInfoViewModel : ObservableObject
    {
        #region binding properties
        public string Name => Person == null ? throw new PersonNullException() : Person.Name;

        public string Surname => Person == null ? throw new PersonNullException() : Person.Surname;

        public string Email => Person == null ? throw new PersonNullException() : Person.Email;

        //[DataType(DataType.Date)]
        public DateTime DateOfBirth => Person?.DateOfBirth ?? throw new PersonNullException();

        public bool IsAdult => Person?.IsAdult ?? throw new PersonNullException();

        public bool IsBirthday => Person?.IsBirthday ?? throw new PersonNullException();

        public AstrologicalSign AstrologicalSign => Person?.AstrologicalSign ?? throw new PersonNullException();

        public ZodiacSign ZodiacSign => Person?.ZodiacSign ?? throw new PersonNullException();
        #endregion

        public Person Person { get; private set; }

        // now i have proper initialization
        public PersonInfoViewModel(Person person)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            NotifyPersonDependentPropertiesChanged();
        }

        void NotifyPersonDependentPropertiesChanged()
        {
            var personDependentProperties = new string[]
            {
                nameof(Name), nameof(Surname), nameof(Email), nameof(DateOfBirth),
                nameof(IsAdult), nameof(IsBirthday), nameof(AstrologicalSign), nameof(ZodiacSign)
            };
            foreach (string propName in personDependentProperties)
            {
                OnPropertyChanged(propName);
            }
        }
    }
}