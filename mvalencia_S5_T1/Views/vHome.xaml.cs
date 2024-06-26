using mvalencia_S5_T1.Models;

namespace mvalencia_S5_T1.Views;

public partial class vHome : ContentPage
{
    public vHome()
    {
        InitializeComponent();
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        App.personRepo.AddNewPerson(txtNombre.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
        txtNombre.Text = "";
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        try
        {
            List<Persona> people = App.personRepo.GetAllPeople();
            listarPersona.ItemsSource = people;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}