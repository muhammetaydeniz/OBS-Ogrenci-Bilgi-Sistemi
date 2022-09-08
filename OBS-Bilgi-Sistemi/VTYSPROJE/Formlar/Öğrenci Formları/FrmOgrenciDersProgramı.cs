using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VTYSPROJE
{
    public partial class FrmOgrenciDersProgramı : Form
    {
        public FrmOgrenciDersProgramı()
        {
            InitializeComponent();
        }

        public string GirisOgrID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmOgrenciDersProgramı_Load(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select TBLDERSLER.DersAd,TBLDERSLER.DersTarih From TBLDERSLER INNER JOIN TBLNOTLAR ON TBLNOTLAR.DersID = TBLDERSLER.DersID INNER JOIN TBLOGRENCI ON TBLOGRENCI.OgrID = TBLNOTLAR.OgrID where TBLOGRENCI.OgrID='" + GirisOgrID + "'  ", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            
        }
    }
}
