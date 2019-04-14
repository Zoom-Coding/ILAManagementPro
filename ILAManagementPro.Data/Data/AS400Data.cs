using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace ILAManagementPro.Data.Data
{
    public class AS400Data : IDisposable
    {
        private string connectionString;
        private OleDbConnection dbConnection;

        public AS400Data()
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            if (connectionStrings.Count > 0)
            {
                foreach (ConnectionStringSettings connectionStringSettings in (ConfigurationElementCollection)connectionStrings)
                {
                    if (connectionStringSettings.Name.Equals("ILAConn"))
                    {
                        this.connectionString = connectionStringSettings.ConnectionString;
                        break;
                    }
                }
            }
            this.Connect();
        }

        internal WelfareMemberEntity returnMemberData(string memberIDNumber)
        {
            WelfareMemberEntity welfareMemberEntity = new WelfareMemberEntity();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("PTPARTH", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberIDNumber);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            welfareMemberEntity.MemberNumber = oleDbDataReader["MEMBER_NUMBER"].ToString();
                            welfareMemberEntity.MemberName = oleDbDataReader["MEMBER_NAME"].ToString();
                            welfareMemberEntity.BirthDate = (DateTime)Convert.ToDateTime(oleDbDataReader["MEMBER_BIRTH_DATE"].ToString());
                            welfareMemberEntity.Age = oleDbDataReader["PARTICIPANT_AGE"].ToString();
                            welfareMemberEntity.MaritalStatus = oleDbDataReader["MARITAL_STATUS"].ToString();
                            welfareMemberEntity.MarriageDate = (DateTime)Convert.ToDateTime(oleDbDataReader["MARRIAGE_DATE"].ToString()).Date;
                            welfareMemberEntity.SpouseDependentNumber = oleDbDataReader["SPOUSE_DEP_NUM"].ToString();
                            welfareMemberEntity.SpouseName = oleDbDataReader["SPOUSE_NAME"].ToString();
                            welfareMemberEntity.SpouseBirthDate = oleDbDataReader["SPOUSE_BIRTH_DATE"].ToString();
                            welfareMemberEntity.SpouseAge = oleDbDataReader["SPOUSE_AGE"].ToString();
                            welfareMemberEntity.LastCalendarYearPosted = (int?)new int?(Convert.ToInt32(oleDbDataReader["LAST_CAL_YEAR_POSTED"].ToString()));
                            welfareMemberEntity.LastCalendarDatePosted = (DateTime)Convert.ToDateTime(oleDbDataReader["LAST_CAL_DATE_POSTED"].ToString()).Date;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400.");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return welfareMemberEntity;
        }

        internal AccumulatedPensionEntity returnMemberAccumulated(
          string memberIDNumber)
        {
            AccumulatedPensionEntity accumulatedPensionEntity = new AccumulatedPensionEntity();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("PNTOT", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberIDNumber);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            accumulatedPensionEntity.MemberNumber = oleDbDataReader["MEMBER_NUMBER"].ToString();
                            accumulatedPensionEntity.AccumulatedYrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_YEARS"]));
                            accumulatedPensionEntity.AccumulatedHrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_HOURS"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400.");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return accumulatedPensionEntity;
        }

        internal AccumulatedPensionEntity returnFSVBData(string memberIDNumber)
        {
            AccumulatedPensionEntity accumulatedPensionEntity = new AccumulatedPensionEntity();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("CTTOT", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberIDNumber);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            accumulatedPensionEntity.MemberNumber = oleDbDataReader["MEMBER_NUMBER"].ToString();
                            accumulatedPensionEntity.AccumulatedYrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_YEARS"]));
                            accumulatedPensionEntity.AccumulatedHrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_HOURS"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400.");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return accumulatedPensionEntity;
        }

        internal AccumulatedPensionEntity returnWelfareData(
          string memberIDNumber)
        {
            AccumulatedPensionEntity accumulatedPensionEntity = new AccumulatedPensionEntity();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("WFTOT", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberIDNumber);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            accumulatedPensionEntity.MemberNumber = oleDbDataReader["MEMBER_NUMBER"].ToString();
                            accumulatedPensionEntity.AccumulatedYrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_YEARS"]));
                            accumulatedPensionEntity.AccumulatedHrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_HOURS"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400.");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return accumulatedPensionEntity;
        }

        internal PensionCalculationsEntity getPension(
          string memberID,
          string retiredDate,
          string spouseOpt,
          string projectedYrs,
          string projectedHrs)
        {
            PensionCalculationsEntity calculationsEntity = new PensionCalculationsEntity();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("PNCAL2", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter1 = new OleDbParameter("AID", (object)memberID);
                    OleDbParameter oleDbParameter2 = new OleDbParameter("RETD", (object)retiredDate);
                    OleDbParameter oleDbParameter3 = new OleDbParameter("SPOP", (object)spouseOpt);
                    OleDbParameter oleDbParameter4 = new OleDbParameter("PROY", (object)projectedYrs);
                    OleDbParameter oleDbParameter5 = new OleDbParameter("PROH", (object)projectedHrs);
                    oleDbCommand.Parameters.Add(oleDbParameter1);
                    oleDbCommand.Parameters.Add(oleDbParameter2);
                    oleDbCommand.Parameters.Add(oleDbParameter3);
                    oleDbCommand.Parameters.Add(oleDbParameter4);
                    oleDbCommand.Parameters.Add(oleDbParameter5);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            calculationsEntity.MemberNum = oleDbDataReader["MEMBER_NUMBER"].ToString();
                            calculationsEntity.CreditedYears = (int?)new int?(Convert.ToInt32(oleDbDataReader["CREDITED_YEARS"].ToString()));
                            calculationsEntity.CreditedHours = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["CREDITED_HOURS"]));
                            calculationsEntity.ParticipantAge = (int?)new int?(Convert.ToInt32(oleDbDataReader["PARTICIPANT_AGE"]));
                            calculationsEntity.SpouseAge = (int?)new int?(Convert.ToInt32(oleDbDataReader["SPOUSE_AGE"]));
                            calculationsEntity.MonthlyPension_0 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MONTHLY_PENSION_00"]));
                            calculationsEntity.MonthlyPension_5 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MONTHLY_PENSION_05"]));
                            calculationsEntity.MonthlyPension_10 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MONTHLY_PENSION_10"]));
                            calculationsEntity.MonthlyPension_15 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MONTHLY_PENSION_15"]));
                            calculationsEntity.MonthlyPension_20 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MONTHLY_PENSION_20"]));
                            calculationsEntity.MonthlyPension_25 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MONTHLY_PENSION_25"]));
                            calculationsEntity.LumpSum_0 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["LUMP_SUM_00"]));
                            calculationsEntity.LumpSum_5 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["LUMP_SUM_05"]));
                            calculationsEntity.LumpSum_10 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["LUMP_SUM_10"]));
                            calculationsEntity.LumpSum_15 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["LUMP_SUM_15"]));
                            calculationsEntity.LumpSum_20 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["LUMP_SUM_20"]));
                            calculationsEntity.LumpSum_25 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["LUMP_SUM_25"]));
                            calculationsEntity.MemberPension_0 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MEMBER_PENSION_00"]));
                            calculationsEntity.MemberPension_5 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MEMBER_PENSION_05"]));
                            calculationsEntity.MemberPension_10 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MEMBER_PENSION_10"]));
                            calculationsEntity.MemberPension_15 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MEMBER_PENSION_15"]));
                            calculationsEntity.MemberPension_20 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MEMBER_PENSION_20"]));
                            calculationsEntity.MemberPension_25 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["MEMBER_PENSION_25"]));
                            calculationsEntity.SpousePension_0 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["SPOUSE_PENSION_00"]));
                            calculationsEntity.SpousePension_5 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["SPOUSE_PENSION_05"]));
                            calculationsEntity.SpousePension_10 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["SPOUSE_PENSION_10"]));
                            calculationsEntity.SpousePension_15 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["SPOUSE_PENSION_15"]));
                            calculationsEntity.SpousePension_20 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["SPOUSE_PENSION_20"]));
                            calculationsEntity.SpousePension_25 = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["SPOUSE_PENSION_25"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading pension data in AS400");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return calculationsEntity;
        }

        internal List<PensionHrsEntity> getHrs(string memberID)
        {
            List<PensionHrsEntity> pensionHrsEntityList = new List<PensionHrsEntity>();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("PNHRS", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberID);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                            pensionHrsEntityList.Add(new PensionHrsEntity()
                            {
                                MemberNum = oleDbDataReader["MEMBER_NUMBER"].ToString(),
                                CalendarYr = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["YEAR_WORKED"])),
                                Hours = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["HOURS_WORKED"])),
                                AccumulatedHrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_HOURS"])),
                                AccumulatedYrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_YEARS"])),
                                GratuitousType = oleDbDataReader["GRAT_HOURS"].ToString(),
                                Desc = oleDbDataReader["DESCRIPTION"].ToString()
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return pensionHrsEntityList;
        }

        internal List<PensionHrsEntity> getFSVBHrs(string memberID)
        {
            List<PensionHrsEntity> pensionHrsEntityList = new List<PensionHrsEntity>();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("CTHRS", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberID);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                            pensionHrsEntityList.Add(new PensionHrsEntity()
                            {
                                MemberNum = oleDbDataReader["MEMBER_NUMBER"].ToString(),
                                ContractYr = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["YEAR_WORKED"])),
                                Hours = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["HOURS_WORKED"])),
                                AccumulatedYrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_YEARS"])),
                                GratuitousType = oleDbDataReader["GRAT_HOURS"].ToString(),
                                Desc = oleDbDataReader["DESCRIPTION"].ToString()
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return pensionHrsEntityList;
        }

        internal List<PensionMemberDataEntity> getPensionMemberData()
        {
            List<PensionMemberDataEntity> memberDataEntityList = new List<PensionMemberDataEntity>();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("PNHEDO", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            PensionMemberDataEntity memberDataEntity1 = new PensionMemberDataEntity();
                            memberDataEntity1.MemberNumber = oleDbDataReader["MEMBER"].ToString();
                            memberDataEntity1.SSN = oleDbDataReader["P_SSN"].ToString();
                            memberDataEntity1.FullName = oleDbDataReader["P_FULL_NAME"].ToString();
                            memberDataEntity1.SupplementalName = oleDbDataReader["P_SUPP_NAME"].ToString();
                            memberDataEntity1.FirstName = oleDbDataReader["P_FIRST_NAME"].ToString();
                            memberDataEntity1.MiddleName = oleDbDataReader["P_MIDDLE_NAME"].ToString();
                            memberDataEntity1.LastName = oleDbDataReader["P_LAST_NAME"].ToString();
                            memberDataEntity1.Suffix = oleDbDataReader["P_SUFFIX"].ToString();
                            memberDataEntity1.Status = oleDbDataReader["P_STATUS"].ToString();
                            memberDataEntity1.Gender = oleDbDataReader["P_GENDER"].ToString();
                            PensionMemberDataEntity memberDataEntity2 = memberDataEntity1;
                            DateTime dateTime;
                            string str1;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["P_RETIRE"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["P_RETIRE"].ToString());
                                dateTime = dateTime.Date;
                                str1 = dateTime.ToShortDateString();
                            }
                            else
                                str1 = "";
                            memberDataEntity2.Retirement = str1;
                            PensionMemberDataEntity memberDataEntity3 = memberDataEntity1;
                            string str2;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["P_BIRTH"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["P_BIRTH"].ToString());
                                dateTime = dateTime.Date;
                                str2 = dateTime.ToShortDateString();
                            }
                            else
                                str2 = "";
                            memberDataEntity3.BirthDate = str2;
                            memberDataEntity1.BirthDateProven = oleDbDataReader["P_Birth_Proven"].ToString();
                            PensionMemberDataEntity memberDataEntity4 = memberDataEntity1;
                            string str3;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["P_DOD"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["P_DOD"].ToString());
                                dateTime = dateTime.Date;
                                str3 = dateTime.ToShortDateString();
                            }
                            else
                                str3 = "";
                            memberDataEntity4.Deceased = str3;
                            memberDataEntity1.StreetAddress1 = oleDbDataReader["P_ADD1"].ToString();
                            memberDataEntity1.StreetAddress2 = oleDbDataReader["P_ADD2"].ToString();
                            memberDataEntity1.City = oleDbDataReader["P_CITY"].ToString();
                            memberDataEntity1.State = oleDbDataReader["P_STATE"].ToString();
                            memberDataEntity1.ZipCode = oleDbDataReader["P_ZIP"].ToString();
                            memberDataEntity1.Class = oleDbDataReader["P_CLASS"].ToString();
                            memberDataEntity1.Local = oleDbDataReader["P_LOCAL"].ToString();
                            memberDataEntity1.LocalName = oleDbDataReader["P_LOCAL_NAME"].ToString();
                            PensionMemberDataEntity memberDataEntity5 = memberDataEntity1;
                            string str4;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["P_HIRE"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["P_HIRE"].ToString());
                                dateTime = dateTime.Date;
                                str4 = dateTime.ToShortDateString();
                            }
                            else
                                str4 = "";
                            memberDataEntity5.HireDate = str4;
                            memberDataEntity1.YearsOfService = (int?)new int?(this.returnZeroIfInvalidInt(oleDbDataReader["YEARS_OF_SERVICE"].ToString()));
                            memberDataEntity1.EligibilityYear1 = oleDbDataReader["Elg_Yr1"].ToString();
                            memberDataEntity1.EligibilityHours1 = (double?)new double?(this.returnZeroIfInvalidDouble(oleDbDataReader["Elg_Hrs1"].ToString()));
                            memberDataEntity1.EligibilityYear2 = oleDbDataReader["Elg_Yr2"].ToString();
                            memberDataEntity1.EligibilityHours2 = (double?)new double?(this.returnZeroIfInvalidDouble(oleDbDataReader["Elg_Hrs2"].ToString()));
                            memberDataEntity1.EligibilityYear3 = oleDbDataReader["Elg_Yr3"].ToString();
                            memberDataEntity1.EligibilityHours3 = (double?)new double?(this.returnZeroIfInvalidDouble(oleDbDataReader["Elg_Hrs3"].ToString()));
                            memberDataEntity1.Medicare = oleDbDataReader["P_MEDICARE"].ToString();
                            memberDataEntity1.MaritalStatus = oleDbDataReader["MARITAL_STATUS"].ToString();
                            PensionMemberDataEntity memberDataEntity6 = memberDataEntity1;
                            string str5;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["MARRIAGE"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["MARRIAGE"].ToString());
                                dateTime = dateTime.Date;
                                str5 = dateTime.ToShortDateString();
                            }
                            else
                                str5 = "";
                            memberDataEntity6.MarriageDate = str5;
                            PensionMemberDataEntity memberDataEntity7 = memberDataEntity1;
                            string str6;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["DIVORCE"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["DIVORCE"].ToString());
                                dateTime = dateTime.Date;
                                str6 = dateTime.ToShortDateString();
                            }
                            else
                                str6 = "";
                            memberDataEntity7.DivorceDate = str6;
                            memberDataEntity1.SpouseName = oleDbDataReader["S_NAME"].ToString();
                            memberDataEntityList.Add(memberDataEntity1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading pension member data in AS400");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return memberDataEntityList;
        }

        internal List<PensionMemberDependentEntity> getPensionMemberDependentData(
          string ssn)
        {
            List<PensionMemberDependentEntity> memberDependentEntityList = new List<PensionMemberDependentEntity>();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("PNDEPO", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("SSN", (object)ssn);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                        {
                            PensionMemberDependentEntity memberDependentEntity1 = new PensionMemberDependentEntity();
                            memberDependentEntity1.PrimarySSN = oleDbDataReader["P_SSN"].ToString();
                            memberDependentEntity1.Number = oleDbDataReader["DEPN"].ToString();
                            memberDependentEntity1.SSN = oleDbDataReader["D_SSN"].ToString();
                            memberDependentEntity1.FullName = oleDbDataReader["D_FULL_NAME"].ToString();
                            memberDependentEntity1.FirstName = oleDbDataReader["D_FIRST_NAME"].ToString();
                            memberDependentEntity1.MiddleName = oleDbDataReader["D_MIDDLE_NAME"].ToString();
                            memberDependentEntity1.LastName = oleDbDataReader["D_LAST_NAME"].ToString();
                            memberDependentEntity1.Suffix = oleDbDataReader["D_SUFFIX"].ToString();
                            PensionMemberDependentEntity memberDependentEntity2 = memberDependentEntity1;
                            DateTime dateTime;
                            string str1;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["D_BIRTH"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["D_BIRTH"].ToString());
                                dateTime = dateTime.Date;
                                str1 = dateTime.ToShortDateString();
                            }
                            else
                                str1 = "";
                            memberDependentEntity2.BirthDate = str1;
                            memberDependentEntity1.BirthDateProven = oleDbDataReader["D_Birth_Proven"].ToString();
                            memberDependentEntity1.Gender = oleDbDataReader["D_GENDER"].ToString();
                            memberDependentEntity1.Relation = oleDbDataReader["D_RELATION"].ToString();
                            memberDependentEntity1.Relationship = oleDbDataReader["D_RELATIONSHIP"].ToString();
                            memberDependentEntity1.Type = oleDbDataReader["D_TYPE"].ToString();
                            memberDependentEntity1.TypeDescription = oleDbDataReader["D_TDSC"].ToString();
                            PensionMemberDependentEntity memberDependentEntity3 = memberDependentEntity1;
                            string str2;
                            if (!string.IsNullOrWhiteSpace(oleDbDataReader["D_ELG_END"].ToString()))
                            {
                                dateTime = Convert.ToDateTime(oleDbDataReader["D_ELG_END"].ToString());
                                dateTime = dateTime.Date;
                                str2 = dateTime.ToShortDateString();
                            }
                            else
                                str2 = "";
                            memberDependentEntity3.EligibilityEnd = str2;
                            memberDependentEntityList.Add(memberDependentEntity1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading pension member dependent data in AS400");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return memberDependentEntityList;
        }

        internal List<PensionHrsEntity> getWelfareHrs(string memberID)
        {
            List<PensionHrsEntity> pensionHrsEntityList = new List<PensionHrsEntity>();
            try
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand("WFHRS", this.dbConnection))
                {
                    oleDbCommand.CommandType = CommandType.StoredProcedure;
                    OleDbParameter oleDbParameter = new OleDbParameter("AID", (object)memberID);
                    oleDbCommand.Parameters.Add(oleDbParameter);
                    using (OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader())
                    {
                        while (oleDbDataReader.Read())
                            pensionHrsEntityList.Add(new PensionHrsEntity()
                            {
                                MemberNum = oleDbDataReader["MEMBER_NUMBER"].ToString(),
                                ContractYr = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["YEAR_WORKED"])),
                                Hours = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["HOURS_WORKED"])),
                                AccumulatedYrs = (Decimal?)new Decimal?(Convert.ToDecimal(oleDbDataReader["ACCUM_YEARS"])),
                                GratuitousType = oleDbDataReader["GRAT_HOURS"].ToString(),
                                Desc = oleDbDataReader["DESCRIPTION"].ToString()
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Error loading member data in AS400");
                stringBuilder.AppendLine("Error: " + ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
            return pensionHrsEntityList;
        }

        private int returnZeroIfInvalidInt(string input)
        {
            int result = 0;
            return !int.TryParse(input, out result) ? 0 : Convert.ToInt32(input);
        }

        private double returnZeroIfInvalidDouble(string input)
        {
            double result = 0.0;
            return !double.TryParse(input, out result) ? 0.0 : Convert.ToDouble(input);
        }

        private void Connect()
        {
            this.dbConnection = new OleDbConnection(this.connectionString);
            this.dbConnection.Open();
        }

        public void Dispose()
        {
            this.Dispose(true);
            this.connectionString = (string)null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.dbConnection == null)
                return;
            if (this.dbConnection.State != ConnectionState.Closed)
                this.dbConnection.Close();
            this.dbConnection.Dispose();
        }
    }
}