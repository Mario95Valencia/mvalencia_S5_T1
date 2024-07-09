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

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button.BindingContext as Persona;

        // Obtener el nuevo nombre de alguna manera, por ejemplo, mediante una entrada de texto adicional.
        // Aqu� simplificamos para mostrar el flujo sincr�nico
        string newName = "Nuevo Nombre"; // Deber�as reemplazar esto con la l�gica adecuada para obtener el nuevo nombre

        if (!string.IsNullOrEmpty(newName))
        {
            bool success = App.personRepo.UpdatePerson(person.Id, newName);
            statusMessage.Text = success ? "Persona actualizada correctamente" : App.personRepo.StatusMessage;
            btnObtener_Clicked(sender, e); // Refrescar la lista
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button.BindingContext as Persona;

        // Confirmaci�n sincr�nica de la eliminaci�n
        bool confirm = true; // Simulamos una confirmaci�n; deber�as reemplazar esto con la l�gica adecuada para confirmar
        if (confirm)
        {
            bool success = App.personRepo.DeletePerson(person.Id);
            statusMessage.Text = success ? "Persona eliminada correctamente" : App.personRepo.StatusMessage;
            btnObtener_Clicked(sender, e); // Refrescar la lista
        }
    }
}