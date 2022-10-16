using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Domains;
using Student_Management_System.Models;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public class LocalResourceService : ILocalResourceService
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<string, string> _localResources = new Dictionary<string, string>();
        public LocalResourceService(ApplicationDbContext context)
        {
            _context = context;
            //_localResources = new Dictionary<string, string>();
        }
        public async Task<List<LocalResourceViewModel>> GetAllLocalResourceAsync()
        {
            var model = await _context.LocalResource.Select(x => new LocalResourceViewModel()
            {
                Id = x.Id,
                ResourceName = x.ResourceName,
                Value = x.Value,
                Language = x.Language.Name
            }).ToListAsync();

            return model;
        }

        public async Task<List<LocalResourceViewModel>> GetLocalResourceByLanguageAsync(int? id)
        {
            //var lanugage = _context.Languages.FirstOrDefault(x => x.Id == id);
            var model = await _context.LocalResource.Where(x => x.Language.Id == id).Select(y => new LocalResourceViewModel()
            {
                Id = y.Id,
                ResourceName = y.ResourceName,
                Value = y.Value
            }).ToListAsync();
            return model;
        }

        public async Task LoadLocalResourceAsync(int? id)
        {
            var model = await GetLocalResourceByLanguageAsync(id);
            _localResources.Clear();
            foreach (var data in model)
            {
                _localResources.Add(data.ResourceName, data.Value);
            }
        }
        public string GetLocalResourceByName(string resourceName)
        {
            string result;
            if (_localResources.TryGetValue(resourceName, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task CreateLocalResourceAsync(CreateLocalResourceViewModel viewModel, int? languageId)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Id == languageId);

            var model = new LocalResourceDomain()
            {
                ResourceName = viewModel.ResourceName,
                Value = viewModel.Value,
                Language = language
            };

            _context.LocalResource.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
