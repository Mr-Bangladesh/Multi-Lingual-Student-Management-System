using System.Collections.Generic;

namespace Student_Management_System.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel()
        {
            LocalizedProperty = new List<LocalizedPropertyViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<LocalizedPropertyViewModel> LocalizedProperty { get; set; }
    }
}
