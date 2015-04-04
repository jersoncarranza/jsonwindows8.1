using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


using System.Net.Http;
//using Newtonsoft.Json;
using System.Net.Http.Headers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Snatly.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var request = await httpClient.GetAsync(new Uri("https://snatlybackend.herokuapp.com/files/see/" + txtId.Text, UriKind.RelativeOrAbsolute));
            var txtJson = await request.Content.ReadAsStringAsync();
            JsonValue jsonList = JsonValue.Parse(txtJson);

            if (txtJson != "null")
            {
                try
                {
                    var iduser = jsonList.GetObject().GetNamedArray("materia")[0].GetObject().GetNamedArray("materia_n")[1].GetObject().GetNamedString("description"); 
                    //jsonList.GetObject().GetNamedString("materia");
                    //jsonList.GetObject().GetNamedArray("materia")[0].GetObject().GetNamedString("partial_n"); 
                    txtRegistro.Text = iduser.ToString();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

            }
        }
    }
}
