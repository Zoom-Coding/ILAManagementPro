using ILAManagementPro.Data.Data;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Repositories
{
    public class absGPACredentialsRepository
    {
        public List<absGPACredentialsEntity> Get()
        {
            throw new NotImplementedException();
        }

        public absGPACredentialsEntity Get(string Id)
        {
            throw new NotImplementedException();
        }

        public string Add(absGPACredentialsEntity dto)
        {
            return "";
        }

        public string Update(absGPACredentialsEntity dto)
        {
            return "";
        }

        public string Delete(absGPACredentialsEntity dto)
        {
            return "";
        }

        public string Delete(string Id)
        {
            return "";
        }

        private absGPACredentialsEntity BuildEntity(absGPACredential creds)
        {
            absGPACredentialsEntity credentialsEntity = new absGPACredentialsEntity();
            credentialsEntity.CardId = creds.CARD_ID.ToString();
            if (creds.FIRST_NAME != null)
                credentialsEntity.FirstName = creds.FIRST_NAME;
            if (creds.MIDDLE_INIT != null)
                credentialsEntity.MiddleName = creds.MIDDLE_INIT;
            if (creds.LAST_NAME != null)
                credentialsEntity.LastName = creds.LAST_NAME;
            if (creds.DOB.HasValue)
                credentialsEntity.DOB = (DateTime?)new DateTime?(creds.DOB.Value);
            if (creds.SSN.HasValue)
                credentialsEntity.SSNo = creds.SSN.ToString();
            if (creds.ILACardNumber.HasValue)
                credentialsEntity.ILACardNumber = creds.ILACardNumber.ToString();
            return credentialsEntity;
        }
    }
}