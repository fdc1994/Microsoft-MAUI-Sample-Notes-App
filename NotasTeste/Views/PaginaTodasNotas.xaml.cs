using NotasTeste.Models;

namespace NotasTeste.Views;
public partial class PaginaTodasNotas : ContentPage
{
    public PaginaTodasNotas()
    {
        InitializeComponent();
        BindingContext = new Models.TodasNotas();
    }
    protected override async void OnAppearing()
    {
        await ((Models.TodasNotas)BindingContext).CarregaNotas();
    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PaginaNotas), true, new Dictionary<string, object>
        {
            ["Nota"] = new Nota()
        });
    }
    private async void notesCollection_SelectionChanged(object sender,SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Nota nota)
            return;

        await Shell.Current.GoToAsync(nameof(PaginaNotas), true, new Dictionary<string, object>
        {
            ["Nota"] = nota
        });
    }
}