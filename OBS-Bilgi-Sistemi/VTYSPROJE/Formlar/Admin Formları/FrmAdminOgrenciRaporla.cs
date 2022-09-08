using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYSPROJE
{
    public partial class FrmAdminOgrenciRaporla : Form
    {
        public FrmAdminOgrenciRaporla()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string secilen;

        private void FrmAdminOgrenciRaporla_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLNOTLAR where OgrID='" + secilen + "'", bgl.baglanti());
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = @"C:\Users\AYDENİZ\Desktop\VTYSPROJE\VTYSPROJE\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
