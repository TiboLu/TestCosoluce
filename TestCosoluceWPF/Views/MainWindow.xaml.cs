using System;
using System.Windows;
using Prism.Regions;

namespace TestCosoluceWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            if (regionManager == null) {
                throw new ArgumentNullException(nameof(regionManager));
            }
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(UserControl1));
        }
    }
}
