﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucHanhWedMVC.Models;
using ThucHanhWedMVC.Models.ProductModels;

namespace ThucHanhWedMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPham = (from p in db.TDanhMucSps select new Product
            {
                MaSp = p.MaSp,
                TenSp = p.TenSp,
                MaLoai = p.MaLoai,
                AnhDaiDien = p.AnhDaiDien,
                GiaNhoNhat  = p.GiaNhoNhat
            }).ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(String maLoai)
        {
            var sanPham = (from p in db.TDanhMucSps where p.MaLoai == maLoai select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }

    }
}
