namespace Student_Management_System.Domains
{
    public class LocalResourceDomain : BaseDomain
    {
        public string ResourceName { get; set; }
        public string Value { get; set; }
        public LanguageDomain Language { get; set; }
    }
}
