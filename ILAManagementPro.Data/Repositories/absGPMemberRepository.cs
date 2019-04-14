using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using InsuredMaster = ILAManagementPro.Data.Data.InsuredMaster;

namespace ILAManagementPro.Data.Repositories
{
    public class absGPMemberRepository : RepositoryBase<absGPMemberEntity>, IRepository<absGPMemberEntity>
    {
        public List<absGPMemberEntity> GetAll()
        {
            List<absGPMemberEntity> absGpMemberEntityList = new List<absGPMemberEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                List<InsuredMaster> list = ilaEntities.InsuredMasters.ToList<InsuredMaster>();
                DateTime dateTime = DateTime.Now.AddMinutes(-10.0);
                foreach (InsuredMaster member in list)
                {
                    DateTime? nullable = member.DateDeceased;
                    int num;
                    if (!nullable.HasValue)
                    {
                        nullable = member.DateRetired;
                        num = nullable.HasValue ? 1 : 0;
                    }
                    else
                        num = 1;
                    if (num == 0)
                    {
                        nullable = member.UpdateDate;
                        if (nullable.HasValue)
                        {
                            nullable = member.UpdateDate;
                            if (nullable.Value > dateTime)
                                absGpMemberEntityList.Add(this.BuildEntity(member, 'U'));
                        }
                        else
                        {
                            nullable = member.AddedDate;
                            if (nullable.HasValue)
                            {
                                nullable = member.AddedDate;
                                if (nullable.Value > dateTime)
                                    absGpMemberEntityList.Add(this.BuildEntity(member, 'A'));
                            }
                        }
                    }
                }
            }
            return absGpMemberEntityList;
        }

        public absGPMemberEntity Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(absGPMemberEntity id)
        {
            throw new NotImplementedException();
        }

        public void Add(absGPMemberEntity id)
        {
            throw new NotImplementedException();
        }

        public void Update(absGPMemberEntity id)
        {
            throw new NotImplementedException();
        }

        private absGPMemberEntity BuildEntity(InsuredMaster member, char letter)
        {
            absGPMemberEntity absGpMemberEntity1 = new absGPMemberEntity();
            absGpMemberEntity1.CardID = member.CardNo.ToString();
            absGpMemberEntity1.MFirstName = string.IsNullOrEmpty(member.FirstName) ? " " : member.FirstName;
            absGpMemberEntity1.MLastName = string.IsNullOrEmpty(member.LastName) ? " " : member.LastName;
            absGpMemberEntity1.Address1 = string.IsNullOrEmpty(member.Address) ? " " : member.Address;
            absGpMemberEntity1.City = string.IsNullOrEmpty(member.City) ? " " : member.City;
            absGpMemberEntity1.State = string.IsNullOrEmpty(member.ST) ? " " : member.ST;
            absGpMemberEntity1.Zipcode = string.IsNullOrEmpty(member.Zip) ? " " : member.Zip;
            absGpMemberEntity1.Phone = string.IsNullOrEmpty(member.AreaPhone) ? " " : member.AreaPhone;
            absGpMemberEntity1.Status = letter;
            absGPMemberEntity absGpMemberEntity2 = absGpMemberEntity1;
            bool? active = member.Active;
            int num;
            if (!active.HasValue)
            {
                num = 0;
            }
            else
            {
                active = member.Active;
                num = active.Value ? 1 : 0;
            }
            absGpMemberEntity2.Active = num != 0;
            absGpMemberEntity1.LastFour = member.SSNo.Substring(member.SSNo.Length - 4, 4);
            return absGpMemberEntity1;
        }
    }
}