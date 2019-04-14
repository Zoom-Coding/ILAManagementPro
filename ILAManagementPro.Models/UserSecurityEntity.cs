namespace ILAManagementPro.Models
{
    public class UserSecurityEntity : EntityBase
    {
        public UserSecurityEntity()
        {
        }

        public UserSecurityEntity(UserSecurityEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.LogIn = old.LogIn.Trim();
            if (this.UserName != null)
                this.UserName = old.UserName.Trim();
            bool? nullable = old.AuthorizeUsers;
            if (nullable.HasValue)
            {
                nullable = old.AuthorizeUsers;
                this.AuthorizeUsers = new bool?(nullable.Value);
            }
            nullable = old.PrintBadges;
            if (nullable.HasValue)
            {
                nullable = old.PrintBadges;
                this.PrintBadges = new bool?(nullable.Value);
            }
            nullable = old.WorkScheduleMaintenance;
            if (nullable.HasValue)
            {
                nullable = old.WorkScheduleMaintenance;
                this.WorkScheduleMaintenance = new bool?(nullable.Value);
            }
            nullable = old.TimeCardMaintenance;
            if (!nullable.HasValue)
                return;
            nullable = old.TimeCardMaintenance;
            this.TimeCardMaintenance = new bool?(nullable.Value);
        }

        public string LogIn { get; set; }

        public string UserName { get; set; }

        public bool? AuthorizeUsers { get; set; }

        public bool? PrintBadges { get; set; }

        public bool? WorkScheduleMaintenance { get; set; }

        public bool? TimeCardMaintenance { get; set; }

        public bool? PodiumProgram { get; set; }

        public string User { get; set; }
    }
}