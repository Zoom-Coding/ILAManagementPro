using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class MaintenanceBll
    {
        public static List<WorkGangDescriptionEntity> GetWorkGangDescriptions()
        {
            return new AbsWorkGangDescriptionRepository().GetAll().OrderBy<WorkGangDescriptionEntity, string>((Func<WorkGangDescriptionEntity, string>)(g => g.WorkGangDescription)).ToList<WorkGangDescriptionEntity>();
        }

        public static void UpdateWorkGangDescription(WorkGangDescriptionEntity gang)
        {
            new AbsWorkGangDescriptionRepository().Update(gang);
        }

        public static List<HeaderEntity> GetAllAvailableMembers(bool header)
        {
            List<HeaderEntity> headerEntityList = new List<HeaderEntity>();
            return !header ? new HeaderRepository().GetAll().Where<HeaderEntity>((Func<HeaderEntity, bool>)(c =>
            {
                if (!c.DailySuspension)
                    return c.Active;
                return false;
            })).OrderBy<HeaderEntity, string>((Func<HeaderEntity, string>)(s => s.LastName)).ThenBy<HeaderEntity, string>((Func<HeaderEntity, string>)(s => s.FirstName)).ToList<HeaderEntity>() : new HeaderRepository().GetAll().Where<HeaderEntity>((Func<HeaderEntity, bool>)(c =>
            {
                if (c.HeaderMember && !c.DailySuspension)
                    return c.Active;
                return false;
            })).OrderBy<HeaderEntity, string>((Func<HeaderEntity, string>)(s => s.LastName)).ThenBy<HeaderEntity, string>((Func<HeaderEntity, string>)(s => s.FirstName)).ToList<HeaderEntity>();
        }

        public static BerthEntity AddNewBerth(BerthEntity berth)
        {
            AbsBerthRepository absBerthRepository = new AbsBerthRepository();
            absBerthRepository.Add(berth);
            return absBerthRepository.GetAll().Where<BerthEntity>((Func<BerthEntity, bool>)(s => s.ShortBerthName.ToUpper().Trim() == berth.ShortBerthName.ToUpper().Trim())).FirstOrDefault<BerthEntity>();
        }

        public static ShiftEntity AddNewShift(ShiftEntity shift)
        {
            AbsShiftTimeRepository shiftTimeRepository = new AbsShiftTimeRepository();
            shiftTimeRepository.Add(shift);
            return shiftTimeRepository.GetAll().Where<ShiftEntity>((Func<ShiftEntity, bool>)(s => s.MilitaryTime.ToUpper().Trim() == shift.MilitaryTime.ToUpper().Trim())).FirstOrDefault<ShiftEntity>();
        }

        public static VesselEntity AddNewVessel(VesselEntity vessel)
        {
            absVesselRepository vesselRepository = new absVesselRepository();
            vesselRepository.Add(vessel);
            return vesselRepository.GetAll().Where<VesselEntity>((Func<VesselEntity, bool>)(s => s.VesselName.ToUpper().Trim() == vessel.VesselName.ToUpper().Trim())).FirstOrDefault<VesselEntity>();
        }

        public static WorkGangDescriptionEntity AddNewWorkGang(
          WorkGangDescriptionEntity gang)
        {
            AbsWorkGangDescriptionRepository descriptionRepository = new AbsWorkGangDescriptionRepository();
            descriptionRepository.Add(gang);
            return descriptionRepository.GetAll().Where<WorkGangDescriptionEntity>((Func<WorkGangDescriptionEntity, bool>)(s => s.WorkGangDescription.ToUpper().Trim() == gang.WorkGangDescription.ToUpper().Trim())).FirstOrDefault<WorkGangDescriptionEntity>();
        }

        public static List<absWorkGangTemplateEntity> GetWorkGangTemplates()
        {
            return new absWorkGangTemplateRepository().GetAll();
        }

        public static void AddWorkGangTemplate(absWorkGangTemplateEntity dto)
        {
            new absWorkGangTemplateRepository().Add(dto);
        }

        public static void UpdateWorkGangTemplate(absWorkGangTemplateEntity dto)
        {
            new absWorkGangTemplateRepository().Update(dto);
        }
    }
}