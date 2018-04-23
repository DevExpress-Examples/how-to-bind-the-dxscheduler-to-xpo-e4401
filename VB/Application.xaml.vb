Imports Microsoft.VisualBasic
Imports System.Windows
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace SchedulerXPOWpf
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application
		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)

				'MSSqlConnectionProvider.GetConnectionString(".\\SQLExpress", "SchedulerXPOWpf"),
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(AccessConnectionProvider.GetConnectionString("SchedulerXPOWpf.mdb"), AutoCreateOption.DatabaseAndSchema)
		End Sub
	End Class
End Namespace