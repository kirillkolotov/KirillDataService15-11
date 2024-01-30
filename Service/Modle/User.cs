using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class User:BaseEntity
    {
       
        protected string firstname;
        protected string lastname;
        protected string email;
        protected string username;
        protected string password;
        protected bool isAdmin;

        [DataMember] public string Firstname { get {return firstname; } set { firstname=value; } }
        [DataMember] public string Lastname { get {return lastname; } set { lastname = value; } }
        [DataMember] public string Email { get {return email; } set { email = value; } }
        [DataMember] public string Username { get {return username; } set { username = value; } }
        [DataMember] public string Password { get {return password; } set { password = value; } }
        [DataMember] public bool IsAdmin { get {return isAdmin; } set { isAdmin = value; } }

    }
    [CollectionDataContract]
    public class UserList : List<User>
    {
        public UserList() { } // default c'tor with empty list

        public UserList(IEnumerable<User> list) : base(list) { } // parse generic list to User list

        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to User list
    }
}
