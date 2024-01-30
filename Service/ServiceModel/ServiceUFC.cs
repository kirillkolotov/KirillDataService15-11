using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class ServiceUFC : IServiceUFC
    {
        #region User
        public UserList GetAllUsers()
        {
            UserDB db = new UserDB();
            return db.SelectAll();
        }
        public int NewUser(User user) {
            UserDB db = new UserDB();
            return db.Insert(user);
        }
        public int UpdateUser(User user) {
            UserDB db = new UserDB();
            return db.Update(user);
        }
        public int DeleteUser(User user) {
            UserDB db = new UserDB();
            return db.Delete(user);
        }
        public User Login(User user)
        {
            UserDB db = new UserDB();
            return db.Login(user);
        }
        public bool FindUsername(string username)
        {
            UserDB db = new UserDB();
            return db.FindUsername(username);
        }
        #endregion
        #region Country
        public CountryList GetAllCountries(){
            CountryDB db = new CountryDB();
            return db.SelectAll();
        }
       public int NewCountry(Country country){
            CountryDB db = new CountryDB();
            return db.Insert(country);
        }
       public int UpdateCountry(Country country){
            CountryDB db = new CountryDB();
            return db.Update(country);
        }
       public int DeleteCountry(Country country){
            CountryDB db = new CountryDB();
            return db.Delete(country);
        }
        #endregion
        #region Division
       public DivisionList GetAllDivisions(){
           DivisionDB db = new DivisionDB();
            return db.SelectAll();
        }
       public int NewDivision(Division division){
            DivisionDB db = new DivisionDB();
            return db.Insert(division);
        }
       public int UpdateDivision(Division division){
            DivisionDB db = new DivisionDB();
            return db.Update(division);
        }
       public int DeleteDivision(Division division){
            DivisionDB db = new DivisionDB();
            return db.Delete(division);
        }
        #endregion
        #region Fighter
       public FighterList GetAllFighters(){
            FighterDB db = new FighterDB();
            return db.SelectAll();
        }
       public int NewFighter(Fighter fighter){
            FighterDB db = new FighterDB();
        return db.Insert(fighter);
    }
       public int UpdateFighter(Fighter fighter){
            FighterDB db = new FighterDB();
            return db.Update(fighter);
        }
       public int DeleteFighter(Fighter fighter){
            FighterDB db = new FighterDB();
            return db.Delete(fighter);
        }
        #endregion

    }
}
