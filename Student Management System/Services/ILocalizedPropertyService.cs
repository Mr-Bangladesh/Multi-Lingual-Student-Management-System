using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Management_System.Domains;
using Student_Management_System.Models;

namespace Student_Management_System.Services
{
    public interface ILocalizedPropertyService
    {
        Task CreateLocalizedProperty(string entityName, string entityPropertyName, string localValue, LanguageDomain languageId, int entityId);
        List<LocalizedPropertyDomain> GetLocalizedPropertyAsync(string entityName, int entityId);
        Task DeleteLocalizedPropertyAsync(int entityId);
    }
}