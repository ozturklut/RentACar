using System;
namespace Application.Features.Models.Dtos
{
    public class CreatedModelDto
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal DailyPrice { get; set; }

        public string ImagePath { get; set; } = string.Empty;
    }
}

