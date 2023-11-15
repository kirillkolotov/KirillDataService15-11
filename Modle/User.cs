using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:BaseEntity
    {
        protected string firstname;
        protected string lastname;
        protected string email;
        protected string username;
        protected string password;

        public string Firstname { get {return firstname; } set { value = firstname; } }
        public string Lastname { get {return lastname; } set { value = lastname; } }
        public string Email { get {return email; } set { value = email; } }
        public string Username { get {return username; } set { value = username; } }
        public string Password { get {return password; } set { value = password; } }

    }
    public class UserList : List<User>
    {
        public UserList() { } // default c'tor with empty list

        public UserList(IEnumerable<User> list) : base(list) { } // parse generic list to User list

        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to User list
    }
}
