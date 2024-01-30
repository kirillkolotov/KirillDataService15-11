using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Fighter:BaseEntity
    {
        protected string name;
        [DataMember] public string Name { get { return name; } set { name = value; } }

        protected string nickname;
        [DataMember] public string Nickname { get { return nickname; } set { nickname = value; } }

        protected DateTime age;
        [DataMember] public DateTime Age { get { return age; } set { age = value; } }

        protected int height;
        [DataMember] public int Height { get { return height; } set { height = value; } } // in inches

        protected int reach;
        [DataMember] public int Reach { get { return reach; } set { reach = value; } } // in inches

        protected Country country;
        [DataMember] public Country Country { get { return country; } set { country = value; } }

        protected string fightingstyle;
        [DataMember] public string FightingStyle { get { return fightingstyle; } set { fightingstyle = value; } }

        protected Division division;
        [DataMember] public Division Division { get { return division; } set { division = value; } }
        //weight class category
        // STATS & RECORDS
        // general stats 
        protected int winbyknockout;
        [DataMember] public int WinByKnockout { get { return winbyknockout; } set { winbyknockout = value; } }

        protected int winbysubmission;
        [DataMember] public int WinBySubmission { get { return winbysubmission; } set { winbysubmission = value; } }

        protected int winbydecision;
        [DataMember] public int WinByDecision { get { return winbydecision; } set { winbydecision = value; } }

        protected int losses;
        [DataMember] public int Losses { get { return losses; } set { losses = value; } }

        protected int disqualifications;
        [DataMember] public int Disqualifications { get { return disqualifications; } set { disqualifications = value; } }

        protected int sigStrikesLandedTotal;
        [DataMember] public int SigStrikesLandedTotal { get { return sigStrikesLandedTotal; } set { sigStrikesLandedTotal = value; } }

        protected int sigStrikesAttempted;
        [DataMember] public int SigStrikesAttempted { get { return sigStrikesAttempted; } set { sigStrikesAttempted = value; } }

        protected int takedownLanded;
        [DataMember] public int TakedownLanded { get { return takedownLanded; } set { takedownLanded = value; } }

        protected int takedownAttempted;
        [DataMember] public int TakedownAttempted { get { return takedownAttempted; } set { takedownAttempted = value; } }



        // fighter defence stats / fight time  

        protected int sigStrikesDefence;
        [DataMember] public int SigStrikesDefence { get { return sigStrikesDefence; } set { sigStrikesDefence = value; } }

        protected int takedownDefence;
        [DataMember] public int TakedownDefence { get { return takedownDefence; } set { takedownDefence = value; } }

        protected int fightTimeAvg;
        [DataMember] public int FightTimeAvg { get { return fightTimeAvg; } set { fightTimeAvg = value; } }

        protected int knockdownAvg;
        [DataMember] public int KnockdownAvg { get { return knockdownAvg; } set { knockdownAvg = value; } }


        // average stats per 1 min / 15 min;

        protected int sigStrikesLandedPerMin;
        [DataMember] public int SigStrikesLandedPerMin { get { return sigStrikesLandedPerMin; } set { sigStrikesLandedPerMin = value; } }

        protected int sigStrikesAbsorbedPerMin;
        [DataMember] public int SigStrikesAbsorbedPerMin { get { return sigStrikesAbsorbedPerMin; } set { sigStrikesAbsorbedPerMin = value; } }

        protected int takedownAvgPer15Min;
        [DataMember] public int TakedownAvgPer15Min { get { return takedownAvgPer15Min; } set { takedownAvgPer15Min = value; } }

        protected int submissionAvgPer15Min;
        [DataMember] public int SubmissionAvgPer15Min { get { return submissionAvgPer15Min; } set { submissionAvgPer15Min = value; } }


        //significant strikes landed by target;
        protected int sigStrikesHead;
        [DataMember] public int SigStrikesHead { get { return sigStrikesHead; } set { sigStrikesHead = value; } }

        protected int sigStrikesBody;
        [DataMember] public int SigStrikesBody { get { return sigStrikesBody; } set { sigStrikesBody = value; } }

        protected int sigStrikesLeg;
        [DataMember] public int SigStrikesLeg { get { return sigStrikesLeg; } set { sigStrikesLeg = value; } }


        // significant srikes landed by position;
        protected int sigStrikesStanding;
        [DataMember] public int SigStrikesStanding { get { return sigStrikesStanding; } set { sigStrikesStanding = value; } }

        protected int sigStrikesClinch;
        [DataMember] public int SigStrikesClinch { get { return sigStrikesClinch; } set { sigStrikesClinch = value; } }

        protected int sigStrikesGround;
        [DataMember] public int SigStrikesGround { get { return sigStrikesGround; } set { sigStrikesGround = value; } }
    }
    [CollectionDataContract]
    public class FighterList : List<Fighter>
    {
        public FighterList() { } // default c'tor with empty list

        public FighterList(IEnumerable<Fighter> list) : base(list) { } // parse generic list to Language list

        public FighterList(IEnumerable<BaseEntity> list) : base(list.Cast<Fighter>().ToList()) { }
    }
}
