using mvalencia_S5_T1.Utils;
using System.Security.Cryptography.X509Certificates;

namespace mvalencia_S5_T1
{
    public partial class App : Application
    {
        public static PersonRepository personRepo { get; set; }
        public App(PersonRepository PersonRepository)
        {            
            InitializeComponent();

            MainPage = new Views.vHome();
            personRepo = PersonRepository;
        }
    }
}