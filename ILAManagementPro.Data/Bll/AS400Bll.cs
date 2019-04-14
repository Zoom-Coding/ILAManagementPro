using ILAManagementPro.Data.Data;
using ILAManagementPro.Models;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Bll
{
    public class AS400Bll
    {
        public static WelfareMemberEntity returnMemberData(string memberID)
        {
            WelfareMemberEntity welfareMemberEntity = new WelfareMemberEntity();
            using (AS400Data as400Data = new AS400Data())
                welfareMemberEntity = as400Data.returnMemberData(memberID);
            return welfareMemberEntity;
        }

        public static AccumulatedPensionEntity returnMemberAccumulated(
          string memberID)
        {
            AccumulatedPensionEntity accumulatedPensionEntity = new AccumulatedPensionEntity();
            using (AS400Data as400Data = new AS400Data())
                accumulatedPensionEntity = as400Data.returnMemberAccumulated(memberID);
            return accumulatedPensionEntity;
        }

        public static AccumulatedPensionEntity returnFSVBData(string memberID)
        {
            AccumulatedPensionEntity accumulatedPensionEntity = new AccumulatedPensionEntity();
            using (AS400Data as400Data = new AS400Data())
                accumulatedPensionEntity = as400Data.returnFSVBData(memberID);
            return accumulatedPensionEntity;
        }

        public static AccumulatedPensionEntity returnWelfareData(string memberID)
        {
            AccumulatedPensionEntity accumulatedPensionEntity = new AccumulatedPensionEntity();
            using (AS400Data as400Data = new AS400Data())
                accumulatedPensionEntity = as400Data.returnWelfareData(memberID);
            return accumulatedPensionEntity;
        }

        public static PensionCalculationsEntity getPension(
          string memberID,
          string retiredDate,
          string spouseOpt,
          string projectedYrs,
          string projectedHrs)
        {
            PensionCalculationsEntity calculationsEntity = new PensionCalculationsEntity();
            using (AS400Data as400Data = new AS400Data())
                calculationsEntity = as400Data.getPension(memberID, retiredDate, spouseOpt, projectedYrs, projectedHrs);
            return calculationsEntity;
        }

        public static List<PensionHrsEntity> getHrs(string memberID)
        {
            List<PensionHrsEntity> pensionHrsEntityList = new List<PensionHrsEntity>();
            using (AS400Data as400Data = new AS400Data())
                pensionHrsEntityList = as400Data.getHrs(memberID);
            return pensionHrsEntityList;
        }

        public static List<PensionHrsEntity> getFSVBHrs(string memberID)
        {
            List<PensionHrsEntity> pensionHrsEntityList = new List<PensionHrsEntity>();
            using (AS400Data as400Data = new AS400Data())
                pensionHrsEntityList = as400Data.getFSVBHrs(memberID);
            return pensionHrsEntityList;
        }

        public static List<PensionMemberDataEntity> getPensionMemberData()
        {
            List<PensionMemberDataEntity> memberDataEntityList = new List<PensionMemberDataEntity>();
            using (AS400Data as400Data = new AS400Data())
                memberDataEntityList = as400Data.getPensionMemberData();
            return memberDataEntityList;
        }

        public static List<PensionMemberDependentEntity> getPensionMemberDependentData(
          string ssn)
        {
            List<PensionMemberDependentEntity> memberDependentEntityList = new List<PensionMemberDependentEntity>();
            using (AS400Data as400Data = new AS400Data())
                memberDependentEntityList = as400Data.getPensionMemberDependentData(ssn);
            return memberDependentEntityList;
        }

        public static List<PensionHrsEntity> getWelfareHrs(string memberID)
        {
            List<PensionHrsEntity> pensionHrsEntityList = new List<PensionHrsEntity>();
            using (AS400Data as400Data = new AS400Data())
                pensionHrsEntityList = as400Data.getWelfareHrs(memberID);
            return pensionHrsEntityList;
        }
    }
}