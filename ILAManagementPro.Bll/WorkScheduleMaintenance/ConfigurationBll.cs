using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class ConfigurationBLL
    {
        private static readonly string _selectOption = "selectOptionKey";
        private static readonly string _addOption = "addOptionKey";
        private static readonly string _domainString = "domainKey";
        private static readonly string _suspendMessage1 = "suspendMessage1Key";
        private static readonly string _badgeLengthKey = "badgeLengthKey";
        private static readonly string _checkIn = "I";
        private static readonly string _checkOut = "O";
        private static readonly string _programName = "Work Schedule Maintenance";
        private static readonly string _setBackPhrase = "Set Back ";

        public static string GetConfigValue(string key)
        {
            string str = "";
            ConfigurationEntity configurationEntity = new AbsConfigurationRepository().Get(key);
            if (configurationEntity != null)
                str = configurationEntity.PropertyValue;
            return str;
        }

        public static string SelectOption
        {
            get
            {
                return ConfigurationBLL._selectOption;
            }
        }

        public static string AddOption
        {
            get
            {
                return ConfigurationBLL._addOption;
            }
        }

        public static string DomainString
        {
            get
            {
                return ConfigurationBLL._domainString;
            }
        }

        public static string SuspendMessage1
        {
            get
            {
                return ConfigurationBLL._suspendMessage1;
            }
        }

        public static string BadgeLengthKey
        {
            get
            {
                return ConfigurationBLL._badgeLengthKey;
            }
        }

        public static string CheckIn
        {
            get
            {
                return ConfigurationBLL._checkIn;
            }
        }

        public static string CheckOut
        {
            get
            {
                return ConfigurationBLL._checkOut;
            }
        }

        public static string ProgramName
        {
            get
            {
                return ConfigurationBLL._programName;
            }
        }

        public static string SetBackPhrase
        {
            get
            {
                return ConfigurationBLL._setBackPhrase;
            }
        }

        public enum AddNewType
        {
            Berth,
            Shift,
            WorkGang,
            Vessel,
        }
    }
}