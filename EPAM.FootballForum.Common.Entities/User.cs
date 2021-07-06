using System;

namespace EPAM.FootballForum.Common.Entities
{
    public class User
    {
        public User(string login, int age, string email, string hpassword, string createdAt, string userRole)
        {
            Login = login;
            Age = age;
            Email = email;
            HPassword = hpassword;
            CreatedAt = createdAt;
            Role = userRole;
        }

        public int ID { 
            get => ID;
            private set
            {
                if (ID <= 0)
                    throw new ArgumentException("ID can't be less then 0.");
                else
                    ID = value;
            } 
        }

        public string Login {
            get => Login;
            private set 
            {
                if (Login.Trim().Length < 2 || Login == null)
                    throw new ArgumentException($"You can't put null or string with length less then 2 into login.");
                else
                    Login = value;
            }
        }

        public int Age {
            get => Age;
            private set {
                if (Age < 1 || Age > 99)
                    throw new ArgumentException("Age can't be less then 1 or more then 99.");
                else
                    Age = value;
            } 
        }

        public string Email {
            get => Email;
            private set
            {
                if (Email == null || Email == String.Empty)
                    throw new ArgumentException($"You can't put null or empty string into email.");
                else
                    Email = value;
            }
        }

        public string HPassword {
            get => HPassword;
            private set
            {
                if (HPassword == null || HPassword == String.Empty)
                    throw new ArgumentException($"You can't put null into HPassword.");
                else
                    HPassword = value;
            } 
        }

        public string CreatedAt {
            get => CreatedAt;
            private set
            {
                if (CreatedAt == null || CreatedAt == String.Empty)
                    throw new ArgumentException($"You can't put null or empty string to creation time.");
                else
                    CreatedAt = value;
            }
        }

        public string Role {
            get => Role;
            private set
            {
                if (Role == null || Role == String.Empty)
                    throw new ArgumentException($"You can't put null into Role.");
                else
                    Role = value;
            }
        }
    }
}
