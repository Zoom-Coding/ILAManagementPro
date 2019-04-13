namespace ILAManagementPro.Models
{
    public class WorkGangDescription : EntityBase
    {
        public WorkGangDescription()
        {
        }

        public WorkGangDescription(WorkGangDescription old)
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