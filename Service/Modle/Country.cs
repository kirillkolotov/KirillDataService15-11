using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Country:BaseEntity
    {
        protected string country;
        [DataMember] public string CountryName { get { return country; } set { country = value; } }
    }
    [CollectionDataContract]
     public class CountryList : List<Country>
    {
        public CountryList() { } // default c'tor with empty list

        public CountryList(IEnumerable<Country> list) : base(list) { } // parse generic list to Language list

        public CountryList(IEnumerable<BaseEntity> list) : base(list.Cast<Country>().ToList()) { }
    } 
}
