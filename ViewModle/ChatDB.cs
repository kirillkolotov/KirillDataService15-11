using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChatDB : BaseDB
    {
        //הפעולה מחזירה עצם חדש מסוג צא'ט
        protected override BaseEntity NewEntity()
        {
            return new Chat();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            chat.Id = int.Parse(reader["id"].ToString());
            chat.Text = reader["text"].ToString();
            //טעינת מידע מלא של המשתמשים 
            UserDB userDB = new UserDB();
            chat.Sender = userDB.SelectById(int.Parse( reader["sender"].ToString()));
            chat.Reciver = userDB.SelectById(int.Parse(reader["reciver"].ToString()));
            return chat;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@sender", chat.Sender);
            command.Parameters.AddWithValue("@reciver", chat.Reciver);
            command.Parameters.AddWithValue("@text", chat.Text);
            command.Parameters.AddWithValue("@id", chat.Id);
        }
        public ChatList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblChat";
            ChatList list = new ChatList(base.ExecuteCommand());
            return list;
        }
        public Chat SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblChat WHERE id=" + id;
            ChatList list = new ChatList(base.ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Chat chat)
        {
            command.CommandText = "INSERT INTO TblChat (sender,reciver,text) VALUES (@sender,@reciver,@text)";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Update(Chat chat)
        {
            command.CommandText = "UPDATE TblChat SET sender = @sender,reciver = @reciver,text = @text WHERE id = @id";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Delete(Chat chat)

        {
            command.CommandText = "DELETE FROM TblChat WHERE id =@id";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
    }
}
