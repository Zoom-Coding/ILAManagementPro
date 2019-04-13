namespace ILAManagementPro.Models
{
    public class Member : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Phone { get; set; }

        public string CardID { get; set; }

        public char Status { get; set; }

        public bool Active { get; set; }

        public string LastFour { get; set; }
    }
}