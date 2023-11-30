using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceLanguage
    {
        [OperationContract] UserList GetAllUsers();
        [OperationContract] int NewUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] User Login(User user);

        [OperationContract] MyLanguageList GetALLMyLanguages();
        [OperationContract] int NewMyLanguage(MyLanguage Mylanguage);
        [OperationContract] int UpdateMyLanguage(MyLanguage Mylanguage);
        [OperationContract] int DeleteMyLanguage(MyLanguage Mylanguage); 
        [OperationContract] MyLanguageList SelectByUser(User user); 
        [OperationContract] MyLanguageList SelectByLanguage(Language language);

        [OperationContract] LanguageList GetAllLanguages();
        [OperationContract] int NewLanguage(Language language);
        [OperationContract] int UpdateLanguage(Language language);
        [OperationContract] int DeleteLanguage(Language language);

        [OperationContract] ChatList GetAllChats();
        [OperationContract] ChatList GetChat(User user1 , User user2);
        [OperationContract] int NewChat(Chat chat);
        [OperationContract] int UpdateChat(Chat chat);
        [OperationContract] int DeleteChat(Chat chat);
    }
}
