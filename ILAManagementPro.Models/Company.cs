namespace ILAManagementPro.Models
{
    public class Company : EntityBase
    {
        public Company()
        {
        }

        public Company(Company old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.CompanyId = old.CompanyId;
            this.CompanyName = old.CompanyName;
            this.CompanySymbol = old.CompanySymbol;
            this.CompanyCode = old.CompanyCode;
            this.Active = old.Active;
            this.FileName = old.FileName;
            this.CoImport = old.CoImport;
            this.HasNotes = old.HasNotes;
        }

        public override string ToString()
        {
            return this.CompanyId;
        }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanySymbol { get; set; }

        public string CompanyCode { get; set; }

        public bool Active { get; set; }

        public string FileName { get; set; }

        public decimal? CoImport { get; set; }

        public bool? HasNotes { get; set; }
    }
}