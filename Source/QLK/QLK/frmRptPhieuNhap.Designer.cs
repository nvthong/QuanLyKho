namespace QLK
{
    partial class frmRptPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptViewerPhieuNhap = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewerPhieuNhap
            // 
            this.rptViewerPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewerPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.rptViewerPhieuNhap.Name = "rptViewerPhieuNhap";
            this.rptViewerPhieuNhap.Size = new System.Drawing.Size(900, 471);
            this.rptViewerPhieuNhap.TabIndex = 0;
            // 
            // frmRptPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 471);
            this.Controls.Add(this.rptViewerPhieuNhap);
            this.Name = "frmRptPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hóa đơn nhập kho";
            this.Load += new System.EventHandler(this.frmRptPhieuXuatSi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewerPhieuNhap;
    }
}