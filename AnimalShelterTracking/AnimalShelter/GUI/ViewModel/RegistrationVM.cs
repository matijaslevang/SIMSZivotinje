using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Requests;
using AnimalShelter.Model.Users;
using AnimalShelter.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnimalShelter.GUI.ViewModel
{
    public class RegistrationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id;
        private string _firstName;
        private string _lastName;
        private Gender _gender;
        private DateTime _birthDate;
        private string _phoneNumber;
        private string _idCardNumber;
        private string _email;
        private string _password;
        private string _error;

        private readonly string[] _validatedProperties = { "FirstName", "LastName", "BirthDate", "PhoneNumber", "IdCardNumber", "Password", "Email" };
        private Regex _emailRegex = new Regex("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}");
        private Regex _phoneNumberRegex = new Regex("\\d{6,}");


        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                if (value != _error)
                {
                    _error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

        public int Id { get => _id; set => _id = value; }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public Gender Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value != _birthDate)
                {
                    _birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public string IdCardNumber
        {
            get { return _idCardNumber; }
            set
            {
                if (value != _idCardNumber)
                {
                    _idCardNumber = value;
                    OnPropertyChanged("IdCardNumber");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == null || value.ToLower() != _email.ToLower())
                {
                    _email = value.ToLower();
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName" && string.IsNullOrEmpty(FirstName))
                {
                    Error += "First name is required. ";
                }
                else if (columnName == "LastName" && string.IsNullOrEmpty(LastName))
                {
                    Error += "Last name is required. ";
                }
                else if (columnName == "BirthDate" && DateTime.Now.Date.CompareTo(BirthDate.Date) < 0)
                {
                    Error += "Birth date is invalid. ";
                }
                else if (columnName == "PhoneNumber")
                {
                    if (string.IsNullOrEmpty(PhoneNumber))
                    {
                        Error += "Phone number is required. ";
                    }
                    else if (!_phoneNumberRegex.Match(PhoneNumber).Success)
                    {
                        Error += "Phone number is invalid. ";
                    }
                }

                else if (columnName == "IdCardNumber")
                {
                    if (string.IsNullOrEmpty(IdCardNumber))
                    {
                        Error += "Id card number is required. ";
                    }
                    else if (!_phoneNumberRegex.Match(IdCardNumber).Success)
                    {
                        Error += "Id card number is invalid. ";
                    }
                }

                else if (columnName == "Password" && string.IsNullOrEmpty(Password))
                {
                    Error += "Password is required. ";
                }
                else if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        Error += "Email is required. ";
                    }
                    else if (!_emailRegex.Match(Email).Success)
                    {
                        Error += "Email is invalid. ";
                    }
                }
                return Error;
                //"FirstName", "LastName", "BirthDate", "PhoneNumber", "Password", "Email"
            }
        }

        public bool IsValid
        {
            get
            {
                bool returnValue = true;
                foreach (var property in _validatedProperties)
                {
                    if (!string.IsNullOrEmpty(this[property]))
                    {
                        returnValue = false;
                    }
                }
                return returnValue;
            }
        }

        public RegistrationVM()
        {
            Error = "";
        }

        public Model.Users.Member ToMember()
        {
            Account account = new Account(Email, Password, Role.MEMBER);
            return new Model.Users.Member(Id, account, FirstName, LastName, PhoneNumber, IdCardNumber, BirthDate, Gender);
        }

        public RegistrationRequest ToRequest()
        {
            Address address = new Address("Serbia", "Sid", "Marsala Tita", "103", "22240");
            RegistrationRequestService service = new RegistrationRequestService();
            return new RegistrationRequest(FirstName, LastName, PhoneNumber, Email, Password, IdCardNumber, address, Gender, BirthDate);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
