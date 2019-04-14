using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NoteEntity = ILAManagementPro.Models.NoteEntity;

namespace ILAManagementPro.Data.Repositories
{
    public class ScheduleNoteRepository : RepositoryBase<NoteEntity>, IRepository<NoteEntity>
    {
        public List<NoteEntity> GetAll()
        {
            List<NoteEntity> noteEntityList = new List<NoteEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absScheduleNote absScheduleNote in (IEnumerable<absScheduleNote>)ilaEntities.absScheduleNotes)
                    noteEntityList.Add(this.BuildEntity(absScheduleNote));
            }
            return noteEntityList;
        }

        public NoteEntity Get(string id)
        {
            NoteEntity noteEntity = (NoteEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absScheduleNote note = ilaEntities.absScheduleNotes.Where<absScheduleNote>((Expression<Func<absScheduleNote, bool>>)(b => b.Id == ID)).FirstOrDefault<absScheduleNote>();
                    if (note != null)
                        noteEntity = this.BuildEntity(note);
                }
            }
            return noteEntity;
        }

        public List<NoteEntity> GetByDate(DateTime StartDate, DateTime EndDate)
        {
            List<NoteEntity> noteEntityList = new List<NoteEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absScheduleNote> absScheduleNotes = ilaEntities.absScheduleNotes;
                Expression<Func<absScheduleNote, bool>> predicate = (Expression<Func<absScheduleNote, bool>>)(b => b.BeginDate >= StartDate && b.BeginDate <= EndDate);
                foreach (absScheduleNote note in (IEnumerable<absScheduleNote>)absScheduleNotes.Where<absScheduleNote>(predicate))
                    noteEntityList.Add(this.BuildEntity(note));
            }
            return noteEntityList;
        }

        public void Update(NoteEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absScheduleNote Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][ScheduleNoteRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absScheduleNote absScheduleNote1 = ilaEntities.absScheduleNotes.Where<absScheduleNote>((Expression<Func<absScheduleNote, bool>>)(b => b.Id == ID)).FirstOrDefault<absScheduleNote>();
                if (absScheduleNote1 != null)
                {
                    absScheduleNote1.Note = entity.Content.Trim();
                    DateTime? nullable;
                    if (((DateTime?)entity.ScheduleBeginDate).HasValue)
                    {
                        absScheduleNote absScheduleNote2 = absScheduleNote1;
                        nullable = (DateTime?)entity.ScheduleBeginDate;
                        DateTime dateTime = nullable.Value;
                        absScheduleNote2.BeginDate = dateTime;
                    }
                    nullable = (DateTime?)entity.ScheduleEndDate;
                    if (nullable.HasValue)
                    {
                        absScheduleNote absScheduleNote2 = absScheduleNote1;
                        nullable = (DateTime?)entity.ScheduleEndDate;
                        DateTime dateTime = nullable.Value;
                        absScheduleNote2.EndDate = dateTime;
                    }
                    if (!string.IsNullOrEmpty(entity.User))
                        absScheduleNote1.UpdateUser = entity.User.ToString();
                    absScheduleNote1.UpdateDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                        {
                            stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                            foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                            {
                                stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                                stringBuilder.AppendLine("Message: ");
                                stringBuilder.AppendLine(validationError.ErrorMessage);
                            }
                            stringBuilder.AppendLine();
                        }
                        throw new DbUnexpectedValidationException(stringBuilder.ToString());
                    }
                    catch (Exception ex)
                    {
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
            }
        }

        public void Add(NoteEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding record to absScheduleNote Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][ScheduleNoteRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absScheduleNote entity1 = new absScheduleNote();
                entity1.Note = entity.Content.Trim();
                if (((DateTime?)entity.ScheduleBeginDate).HasValue)
                    entity1.BeginDate = ((DateTime?)entity.ScheduleBeginDate).Value;
                if (((DateTime?)entity.ScheduleEndDate).HasValue)
                    entity1.EndDate = ((DateTime?)entity.ScheduleEndDate).Value;
                if (!string.IsNullOrEmpty(entity.User))
                    entity1.AddUser = entity.User.ToString();
                entity1.AddDateTime = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.absScheduleNotes.Add(entity1);
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                    {
                        stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                        foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                        {
                            stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                            stringBuilder.AppendLine("Message: ");
                            stringBuilder.AppendLine(validationError.ErrorMessage);
                        }
                        stringBuilder.AppendLine();
                    }
                    throw new DbUnexpectedValidationException(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        public void Delete(NoteEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting record from Note Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][ScheduleNoteRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absScheduleNote entity1 = ilaEntities.absScheduleNotes.Where<absScheduleNote>((Expression<Func<absScheduleNote, bool>>)(b => b.Id == ID)).FirstOrDefault<absScheduleNote>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absScheduleNotes.Remove(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                        {
                            stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                            foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                            {
                                stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                                stringBuilder.AppendLine("Message: ");
                                stringBuilder.AppendLine(validationError.ErrorMessage);
                            }
                            stringBuilder.AppendLine();
                        }
                        throw new DbUnexpectedValidationException(stringBuilder.ToString());
                    }
                    catch (Exception ex)
                    {
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
            }
        }

        private NoteEntity BuildEntity(absScheduleNote note)
        {
            NoteEntity noteEntity = new NoteEntity();
            noteEntity.Id = note.Id.ToString();
            if (!string.IsNullOrEmpty(note.Note))
                noteEntity.Content = note.Note.Trim();
            noteEntity.ScheduleBeginDate = (DateTime?)new DateTime?(note.BeginDate);
            noteEntity.ScheduleEndDate = (DateTime?)new DateTime?(note.EndDate);
            return noteEntity;
        }
    }
}