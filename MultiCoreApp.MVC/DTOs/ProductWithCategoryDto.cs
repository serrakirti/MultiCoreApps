﻿//using MultiCoreApp.Core.Models;

namespace MultiCoreApp.MVC.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public  CategoryDto Category { get; set; }
    }
}
