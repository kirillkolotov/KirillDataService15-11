using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountryDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Country();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Country country = entity as Country;
            country.Id = int.Parse(reader["id"].ToString());
            country.CountryName = reader["CountryName"].ToString();
            return country;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Country country = entity as Country;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@CountryName", country.CountryName);
            command.Parameters.AddWithValue("@id", country.Id);
        }
        public CountryList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblCountry";
            CountryList list = new CountryList(base.ExecuteCommand());
            return list;
        }
        public Country SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblCountry WHERE id="+id;
            CountryList list = new CountryList(base.ExecuteCommand());
            if(list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Country country)
        {
            command.CommandText = "INSERT INTO TblCountry (CountryName) VALUES (@CountryName)";
            LoadParameters(country);
            return ExecuteCRUD();
        }
        public int Update(Country country)
        {
            command.CommandText = "UPDATE TblCountry SET CountryName = @CountryName WHERE id = @id";
            LoadParameters(country);
            return ExecuteCRUD();
        }
        public int Delete(Country country)
        {
            command.CommandText = "DELETE FROM TblCountry WHERE id =@id";
            LoadParameters(country);
            return ExecuteCRUD();
        }
    }
}
