using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NoteEntity = ILAManagementPro.Models.NoteEntity;
using DbNote = ILAManagementPro.Data.Data.Note;


namespace ILAManagementPro.Data.Repositories
{
    public class MemberSuspendRepository : RepositoryBase<NoteEntity>, IRepository<NoteEntity>
    {
        public List<NoteEntity> GetAll()
        {
            List<NoteEntity> noteEntityList = new List<NoteEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (DbNote note in (IEnumerable<DbNote>)ilaEntities.Notes)
                    noteEntityList.Add(this.BuildEntity(note));
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
                    DbNote note = ilaEntities.Notes.Where<DbNote>((Expression<Func<DbNote, bool>>)(b => b.NoteId == ID)).FirstOrDefault<DbNote>();
                    if (note != null)
                        noteEntity = this.BuildEntity(note);
                }
            }
            return noteEntity;
        }

        public void Update(NoteEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(NoteEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                Decimal? cardNo = (Decimal?)entity.CardNo;
                if (!cardNo.HasValue)
                    return;
                InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(m => m.CardNo == entity.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                if (insuredMaster == null)
                    return;
                insuredMaster.DailySuspension = new bool?(true);
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Updating Insured Master Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][MemberSuspendRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
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
                    stringBuilder.AppendLine("Error Updating Insured Master Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][MemberSuspendRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
                DbNote entity1 = new DbNote();
                entity1.CardNo = (Decimal?)entity.CardNo;
                entity1.Content = entity.Content;
                if (!string.IsNullOrEmpty(entity.User))
                    entity1.AddedUser = entity.User;
                entity1.AddedDate = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.Notes.Add(entity1);
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error writing to Notes Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][MemberSuspendRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
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
                    stringBuilder.AppendLine("Error writing to Notes Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][MemberSuspendRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
                absDailySuspension entity2 = new absDailySuspension();
                absDailySuspension absDailySuspension = entity2;
                cardNo = (Decimal?)entity.CardNo;
                Decimal num = cardNo.Value;
                absDailySuspension.CardNumber = num;
                entity2.SuspensionExpireDateTime = ((DateTime?)entity.SuspensionExpire).Value;
                entity2.AddDateTime = new DateTime?(DateTime.Now);
                entity2.AddUser = entity.User;
                try
                {
                    ilaEntities.absDailySuspensions.Add(entity2);
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error writing to absDailySuspension Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][MemberSuspendRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
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
                    stringBuilder.AppendLine("Error writing to absDailySuspension Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][MemberSuspendRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        public void Delete(NoteEntity entity)
        {
            throw new NotImplementedException();
        }

        private NoteEntity BuildEntity(DbNote note)
        {
            NoteEntity noteEntity = new NoteEntity();
            noteEntity.Id = note.NoteId.ToString();
            if (note.CardNo.HasValue)
                noteEntity.CardNo = (Decimal?)new Decimal?(note.CardNo.Value);
            if (!string.IsNullOrWhiteSpace(note.Content))
                noteEntity.Content = note.Content.Trim();
            return noteEntity;
        }
    }
}