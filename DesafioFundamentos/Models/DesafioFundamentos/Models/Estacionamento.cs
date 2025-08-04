using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial;
        private readonly decimal precoPorHora;
        private readonly List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (Ex: AAA-1111):");
            string placa = Console.ReadLine()?.Trim().ToUpper() ?? "";

            // Regex para validar placa no padrão AAA-1111 (3 letras, hífen, 4 números)
            string pattern = @"^[A-Z]{3}-\d{4}$";

            if (!Regex.IsMatch(placa, pattern))
            {
                Console.WriteLine("Placa inválida! Use o padrão AAA-1111.");
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Veículo já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine("Veículo cadastrado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (!veiculos.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira a placa e tente novamente.");
                return;
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            bool parseOk = int.TryParse(Console.ReadLine(), out int horas);

            if (!parseOk || horas < 0)
            {
                Console.WriteLine("Entrada inválida para horas. Por favor, digite um número inteiro positivo.");
                return;
            }

            decimal valorTotal = precoInicial + precoPorHora * horas;
            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
        }

        public void ListarVeiculos()
