using Ardalis.Specification;
using Microsoft.Extensions.Hosting;
using PCStore.Core.Entities.SIte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PCStore.Core.Entities.Specifications
{
    public static class Goods
    {
        public class All : Specification<Good>
        {
            public All()
            {
                Query.Include(x => x.Category).OrderByDescending(x => x.Id);
            }
        }

        public class ById : Specification<Good>
        {
            public ById(int id)
            {
                Query.Where(p => p.Id == id).Include(x => x.Category);
            }
        }

        public class ByCategory : Specification<Good>
        {
            public ByCategory(int categoryId)
            {
                Query
                  .Include(x => x.Category)
                  .Where(c => c.CategoryId == categoryId).OrderByDescending(x => x.Id); ;
            }
        }
        public class Search : Specification<Good>
        {
            public Search(string searchString)
            {
                Query
                    .Include(p => p.Category)
                    .Where(p => p.Title.Contains(searchString) || p.Producer.Contains(searchString)).OrderByDescending(x => x.Id);
            }
        }
    }
}
