﻿using Repository.Entity;

namespace MRC_API.Payload.Request.Product
{
    public class CreateProductRequest
    {
       

        public string ProductName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }

        public List<IFormFile> ImageLink { get; set; } = new List<IFormFile>();
    }
}
