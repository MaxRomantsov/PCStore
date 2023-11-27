using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PCStore.Core.DTO_s.Good;
using PCStore.Core.Entities.SIte;
using PCStore.Core.Entities.Specifications;
using PCStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCStore.Core.Services
{
    public class GoodService : IGoodService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IRepository<Good> _goodRepo;

        public GoodService(IConfiguration configuration, IRepository<Good> goodRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _goodRepo = goodRepo;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public async Task Create(GoodDto model)
        {
            if (model.File.Count > 0)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string upload = webRootPath + _configuration.GetValue<string>("ImageSettings:ImagePath");
                var files = model.File;
                string fileName = Guid.NewGuid().ToString();
                string extensions = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extensions), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                model.ImagePath = fileName + extensions;
            }
            else
            {
                model.ImagePath = "Default.png";
            }

            DateTime currentDate = DateTime.Today;
            string formatedDate = currentDate.ToString("d");
            model.PublishDate = formatedDate;
            await _goodRepo.Insert(_mapper.Map<Good>(model));
            await _goodRepo.Save();
        }
        public async Task<GoodDto?> Get(int id)
        {
            if (id < 0) return null;

            var post = await _goodRepo.GetByID(id);

            if (post == null) return null;

            return _mapper.Map<GoodDto>(post);
        }

        public async Task<List<GoodDto>> GetByCategory(int id)
        {
            var result = await _goodRepo.GetListBySpec(new Goods.ByCategory(id));
            return _mapper.Map<List<GoodDto>>(result);
        }
        public async Task<List<GoodDto>> GetAll()
        {
            var result = await _goodRepo.GetListBySpec(new Goods.All());
            return _mapper.Map<List<GoodDto>>(result);
        }
        public async Task Update(GoodDto model)
        {
            var currentPost = await _goodRepo.GetByID(model.Id);
            if (model.File.Count > 0)
            {
                string webPathRoot = _webHostEnvironment.WebRootPath;
                string upload = webPathRoot + _configuration.GetValue<string>("ImageSettings:ImagePath");

                string existingFilePath = Path.Combine(upload, currentPost.ImagePath);

                if (File.Exists(existingFilePath) && model.ImagePath != "Default.png")
                {
                    File.Delete(existingFilePath);
                }

                var files = model.File;

                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                model.ImagePath = fileName + extension;

            }
            else
            {
                model.ImagePath = currentPost.ImagePath;
            }
            await _goodRepo.Update(_mapper.Map<Good>(model));
            await _goodRepo.Save();
        }
        public async Task Delete(int id)
        {
            var currentPost = await Get(id);

            if (currentPost == null) return;

            string webPathRoot = _webHostEnvironment.WebRootPath;
            string upload = webPathRoot + _configuration.GetValue<string>("ImageSettings:ImagePath");

            string existingFilePath = Path.Combine(upload, currentPost.ImagePath);

            if (File.Exists(existingFilePath) && currentPost.ImagePath != "Default.png")
            {
                File.Delete(existingFilePath);
            }

            await _goodRepo.Delete(id);
            await _goodRepo.Save();
        }
    }
}
