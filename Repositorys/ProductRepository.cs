﻿using API_Gestao_Sock.Data;
using API_Gestao_Sock.Model;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sales_System_API.Model;

namespace API_Gestao_Sock.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;


        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       public  async Task<ProdutoModel> AddProduct(ProdutoModel product)
        {
            await _dataContext.Productos.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<ProdutoModel>> GetAllProducts()
        {
           return await _dataContext.Productos.ToListAsync();
        }

        public async Task<ProdutoModel> GetProductByName(string name)
        {
            return await _dataContext.Productos.FirstOrDefaultAsync(x => x.Nome == name);
        }

       public async Task<ProdutoModel> GetProdutoByCode(string code)
        {
            return await _dataContext.Productos.FirstOrDefaultAsync(x => x.Codigo == code);
        }
        public async Task<bool> DeleteproductByName(string name)
        {
            ProdutoModel produto = await GetProductByName(name);
            if (produto == null)
            {
                throw new Exception($"O Producto com o nome: {name} não foi encontrado");
            }
            _dataContext.Productos.Remove(produto);
            await _dataContext.SaveChangesAsync();
            return true;
        }

       public async Task<bool> DeleteprodutoByCode(string code)
        {
            ProdutoModel produto = await GetProdutoByCode(code);
            if (produto == null)
            {
                throw new Exception($"O Producto com o Codigo: {code} não foi encontrado");
            }
            _dataContext.Productos.Remove(produto);
            await _dataContext.SaveChangesAsync();
            return true;
        }

       

       public async Task<ProdutoModel> updateProductByCode(ProdutoModel model, string code)
        {
            ProdutoModel produto = await GetProdutoByCode(code);
            if (produto == null)
            {
                throw new Exception($"O Producto com o Codigo: {code} não foi encontrado");
            }
            produto.Nome = model.Nome;
            produto.Descricao = model.Descricao;
            produto.Categoria = model.Categoria;
            produto.ProductPrice = model.ProductPrice;
            _dataContext.Productos.Update(produto);
            await _dataContext.SaveChangesAsync();

            return produto;
        }

       
    }
}
