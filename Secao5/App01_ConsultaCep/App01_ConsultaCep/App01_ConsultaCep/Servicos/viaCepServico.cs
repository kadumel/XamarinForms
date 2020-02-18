using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultaCep.Servicos.Model;
using Newtonsoft.Json;

namespace App01_ConsultaCep.Servicos
{
    class viaCepServico
    {

        public static string enderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCep(string cep)
        {
            string novoEnderecoUrl = string.Format(enderecoURL, cep);
            
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;

        }
    }
}
