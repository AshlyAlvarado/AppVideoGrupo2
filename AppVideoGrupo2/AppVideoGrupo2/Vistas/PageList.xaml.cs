using AppVideoGrupo2.Modelos;
namespace AppVideoGrupo2.Vistas;

public partial class PageList : ContentPage
{
	public PageList()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        viewListado.ItemsSource = await App.db.SelectAll();
    }
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        Paises d = args.SelectedItem as Paises;
        await Navigation.PushAsync(new VideoPage(d.VideoFilePath));
    }
}