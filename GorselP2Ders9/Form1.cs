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

namespace GorselP2Ders9
//uygulama Olayın E argümanı kullanılacak. klavyenin yön tuşlarına basıldığında form daki resmi yön tuşlarına göre hareket ettiren kodu yazınız.
{//Uygulama 2 // Kulanıcı adı ve şifre kontolü yaparak doğruysa 2. formu açan yanlışsa mesaj veren.
    public partial class Form1 : Form
    {
        #region Uygulama 1 = Login
        sqlbaglantisi bgl = new sqlbaglantisi();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            userCheck();
        }
        public void userCheck()
        {

            //string kadiGiris = textBoxKadi.Text;
            //string sifreGiris = textBoxSifre.Text; farklı kullanım şekli için yorum satırı yaptırm.
            string sql = "select * from kullanici where kadi=@kadi and sifre=@sifre";
            SqlDataAdapter da = new SqlDataAdapter(sql, bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@kadi", textBoxKadi.Text);
            da.SelectCommand.Parameters.AddWithValue("@sifre", textBoxSifre.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Form2 frm = new Form2();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Geçersiz");
            }

        }
        #endregion

    }
}
