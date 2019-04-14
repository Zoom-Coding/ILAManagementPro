using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ILAManagementPro.Data.Repositories
{
    public class absVesselRepository : RepositoryBase<VesselEntity>, IRepository<VesselEntity>
    {
        public List<VesselEntity> GetAll()
        {
            List<VesselEntity> source = new List<VesselEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absVessel absVessel in (IEnumerable<absVessel>)ilaEntities.absVessels)
                    source.Add(this.BuildEntity(absVessel));
            }
            return source.OrderBy<VesselEntity, string>((Func<VesselEntity, string>)(b => b.VesselName)).ToList<VesselEntity>();
        }

        public VesselEntity Get(string id)
        {
            VesselEntity vesselEntity = (VesselEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absVessel vessel = ilaEntities.absVessels.Where<absVessel>((Expression<Func<absVessel, bool>>)(b => b.id == ID)).FirstOrDefault<absVessel>();
                    if (vessel != null)
                        vesselEntity = this.BuildEntity(vessel);
                }
            }
            return vesselEntity;
        }

        public void Update(VesselEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absVessel Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absVesselRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absVessel absVessel = ilaEntities.absVessels.Where<absVessel>((Expression<Func<absVessel, bool>>)(b => b.id == ID)).FirstOrDefault<absVessel>();
                if (absVessel != null)
                {
                    absVessel.VesselName = entity.VesselName.ToUpper().Trim();
                    absVessel.LLoydsId = string.IsNullOrEmpty(entity.LLoydsNumber) ? (string)null : entity.LLoydsNumber.Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        absVessel.UpdateUser = entity.User.Trim();
                    absVessel.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void Add(VesselEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absVessel absVessel = ilaEntities.absVessels.Where<absVessel>((Expression<Func<absVessel, bool>>)(b => b.VesselName.ToUpper().Trim() == entity.VesselName.ToUpper().Trim())).FirstOrDefault<absVessel>();
                if (absVessel == null)
                {
                    absVessel entity1 = new absVessel();
                    entity1.VesselName = entity.VesselName.ToUpper().Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.Trim();
                    entity1.LLoydsId = string.IsNullOrEmpty(entity.LLoydsNumber) ? (string)null : entity.LLoydsNumber.Trim();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absVessels.Add(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Adding record " + entity.VesselName.Trim() + " to absVessel Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absVesselRepository.cs][Add]");
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
                        stringBuilder.AppendLine("Error Adding record " + entity.VesselName.Trim() + " to absVessel Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absVesselRepository.cs][Add]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
                else
                {
                    flag = true;
                    num = absVessel.id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(VesselEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting " + entity.VesselName.Trim() + " from absVessel Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absVesselRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absVessel entity1 = ilaEntities.absVessels.Where<absVessel>((Expression<Func<absVessel, bool>>)(b => b.id == ID)).FirstOrDefault<absVessel>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absVessels.Remove(entity1);
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

        private VesselEntity BuildEntity(absVessel vessel)
        {
            VesselEntity vesselEntity = new VesselEntity();
            vesselEntity.Id = vessel.id.ToString();
            vesselEntity.VesselName = vessel.VesselName.Trim();
            if (!string.IsNullOrEmpty(vessel.LLoydsId))
                vesselEntity.LLoydsNumber = vessel.LLoydsId.Trim();
            return vesselEntity;
        }
    }
}