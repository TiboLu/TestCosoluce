using Prism.Mvvm;

namespace TestCosoluceWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Validation SIREN/SIRET";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}