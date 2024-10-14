namespace SGME.Model
{
    public class UsageHistory
    {
        public int UsageHistoryID { get; set; }  // Primary Key
        public required DateTime ViewDate { get; set; }
        public int ViewDuration { get; set; }  // Time in seconds or minutes

        // Foreign key to User
        public int UserID { get; set; }
        public required User User { get; set; }  // Navigation property

        // Foreign key to Content
        public int ContentID { get; set; }
        public virtual required Content Content { get; set; }  // Navigation property
        public int UsageHistoryId { get; internal set; }
        public bool IsDeleted { get; internal set; }
    }
}
