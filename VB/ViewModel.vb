Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace SchedulerXPOWpf
	Public Class SchedulerViewModel
		Private privateAppointments As XPCollection
		Public Property Appointments() As XPCollection
			Get
				Return privateAppointments
			End Get
			Private Set(ByVal value As XPCollection)
				privateAppointments = value
			End Set
		End Property
		Private privateResources As XPCollection
		Public Property Resources() As XPCollection
			Get
				Return privateResources
			End Get
			Private Set(ByVal value As XPCollection)
				privateResources = value
			End Set
		End Property

		Public Sub New()
			Appointments = New XPCollection(GetType(XPAppointment)) With {.DeleteObjectOnRemove = True}
			Resources = New XPCollection(GetType(XPResource)) With {.DeleteObjectOnRemove = True}

			AddTestData()
		End Sub

		Private Sub AddTestData()
			If Resources.Count = 0 Then
				Dim res1 As New XPResource() With {.Name = "Computer1", .Color = ToRgb(System.Drawing.Color.Yellow)}

				Resources.Add(res1)
				res1.Save()

				Dim res2 As New XPResource() With {.Name = "Computer2", .Color = ToRgb(System.Drawing.Color.Green)}

				Resources.Add(res2)
				res2.Save()

				Dim res3 As New XPResource() With {.Name = "Computer3", .Color = ToRgb(System.Drawing.Color.Blue)}

				Resources.Add(res3)
				res3.Save()
			End If

			If Appointments.Count = 0 Then
				Dim baseTime As DateTime = DateTime.Today

				Dim apt1 As New XPAppointment() With {.Created = baseTime.AddHours(1), .Finish = baseTime.AddHours(2), .Subject = "Test1", .Location = "Office", .Description = "Test procedure", .Price = 20D}

				Appointments.Add(apt1)
				apt1.Save()

				Dim apt2 As New XPAppointment() With {.Created = baseTime.AddHours(2), .Finish = baseTime.AddHours(3), .Subject = "Test2", .Location = "Office", .Description = "Test procedure"}

				apt2.Resources.Add(CType(Resources(0), XPResource))
				apt2.Resources.Add(CType(Resources(1), XPResource))

				Appointments.Add(apt2)
				apt2.Save()
			End If
		End Sub

		Private Function ToRgb(ByVal color As System.Drawing.Color) As Integer
			Return color.B << 16 Or color.G << 8 Or color.R
		End Function
	End Class
End Namespace