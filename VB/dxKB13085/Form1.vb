Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Control
Imports DevExpress.XtraReports.UserDesigner

Namespace dxKB13085
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private designForm As XRDesignFormEx

        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles button1.Click
            designForm = New XRDesignFormEx()
            AddHandler designForm.DesignPanel.DesignerHostLoaded, AddressOf OnDesignerLoaded
            designForm.DesignPanel.ExecCommand(ReportCommand.NewReport)
            designForm.ShowDialog()
        End Sub

        Private Sub OnDesignerLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
            designForm.DesignPanel.Report.ScriptsSource = designForm.DesignPanel.Report.ScriptsSource + _
                "private void OnAfterPrint(object sender, " _
                & "System.EventArgs e) {((XtraReport)sender).PrintingSystem.AddCommandHandler(new " _
                & "dxKB13085.ZoomInCommandHandler());}"
            designForm.DesignPanel.Report.Scripts.OnAfterPrint = "OnAfterPrint"
        End Sub

    End Class

    Public Class ZoomInCommandHandler
        Implements DevExpress.XtraPrinting.ICommandHandler

        Public Overridable Sub HandleCommand(ByVal command As PrintingSystemCommand, _
        ByVal args As Object(), ByVal control As IPrintControl, ByRef handled As Boolean) _
        Implements DevExpress.XtraPrinting.ICommandHandler.HandleCommand
            If (Not CanHandleCommand(command, control)) Then
                Return
            End If
            MessageBox.Show("Handled!")
            handled = True
        End Sub

        Public Overridable Function CanHandleCommand(ByVal command As PrintingSystemCommand, _
        ByVal control As IPrintControl) As Boolean _
        Implements DevExpress.XtraPrinting.ICommandHandler.CanHandleCommand
            Return command = PrintingSystemCommand.ZoomIn
        End Function

    End Class

End Namespace