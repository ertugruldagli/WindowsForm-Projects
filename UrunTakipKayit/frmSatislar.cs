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

namespace UrunTakipKayit
{
    public partial class frmSatislar : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ED-INTERN;Initial Catalog=Northwind;Integrated Security=True");

        string sqlQuery = "";

        public frmSatislar()
        {
            InitializeComponent();
        }

        private void ShowData()
        {
            conn.Open();
            sqlQuery = "exec dbo.SatisListesi ";
            using (SqlCommand cmd =new SqlCommand(sqlQuery,conn))
            {
                using (SqlDataAdapter dAdapter=new SqlDataAdapter(cmd))
                {
                    DataTable dTable=new DataTable();
                    dAdapter.Fill(dTable);
                    dgridSatis.DataSource = dTable;

                }
            }


                conn.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ShowData();
        }

       
    }


    
}
