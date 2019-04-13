using Newtonsoft.Json;
using System.IO;

namespace ILAManagementPro.Models
{
    public abstract class EntityBase
    {
        public string ToJson()
        {
            StringWriter stringWriter = new StringWriter();
            new JsonSerializer().Serialize((JsonWriter)new JsonTextWriter((TextWriter)stringWriter), (object)this);
            return stringWriter.ToString();
        }

        public string Id { get; set; }

        public string Description { get; set; }
    }
}