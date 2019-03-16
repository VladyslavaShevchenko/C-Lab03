using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Lab2.Models;

namespace Lab2.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region binding properties
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public ICommand PersonDataSubmitCommand { get; }
        #endregion

        readonly Grid _personInfoGrid;

        internal MainWindowViewModel(Grid personInfoGrid)
        {
            _personInfoGrid = personInfoGrid ?? throw new ArgumentNullException(nameof(personInfoGrid));
            PersonDataSubmitCommand = new Async(CreateAndShowPersonFromInputedData, _ =>
                _personInfoGrid.Visibility != Visibility.Visible && AllFieldsHaveBeenSet());
        }

        #region command delegates

        bool AllFieldsHaveBeenSet()
        {
            return !(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) ||
                string.IsNullOrEmpty(Email)); // date time always has default value 
        }

        async Task CreateAndShowPersonFromInputedData(object o)
        {

            Console.WriteLine(DateOfBirth);
            if (DateOfBirthday.DateOfBirthIsTrue(DateOfBirth) == false)
            {
                MessageBox.Show("Enter a valid date!", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            if (DateOfBirthday.IsBirthday(DateOfBirth))
            {
                MessageBox.Show("Wow, it's your birthday! Go enjoy yourself.", "your only invite today",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            if (!EmailValidator.IsValidFormat(Email))
            {
                MessageBox.Show("The email is badly formatted!", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            // cannot access DataContext from non-ui thread
            // and anyway, creating the new thread would take more time that just execution this code
            var person = new Person(Name, Surname, Email, DateOfBirth);
            var personInfoVM = new PersonInfoViewModel(person);
            _personInfoGrid.DataContext = personInfoVM;

            _personInfoGrid.Visibility = Visibility.Visible;

        }
        #endregion

    }
}