using ILAManagementPro.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Security.Principal;
using System.Threading;

namespace ILAManagementPro.Data.Repositories
{
    public class RepositoryBase<TEntity> where TEntity : EntityBase
    { 
        protected readonly IIdentity Identity;
        protected readonly string ConnectionString;

        protected RepositoryBase()
        {
            this.ConnectionString = ConfigurationManager.AppSettings[nameof(ConnectionString)];
            this.Identity = Thread.CurrentPrincipal.Identity;
        }

        public static TEntity FromJson(string json)
        {
            return (TEntity)new JsonSerializer().Deserialize<TEntity>((JsonReader)new JsonTextReader((TextReader)new StringReader(json)));
        }
    }
}