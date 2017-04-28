using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herramientas
{
    public class Metodos
    {

        public static DataSet Ejecutar(string cmd)
        {

            DataSet ds = new DataSet();

            try
            {

                SqlConnection Con = new SqlConnection("Data Source=YoelTorres-PC;Initial Catalog=PuntoVenta;Integrated Security=True");
                Con.Open();
                SqlDataAdapter dp = new SqlDataAdapter(cmd, Con);
                dp.Fill(ds);
                Con.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }

            return ds;
        }

        public static Boolean ValidarFormulario(Control objeto, ErrorProvider errorprovider)
        {
            Boolean Hayerrores = false;


            foreach (Control item in objeto.Controls)
            {
                if (item is ErrorTxtBox)
                {
                    ErrorTxtBox obj = (ErrorTxtBox)item;

                    if (obj.Validar == true)
                    {
                        if (string.IsNullOrEmpty(obj.Text.Trim()))
                        {
                            errorprovider.SetError(obj, "No puede estar vacio");
                            Hayerrores = true;
                        }
                    }
                    else
                    {
                        errorprovider.SetError(obj, "");
                    }

                }

            }


            return Hayerrores;

        }
    }
}
