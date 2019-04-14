using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class MaintenanceBll
    {
        internal static List<WorkGangDescriptionEntity> GetWorkGangDescriptions()
        {
            return new AbsWorkGangDescriptionRepository().GetAll().OrderBy<WorkGangDescriptionEntity, string>((Func<WorkGangDescriptionEntity, string>)(g => g.WorkGangDescription)).ToList<WorkGangDescriptionEntity>();
        }

        internal static void UpdateWorkGangDescription(WorkGangDescriptionEntity gang)
        {
            new AbsWorkGangDescriptionRepository().Update(gang);
        }

        internal static List<HeaderEntity> GetAllAvailableMembers(bool header)
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

        internal static BerthEntity AddNewBerth(BerthEntity berth)
        {
            AbsBerthRepository absBerthRepository = new AbsBerthRepository();
            absBerthRepository.Add(berth);
            return absBerthRepository.GetAll().Where<BerthEntity>((Func<BerthEntity, bool>)(s => s.ShortBerthName.ToUpper().Trim() == berth.ShortBerthName.ToUpper().Trim())).FirstOrDefault<BerthEntity>();
        }

        internal static ShiftEntity AddNewShift(ShiftEntity shift)
        {
            AbsShiftTimeRepository shiftTimeRepository = new AbsShiftTimeRepository();
            shiftTimeRepository.Add(shift);
            return shiftTimeRepository.GetAll().Where<ShiftEntity>((Func<ShiftEntity, bool>)(s => s.MilitaryTime.ToUpper().Trim() == shift.MilitaryTime.ToUpper().Trim())).FirstOrDefault<ShiftEntity>();
        }

        internal static VesselEntity AddNewVessel(VesselEntity vessel)
        {
            absVesselRepository vesselRepository = new absVesselRepository();
            vesselRepository.Add(vessel);
            return vesselRepository.GetAll().Where<VesselEntity>((Func<VesselEntity, bool>)(s => s.VesselName.ToUpper().Trim() == vessel.VesselName.ToUpper().Trim())).FirstOrDefault<VesselEntity>();
        }

        internal static WorkGangDescriptionEntity AddNewWorkGang(
          WorkGangDescriptionEntity gang)
        {
            AbsWorkGangDescriptionRepository descriptionRepository = new AbsWorkGangDescriptionRepository();
            descriptionRepository.Add(gang);
            return descriptionRepository.GetAll().Where<WorkGangDescriptionEntity>((Func<WorkGangDescriptionEntity, bool>)(s => s.WorkGangDescription.ToUpper().Trim() == gang.WorkGangDescription.ToUpper().Trim())).FirstOrDefault<WorkGangDescriptionEntity>();
        }

        internal static List<absWorkGangTemplateEntity> GetWorkGangTemplates()
        {
            return new absWorkGangTemplateRepository().GetAll();
        }

        internal static void AddWorkGangTemplate(absWorkGangTemplateEntity dto)
        {
            new absWorkGangTemplateRepository().Add(dto);
        }

        internal static void UpdateWorkGangTemplate(absWorkGangTemplateEntity dto)
        {
            new absWorkGangTemplateRepository().Update(dto);
        }
    }
}