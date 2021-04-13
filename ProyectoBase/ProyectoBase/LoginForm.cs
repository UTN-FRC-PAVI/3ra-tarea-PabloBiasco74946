using ProyectoBase.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBase
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ingreso_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario(txtUsuario.Text, txtContraseña.Text);
            MessageBox.Show("Hola, " + usu.NombreDeUsuario + " " + usu.Password);

            string usuCorrecto = "Pablo";
            string contraCorrecta = "123456";

            if (txtUsuario.Text.Equals(usuCorrecto) && txtContraseña.Text.Equals(contraCorrecta))
            {
                //Nombre de usuario y password son correctos
                PrincipalForm ventana = new PrincipalForm(usu);
                ventana.Show();
                this.Hide();
            }
            else
            {
                //Nombre de usuario o password son incorrectos
                MessageBox.Show("Ingrese valores correctos");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
