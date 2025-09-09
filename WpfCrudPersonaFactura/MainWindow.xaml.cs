using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCrudPersonaFactura.Models;

namespace WpfCrudPersonaFactura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();

        public MainWindow()
        {
            client.BaseAddress = new Uri("http://localhost:5132/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            var persona = new Persona()
            {
                nombre = txtNombre.Text,
                apellidoPaterno=txtApellidoPaterno.Text,
                apellidoMaterno=txtApellidoMaterno.Text,
                identificacion=txtidentificacion.Text
            };
            this.SavePersona(persona);
        }

        private async void SavePersona(Persona persona)
        {
            await client.PostAsJsonAsync("DirectorioRestService/CreatePersona", persona);
        }
    }
}