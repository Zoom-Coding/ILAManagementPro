using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class WorkHeaderBll
    {
        public static List<ShiftEntity> GetShifts()
        {
            return new AbsShiftTimeRepository().GetAll().OrderBy<ShiftEntity, string>((Func<ShiftEntity, string>)(s => s.MilitaryTime)).ToList<ShiftEntity>();
        }

        public static List<BerthEntity> GetBerths()
        {
            return new AbsBerthRepository().GetAll().OrderBy<BerthEntity, string>((Func<BerthEntity, string>)(b => b.ShortBerthName)).ToList<BerthEntity>();
        }

        public static List<VesselEntity> GetVessels()
        {
            return new absVesselRepository().GetAll().OrderBy<VesselEntity, string>((Func<VesselEntity, string>)(v => v.VesselName)).ToList<VesselEntity>();
        }

        public static List<CompanyEntity> GetCompanies()
        {
            return new CompanyRepository().GetAll().OrderBy<CompanyEntity, string>((Func<CompanyEntity, string>)(c => c.CompanyId)).ToList<CompanyEntity>();
        }

        public static WorkScheduleHeaderEntity RefreshSchedule(
          WorkScheduleHeaderEntity schedule)
        {
            return new AbsWorkScheduleHeaderRepository().GetByDateShiftCompanyShipBerth((DateTime)schedule.DateWorked, (DateTime)schedule.ShiftTime, Convert.ToInt32(schedule.Company.Id), Convert.ToInt32(schedule.Vessel.Id), Convert.ToInt32(schedule.Berth.Id));
        }

        public static List<absWorkHeaderEntity> GetHeadersBySchedule(
          string scheduleId)
        {
            return new AbsWorkHeaderRepository().GetByScheduleHeaderWithoutDetails(Convert.ToInt32(scheduleId));
        }

        public static void SaveSchedule(bool add, WorkScheduleHeaderEntity schedule)
        {
            AbsWorkScheduleHeaderRepository headerRepository = new AbsWorkScheduleHeaderRepository();
            if (add)
                headerRepository.Add(schedule);
            else
                headerRepository.Update(schedule);
        }

        public static void SaveHeader(bool add, absWorkHeaderEntity workHeader)
        {
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            if (add)
                headerRepository.Add(workHeader);
            else
                headerRepository.Update(workHeader);
        }

        public static void DeleteHeader(absWorkHeaderEntity header)
        {
            new AbsWorkHeaderRepository().Delete(header);
        }

        public static bool IsCheckedIn(List<absWorkHeaderEntity> list)
        {
            bool flag = false;
            if (list.Count == 0)
                return flag;
            List<absWorkHeaderEntity> workedWithoutDetails = new AbsWorkHeaderRepository().GetAllByDateWorkedWithoutDetails((DateTime)list[0].WorkScheduleHeader.DateWorked);
            foreach (absWorkHeaderEntity workHeaderEntity in list)
            {
                absWorkHeaderEntity l = workHeaderEntity;
                if (workedWithoutDetails.Where<absWorkHeaderEntity>((Func<absWorkHeaderEntity, bool>)(c =>
                {
                    if ((DateTime)c.WorkScheduleHeader.DateWorked == (DateTime)l.WorkScheduleHeader.DateWorked && c.Id == l.Id && c.CheckIn != null)
                        return c.CheckIn == ConfigurationBLL.CheckIn;
                    return false;
                })).FirstOrDefault<absWorkHeaderEntity>() != null)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static void DeleteJob(WorkScheduleHeaderEntity _schedule)
        {
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            AbsWorkDetailRepository detailRepository = new AbsWorkDetailRepository();
            foreach (absWorkHeaderEntity workHeader in (List<absWorkHeaderEntity>)_schedule.WorkHeaders)
            {
                foreach (absWorkDetailEntity entity in detailRepository.GetByWorkHeader(workHeader.Id))
                    detailRepository.Delete(entity);
                headerRepository.Delete(workHeader);
            }
            new AbsWorkScheduleHeaderRepository().Delete(_schedule);
        }

        private static WorkHeaderEntity BuildWorkHeader(
          absWorkHeaderEntity gang,
          string user)
        {
            return new WorkHeaderEntity()
            {
                DateWorked = (DateTime?)new DateTime?((DateTime)gang.WorkScheduleHeader.DateWorked),
                Header = gang.ReplaceHeader != null ? gang.ReplaceHeader.Id : gang.Header.Id,
                Company = gang.WorkScheduleHeader.Company,
                Berth = gang.WorkScheduleHeader.Berth.ShortBerthName,
                Vessel = gang.WorkScheduleHeader.Vessel.VesselName,
                CheckIn = ConfigurationBLL.CheckIn,
                CheckInTime = (DateTime?)new DateTime?(DateTime.Now),
                User = user
            };
        }

        private static List<WorkDetailEntity> BuildWorkDetails(
          absWorkHeaderEntity gang,
          string user)
        {
            List<WorkDetailEntity> workDetailEntityList = new List<WorkDetailEntity>();
            DateTime now = DateTime.Now;
            foreach (absWorkDetailEntity workDetail in (List<absWorkDetailEntity>)gang.WorkDetails)
            {
                WorkDetailEntity workDetailEntity = new WorkDetailEntity();
                workDetailEntity.DateOfWork = (DateTime?)new DateTime?((DateTime)gang.WorkScheduleHeader.DateWorked);
                workDetailEntity.Header = gang.ReplaceHeader != null ? gang.ReplaceHeader.Id : gang.Header.Id;
                if (((int?)workDetail.Seq).HasValue)
                    workDetailEntity.Seq = (int?)new int?(((int?)workDetail.Seq).Value);
                if (((Decimal?)workDetail.CardNo).HasValue)
                    workDetailEntity.CardNo = (Decimal?)new Decimal?(((Decimal?)workDetail.CardNo).Value);
                workDetailEntity.CheckIn = ConfigurationBLL.CheckIn;
                workDetailEntity.CheckInTime = (DateTime?)new DateTime?(now);
                workDetailEntity.User = user;
                workDetailEntityList.Add(workDetailEntity);
            }
            return workDetailEntityList;
        }
    }
}