using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class ServiceLanguage : IServiceLanguage
    {
        public UserList GetAllUsers()
        {
            UserDB db = new UserDB();
            return db.SelectAll();
        }
        public int NewUser(User user) {
            UserDB db = new UserDB();
            return db.Insert(user);
        }
        public int UpdateUser(User user) {
            UserDB db = new UserDB();
            return db.Update(user);
        }
        public int DeleteUser(User user) {
            UserDB db = new UserDB();
            return db.Delete(user);
        }
        public User Login(User user)
        {
            UserDB db = new UserDB();
            return db.Login(user);
        }

        public MyLanguageList GetALLMyLanguages() {
            MyLanguageDB db = new MyLanguageDB();
            return db.SelectAll();
        }
        public int NewMyLanguage(MyLanguage mylanguage)
        {
            MyLanguageDB db = new MyLanguageDB();
            return db.Insert(mylanguage);
        }
        public int UpdateMyLanguage(MyLanguage mylanguage)
        {
            MyLanguageDB db = new MyLanguageDB();
            return db.Update(mylanguage);
        }
        public int DeleteMyLanguage(MyLanguage mylanguage)
        {
            MyLanguageDB db = new MyLanguageDB();
            return db.Delete(mylanguage);
        }
        public MyLanguageList SelectByUser(User user)
        {
            MyLanguageDB db = new MyLanguageDB();
            return db.SelectByUser(user);
        }
        public MyLanguageList SelectByLanguage(Language language)
        {
            MyLanguageDB db = new MyLanguageDB();
            return db.SelectAll();
        }

        public LanguageList GetAllLanguages()
        {
            LanguageDB db = new LanguageDB();
            return db.SelectAll();
        }
        public int NewLanguage(Language language)
        {
            LanguageDB db = new LanguageDB();
            return db.Insert(language);
        }
        public int UpdateLanguage(Language language)
        {
            LanguageDB db = new LanguageDB();
            return db.Update(language);
        }
        public int DeleteLanguage(Language language)
        {
            LanguageDB db = new LanguageDB();
            return db.Delete(language);
        }
        public ChatList GetAllChats() {
            ChatDB db = new ChatDB();
            return db.SelectAll();
        }
        public ChatList GetChat(User user1, User user2) {
            ChatDB db = new ChatDB();
            return db.SelectChat(user1,user2);
        }
        public int NewChat(Chat chat)
        {
            ChatDB db = new ChatDB();
            return db.Insert(chat);
        }
        public int UpdateChat(Chat chat)
        {
            ChatDB db = new ChatDB();
            return db.Update(chat);
        }
        public int DeleteChat(Chat chat)
        {
            ChatDB db = new ChatDB();
            return db.Delete(chat);
        }
    }
}
