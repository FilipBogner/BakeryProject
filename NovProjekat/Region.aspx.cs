using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NovProjekat
{
    public partial class Region : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q5KDKVD\\SQLEXPRESS;Initial Catalog=NajboljaBaza;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ime = "";
                string adresa = "";
                int telefon;
                if (Request.HttpMethod == "POST")
                {
                    ime = Request.Form["ime"];
                    adresa = Request.Form["adresa"];
                    telefon = int.Parse(Request.Form["telefon"]);
                    UbacijeUTabelu(ime, adresa, telefon);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }
        void UbacijeUTabelu(string ime, string adresa, int telefon)
        {
            using (con)
            {
                con.Open();
                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();
                SqlParameter p3 = new SqlParameter();

                p1.Value = ime;
                p2.Value = adresa;
                p3.Value = telefon;

                p1.ParameterName = "@Ime";
                p2.ParameterName = "@Adresa";
                p3.ParameterName = "@Telefon";

                string upit = "Insert into Prijavljeni(Ime,Adresa,BrTelefon) values(@Ime,@Adresa,@Telefon)";

                SqlCommand cmd = new SqlCommand(upit,con);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                cmd.ExecuteNonQuery();
            }

        }
    }
}