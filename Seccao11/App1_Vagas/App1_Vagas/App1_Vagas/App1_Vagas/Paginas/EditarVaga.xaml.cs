using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Banco;
using App1_Vagas.Modelos;



namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarVaga : ContentPage
	{
        private Vaga vaga { get; set; }
		public EditarVaga (Vaga vaga)
		{
			InitializeComponent ();

            this.vaga = vaga;

            NomeVaga.Text = vaga.NomeVaga;
            Empresa.Text = vaga.Empresa;
            Quantidade.Text = vaga.Quantidade.ToString();
            Cidade.Text = vaga.Cidade;
            Salario.Text = vaga.Salario.ToString();
            Descricao.Text = vaga.Descricao;
            TipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
		}


        public void SalvarAction(object sender, EventArgs args)
        {

            //TODO - se a validação for true

            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            Database database = new Database();
            database.Atualizacao(vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }


        private async bool Validate()
        {
            // campos de texto obrigatórios
            //NomeVaga.Text;
            short.Parse(Quantidade.Text);
            double.Parse(Salario.Text);
            //Empresa.Text;
            //Cidade.Text;
            // Descricao.Text;
            //  = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            // Telefone.Text; -- Validacao telefone
            // Email.Text - Validação Email


            if (string.IsNullOrEmpty(NomeVaga.Text))
            {
                await DisplayAlert("Atenção!", "\"NomeVaga\" não pode estar vazio!", "OK");
                // ToastDisplay
                DependencyService.Get<IMessage>().ShortAlert("\"NomeVaga\" não pode estar vazio!");
                NomeVaga.Focus();
            }

            if (string.IsNullOrEmpty(Quantidade.Text))
            {
                await DisplayAlert("Atenção!", "\"Quantidade\" não pode estar vazio!", "OK");
                // ToastDisplay
                DependencyService.Get<IMessage>().ShortAlert("\"Quantidade\" não pode estar vazio!");
                Quantidade.Focus();
            }

            if (string.IsNullOrEmpty(Salario.Text))
            {
                await DisplayAlert("Atenção!", "\"Salario\" não pode estar vazio!", "OK");
                // ToastDisplay
                DependencyService.Get<IMessage>().ShortAlert("\"Salario\" não pode estar vazio!");
                Salario.Focus();
            }


            if (string.IsNullOrEmpty(Empresa.Text))
            {
                await DisplayAlert("Atenção!", "\"Empresa\" não pode estar vazio!", "OK");
                // ToastDisplay
                DependencyService.Get<IMessage>().ShortAlert("\"Empresa\" não pode estar vazio!");
                Empresa.Focus();
            }


            if (string.IsNullOrEmpty(Cidade.Text))
            {
                await DisplayAlert("Atenção!", "\"Cidade\" não pode estar vazio!", "OK");
                // ToastDisplay
                //DependencyService.Get<IMessage>().ShortAlert(string message);
                DependencyService.Get<IMessage>().ShortAlert("\"Cidade\" não pode estar vazio!");
                Cidade.Focus();

            }

            // Campos Numéricos


            // Validar Email



            return true;


        }


        private  bool ValidateEmail()
        {

            return true;
        }


    }
}