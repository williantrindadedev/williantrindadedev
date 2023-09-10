using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.CarManager.Business.Domains.Models;
using WTM.CarManager.Business.Interfaces;
using WTM.CarManager.Business.Validations;

namespace WTM.CarManager.Business.Services
{
    public class BrandService : BaseService, IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> Add(Brand entity)
        {
            if (!ExecuteValidation(new BrandValidation(), entity))
            {
                //Criar o retorno
                return false;
            }
            if ((await _brandRepository.GetByFilter(x => x.Name.ToLower() == entity.Name.ToLower())).Any())
            {
                return false;
            }
            return await _brandRepository.Add(entity);
        }

        public async Task<bool> Update(Brand entity)
        {
            if (!ExecuteValidation(new BrandValidation(), entity))
            {
                //Criar o retorno
                return false;
            }
            if ((await _brandRepository.GetByFilter(x => x.Name.ToLower() == entity.Name.ToLower() && x.Id!=entity.Id)).Any())
            {
                return false;
            }
            return await _brandRepository.Update(entity);
        }
    }
}
