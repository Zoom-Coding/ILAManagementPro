namespace ILAManagementPro.Models
{
    public class Berth : EntityBase
    {
        public Berth()
        {
        }

        public Berth(Berth old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.ShortBerthName = old.ShortBerthName;
            this.FullBerthName = old.FullBerthName;
        }

        public override string ToString()
        {
            return this.ShortBerthName;
        }

        public string ShortBerthName { get; set; }

        public string FullBerthName { get; set; }

        public string User { get; set; }
    }
}