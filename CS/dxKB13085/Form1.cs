using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraReports.UserDesigner;

namespace dxKB13085 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        XRDesignFormEx designForm;

        private void button1_Click(object sender, System.EventArgs e) {
            designForm = new XRDesignFormEx();
            designForm.DesignPanel.DesignerHostLoaded += new DesignerLoadedEventHandler(OnDesignerLoaded);
            designForm.DesignPanel.ExecCommand(ReportCommand.NewReport);
            designForm.Show();
        }

        private void OnDesignerLoaded(object sender, DesignerLoadedEventArgs e) {
            designForm.DesignPanel.Report.ScriptsSource += "private void OnAfterPrint(object sender, " +
                "System.EventArgs e) {((XtraReport)sender).PrintingSystem.AddCommandHandler(new " +
                "dxKB13085.ZoomInCommandHandler());}";
            designForm.DesignPanel.Report.Scripts.OnAfterPrint = "OnAfterPrint";
        }

    }

    public class ZoomInCommandHandler : DevExpress.XtraPrinting.ICommandHandler {
        public virtual void HandleCommand(PrintingSystemCommand command, object[] args, IPrintControl control, ref bool handled) {
            if (!CanHandleCommand(command, control)) return;
            MessageBox.Show("Handled!");
            handled = true;
        }

        public virtual bool CanHandleCommand(PrintingSystemCommand command, IPrintControl control) {
            return command == PrintingSystemCommand.ZoomIn;
        }
    }
}