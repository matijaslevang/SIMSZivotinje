using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnimalShelter.GUI.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged, IDataErrorInfo
    {


        private string _email;
        private string _password;
        private string _error;
        private Regex _emailRegex = new Regex("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}");
        private readonly string[] _validatedProperties = { "Password", "Email" };

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email == null || value.ToLower() != _email.ToLower())
                {
                    _email = value.ToLower();
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string this[string columnName]
        {
            get
            {
                string start = string.Empty;
                if (columnName == "Email")
                {

                    if (string.IsNullOrEmpty(Email))
                    {
                        Error = "Email is required.";
                        start = "Email is required.";
                    }


                    else if (!_emailRegex.Match(Email).Success)
                    {
                        Error = "Format not good. Try again.";
                        start = "Format not good. Try again.";
                    }
                    else
                    {
                        Error = "";
                        start = string.Empty;

                    }


                }
                else if (columnName == "Password")
                {
                    if (string.IsNullOrEmpty(Password))
                    {
                        Error = "Password is required.";
                        start = "Password is required.";
                    }
                    else
                    {
                        Error = "";
                        start = string.Empty;

                    }

                }
                return start;
            }
        }


        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    var q = this[property];

                    if (!string.IsNullOrEmpty(this[property]))
                    {

                        return false;
                    }

                }

                Error = "";
                return true;
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
