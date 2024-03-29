﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemplosLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // FONTE DE DADOS
            var listaProdutos = new List<Produto>()
            {
                new Produto {Id = 9, CategoriaId = 2, Nome = "Geladeira", Status = true, Valor = 10},
                new Produto {Id = 2, CategoriaId = 3, Nome = "Short", Status = true, Valor = 1},
                new Produto {Id = 4, CategoriaId = 1, Nome = "Maquina de lavar", Status = false, Valor = 32},
                new Produto {Id = 3, CategoriaId = 1, Nome = "Video Game", Status = true, Valor = 99},
                new Produto {Id = 6, CategoriaId = 2, Nome = "Arroz", Status = true, Valor = 55},
                new Produto {Id = 8, CategoriaId = 1, Nome = "TV", Status = true, Valor = 45},
                new Produto {Id = 1, CategoriaId = 3, Nome = "Camiseta", Status = true, Valor = 100},
                new Produto {Id = 5, CategoriaId = 1, Nome = "Microondas", Status = true, Valor = 90},
                new Produto {Id = 7, CategoriaId = 2, Nome = "Feijão", Status = true, Valor = 12},
            };

            var listaCategoria = new List<Categoria>()
            {
                new Categoria(1,"Eletrodomésticos",  true),
                new Categoria(2,"Alimentos",  true),
                new Categoria(3,"Roupas",  true)
            };



            // // valor total da lista
            // var valotTotal = listaProdutos.Sum(prod => prod.Valor);

            // // media do valor dos produtos
            // var mediaValorProdutos = listaProdutos.Average(prod => prod.Valor);

            // // quantos itens tem na lista
            // var quantidadeItensLista = listaProdutos.Count();
            // var quantidaItensValorMaiorQue90 = listaProdutos.Count(prod => prod.Valor > 90);

            // Console.WriteLine($"Valor total: {valotTotal}");
            // Console.WriteLine($"Media: {mediaValorProdutos}");
            // Console.WriteLine($"Total de itens: {quantidadeItensLista}");
            // Console.WriteLine($"Total de itens com valor maior que 90: {quantidaItensValorMaiorQue90}");

            // // criar uma lista com um range de numeros
            // var range = Enumerable.Range(1, 15);

            // foreach (var item in range)
            // {
            //     Console.WriteLine(item);
            // }



            // buscar o produto e informar nome da categoria

            // Método SQL
            var linqSQL = from produtos in listaProdutos
                join categoria in listaCategoria
                on produtos.CategoriaId equals categoria.Id
                select new 
                {
                    NomeProd = produtos.Nome,
                    NomeCat = categoria.Nome 
                };
            Console.WriteLine("Método SQL: ");
            foreach (var item in linqSQL)
                Console.WriteLine($"Product: {item.NomeProd} -- Categoria: {item.NomeCat}");


            // Método Csharp
            var linqCsharp = listaProdutos
                            .Join(listaCategoria,
                            lp => lp.CategoriaId,
                            lc => lc.Id,
                            (lp,lc) => new{
                                NomeProd = lp.Nome,
                                NomeCat = lc.Nome
                            }) 
                            .Select(k => new {
                                Nomeprod = k.NomeProd,
                                Nomecat = k.NomeCat
                            });
            Console.WriteLine("\nMétodo Csharp");    
            foreach (var item in linqCsharp)
                Console.WriteLine($"Product: {item.Nomeprod} -- Categoria: {item.Nomecat}");



            // criar uma lista com varios itens semelhantes
            // var listaProdutoIguais = Enumerable.Repeat(new Produto() { Id = 1 }, 5);

            // foreach (var item in listaProdutoIguais)
            // {
            //     Console.WriteLine(item);
            // }
        }

        class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public bool Status { get; set; }
            public decimal Valor { get; set; }
            public int CategoriaId { get; set; }
            public List<Categoria> Categorias { get; set; }
        }

        class Categoria
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public bool Status { get; set; }

            public Categoria(int id, string nome, bool status)
            {
                this.Id = id;
                this.Nome = nome;
                this.Status = status;
            }
        }
    }
}