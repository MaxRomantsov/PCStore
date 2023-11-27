using PCStore.Core.DTO_s.Site;
using PCStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GettAll();
        Task<CategoryDto> Get(int id);
        Task<ServiceResponse> GetByName(CategoryDto model);
        Task Create(CategoryDto model);
        Task Update(CategoryDto model);
        Task Delete(int id);
    }
}
