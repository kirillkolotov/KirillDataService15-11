using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.Id = int.Parse(reader["id"].ToString());
            user.Firstname = reader["firstname"].ToString();
            user.Lastname = reader["lastname"].ToString();
            user.Email = reader["email"].ToString();
            user.Username = reader["username"].ToString();
            user.Password = reader["password"].ToString();
            return user;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@firstname", user.Firstname);
            command.Parameters.AddWithValue("@lastname", user.Lastname);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@id", user.Id);
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblUsers";
            UserList list = new UserList(base.ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblUsers WHERE id=" + id;
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO TblUsers (firstname,lastname,email,username,password) VALUES (@firstname,@lastname,@email,@username,@password)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE TblUsers SET firstname = @firstname,lastname = @lastname,email = @email,username = @username,password = @password WHERE id = @id";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user) 

        {
            command.CommandText = "DELETE FROM TblUser WHERE id =@id";
            LoadParameters(user);
            return ExecuteCRUD();
        }
    }
}
