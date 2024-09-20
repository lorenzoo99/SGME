namespace SGME.Model
{
    public class Platform
    {
        public int PlatformID { get; set; }  // Primary Key
        public string PlatformName { get; set; }
        public string PlatformDescription { get; set; }

        // Navigation property for related Contents
        public ICollection<Content> Contents { get; set; }
    }
}
