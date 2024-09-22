﻿namespace SGME.Model
{
    public class Content
    {
        public int ContentID { get; set; }  // Primary Key
        public required string ContentTitle { get; set; }
        public required string ContentType { get; set; }
        public required DateTime? PublicationDate { get; set; }

        // Foreign key to Platform
        public required int PlatformID { get; set; }
        public virtual required Platform Platform { get; set; }  // Navigation property

        public virtual required ICollection<ContentUsers> ContentUsers { get; set; }
    }
}