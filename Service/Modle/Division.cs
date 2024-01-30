using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Division:BaseEntity
    {
       protected string name;
        protected int minweight;
        protected int maxweight;
        [DataMember] public string Name { get { return name; } set { name = value; } }
        [DataMember] public int Minweight { get { return minweight; } set { minweight = value; } }
        [DataMember] public int Maxweight { get { return maxweight; } set { maxweight = value; } }
    }
    [CollectionDataContract]
    public class DivisionList : List<Division>
    {
        public DivisionList() { } // default c'tor with empty list

        public DivisionList(IEnumerable<Division> list) : base(list) { } // parse generic list to Language list

        public DivisionList(IEnumerable<BaseEntity> list) : base(list.Cast<Division>().ToList()) { } // from base class to Language list
    }
}
