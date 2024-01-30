using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FighterDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Fighter();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Fighter fighter = entity as Fighter;
            fighter.Id = int.Parse(reader["id"].ToString());
            fighter.Name = reader["Name"].ToString();
            fighter.Nickname = reader["Nickname"].ToString();
            fighter.Age = DateTime.Parse(reader["Age"].ToString());
            fighter.Height = int.Parse(reader["Height"].ToString());
            fighter.Reach = int.Parse(reader["Reach"].ToString());
            fighter.FightingStyle = reader["FightingStyle"].ToString();
            fighter.WinByKnockout = int.Parse(reader["WinByKnockout"].ToString());
            fighter.WinBySubmission = int.Parse(reader["WinBySubmission"].ToString());
            fighter.WinByDecision = int.Parse(reader["WinByDecision"].ToString());
            fighter.SigStrikesLandedTotal = int.Parse(reader["SigStrikesLandedTotal"].ToString());
            fighter.SigStrikesAttempted = int.Parse(reader["SigStrikesAttempted"].ToString());
            fighter.TakedownLanded = int.Parse(reader["TakedownLanded"].ToString());
            fighter.TakedownAttempted = int.Parse(reader["TakedownAttempted"].ToString());
            fighter.SigStrikesDefence = int.Parse(reader["SigStrikesDefence"].ToString());
            fighter.TakedownDefence = int.Parse(reader["TakedownDefence"].ToString());
            fighter.FightTimeAvg = int.Parse(reader["FightTimeAvg"].ToString());
            fighter.KnockdownAvg = int.Parse(reader["KnockdownAvg"].ToString());
            fighter.SigStrikesLandedPerMin = int.Parse(reader["SigStrikesLandedPerMin"].ToString());
            fighter.SigStrikesAbsorbedPerMin = int.Parse(reader["SigStrikesAbsorbedPerMin"].ToString());
            fighter.TakedownAvgPer15Min = int.Parse(reader["TakedownAvgPer15Min"].ToString());
            fighter.SubmissionAvgPer15Min = int.Parse(reader["SubmissionAvgPer15Min"].ToString());
            fighter.SigStrikesHead = int.Parse(reader["SigStrikesHead"].ToString());
            fighter.SigStrikesBody = int.Parse(reader["SigStrikesBody"].ToString());
            fighter.SigStrikesLeg = int.Parse(reader["SigStrikesLeg"].ToString());
            fighter.SigStrikesStanding = int.Parse(reader["SigStrikesStanding"].ToString());
            fighter.SigStrikesClinch = int.Parse(reader["SigStrikesClinch"].ToString());
            fighter.SigStrikesGround = int.Parse(reader["SigStrikesGround"].ToString());
            fighter.Losses = int.Parse(reader["Losses"].ToString());
            fighter.Disqualifications = int.Parse(reader["Disqualifications"].ToString());

            CountryDB countryDB = new CountryDB();
            fighter.Country = countryDB.SelectById((int) reader["Country"]);
            DivisionDB divisionDB = new DivisionDB();
            fighter.Division = divisionDB.SelectById((int) reader["Division"]);

            return fighter;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Fighter fighter = entity as Fighter;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Name", fighter.Name);
            command.Parameters.AddWithValue("@Name", fighter.Name);
            command.Parameters.AddWithValue("@Nickname", fighter.Nickname);
            command.Parameters.AddWithValue("@Age", fighter.Age);
            command.Parameters.AddWithValue("@Height", fighter.Height);
            command.Parameters.AddWithValue("@Reach", fighter.Reach);
            command.Parameters.AddWithValue("@Country", fighter.Country);
            command.Parameters.AddWithValue("@FightingStyle", fighter.FightingStyle);
            command.Parameters.AddWithValue("@Division", fighter.Division);
            command.Parameters.AddWithValue("@WinByKnockout", fighter.WinByKnockout);
            command.Parameters.AddWithValue("@WinBySubmission", fighter.WinBySubmission);
            command.Parameters.AddWithValue("@WinByDecision", fighter.WinByDecision);
            command.Parameters.AddWithValue("@SigStrikesLandedTotal", fighter.SigStrikesLandedTotal);
            command.Parameters.AddWithValue("@SigStrikesAttempted", fighter.SigStrikesAttempted);
            command.Parameters.AddWithValue("@TakedownLanded", fighter.TakedownLanded);
            command.Parameters.AddWithValue("@TakedownAttempted", fighter.TakedownAttempted);
            command.Parameters.AddWithValue("@SigStrikesDefence", fighter.SigStrikesDefence);
            command.Parameters.AddWithValue("@TakedownDefence", fighter.TakedownDefence);
            command.Parameters.AddWithValue("@FightTimeAvg", fighter.FightTimeAvg);
            command.Parameters.AddWithValue("@KnockdownAvg", fighter.KnockdownAvg);
            command.Parameters.AddWithValue("@SigStrikesLandedPerMin", fighter.SigStrikesLandedPerMin);
            command.Parameters.AddWithValue("@SigStrikesAbsorbedPerMin", fighter.SigStrikesAbsorbedPerMin);
            command.Parameters.AddWithValue("@TakedownAvgPer15Min", fighter.TakedownAvgPer15Min);
            command.Parameters.AddWithValue("@SubmissionAvgPer15Min", fighter.SubmissionAvgPer15Min);
            command.Parameters.AddWithValue("@SigStrikesHead", fighter.SigStrikesHead);
            command.Parameters.AddWithValue("@SigStrikesBody", fighter.SigStrikesBody);
            command.Parameters.AddWithValue("@SigStrikesLeg", fighter.SigStrikesLeg);
            command.Parameters.AddWithValue("@SigStrikesStanding", fighter.SigStrikesStanding);
            command.Parameters.AddWithValue("@SigStrikesClinch", fighter.SigStrikesClinch);
            command.Parameters.AddWithValue("@SigStrikesGround", fighter.SigStrikesGround);
            command.Parameters.AddWithValue("@Losses", fighter.Losses);
            command.Parameters.AddWithValue("@Disqualifications", fighter.Disqualifications);
            command.Parameters.AddWithValue("@id", fighter.Id);
        }
        public FighterList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblFighter";
            FighterList list = new FighterList(base.ExecuteCommand());
            return list;
        }
        public Fighter SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblFighter WHERE id="+id;
            FighterList list = new FighterList(base.ExecuteCommand());
            if(list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Fighter Fighter)
        {
            command.CommandText = "INSERT INTO TblFighter (Name, Nickname, Age, Height, Reach, Country, FightingStyle, Division,WinByKnockout, WinBySubmission, WinByDecision, SigStrikesLandedTotal,      SigStrikesAttempted, TakedownLanded, TakedownAttempted, SigStrikesDefence,      TakedownDefence, FightTimeAvg, KnockdownAvg, SigStrikesLandedPerMin,      SigStrikesAbsorbedPerMin, TakedownAvgPer15Min, SubmissionAvgPer15Min,SigStrikesHead, SigStrikesBody, SigStrikesLeg, SigStrikesStanding,SigStrikesClinch, SigStrikesGround, Losses, Disqualifications )  " +
                " VALUES (@Name, @Nickname, @Age, @Height, @Reach, @Country, @FightingStyle, @Division,@WinByKnockout, @WinBySubmission, @WinByDecision, @SigStrikesLandedTotal,      @SigStrikesAttempted, @TakedownLanded, @TakedownAttempted, @SigStrikesDefence,      @TakedownDefence, @FightTimeAvg, @KnockdownAvg, @SigStrikesLandedPerMin,      @SigStrikesAbsorbedPerMin, @TakedownAvgPer15Min, @SubmissionAvgPer15Min, @SigStrikesHead, @SigStrikesBody, @SigStrikesLeg, @SigStrikesStanding,@SigStrikesClinch, @SigStrikesGround , @Losses, @Disqualifications)";
            LoadParameters(Fighter);
            return ExecuteCRUD();
        }
        public int Update(Fighter Fighter)
        {
            command.CommandText = "UPDATE TblFighter SET Name = @Name, Nickname = @Nickname, Age = @Age, Height = @Height, Reach = @Reach, Country = @Country, FightingStyle = @FightingStyle, Division = @Division, WinByKnockout = @WinByKnockout, " +
                "WinBySubmission = @WinBySubmission, WinByDecision = @WinByDecision, SigStrikesLandedTotal = @SigStrikesLandedTotal, SigStrikesAttempted = @SigStrikesAttempted, TakedownLanded = @TakedownLanded, " +
                "TakedownAttempted = @TakedownAttempted, SigStrikesDefence = @SigStrikesDefence, TakedownDefence = @TakedownDefence, FightTimeAvg = @FightTimeAvg, KnockdownAvg = @KnockdownAvg, " +
                "SigStrikesLandedPerMin = @SigStrikesLandedPerMin, SigStrikesAbsorbedPerMin = @SigStrikesAbsorbedPerMin, TakedownAvgPer15Min = @TakedownAvgPer15Min, SubmissionAvgPer15Min = @SubmissionAvgPer15Min, " +
                "SigStrikesHead = @SigStrikesHead, SigStrikesBody = @SigStrikesBody, SigStrikesLeg = @SigStrikesLeg, SigStrikesStanding = @SigStrikesStanding, SigStrikesClinch = @SigStrikesClinch, SigStrikesGround = @SigStrikesGround, " +
                "Losses = @Losses, Disqualifications = @Disqualifications" +
                "WHERE Id = @Id; -- Replace with the actual condition based on your table structure ";
            LoadParameters(Fighter);
            return ExecuteCRUD();
        }
        public int Delete(Fighter Fighter)
        {
            command.CommandText = "DELETE FROM TblFighter WHERE id =@id";
            LoadParameters(Fighter);
            return ExecuteCRUD();
        }
    }
}
