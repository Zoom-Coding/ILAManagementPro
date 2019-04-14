using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ILAManagementPro.Data.Data
{
    public class SQLData
    {
        public static ControlEntity GetControl()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT FtpFileName, FtpFileFolder, FtpDrugTestFileName, FtpWelfareFileName, ");
            stringBuilder.AppendLine("FtpWelfareArchiveFileName, FtpScriptFileName, FtpLogFileName, FtpBatchFileName, ");
            stringBuilder.AppendLine("FtpServerAddress, FtpUserId, FtpPWD, EmpDues, UnionDues, FtpCutOff, FtpInterval, ");
            stringBuilder.AppendLine("FtpSendFileName, CheckInProcess, CreditUnionInProcess, CoImportFileFolder, ");
            stringBuilder.AppendLine("CoImportArchiveFolder, HHRate, WeekImportTo, WeekImportCC, AccountantTo, AccountantCC, ");
            stringBuilder.AppendLine("EmailWeek, EmailAcct, UpdateUser, UpdateDate ");
            stringBuilder.AppendLine("FROM dbo.Control");
            DataTable dataTable = RunSQLScript(stringBuilder.ToString());
            return new ControlEntity()
            {
                FtpFileName = dataTable.Rows[0]["FtpFileName"].ToString(),
                FtpFileFolder = dataTable.Rows[0]["FtpFileFolder"].ToString(),
                FtpDrugTestFileName = dataTable.Rows[0]["FtpDrugTestFileName"].ToString(),
                FtpWelfareFileName = dataTable.Rows[0]["FtpWelfareFileName"].ToString(),
                FtpWelfareArchiveFileName = dataTable.Rows[0]["FtpWelfareArchiveFileName"].ToString(),
                FtpScriptFileName = dataTable.Rows[0]["FtpScriptFileName"].ToString(),
                FtpLogFileName = dataTable.Rows[0]["FtpLogFileName"].ToString(),
                FtpBatchFileName = dataTable.Rows[0]["FtpBatchFileName"].ToString(),
                FtpServerAddress = dataTable.Rows[0]["FtpServerAddress"].ToString(),
                FtpUserId = dataTable.Rows[0]["FtpUserId"].ToString(),
                FtpPWD = dataTable.Rows[0]["FtpPWD"].ToString(),
                EmpDues = (Decimal?)new Decimal?(Convert.ToDecimal(dataTable.Rows[0]["EmpDues"].ToString())),
                UnionDues = (Decimal?)new Decimal?(Convert.ToDecimal(dataTable.Rows[0]["UnionDues"].ToString())),
                FtpCutOff = (DateTime?)new DateTime?(Convert.ToDateTime(dataTable.Rows[0]["FtpCutOff"].ToString())),
                FtpInterval = (Decimal?)new Decimal?(Convert.ToDecimal(dataTable.Rows[0]["FtpInterval"].ToString())),
                FtpSendFileName = dataTable.Rows[0]["FtpSendFileName"].ToString(),
                CheckInProcess = (bool?)new bool?(Convert.ToBoolean(dataTable.Rows[0]["CheckInProcess"].ToString())),
                CreditUnionInProcess = (bool?)new bool?(Convert.ToBoolean(dataTable.Rows[0]["CreditUnionInProcess"].ToString())),
                CoImportFileFolder = dataTable.Rows[0]["CoImportFileFolder"].ToString(),
                CoImportArchiveFolder = dataTable.Rows[0]["CoImportArchiveFolder"].ToString(),
                HHRate = (Decimal?)new Decimal?(Convert.ToDecimal(dataTable.Rows[0]["HHRate"].ToString())),
                WeekImportTo = dataTable.Rows[0]["WeekImportTo"].ToString(),
                WeekImportCC = dataTable.Rows[0]["WeekImportCC"].ToString(),
                AccountantTo = dataTable.Rows[0]["AccountantTo"].ToString(),
                AccountantCC = dataTable.Rows[0]["AccountantCC"].ToString(),
                EmailWeek = dataTable.Rows[0]["EmailWeek"].ToString(),
                EmailAcct = dataTable.Rows[0]["EmailAcct"].ToString(),
                UpdateUser = dataTable.Rows[0]["UpdateUser"].ToString(),
                UpdateDate = (DateTime?)new DateTime?(Convert.ToDateTime(dataTable.Rows[0]["UpdateDate"].ToString()))
            };
        }

        public static string UpdateControl(ControlEntity dto)
        {
            string str = "";
            if (!RunSQLUpdateScript("UPDATE Control SET FtpSendFileName = '" + dto.FtpSendFileName.Trim() + "'"))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Unable to update Control Table.");
                stringBuilder.AppendLine("[ILA.DAL][ILA.Data][Data][SQLData.cs][UpdateControl]");
                str = stringBuilder.ToString();
            }
            return str;
        }

        public static void AddTimeCardErrorLog(string sql)
        {
            RunSQLUpdateScript(sql);
        }

        public List<absvwHeaderLookup> GetHeadersByDate(
          DateTime workDate)
        {
            List<absvwHeaderLookup> headerLookupEntityList = new List<absvwHeaderLookup>();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT Header, VesselName, BerthShortName, FirstName, ");
            stringBuilder.AppendLine(" LastName, ClassCode, DateBirth, MI, DateWorked, DailySuspension, ShiftTime");
            stringBuilder.AppendLine("FROM dbo.[absvwAssignedHeaders]");
            stringBuilder.AppendLine("WHERE DateWorked >= '" + workDate.ToShortDateString() + "'");
            stringBuilder.AppendLine("AND DateWorked < '" + workDate.AddDays(1.0).ToShortDateString() + "'");
            stringBuilder.AppendLine("AND Header IS NOT NULL");
            foreach (DataRow row in (InternalDataCollectionBase)SQLData.RunSQLScript(stringBuilder.ToString()).Rows)
            {
                absvwHeaderLookup headerLookupEntity = new absvwHeaderLookup();
                headerLookupEntity.Id = row["Header"].ToString();
                headerLookupEntity.FirstName = row["FirstName"].ToString();
                headerLookupEntity.LastName = row["LastName"].ToString();
                headerLookupEntity.MiddleInitial = row["MI"].ToString();
                headerLookupEntity.ClassCode = row["ClassCode"].ToString();
                string str1 = row["DateBirth"].ToString();
                if (!string.IsNullOrEmpty(str1))
                    headerLookupEntity.BirthDate = (DateTime?)new DateTime?(Convert.ToDateTime(str1));
                headerLookupEntity.VesselName = row["VesselName"].ToString();
                headerLookupEntity.Berth = row["BerthShortName"].ToString();
                string str2 = row["ShiftTime"].ToString();
                if (!string.IsNullOrEmpty(str2))
                    headerLookupEntity.ShiftTime = Convert.ToDateTime(str2).ToShortTimeString();
                headerLookupEntityList.Add(headerLookupEntity);
            }
            return headerLookupEntityList;
        }

        public MemberDetail GetMemberDetail(Decimal cardNo)
        {
            MemberDetail absMemberDetails = new MemberDetail();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absvwMemberDetail absvwMemberDetail = ilaEntities.absvwMemberDetails.Where<absvwMemberDetail>((Expression<Func<absvwMemberDetail, bool>>)(b => b.CardNo == cardNo)).FirstOrDefault<absvwMemberDetail>();
                if (absvwMemberDetail != null)
                {
                    absMemberDetails.CardNumber = Convert.ToInt32(cardNo).ToString();
                    if (!string.IsNullOrEmpty(absvwMemberDetail.ClassCode))
                        absMemberDetails.ClassCode = absvwMemberDetail.ClassCode;
                    if (!string.IsNullOrEmpty(absvwMemberDetail.FirstName))
                        absMemberDetails.FirstName = absvwMemberDetail.FirstName;
                    if (!string.IsNullOrEmpty(absvwMemberDetail.LastName))
                        absMemberDetails.LastName = absvwMemberDetail.LastName;
                    if (!string.IsNullOrEmpty(absvwMemberDetail.MI))
                        absMemberDetails.MI = absvwMemberDetail.MI;
                    if (absvwMemberDetail.DateBirth.HasValue)
                        absMemberDetails.BirthDate = (DateTime)absvwMemberDetail.DateBirth.Value;
                    if (absvwMemberDetail.Photo != null)
                        absMemberDetails.Photo = absvwMemberDetail.Photo;
                }
            }
            return absMemberDetails;
        }

        private static bool RunSQLUpdateScript(string SQL)
        {
            bool flag = true;
            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.AppSettings["ILASQL"]))
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection))
                    {
                        oleDbCommand.CommandTimeout = 600;
                        flag = oleDbCommand.ExecuteNonQuery() == 1;
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    connection.Close();
                }
            }
            return flag;
        }

        private static DataTable RunSQLScript(string SQL)
        {
            DataTable dataTable = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.AppSettings["ILASQL"]))
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection))
                    {
                        oleDbCommand.CommandTimeout = 600;
                        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                        dataTable.Load((IDataReader)oleDbDataReader);
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    connection.Close();
                }
            }
            return dataTable;
        }
    }
}