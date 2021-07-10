using System;

namespace EPAM.FootballForum.Common.Entities
{
    public class User
    {
        public User(int id, string login, string email, int age, string createdAt)
        {
            ID = id;
            Login = login;
            Age = age;
            Email = email;
            CreatedAt = createdAt;
        }

        public User(string login, int age, string email, string hpassword, string createdAt, string userRole)
        {
            Login = login;
            Age = age;
            Email = email;
            HPassword = hpassword;
            CreatedAt = createdAt;
            Role = userRole;
        }

        private int _id;
        public int ID { 
            get => _id;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("ID can't be less then 0.");
                else
                    _id = value;
            } 
        }

        private string _login;
        public string Login {
            get => _login;
            private set 
            {
                if (value.Trim().Length < 2 || value == null)
                    throw new ArgumentException($"You can't put null or string with length less then 2 into login.");
                else
                    _login = value;
            }
        }

        private int _age;
        public int Age {
            get => _age;
            private set {
                if (value < 1 || value > 99)
                    throw new ArgumentException("Age can't be less then 1 or more then 99.");
                else
                    _age = value;
            } 
        }

        private string _email;
        public string Email {
            get => _email;
            private set
            {
                if (value == null || value == String.Empty)
                    throw new ArgumentException($"You can't put null or empty string into email.");
                else
                    _email = value;
            }
        }

        private string _hPassword;
        public string HPassword {
            get => _hPassword;
            private set
            {
                if (value == null || value == String.Empty)
                    throw new ArgumentException($"You can't put null into HPassword.");
                else
                    _hPassword = value;
            } 
        }

        private string _createdAt;
        public string CreatedAt {
            get => _createdAt;
            private set
            {
                if (value == null || value == String.Empty)
                    throw new ArgumentException($"You can't put null or empty string to creation time.");
                else
                    _createdAt = value;
            }
        }

        private string _role;
        public string Role {
            get => _role;
            private set
            {
                if (value == null || value == String.Empty)
                    throw new ArgumentException($"You can't put null into Role.");
                else
                    _role = value;
            }
        }
    }
}
