using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class WorkScheduleBLL
    {
        internal static List<WorkScheduleHeaderEntity> GetAllSchedules()
        {
            return new AbsWorkScheduleHeaderRepository().GetAll();
        }

        internal static List<WorkScheduleHeaderEntity> GetSchedule()
        {
            return new AbsWorkScheduleHeaderRepository().GetMostCurrentTwoDays().OrderBy<WorkScheduleHeaderEntity, DateTime>((Func<WorkScheduleHeaderEntity, DateTime>)(b => (DateTime)b.ShiftTime)).ToList<WorkScheduleHeaderEntity>();
        }

        internal static void SaveSchedule(bool add, WorkScheduleHeaderEntity workScheduleHeader)
        {
            AbsWorkScheduleHeaderRepository headerRepository = new AbsWorkScheduleHeaderRepository();
            if (add)
                headerRepository.Add(workScheduleHeader);
            else
                headerRepository.Update(workScheduleHeader);
        }

        internal static void AddScheduleNote(NoteEntity note)
        {
            new ScheduleNoteRepository().Add(note);
        }

        internal static void UpdateScheduleNote(NoteEntity dto)
        {
            new ScheduleNoteRepository().Update(dto);
        }

        internal static List<NoteEntity> GetNotes(DateTime startDate, DateTime endDate)
        {
            return new ScheduleNoteRepository().GetByDate(startDate, endDate);
        }

        internal static void DeleteNote(NoteEntity dto)
        {
            new ScheduleNoteRepository().Delete(dto);
        }
    }
}