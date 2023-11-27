using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Chat:BaseEntity
    {
        
        protected User sender;
        protected User reciver;
        protected string text;

        [DataMember]
        public User Sender { get {return sender; } set {sender = value; } }
        [DataMember]
        public User Reciver { get {return reciver; } set {reciver = value; } }
        [DataMember]
        public string Text { get{return Text; } set {text = value; } }
    }
    [CollectionDataContract]
    public class ChatList : List<Chat>
    {
        public ChatList() { } // default c'tor with empty list

        public ChatList(IEnumerable<Chat> list) : base(list) { } // parse generic list to Chat list

        public ChatList(IEnumerable<BaseEntity> list) : base(list.Cast<Chat>().ToList()) { } // from base class to Chat list
    }
}
