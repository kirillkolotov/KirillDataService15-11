using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LanguageDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Language();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Language language = entity as Language;
            language.Id = int.Parse(reader["id"].ToString());
            language.Name = reader["name"].ToString();
            language.Url = reader["url"].ToString();
            return language;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Language language = entity as Language;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", language.Name);
            command.Parameters.AddWithValue("@url", language.Url);
            command.Parameters.AddWithValue("@id", language.Id);
        }
        public LanguageList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblLanguage";
            LanguageList list = new LanguageList(base.ExecuteCommand());
            return list;
        }
        public Language SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblLanguage WHERE id="+id;
            LanguageList list = new LanguageList(base.ExecuteCommand());
            if(list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Language language)
        {
            command.CommandText = "INSERT INTO TblLanguage (name,url) VALUES (@name,@url)";
            LoadParameters(language);
            return ExecuteCRUD();
        }
        public int Update(Language language)
        {
            command.CommandText = "UPDATE TblLanguage SET name = @name,url = @url WHERE id = @id";
            LoadParameters(language);
            return ExecuteCRUD();
        }
        public int Delete(Language language)
        {
            command.CommandText = "DELETE FROM TblLanguage WHERE id =@id";
            LoadParameters(language);
            return ExecuteCRUD();
        }
    }
}
