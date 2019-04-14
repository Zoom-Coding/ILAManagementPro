namespace ILAManagementPro.Models
{
    public class ShiftEntity : EntityBase
    {
        public ShiftEntity()
        {
        }

        public ShiftEntity(ShiftEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.DisplayTime = old.DisplayTime;
            this.MilitaryTime = old.MilitaryTime;
        }

        public override string ToString()
        {
            return this.DisplayTime;
        }

        public string DisplayTime { get; set; }

        public string MilitaryTime { get; set; }

        public string PickTime { get; set; }

        public string User { get; set; }
    }
}