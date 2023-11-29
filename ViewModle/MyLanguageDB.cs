using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MyLanguageDB : BaseDB
    {
        //הפעולה מחזירה עצם חדש מסוג השפות שלך
        protected override BaseEntity NewEntity()
        {
            return new MyLanguage();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyLanguage myLanguage = new MyLanguage();
            myLanguage.Id = int.Parse(reader["id"].ToString());
            myLanguage.Level = (Level)reader["level"];
            //טעינת מידע מלא של המשתמש
            UserDB userDB = new UserDB();
            myLanguage.Me = userDB.SelectById(int.Parse(reader["user"].ToString()));
            //טעינת מידע מלא של המשתמש
            LanguageDB languageDB = new LanguageDB();
            myLanguage.Language = languageDB.SelectById(int.Parse(reader["language"].ToString()));
            return myLanguage;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            MyLanguage myLanguage = new MyLanguage();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@level", myLanguage.Level);
            command.Parameters.AddWithValue("@user", myLanguage.Me);
            command.Parameters.AddWithValue("@language", myLanguage.Language);
            command.Parameters.AddWithValue("@id", myLanguage.Id);
        }
        public LanguageList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblMyLanguage";
            LanguageList list = new LanguageList(base.ExecuteCommand());
            return list;
        }
        public MyLanguage SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblMyLanguage WHERE id=" + id;
            ChatList list = new ChatList(base.ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Chat chat)
        {
            command.CommandText = "INSERT INTO TblMyLanguage (level,user,language) VALUES (@level,@user,@language)";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Update(Chat chat)
        {
            command.CommandText = "UPDATE TblMyLanguage SET level = @level,user = @user,language = @language WHERE id = @id";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Delete(Chat chat)

        {
            command.CommandText = "DELETE FROM TblMyLanguage WHERE id =@id";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
    }
}
