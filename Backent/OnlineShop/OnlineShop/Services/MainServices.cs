﻿using OnlineShop.Data;

namespace OnlineShop.Services
{
    public class MainServices
    {
        private IProductRepository _productRepository;
        public MainServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetProductsList()
        {
            return _productRepository.GetProductsList().ToList();
        }
        public List<Product> GetProductsList(string category)
        {
            return _productRepository.GetProductsList(category).ToList();
        }
    }
}
