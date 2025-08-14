using System;

namespace UsersApp
{
    class User
    {
        public int id { get; set; }
        private string login, password, email;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public User() { }

        public User(string login, string password, string email)
        {
            this.login = login;
            this.email = email;
            this.password = password;
        }

        //чтобы понять что за пользователи
        public override string ToString() //переписываем метод ToString
        {
            // return base.ToString();
            return "User: " + Login + ". Email: " + Email;
        }

    }

}
