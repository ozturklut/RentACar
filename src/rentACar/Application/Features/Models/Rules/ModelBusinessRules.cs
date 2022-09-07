using System;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Rules
{
	public class ModelBusinessRules
	{
		private readonly IModelRepository _modelRepository;
        private readonly IBrandRepository _brandRepository;

        public ModelBusinessRules(IModelRepository modelRepository, IBrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        public async Task ModelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Model> result = await _modelRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Model name exists.");
        }

        public async Task BrandShouldExistWhenInserted(int brandId)
        {
            Brand brand = await _brandRepository.GetAsync(x => x.Id == brandId);
            if (brand == null) throw new BusinessException("No brand found for the submitted brand id.");
        }
    }
}

