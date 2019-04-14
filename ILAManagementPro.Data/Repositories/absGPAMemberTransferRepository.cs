using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using InsuredMaster = ILAManagementPro.Data.Data.InsuredMaster;

namespace ILAManagementPro.Data.Repositories
{
    public class absGPAMemberTransferRepository : RepositoryBase<absGPAMemberTransferDto>, IRepository<absGPAMemberTransferDto>
    {
        public List<absGPAMemberTransferDto> GetAll()
        {
            List<absGPAMemberTransferDto> memberTransferDtoList = new List<absGPAMemberTransferDto>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                List<InsuredMaster> list = ilaEntities.InsuredMasters.ToList<InsuredMaster>();
                DateTime dateTime = DateTime.Now.AddMinutes(-5.0);
                foreach (InsuredMaster dbRecord in list)
                {
                    DateTime? nullable = dbRecord.DateDeceased;
                    int num;
                    if (!nullable.HasValue)
                    {
                        nullable = dbRecord.DateRetired;
                        if (!nullable.HasValue)
                        {
                            bool? active = dbRecord.Active;
                            num = (!active.GetValueOrDefault() ? 0 : (active.HasValue ? 1 : 0)) == 0 ? 1 : 0;
                            goto label_7;
                        }
                    }
                    num = 1;
                    label_7:
                    if (num == 0)
                    {
                        nullable = dbRecord.UpdateDate;
                        if (nullable.HasValue)
                        {
                            nullable = dbRecord.UpdateDate;
                            if (nullable.Value > dateTime)
                                memberTransferDtoList.Add(this.BuildDto(dbRecord, 'U'));
                        }
                        else
                        {
                            nullable = dbRecord.AddedDate;
                            if (nullable.HasValue)
                            {
                                nullable = dbRecord.AddedDate;
                                if (nullable.Value > dateTime)
                                    memberTransferDtoList.Add(this.BuildDto(dbRecord, 'A'));
                            }
                        }
                    }
                }
            }
            return memberTransferDtoList;
        }

        public absGPAMemberTransferDto Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(absGPAMemberTransferDto id)
        {
            throw new NotImplementedException();
        }

        public void Add(absGPAMemberTransferDto id)
        {
            throw new NotImplementedException();
        }

        public void Update(absGPAMemberTransferDto id)
        {
            throw new NotImplementedException();
        }

        private absGPAMemberTransferDto BuildDto(InsuredMaster dbRecord, char action)
        {
            absGPAMemberTransferDto memberTransferDto = new absGPAMemberTransferDto();
            memberTransferDto.CardId = dbRecord.CardNo.ToString();
            memberTransferDto.FirstName = string.IsNullOrEmpty(dbRecord.FirstName) ? " " : dbRecord.FirstName;
            memberTransferDto.MiddleName = string.IsNullOrEmpty(dbRecord.MiddleName) ? " " : dbRecord.MiddleName;
            if (memberTransferDto.MiddleName == " ")
                memberTransferDto.MiddleName = string.IsNullOrEmpty(dbRecord.MI) ? " " : dbRecord.MI;
            memberTransferDto.LastName = string.IsNullOrEmpty(dbRecord.LastName) ? " " : dbRecord.LastName;
            memberTransferDto.DateOfBirth = !dbRecord.DateBirth.HasValue ? (DateTime?)new DateTime?(DateTime.MinValue) : (DateTime?)new DateTime?(dbRecord.DateBirth.Value.Date);
            memberTransferDto.Action = (char?)new char?(action);
            return memberTransferDto;
        }
    }
}