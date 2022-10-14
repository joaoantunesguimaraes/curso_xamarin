using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();

			// Binging - Link
			// Está linkado à Classe Grupo que tem a variável de instância NomeGrupo1 = "Os Machos"
			BindingContext = new Grupo();

		}

		public class Grupo : System.ComponentModel.INotifyPropertyChanged
        {

			// Variável de Instância
			private string _NomeGrupo1;

			// Método
			public string NomeGrupo1 { get { return _NomeGrupo1;} set { _NomeGrupo1 = value; PropriedadeMudada("PropriedadeMudada"); } }

			// Construtor
			public Grupo()
			{
				NomeGrupo1 = "Os Machos";


			}

			// implementar a Interface
            public event PropertyChangedEventHandler PropertyChanged;

			// Método para ajudar a chamar o Evento event "PropertyChangedEventHandler"
			private void PropriedadeMudada(string NomePropriedade)
            {
				if(PropertyChanged != null)
                {
					// chamar o Evento
					PropertyChanged(this,new PropertyChangedEventArgs(NomePropriedade));

                }
            }



        }



	}
}