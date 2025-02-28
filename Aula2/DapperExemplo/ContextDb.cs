using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

// Para usar o Dapper é necessário instalar o pacote Dapper
// dotnet add package Dapper
// dotnet add package Npgsql

namespace Aula2
{
    public class ContextDb
    {
        // private const string
        private static readonly string conexaoDb = "Host=localhost;Database=Aula1;Port=5432;Username=postgres;Password=1234";

        public static IDbConnection GetConexao() // é uma interface que representa uma conexão aberta com banco de dados
        {
            return new NpgsqlConnection(conexaoDb);
        }
    }
}