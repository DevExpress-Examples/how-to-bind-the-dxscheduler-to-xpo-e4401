using System.Windows;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace SchedulerXPOWpf {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                AccessConnectionProvider.GetConnectionString("SchedulerXPOWpf.mdb"),
                //MSSqlConnectionProvider.GetConnectionString(".\\SQLExpress", "SchedulerXPOWpf"),
                AutoCreateOption.DatabaseAndSchema);
        }
    }
}