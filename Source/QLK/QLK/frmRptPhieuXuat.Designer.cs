namespace QLK
{
    partial class frmRptPhieuXuatKho
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
            this.rptViewerPhieuXuatSi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewerPhieuXuatSi
            // 
            this.rptViewerPhieuXuatSi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewerPhieuXuatSi.Location = new System.Drawing.Point(0, 0);
            this.rptViewerPhieuXuatSi.Name = "rptViewerPhieuXuatSi";
            this.rptViewerPhieuXuatSi.Size = new System.Drawing.Size(900, 472);
            this.rptViewerPhieuXuatSi.TabIndex = 0;
            // 
            // frmRptPhieuXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 472);
            this.Controls.Add(this.rptViewerPhieuXuatSi);
            this.Name = "frmRptPhieuXuatKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hóa đơn bán sỉ";
            this.Load += new System.EventHandler(this.frmRptPhieuXuatSi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewerPhieuXuatSi;
    }
}