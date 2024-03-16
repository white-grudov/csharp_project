﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using csharp_project.Models;
using csharp_project.Utilities;

namespace csharp_project.ViewModels
{
    public class DateInfoViewModel : INotifyPropertyChanged
    {
        public ICommand? ProcessDateButtonCommand { get; set; }
        public ICommand? ProcessClearButtonCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        private Person? _person;

        public DateInfoViewModel()
        {
            ProcessDateButtonCommand = new RelayCommand((object parameter) => true, (object parameter) => SubmitDate());
            ProcessClearButtonCommand = new RelayCommand((object parameter) => true, (object parameter) => ClearDate());
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
                OnPropertyChanged("FirstName");
            } 
        }
        public string LastName 
        { 
            get => _lastName; 
            set 
            { 
                _lastName = value; 
                OnPropertyChanged("LastName"); 
            } 
        }
        public string EmailAddress 
        { 
            get => _emailAddress; 
            set 
            { 
                _emailAddress = value; 
                OnPropertyChanged("EmailAddress"); 
            } 
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string? _personInfo;
        public string? PersonInfo
        {
            get => _personInfo;
            set
            {
                _personInfo = value;
                OnPropertyChanged("PersonInfo");
            }
        }
        
        public RelayCommand ProcessDateCommand
        {
            get
            {
                return new RelayCommand((object parameter) => true, (object parameter) => SubmitDate());
            }
        }

        public async void SubmitDate()
        {
            await Task.Run(() =>
            {
                if (FirstName == "" || LastName == "" || EmailAddress == "")
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }
                _person = new Person(FirstName, LastName, EmailAddress, BirthDate);
                if (_person.Age < 0 || _person.Age > 135)
                {
                    MessageBox.Show("Invalid age");
                    return;
                }

                if (_person.IsBirthday)
                {
                    MessageBox.Show("Happy Birthday!");
                }

                PersonInfo = $"Name: {_person.FirstName} {_person.LastName}\n" +
                             $"Email: {_person.EmailAddress}\n" +
                             $"Age: {_person.Age}\n" +
                             $"Date of Birth: {_person.DateOfBirth:dd-MM-yyyy}\n" +
                             $"Is Adult: {(_person.IsAdult ? "Yes" : "No")}\n" +
                             $"Western Zodiac: {_person.WesternZodiac}\n" +
                             $"Chinese Zodiac: {_person.ChineseZodiac}";
            });
        }

        public async void ClearDate()
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
