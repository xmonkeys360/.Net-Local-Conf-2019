using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureFunction
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

        private async void ExecuteAzureFunction_Clicked(object sender, EventArgs e)
        {
            var url = $"https://function120190928012602.azurewebsites.net/" +
                $"api/Function1?code=yhgTlGoy5QaKOh55LVTBXeuVPmY2KKqTTjYXS1yPZklJstFXJJYljw==&name={UserName.Text}";
            var client = new HttpClient();
            try
            {
                if(string.IsNullOrWhiteSpace(this.UserName.Text))
                {
                    await this.DisplayAlert("Warning..!", "Please enter some text for the name.", "Cancel");
                    return;
                }
                this.Overlay.IsVisible = true;
                this.BusyIndicator.IsVisible = true;
                this.ResultLabel.Text = "Please Wait...!";
                var result = await client.GetStringAsync(url);
                this.ResultLabel.Text = result;
                this.Overlay.IsVisible = false;
                this.BusyIndicator.IsVisible = false;
            }
            catch (Exception ex)
            {
                this.BusyIndicator.IsVisible = false;
                this.Overlay.IsVisible = false;
                this.ResultLabel.Text = "Its us, Its not you...";
            }
        }
    }
}
