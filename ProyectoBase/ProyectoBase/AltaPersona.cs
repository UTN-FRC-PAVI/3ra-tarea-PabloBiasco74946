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
    public partial class AltaPersona : Form
    {
        public AltaPersona()
        {
            InitializeComponent();
        }

        private void AltaPersona_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCantidadHijos.Enabled = false;
            cmbCarrera.Items.Add("Ing. en sistemas de información");
            cmbCarrera.Items.Add("Ing. Mecánica");
            cmbCarrera.Items.Add("Ing. Industrial");
            cmbTipoDocumento.Items.Add("DNI");
            cmbTipoDocumento.Items.Add("Pasaporte");
            cmbTipoDocumento.Items.Add("Libreta universitaria");
            
        }

        private void btnGuardarPersona_Click(object sender, EventArgs e)
        {
            string resultado = "";
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string fechaNacimiento = txtFechaNacimiento.Text;
            string sexo = "";
            if (rdMasculino.Checked)
            {
                sexo = "Masculindo";
            }
            if (rdFeminino.Checked)
            {
                sexo = "Femenino";
            }
            if (rdOtro.Checked)
            {
                sexo = "Otro";
            }
            string TipoDocumento = cmbTipoDocumento.GetItemText(cmbTipoDocumento.SelectedItem);
            string NroDocumento = txtNumeroDocumento.Text;
            string Calle = txtCalle.Text;
            string NroCasa = txtNumeroCasa.Text;
            string Soltero = "";
            string Casado = "";
            String ConHijos = "";
            string CantHijos = "";

            if (chkSoltero.Checked)
            {
                Soltero = "Soltero";

            }
            else
            {
                Soltero = "No es soltero";
            }

            if (chkCasado.Checked == true)
            {
                Casado = "Casado";
            }
            else
            {
                Casado = "No es casado";
            }
            if (chkHijos.Checked)
            {
                ConHijos = "Tiene hijos";
            }

            else
            {
                ConHijos = "No tiene hijos";
            }

            CantHijos = txtCantidadHijos.Text;

            string carrera = cmbCarrera.GetItemText(cmbCarrera.SelectedItem);

            bool tieneNombre = false;
            bool tieneApellido = false;
            bool tieneDocumento = false;
            bool existeEnLaGrilla = false;

            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Nombre.");
                txtNombre.Focus();

            }

            else
            {
                tieneNombre = true;
            }


            if (txtApellido.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Apellido.");
                txtApellido.Focus();

            }

            else
            {
                tieneApellido = true;
            }



              if(txtNumeroDocumento.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Nro de documento.");
                txtNumeroDocumento.Focus();

            }

            else
            {
                tieneDocumento = true;
            }

            existeEnLaGrilla = ExisteGrilla(NroDocumento);
            if (existeEnLaGrilla == true)
            {
                MessageBox.Show("Persona dada de alta previamente en el sistema");
            }

            if (tieneNombre && tieneApellido && tieneDocumento && existeEnLaGrilla == false)
            {
                Persona per = new Persona(NroDocumento, apellido, nombre);

                AgregarPersona(per);
            }




            //MessageBox.Show(nombre + " " + apellido + " " + sexo + " " + TipoDocumento + " " + NroDocumento + " " + NroCasa);



            //MessageBox.Show("Datos de la persona: " + per.NombrePersona + per.ApellidoPersona + " " + per.DocumentoPersona);


        }
        private void AgregarPersona(Persona per)
        {
            DataGridViewRow fila = new DataGridViewRow();
            DataGridViewTextBoxCell celdaDocumento = new DataGridViewTextBoxCell();
            celdaDocumento.Value = per.DocumentoPersona;
            fila.Cells.Add(celdaDocumento);

            DataGridViewTextBoxCell celdaApellido = new DataGridViewTextBoxCell();
            celdaDocumento.Value = per.ApellidoPersona;
            fila.Cells.Add(celdaApellido);

            DataGridViewTextBoxCell celdaNombre = new DataGridViewTextBoxCell();
            celdaDocumento.Value = per.NombrePersona;
            fila.Cells.Add(celdaNombre);

            GdrPersonas.Rows.Add(fila);
            MessageBox.Show("Persona agregada con exito");
            txtNombre.Focus();
            LimpiarCampos();

        }
        private void chkHijos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHijos.Checked)
            {
                txtCantidadHijos.Enabled = true;

            }
            else
            {
                txtCantidadHijos.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCalle.Text = "";
            txtCantidadHijos.Text = "";
            txtFechaNacimiento.Text = "";
            txtNumeroCasa.Text = "";
            txtNumeroDocumento.Text = "";
            rdMasculino.Checked = true;
            chkCasado.Checked = false;
            chkHijos.Checked = false;
            chkSoltero.Checked = false;
        }


        private bool ExisteGrilla(string criterioABuscasr)
        {
            bool resultado = false;
            for (int i = 0; i < GdrPersonas.Rows.Count; i++)
            {
                if (GdrPersonas.Rows[i].Cells["Documento"].Value.Equals(criterioABuscasr))
                {
                    resultado = true;
                    break;
                }

            }

            return resultado;
        }

        private void GdrPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
