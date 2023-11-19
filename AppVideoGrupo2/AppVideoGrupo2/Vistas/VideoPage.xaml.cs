using CommunityToolkit.Maui.Views;
namespace AppVideoGrupo2.Vistas;

public partial class VideoPage : ContentPage
{
    string videoPath;
    public VideoPage(string videoPath)
    {
        InitializeComponent();
        this.videoPath = videoPath;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        videoElement.Source = MediaSource.FromFile(videoPath);
    }
}