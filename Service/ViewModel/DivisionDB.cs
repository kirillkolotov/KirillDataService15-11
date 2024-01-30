using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DivisionDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Division();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Division Division = entity as Division;
            Division.Id = int.Parse(reader["id"].ToString());
            Division.Name = reader["Name"].ToString();
            Division.Minweight = int.Parse(reader["Minweight"].ToString());
            Division.Maxweight = int.Parse(reader["Maxweight"].ToString());
            return Division;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Division Division = entity as Division;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Name", Division.Name);
            command.Parameters.AddWithValue("@Minweight", Division.Minweight);
            command.Parameters.AddWithValue("@Maxweight", Division.Maxweight);
            command.Parameters.AddWithValue("@id", Division.Id);
        }
        public DivisionList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblDivision";
            DivisionList list = new DivisionList(base.ExecuteCommand());
            return list;
        }
        public Division SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblDivision WHERE id="+id;
            DivisionList list = new DivisionList(base.ExecuteCommand());
            if(list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Division Division)
        {
            command.CommandText = "INSERT INTO TblDivision (Name,Minweight,Maxweight) VALUES (@Name,@Minweight,@Maxweight)";
            LoadParameters(Division);
            return ExecuteCRUD();
        }
        public int Update(Division Division)
        {
            command.CommandText = "UPDATE TblDivision SET Name = @Name,Minweight=@Minweight,Maxweight=@Maxweight WHERE id = @id";
            LoadParameters(Division);
            return ExecuteCRUD();
        }
        public int Delete(Division Division)
        {
            command.CommandText = "DELETE FROM TblDivision WHERE id =@id";
            LoadParameters(Division);
            return ExecuteCRUD();
        }
    }
}
