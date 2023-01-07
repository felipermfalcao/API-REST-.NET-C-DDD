using FalconDomain.DTO;
using FalconDomain.Interfaces;
using FalconServices.Services;
using log4net;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using System.Collections.Generic;
using System.Collections;

namespace FalconAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IServiceProduto _ProdutosService;
        private readonly ILog _log;

        public ProdutosController(IServiceProduto ProdutosService, ILog log)
        {
            _ProdutosService = ProdutosService;
            _log = log;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            try
            {
                _log.Info("Chamou Método GET no Controller Produtos");
                return await _ProdutosService.GetAll();                
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return Array.Empty<Produto>();
            }           
        }

        [HttpGet("{id}")]
        public async Task<Produto> Get(int id)
        {
            try
            {
                _log.Info($"Chamou Método GET ID no Controller Produtos. ID: {id}");
                return await _ProdutosService.GetById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message + $"(ID: {id})");
                return new Produto();
            }
        }

        [HttpPost]
        public async Task Post(Produto Produto)
        {
            try
            {
                _log.Info($"Novo produto criado!");
                await _ProdutosService.Post(Produto);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task Put(Produto Produto)
        {
            try
            {
                _log.Info($"Produto atualizado");
                await _ProdutosService.Put(Produto);
            }
            catch (Exception ex)
            {
                
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                _log.Info($"Produto deletado");
                await _ProdutosService.Delete(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }            
        }

        [HttpGet("nome/{name}")]
        public async Task<IEnumerable<Produto>> Get(string name)
        {
            try
            {
                _log.Info($"Selecionado nomes que contém: {name}");
                return await _ProdutosService.GetByName(name);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return Array.Empty<Produto>();
            }
        }
    }
}
