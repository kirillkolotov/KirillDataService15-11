using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract(Name = "Level")]
    public enum Level
    {
        [EnumMember] student,
        [EnumMember] basic,
        [EnumMember] speaker,
        [EnumMember] teacher
    }
    [DataContract]
    public class MyLanguage:BaseEntity
    {        
        protected User me;
        protected Level level;
        protected Language language;

        [DataMember] public User Me { get {return me; } set {value = me; } }
        [DataMember] public Level Level { get {return level; } set {value = level; } }
        [DataMember] public Language Language { get {return language; } set {value = language; } }

    }
    [CollectionDataContract]
    public class MyLanguageList: List<MyLanguage>
    {
        public MyLanguageList() { } // default c'tor with empty list

        public MyLanguageList(IEnumerable<MyLanguage> list) : base(list) { } // parse generic list to MyLanguage list

        public MyLanguageList(IEnumerable<BaseEntity> list) : base(list.Cast<MyLanguage>().ToList()) { } // from base class to MyLanguage list
    }
}
