using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2
{
    internal class functions
    {
        private static List<Cliente> listaClientes = new List<Cliente>();

        public static void AdicionarCliente(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }
    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome, string cpf, string telefone, string email, int idade)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            Idade = idade;
        }
    }
}
