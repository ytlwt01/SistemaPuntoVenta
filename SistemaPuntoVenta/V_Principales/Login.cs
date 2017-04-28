using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPuntoVenta.V_Principales
{
    public partial class Login : V_Principales.FormBase
    {
        public Login()
        {
            InitializeComponent();
        }


        private string CodigoUsuario;

        public string GetCodigoUsuario()
        {
            return CodigoUsuario;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Herramientas.Metodos.ValidarFormulario(this, errorProvider1) == false)
            {


                try
                {


                    string cmd = string.Format("EXEC IniciarSesion '{0}','{1}'", TxtUsuario.Text.Trim(), TxtContrasenia.Text.Trim());
                    DataSet DS = Herramientas.Metodos.Ejecutar(cmd);





                    if (Convert.ToString(DS.Tables[0].Rows[0]["Usuario"].ToString().Trim()) == TxtUsuario.Text.Trim() && Convert.ToString(DS.Tables[0].Rows[0]["Contra"].ToString().Trim()) == TxtContrasenia.Text.Trim())
                    {
                        CodigoUsuario = DS.Tables[0].Rows[0]["CodUsuario"].ToString().Trim();

                        V_Principales.Lobin VenLobin = new V_Principales.Lobin();
                        this.Hide();
                        VenLobin.Show();
                    }




                }
                catch (Exception error)
                {
                    MessageBox.Show("Usuario o Contraseña incorrecta, intente de nuevo!.." + error.Message);
                    TxtUsuario.Focus();
                }
            }
            else
            {
                TxtUsuario.Focus();
            }
        }
    }
}
