using System;
using DevExpress.Xpo;

namespace SchedulerXPOWpf {
    public class SchedulerViewModel {
        public XPCollection Appointments { get; private set; }
        public XPCollection Resources { get; private set; }

        public SchedulerViewModel() {
            Appointments = new XPCollection(typeof(XPAppointment)) { DeleteObjectOnRemove = true };
            Resources = new XPCollection(typeof(XPResource)) { DeleteObjectOnRemove = true };
 
            AddTestData();
        }

        private void AddTestData() {
            if (Resources.Count == 0) {
                XPResource res1 = new XPResource() {
                    Name = "Computer1",
                    Color = ToRgb(System.Drawing.Color.Yellow)
                };

                Resources.Add(res1);
                res1.Save();

                XPResource res2 = new XPResource() {
                    Name = "Computer2",
                    Color = ToRgb(System.Drawing.Color.Green)
                };

                Resources.Add(res2);
                res2.Save();

                XPResource res3 = new XPResource() {
                    Name = "Computer3",
                    Color = ToRgb(System.Drawing.Color.Blue)
                };

                Resources.Add(res3);
                res3.Save();
            }

            if (Appointments.Count == 0) {
                DateTime baseTime = DateTime.Today;

                XPAppointment apt1 = new XPAppointment() {
                    Created = baseTime.AddHours(1),
                    Finish = baseTime.AddHours(2),
                    Subject = "Test1",
                    Location = "Office",
                    Description = "Test procedure",
                    Price = 20m
                };

                Appointments.Add(apt1);
                apt1.Save();

                XPAppointment apt2 = new XPAppointment() {
                    Created = baseTime.AddHours(2),
                    Finish = baseTime.AddHours(3),
                    Subject = "Test2",
                    Location = "Office",
                    Description = "Test procedure",
                };

                apt2.Resources.Add((XPResource)Resources[0]);
                apt2.Resources.Add((XPResource)Resources[1]);

                Appointments.Add(apt2);
                apt2.Save();
            }
        }

        private int ToRgb(System.Drawing.Color color) {
            return color.B << 16 | color.G << 8 | color.R;
        }
    }
}