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
    public partial class FrmAdminDuyuruDetay : Form
    {
        public FrmAdminDuyuruDetay()
        {
            InitializeComponent();
        }

        public string secilenduyuru;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmAdminDuyuruDetay_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select TBLDUYURULAR.DuyuruID,TBLOGRETMEN.OgretmenAd,TBLOGRETMEN.OgretmenSoyAd,TBLDUYURULAR.DuyuruMetni,TBLDUYURULAR.DuyuruTarihi From TBLDUYURULAR INNER JOIN TBLOGRETMEN ON TBLDUYURULAR.OgretmenID = TBLOGRETMEN.OgretmenID where TBLDUYURULAR.DuyuruID='" + secilenduyuru + "' ", bgl.baglanti());
            SqlDataReader rd = komut.ExecuteReader();
            while(rd.Read())
            {
                lblogretmenadsoyad.Text = rd[1].ToString()+" "+rd[2].ToString();
                lbdlduyurutarihi.Text = rd[4].ToString();
                richTextBox1.Text = rd[3].ToString();
            }

            bgl.baglanti().Close();
        }
    }
}
