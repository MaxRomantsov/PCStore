using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Core.DTO_s.Good;

namespace PCStore.Core.Interfaces
{
    public interface IGoodService
    {
        Task<List<GoodDto>> GetAll();
        Task<GoodDto?> Get(int id);
        Task<List<GoodDto>> GetByCategory(int id);
        Task Create(GoodDto model);
        Task Update(GoodDto model);
        Task Delete(int id);
        Task<List<GoodDto>> Search(string searchString);
    }
}
