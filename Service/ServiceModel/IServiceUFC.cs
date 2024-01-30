using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceUFC
    {
        #region User
        [OperationContract] UserList GetAllUsers();
        [OperationContract] int NewUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] User Login(User user);
        [OperationContract] bool FindUsername(string username);
        #endregion
        #region Country
        [OperationContract] CountryList GetAllCountries();
        [OperationContract] int NewCountry(Country country);
        [OperationContract] int UpdateCountry(Country country);
        [OperationContract] int DeleteCountry(Country country);
        #endregion
        #region Division
        [OperationContract] DivisionList GetAllDivisions();
        [OperationContract] int NewDivision(Division division);
        [OperationContract] int UpdateDivision(Division division);
        [OperationContract] int DeleteDivision(Division division);
        #endregion
        #region Fighter
        [OperationContract] FighterList GetAllFighters();
        [OperationContract] int NewFighter(Fighter fighter);
        [OperationContract] int UpdateFighter(Fighter fighter);
        [OperationContract] int DeleteFighter(Fighter Fighter);
        #endregion
    }
}
