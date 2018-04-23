using System;
using System.Windows;
using DevExpress.Xpo;
using DevExpress.XtraScheduler;

namespace SchedulerXPOWpf {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            schedulerControl1.Start = DateTime.Today;
        }

        private void SchedulerStorage_AppointmentsModified(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject(schedulerControl1.Storage.GetCoreStorage()) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }

        private void btnAddNewAppointment_Click(object sender, RoutedEventArgs e) {
            XPCollection xpcAppointments = schedulerControl1.Storage.AppointmentStorage.DataSource as XPCollection;
            DateTime baseTime = DateTime.Today;
            XPAppointment apt = new XPAppointment();

            apt.Created = baseTime.AddHours(3);
            apt.Finish = baseTime.AddHours(4);
            apt.Subject = "Test3";
            apt.Location = "Office";
            apt.Description = "Test procedure";
            apt.Price = 20m;
            
            xpcAppointments.Add(apt);
            apt.Save();

            schedulerControl1.Start = baseTime;
        }

        private void btnGetSourceObject_Click(object sender, RoutedEventArgs e) {
            DevExpress.Xpf.Scheduler.SchedulerStorage storage = schedulerControl1.Storage;

            if (storage.AppointmentStorage.Count > 0) {
                XPAppointment apt = (XPAppointment)storage.AppointmentStorage[0].GetSourceObject(storage.GetCoreStorage());
                // Alternative: XPAppointment apt = (XPAppointment)storage.GetObjectRow(storage.AppointmentStorage[0]);
                MessageBox.Show("First Appointment Price: " + apt.Price.ToString());
            }
        }
    }
}