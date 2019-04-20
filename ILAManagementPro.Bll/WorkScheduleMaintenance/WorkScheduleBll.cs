using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class WorkScheduleBLL
    {
        public static List<WorkScheduleHeaderEntity> GetAllSchedules()
        {
            return new AbsWorkScheduleHeaderRepository().GetAll();
        }

        public static List<WorkScheduleHeaderEntity> GetSchedule()
        {
            return new AbsWorkScheduleHeaderRepository().GetMostCurrentTwoDays().OrderBy<WorkScheduleHeaderEntity, DateTime>((Func<WorkScheduleHeaderEntity, DateTime>)(b => (DateTime)b.ShiftTime)).ToList<WorkScheduleHeaderEntity>();
        }

        public static void SaveSchedule(bool add, WorkScheduleHeaderEntity workScheduleHeader)
        {
            AbsWorkScheduleHeaderRepository headerRepository = new AbsWorkScheduleHeaderRepository();
            if (add)
                headerRepository.Add(workScheduleHeader);
            else
                headerRepository.Update(workScheduleHeader);
        }

        public static void AddScheduleNote(NoteEntity note)
        {
            new ScheduleNoteRepository().Add(note);
        }

        public static void UpdateScheduleNote(NoteEntity dto)
        {
            new ScheduleNoteRepository().Update(dto);
        }

        public static List<NoteEntity> GetNotes(DateTime startDate, DateTime endDate)
        {
            return new ScheduleNoteRepository().GetByDate(startDate, endDate);
        }

        public static void DeleteNote(NoteEntity dto)
        {
            new ScheduleNoteRepository().Delete(dto);
        }
    }
}