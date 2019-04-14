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

namespace ILAManagementPro.Data.Repositories
{
    public class EmergencyContactRepository : RepositoryBase<EmergencyContactEntity>, IRepository<EmergencyContactEntity>
    {
        public List<EmergencyContactEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmergencyContactEntity Get(string id)
        {
            EmergencyContactEntity emergencyContactEntity = new EmergencyContactEntity();
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    IMEmergencyContact detail = ilaEntities.IMEmergencyContacts.Where<IMEmergencyContact>((Expression<Func<IMEmergencyContact, bool>>)(h => h.id == ID)).FirstOrDefault<IMEmergencyContact>();
                    if (detail != null)
                        emergencyContactEntity = this.BuildEntity(detail);
                }
            }
            return emergencyContactEntity;
        }

        public List<EmergencyContactEntity> GetByCard(string id)
        {
            List<EmergencyContactEntity> emergencyContactEntityList = new List<EmergencyContactEntity>();
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    DbSet<IMEmergencyContact> emergencyContacts = ilaEntities.IMEmergencyContacts;
                    Expression<Func<IMEmergencyContact, bool>> predicate = (Expression<Func<IMEmergencyContact, bool>>)(h => h.CardNo == (Decimal)ID);
                    foreach (IMEmergencyContact detail in (IEnumerable<IMEmergencyContact>)emergencyContacts.Where<IMEmergencyContact>(predicate))
                        emergencyContactEntityList.Add(this.BuildEntity(detail));
                }
            }
            return emergencyContactEntityList;
        }

        public void Add(EmergencyContactEntity dto)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding to EmergencyContact Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][EmergencyContactRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                IMEmergencyContact entity = new IMEmergencyContact();
                Decimal cardNo = entity.CardNo;
                entity.CardNo = (Decimal)dto.CardNo;
                entity.ContactName = dto.ContactName;
                entity.Phone1 = dto.Phone1;
                entity.Phone2 = dto.Phone2;
                entity.Relationship = dto.Relationship;
                entity.AddUser = dto.AddUser;
                entity.AddDateTime = (DateTime?)dto.AddDateTime;
                entity.UpdateUser = dto.UpdateUser;
                entity.UpdateDateTime = (DateTime?)dto.UpdateDateTime;
                try
                {
                    ilaEntities.IMEmergencyContacts.Add(entity);
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

        public void Update(EmergencyContactEntity dto)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding to EmergencyContact Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][EmergencyContactRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                IMEmergencyContact emergencyContact = ilaEntities.IMEmergencyContacts.Where<IMEmergencyContact>((Expression<Func<IMEmergencyContact, bool>>)(x => x.id == dto.id)).FirstOrDefault<IMEmergencyContact>();
                int id = emergencyContact.id;
                emergencyContact.ContactName = dto.ContactName;
                emergencyContact.Phone1 = dto.Phone1;
                emergencyContact.Phone2 = dto.Phone2;
                emergencyContact.Relationship = dto.Relationship;
                emergencyContact.AddUser = dto.AddUser;
                emergencyContact.AddDateTime = (DateTime?)dto.AddDateTime;
                emergencyContact.UpdateUser = dto.UpdateUser;
                emergencyContact.UpdateDateTime = (DateTime?)dto.UpdateDateTime;
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

        public void Delete(EmergencyContactEntity dto)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding to EmergencyContact Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][EmergencyContactRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                IMEmergencyContact entity = ilaEntities.IMEmergencyContacts.Where<IMEmergencyContact>((Expression<Func<IMEmergencyContact, bool>>)(x => x.id == dto.id)).FirstOrDefault<IMEmergencyContact>();
                if (entity == null)
                    return;
                try
                {
                    ilaEntities.IMEmergencyContacts.Remove(entity);
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

        private EmergencyContactEntity BuildEntity(IMEmergencyContact detail)
        {
            return new EmergencyContactEntity()
            {
                id = detail.id,
                CardNo = (Decimal)detail.CardNo,
                ContactName = detail.ContactName,
                Phone1 = detail.Phone1,
                Phone2 = detail.Phone2,
                Relationship = detail.Relationship,
                AddUser = detail.AddUser,
                AddDateTime = (DateTime?)detail.AddDateTime,
                UpdateUser = detail.UpdateUser,
                UpdateDateTime = (DateTime?)detail.UpdateDateTime
            };
        }
    }
}