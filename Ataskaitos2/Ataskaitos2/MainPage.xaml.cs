using Ataskaitos2.Models;
using Ataskaitos2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ataskaitos2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        public MainPage()
		{
			InitializeComponent();

            BindingContext = new MainViewContext();




		}

      
    }
}
