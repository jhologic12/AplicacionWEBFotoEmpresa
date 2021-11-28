using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System;


namespace AplicacionWEBFotoEmpresa
{
    public partial class Informacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConectionBD =
ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var cadena = "SELECT * FROM eventoempresa";
            var dbConnection = new MySqlConnection(ConectionBD);
            var da = new MySqlDataAdapter(cadena, ConectionBD);

            var commanBuilder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            var dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("foto", Type.GetType("System.Byte[]"));


            foreach (DataRow row in dt.Rows)
            {
                
                row["foto"] = File.ReadAllBytes(Server.MapPath("~/Image/")+ Path.GetFileName(row["imagen"].ToString()));






               

            }


            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}