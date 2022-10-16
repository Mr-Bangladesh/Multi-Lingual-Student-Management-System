namespace Student_Management_System.Domains
{
    public class LocalizedPropertyDomain : BaseDomain
    {
        public string EntityName { get; set; }
        public string EntityPropertyName { get; set; }
        public string LocalValue { get; set; }
        public LanguageDomain Language { get; set; }
        public int EntityId { get; set; }
    }
}
