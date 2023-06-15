using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;


// Exemplo de SQL injection
// '; drop table Cliente; --
// Teste
// Esse script vai dar um drop na tabela cliente


SqlConnectionStringBuilder stringConnectionBuilder = new SqlConnectionStringBuilder();
stringConnectionBuilder.DataSource = @"CT-C-0013G\SQLEXPRESS"; // Nome do servidor
stringConnectionBuilder.InitialCatalog = "example"; // Nome do banco
stringConnectionBuilder.IntegratedSecurity = true; // Autentificação
string stringConnection = stringConnectionBuilder.ConnectionString;

SqlConnection conn = new SqlConnection(stringConnection); // Conecta o banco com as configs do Builder do SQL
conn.Open();

string nome = Console.ReadLine() ?? "";
string senha = Console.ReadLine() ?? "";

SqlCommand comm = new SqlCommand($"select * from Cliente where Nome = '{nome}' and Senha = '{senha}'");
comm.Connection = conn;
var reader = comm.ExecuteReader();

DataTable dt = new DataTable();
dt.Load(reader);

if (dt.Rows.Count > 0)
    Console.WriteLine($"Usuário {dt.Rows[0].ItemArray[0]} Logado");
else
    Console.WriteLine("Conta inexistente");
conn.Close();

//CT-C-0013G\SQLEXPRESS