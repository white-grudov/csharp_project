using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using csharp_project.Exceptions;
using csharp_project.Models;
using csharp_project.Utilities;

namespace csharp_project.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public ICommand? ProcessDateButtonCommand { get; set; }
        public ICommand? ProcessClearButtonCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        private Person? _person;

        public PersonViewModel()
        {
            ProcessDateButtonCommand = new RelayCommand((object parameter) => true, (object parameter) => Submit());
            ProcessClearButtonCommand = new RelayCommand((object parameter) => true, (object parameter) => Clear());
        }

        private string _firstName = "";
        private string _lastName = "";
        private string _emailAddress = "";
        private DateTime _birthDate = DateTime.Now;

        public string FirstName
        {
            get => _firstName; 
            set 
            { 
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            } 
        }
        public string LastName 
        { 
            get => _lastName; 
            set 
            { 
                _lastName = value; 
                OnPropertyChanged(nameof(LastName)); 
            } 
        }
        public string EmailAddress 
        { 
            get => _emailAddress; 
            set 
            { 
                _emailAddress = value; 
                OnPropertyChanged(nameof(EmailAddress)); 
            } 
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        private string? _personInfo;
        public string? PersonInfo
        {
            get => _personInfo;
            set
            {
                _personInfo = value;
                OnPropertyChanged(nameof(PersonInfo));
            }
        }
        
        public RelayCommand ProcessDateCommand
        {
            get
            {
                return new RelayCommand((object parameter) => true, (object parameter) => Submit());
            }
        }

        public async void Submit()
        {
            await Task.Run(() =>
            {
                if (FirstName == "" || LastName == "" || EmailAddress == "")
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }

                try
                {
                    _person = new Person(FirstName, LastName, EmailAddress, BirthDate);

                    PersonInfo = $"Name: {_person.FirstName} {_person.LastName}\n" +
                                 $"Email: {_person.EmailAddress}\n" +
                                 $"Age: {_person.Age}\n" +
                                 $"Date of Birth: {_person.DateOfBirth:dd-MM-yyyy}\n" +
                                 $"Is Adult: {(_person.IsAdult ? "Yes" : "No")}\n" +
                                 $"Western Zodiac: {_person.WesternZodiac}\n" +
                                 $"Chinese Zodiac: {_person.ChineseZodiac}";

                    if (_person.IsBirthday)
                    {
                        MessageBox.Show("Happy Birthday!");
                    }
                }
                catch (IncorrectDateException ex)
                {
                    MessageBox.Show(ex.Message, "Incorrect Date", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (InvalidEmailAddressException ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Email Address", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ShortNameException ex)
                {
                    MessageBox.Show(ex.Message, "Name is too short", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        public async void Clear()
        {
            await Task.Run(() =>
            {
                FirstName = "";
                LastName = "";
                EmailAddress = "";
                PersonInfo = "";
                BirthDate = DateTime.Now;
            });
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
