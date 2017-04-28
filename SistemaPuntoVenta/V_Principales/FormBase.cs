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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir ", "Aviso", MessageBoxButtons.YesNo,
           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
           System.Windows.Forms.DialogResult.Yes)
                Close();
        }



        public virtual Boolean Salvar()
        {
            return false;
        }


        public virtual void Eliminar()
        {


        }

        public virtual void Nuevo()
        {


        }

        public virtual void Consultar()
        {


        }

        public static void bloquear_combo(KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '\b')
            {
                e.Handled = true;
            }

        }
    }
}
