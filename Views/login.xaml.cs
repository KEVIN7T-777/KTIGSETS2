namespace KTIGSETS2.Views;

public partial class login : ContentPage
{
    //LISTA DE USUARIOS:
    List<string> usuarios = new List<string> { "Carlos", "Ana", "Jose" };
    List<string> contrase�as = new List<string> { "carlos123", "ana123", "jose123" };

    public login()
    {
        InitializeComponent();
    }

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string userInput = txtUsu.Text;
            string passInput = txtPas.Text;

            //CAPTURO EL INDICE DEL USUARIO:
            int index = usuarios.IndexOf(userInput);
            //SI EL USUARIO EXISTE Y LA CONTRASE�A INGRESA CORRESPONDE AL INDICE DEL USUARIO:
            if (index != -1 && contrase�as[index] == passInput)
            {
                Navigation.PushAsync(new Views.principal(userInput));
            }
            else
            {
                DisplayAlert("MENSAJE", "USUARIO/CONTRASE�A INCORRECTOS", "OK");
                return;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}