namespace NotasTeste;

using Views;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(PaginaNotas), typeof(PaginaNotas));
    }
}
