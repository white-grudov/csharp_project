using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using csharp_project.Utilities;

namespace csharp_project.Models
{
    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string? _emailAddress;
        private readonly DateTime? _dateOfBirth;
        private uint? _age;
        private bool? _isAdult;
        private string? _westernZodiac;
        private string? _chineseZodiac;
        private bool? _isBirthday;

        public Person(string firstName, string lastName, string? emailAddress, DateTime? dateOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = emailAddress;
            _dateOfBirth = dateOfBirth;
            Calculate();
        }

        public Person(string firstName, string lastName, string emailAddress) : this(firstName, lastName, emailAddress, null)
        {
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth) : this(firstName, lastName, null, dateOfBirth)
        {
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string EmailAddress => _emailAddress ?? "";
        public DateTime DateOfBirth => _dateOfBirth ?? DateTime.Now;

        public uint Age => _age ?? 0;
        public bool IsAdult => _isAdult ?? false;
        public string WesternZodiac => _westernZodiac ?? "";
        public string ChineseZodiac => _chineseZodiac ?? "";
        public bool IsBirthday => _isBirthday ?? false;

        private void Calculate()
        {
            _age = DateUtilites.CalculateAge(_dateOfBirth ?? DateTime.Now);
            _isAdult = DateTime.Now.Year - _dateOfBirth?.Year > 18;
            _westernZodiac = DateUtilites.GetWesternZodiac(_dateOfBirth ?? DateTime.Now);
            _chineseZodiac = DateUtilites.GetChineseZodiac(_dateOfBirth ?? DateTime.Now);
            _isBirthday = DateUtilites.IsBirthday(_dateOfBirth ?? DateTime.Now);
        }
    }
}
