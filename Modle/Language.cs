using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Language: BaseEntity
    {
        protected string name;
        protected string url;
        public string Name { get {return name ; } set { name=value; } }
        public string Url { get {return url; } set { url = value; } }
    }
    public class LanguageList : List<Language>
    {
        public LanguageList() { } // default c'tor with empty list

        public LanguageList(IEnumerable<Language> list) : base(list) { } // parse generic list to Language list

        public LanguageList(IEnumerable<BaseEntity> list) : base(list.Cast<Language>().ToList()) { } // from base class to Language list
    }
}
