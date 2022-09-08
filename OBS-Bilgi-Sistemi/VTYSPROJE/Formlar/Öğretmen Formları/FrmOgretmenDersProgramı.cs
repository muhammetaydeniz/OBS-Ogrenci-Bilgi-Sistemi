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
    public partial class FrmOgretmenDersProgramı : Form
    {
        public FrmOgretmenDersProgramı()
        {
            InitializeComponent();
        }

        public string GirisOgretmenID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmOgretmenDersProgramı_Load(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select DersAd,DersTarih From TBLDERSLER where OgretmenID='" + GirisOgretmenID + "'  ", bgl.baglanti());
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
