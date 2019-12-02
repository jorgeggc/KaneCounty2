using DataLibary.DataAccess;
using DataLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployeeLog(int accessLocationID, string stationID,
            DateTime accessDate,int iDCardNumber,string declineReason)
        {
            EmployeeLog data = new EmployeeLog
            {
                
                AccessLocationID = accessLocationID,
                StationID = stationID,
                AccessDate = accessDate,
                IDCardNumber = iDCardNumber,
                DeclineReason = declineReason

            };

            string sql = @"insert into dbo.AccessLogs (AccessLocationID, StationID, AccessDate, IDCardNumber, DeclineReason) values(@AccessLocationID, @StationID, @AccessDate, @IDCardNumber, @DeclineReason);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeLog> LoadEmployeeLog()
        {
            string sql = @"select AccessLogID, AccessLocationID, StationID, AccessDate, IDCardNumber, 
                            DeclineReason from dbo.AccessLogs;";

            return SqlDataAccess.LoadData<EmployeeLog>(sql);
        }
        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select IdentificationCardID, Name, OrgStructure, PhoneNumber, 
                        EmailAddress, HireDate, CardExpireDate, TerminationDate, WorkerTypeID, 
                        Company, CourtAccessRequired, IDCardNumber from dbo.IdentificationCards;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
