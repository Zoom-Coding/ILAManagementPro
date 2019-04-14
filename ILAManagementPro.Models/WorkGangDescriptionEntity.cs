namespace ILAManagementPro.Models
{
    public class WorkGangDescriptionEntity : EntityBase
    {
        public WorkGangDescriptionEntity()
        {
        }

        public WorkGangDescriptionEntity(WorkGangDescriptionEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.WGDescription = old.WGDescription;
            this.DriverGang = old.DriverGang;
        }

        public override string ToString()
        {
            return this.WGDescription;
        }

        public string WGDescription { get; set; }

        public bool DriverGang { get; set; }

        public string User { get; set; }
    }
}