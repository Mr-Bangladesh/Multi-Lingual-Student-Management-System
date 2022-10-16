using System.Collections.Generic;

namespace Student_Management_System.Domains
{
    public class LanguageDomain : BaseDomain
    {
        public string Name { get; set; }
        public virtual IList<LocalizedPropertyDomain> LocalizedProperty { get; set; }
        public virtual IList<LocalResourceDomain> LocalizedResource { get; set; }
    }
}
