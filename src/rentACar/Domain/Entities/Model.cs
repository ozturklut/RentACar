using System;
using System.Runtime.CompilerServices;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public int BrandId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal DailyPrice { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public virtual Brand? Brand { get; set; }

        public Model()
        {

        }

        public Model(int id, int brandId, string name, decimal dailyPrice, string imageUrl)
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
        }
    }
}

