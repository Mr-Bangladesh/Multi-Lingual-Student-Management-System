using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Management_System.Data;
using Student_Management_System.Domains;
using Student_Management_System.Models;

namespace Student_Management_System.Services
{
    public class LocalizedPropertyService : ILocalizedPropertyService
    {
        private readonly ApplicationDbContext _context;
        public LocalizedPropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateLocalizedProperty(string entityName, string entityPropertyName, string localValue, LanguageDomain language, int entityId)
        {
            var model = new LocalizedPropertyDomain()
            {
                EntityName = entityName,
                EntityPropertyName = entityPropertyName,
                LocalValue = localValue,
                Language = language,
                EntityId = entityId
            };

            await _context.LocalizedProperty.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public List<LocalizedPropertyDomain> GetLocalizedPropertyAsync(string entityName, int entityId)
        {
            var model = _context.LocalizedProperty.Where(x => x.EntityName==entityName && x.EntityId==entityId).Select(y => new LocalizedPropertyDomain()
            {
                Id = y.Id,
                EntityName = y.EntityName,
                EntityPropertyName = y.EntityPropertyName,
                LocalValue = y.LocalValue,
                Language = y.Language,
                EntityId = y.EntityId
            }).ToList();

            return model;
        }

        public async Task DeleteLocalizedPropertyAsync(int entityId)
        {
            var model = _context.LocalizedProperty.Where(x => x.EntityId == entityId).Select(y => new LocalizedPropertyDomain()
            {
                Id = y.Id,
                EntityName = y.EntityName,
                EntityPropertyName = y.EntityPropertyName,
                LocalValue = y.LocalValue,
                Language = y.Language,
                EntityId = y.EntityId
            }).ToList();

            foreach(var data in model)
            {
                _context.LocalizedProperty.Remove(data);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
