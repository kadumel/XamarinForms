using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCep.Servicos.Model;
using App01_ConsultaCep.Servicos;

namespace App01_ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

     public void BuscarCEP(Object sender, EventArgs args)
        {

            string cep = CEP.Text.Trim();

            if (isvalidCep(cep))
            {
                try
                {
                    
                    Endereco end = viaCepServico.BuscaEnderecoViaCep(cep);

                    if(end.cep != null)
                    {
                        TEXTO.Text = string.Format("Endereço: {0}\n,{1}\n,{2}\n,{3}\n,{4}", end.localidade, end.uf, end.logradouro, end.complemento, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para esse CEP.", "OK");
                    }
                    
                }
                catch (Exception e)
                {

                    DisplayAlert("Erro", "Erro crítico, " + e.Message, "OK");
                }
               
            }
        }


        private bool isvalidCep(string cep)
        {

            bool valido = true;

        
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido, CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCEP = 0;

            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! CEP deve conter apenas números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
