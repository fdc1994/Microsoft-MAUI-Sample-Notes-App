
using NotasTeste.Data;
using NotasTeste.Models;

namespace NotasTeste.Views;

[QueryProperty("Nota", "Nota")]
public partial class PaginaNotas : ContentPage
{
    NotasDatabase NotasDatabase = new NotasDatabase();

    Nota nota;
    public Nota Nota
    {
        get => BindingContext as Nota;
        set => BindingContext = value;
    }
    public PaginaNotas()
	{
		InitializeComponent();
        BindingContext = new Models.Nota();
    }

    protected override async void OnAppearing()
    {
        await ((Models.Nota)BindingContext).CarregaNota();
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Nota.Text))
        {
            await DisplayAlert("Texto Obrigatório", "Por Favor introduza um texto para a Nota.", "OK");
            return;
        }
        Nota.Date = DateTime.Now;

        await Nota.SaveNotaAsync(Nota);
        await Shell.Current.GoToAsync("..");
    }
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (Nota.ID == 0)
            return;
        await Nota.DeleteNotaAsync(Nota);
        await Shell.Current.GoToAsync("..");
    }
}