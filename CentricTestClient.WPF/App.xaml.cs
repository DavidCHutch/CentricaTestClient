using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CentricTestClient.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Deleted SartupUri, to handle startup in App.xaml, because of startup properties and dependancy injection further down the pipeline
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();

            base.OnStartup(e);
        }
    }
}
