using Listas.Models;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Listas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lista.ItemsSource = await App.Bancotexto.Listar();
        }

        async void Adicionar(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entrada.Text))
            {

                await App.Bancotexto.Adicionar(new Texto
                {
                    Frase = entrada.Text
                });
                entrada.Text = string.Empty;
                lista.ItemsSource = await App.Bancotexto.Listar();
            }
            
       
        }

        public void Deletar(object sender, EventArgs s)
        {

         
           
        }

        private async void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var x = BindingContext as Texto; as 
            var texto = e.SelectedItem as Texto;
            var t = texto.Frase;
            await CrossTextToSpeech.Current.Speak(t);
        }

        private async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var texto = e.Item as Texto;
            var t = texto.Frase;
            await CrossTextToSpeech.Current.Speak(t);
        }
    }
}
