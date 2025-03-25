using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Modelo;
using Microsoft.Data;
using Microsoft.Data.SqlClient;



namespace BLL
{
    internal class ClienteBLL
    {
        public void Incluir(ClienteInformation cliente)
        {
            //o nome do cliente e obrigatório
            if(cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente e obrigatorio");
            }
            //E-email sempre em minsculo
            cliente.Email = cliente.Email.ToLower();
            //se tudo ok, chama a rotina de inserção
            ClientesDal obj = new ClientesDal();
            obj.Incluir(cliente);
            
        }
        
        public void Alterar(ClienteInformation cliente)
        {
             if(cliente.Nome.Trim().Length == 0)
             { 
                throw new Exception("O nome do cliente é obrigatorio")

             }
             cliente.Email = cliente.Email.ToLower();
             ClientesDal obj = new ClientesDal();
             obj.Alterar(cliente);

        } 
        
        public void Excluir(int codigo)
        {

        }


    
    }


}
