using AppVideoGrupo2.Controladores;
namespace AppVideoGrupo2
{
    public partial class App : Application
    {
        public static readonly BaseController db = new BaseController();
        public static readonly string videosDirectory = Path.Combine(FileSystem.AppDataDirectory, "Videos");

        public App()
        {
            InitializeComponent();
            if (!Directory.Exists(videosDirectory))
            {
                Directory.CreateDirectory(videosDirectory);
            }

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Vistas.Recorrido());
        }
    }
}
