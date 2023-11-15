using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Level
    {
        Low,
        Medium,
        High,
        Top
    }
    public class MyLanguage:BaseEntity
    {
        protected User me;
        protected Level level;
        protected Language language;

        public User Me { get {return me; } set {value = me; } }
        public Level Level { get {return level; } set {value = level; } }
        public Language Language { get {return language; } set {value = language; } }

    }
    public class MyLanguageList : List<MyLanguage>
    {
        public MyLanguageList() { } // default c'tor with empty list

        public MyLanguageList(IEnumerable<MyLanguage> list) : base(list) { } // parse generic list to MyLanguage list

        public MyLanguageList(IEnumerable<BaseEntity> list) : base(list.Cast<MyLanguage>().ToList()) { } // from base class to MyLanguage list
    }
}
