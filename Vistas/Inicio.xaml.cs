using jnarvaezS6.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel; 

namespace jnarvaezS6.Vistas;

public partial class Inicio : ContentPage
{
    private const string Url = "http://192.168.3.11/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estud;

    public Inicio()
	{
		InitializeComponent();
		Obtener();
	}
    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estud = new ObservableCollection<Estudiante>(mostrarEst);
        ListaEstudiantes.ItemsSource = estud;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarEstudiante());
    }

    private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new ActEliminar(objEstudiante));
    }
}