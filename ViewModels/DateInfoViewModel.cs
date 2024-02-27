using System;
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

        private DateInfo _dateInfo = new DateInfo();

        public DateInfoViewModel()
        {
            ProcessDateButtonCommand = new RelayCommand((object parameter) => true, (object parameter) => SubmitDate());
            ProcessClearButtonCommand = new RelayCommand((object parameter) => true, (object parameter) => ClearDate());
        }

        public DateTime BirthDate
        {
            get => _dateInfo.BirthDate;
            set
            {
                _dateInfo.BirthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public string? Age
        {
            get => _dateInfo.Age;
            set
            {
                _dateInfo.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public string? WesternZodiacSign
        {
            get => _dateInfo.WesternZodiacSign;
            set
            {
                _dateInfo.WesternZodiacSign = value;
                OnPropertyChanged("WesternZodiacSign");
            }
        }

        public string? ChineseZodiacSign
        {
            get => _dateInfo.ChineseZodiacSign;
            set
            {
                _dateInfo.ChineseZodiacSign = value;
                OnPropertyChanged("ChineseZodiacSign");
            }
        }
        
        public RelayCommand ProcessDateCommand
        {
            get
            {
                return new RelayCommand((object parameter) => true, (object parameter) => SubmitDate());
            }
        }

        public void SubmitDate()
        {
            var age = DateUtilites.CalculateAge(BirthDate);
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Invalid age");
                return;
            }
            Age = age.ToString();

            WesternZodiacSign = DateUtilites.GetWesternZodiac(BirthDate);
            ChineseZodiacSign = DateUtilites.GetChineseZodiac(BirthDate);

            if (DateUtilites.IsBirthday(BirthDate))
            {
                MessageBox.Show("Happy Birthday!");
            }
        }

        public void ClearDate()
        {
            BirthDate = DateTime.Now;
            Age = null;
            WesternZodiacSign = null;
            ChineseZodiacSign = null;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
