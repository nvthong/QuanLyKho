namespace QLK
{
    partial class frmRptHoaDonXuatKho
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
            this.rptViewerHoaDonXuatKho = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewerHoaDonXuatKho
            // 
            this.rptViewerHoaDonXuatKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewerHoaDonXuatKho.Location = new System.Drawing.Point(0, 0);
            this.rptViewerHoaDonXuatKho.Name = "rptViewerHoaDonXuatKho";
            this.rptViewerHoaDonXuatKho.Size = new System.Drawing.Size(884, 464);
            this.rptViewerHoaDonXuatKho.TabIndex = 0;
            // 
            // frmRptHoaDonXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 464);
            this.Controls.Add(this.rptViewerHoaDonXuatKho);
            this.Name = "frmRptHoaDonXuatKho";
            this.Text = "Hoá đơn xuất kho";
            this.Load += new System.EventHandler(this.frmRptHoaDonXuatKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewerHoaDonXuatKho;
    }
}