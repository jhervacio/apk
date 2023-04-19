using apk.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace apk.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class oLogin : ContentPage
    {
        public oLogin()
        {
            InitializeComponent();
            BindingContext = new UsersViewModels();
        }

        private void btn_signIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuOperativo());
        }
    }
}