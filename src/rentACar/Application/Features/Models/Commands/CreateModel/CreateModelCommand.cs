using System;
using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.CreateModel
{
	public class CreateModelCommand : IRequest<CreatedModelDto>
	{
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelDto>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ModelBusinessRules _modelBusinessRules;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<CreatedModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.BrandShouldExistWhenInserted(request.BrandId);

                Model model = _mapper.Map<Model>(request);

                Model createdModel = await _modelRepository.AddAsync(model);
                CreatedModelDto createdModelDto = _mapper.Map<CreatedModelDto>(createdModel);

                return createdModelDto;
            }
        }
    }
}

