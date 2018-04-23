Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler

Namespace SchedulerXPOWpf
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			schedulerControl1.Start = DateTime.Today
		End Sub

		Private Sub SchedulerStorage_AppointmentsModified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
			For Each apt As Appointment In e.Objects
				Dim o As XPBaseObject = TryCast(apt.GetSourceObject(schedulerControl1.Storage.GetCoreStorage()), XPBaseObject)
				If o IsNot Nothing Then
					o.Save()
				End If
			Next apt
		End Sub

		Private Sub btnAddNewAppointment_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim xpcAppointments As XPCollection = TryCast(schedulerControl1.Storage.AppointmentStorage.DataSource, XPCollection)
			Dim baseTime As DateTime = DateTime.Today
			Dim apt As New XPAppointment()

			apt.Created = baseTime.AddHours(3)
			apt.Finish = baseTime.AddHours(4)
			apt.Subject = "Test3"
			apt.Location = "Office"
			apt.Description = "Test procedure"
			apt.Price = 20D

			xpcAppointments.Add(apt)
			apt.Save()

			schedulerControl1.Start = baseTime
		End Sub

		Private Sub btnGetSourceObject_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim storage As DevExpress.Xpf.Scheduler.SchedulerStorage = schedulerControl1.Storage

			If storage.AppointmentStorage.Count > 0 Then
				Dim apt As XPAppointment = CType(storage.AppointmentStorage(0).GetSourceObject(storage.GetCoreStorage()), XPAppointment)
				' Alternative: XPAppointment apt = (XPAppointment)storage.GetObjectRow(storage.AppointmentStorage[0]);
				MessageBox.Show("First Appointment Price: " & apt.Price.ToString())
			End If
		End Sub
	End Class
End Namespace