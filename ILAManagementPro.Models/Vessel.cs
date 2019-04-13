namespace ILAManagementPro.Models
{
    public class Vessel : EntityBase
    {
        public Vessel()
        {
        }

        public Vessel(Vessel old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.VesselName = old.VesselName;
            this.LLoydsNumber = old.LLoydsNumber;
        }

        public override string ToString()
        {
            return this.VesselName;
        }

        public string VesselName { get; set; }

        public string LLoydsNumber { get; set; }

        public string UpdateAdd { get; set; }

        public string User { get; set; }
    }
}