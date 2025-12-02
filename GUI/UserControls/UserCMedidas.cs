using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UserCMedidas : UserControl
    {
        private readonly int id;
        private int documento = -1; 
        ClientesService clientesService = new ClientesService();
        private Action onMedidaGuardado;
        public UserCMedidas(int id, Action onGuardado)
        {
            InitializeComponent();
            this.documento = id;
            onMedidaGuardado = onGuardado;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = this.FindForm() as FormPrincipal;
            if (formPrincipal != null)
            {
                formPrincipal.AbrirUser(() => new UserCClientes(id));
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el formulario principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.documento == -1) 
                {
                    MessageBox.Show("Error: No se ha identificado al cliente. Guarde los datos personales primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!string.IsNullOrWhiteSpace(txtContornoBusto.Text) && !decimal.TryParse(txtContornoBusto.Text.Replace('.', ','), out _) || !string.IsNullOrWhiteSpace(txtContornoCintura.Text) && !decimal.TryParse(txtContornoCintura.Text.Replace('.', ','), out _))
                {
                    MessageBox.Show("El contorno de busto debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal? GetValor(string texto)
                {
                    if (string.IsNullOrWhiteSpace(texto)) return null;
                    if (decimal.TryParse(texto.Replace('.', ','), out decimal valor)) return valor;
                    return null;
                }

                Clientes medidas = new Clientes
                {
                    documento = this.documento.ToString(),
                    contorno_busto = GetValor(txtContornoBusto.Text),
                    contorno_cintura = GetValor(txtContornoCintura.Text),
                    contorno_cadera = GetValor(txtContornoCadera.Text),
                    ancho_espalda = GetValor(txtAnchoEspalda.Text),
                    talle_delantero = GetValor(txtTalleDelantero.Text),
                    talle_espalda = GetValor(txtTalleEspalda.Text),
                    largo_brazo = GetValor(txtLargoBrazo.Text),
                    contorno_cuello = GetValor(txtContornoCuello.Text),
                    contorno_muneca = GetValor(txtMuñeca.Text),
                    contorno_brazo_biceps = GetValor(txtBiceps.Text)
                };
                bool exito = clientesService.ActualizarMedidas(medidas);
                if (exito)
                {
                    MessageBox.Show("¡Medidas guardados exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Cerrar();
                    onMedidaGuardado?.Invoke();
                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar las medidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }
        private void Cerrar()
        {
            FormPrincipal formPrincipal = this.FindForm() as FormPrincipal;
            if (formPrincipal != null)
            {
                formPrincipal.CerrarModal();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar()
        {
            txtContornoCuello.Clear();
            txtContornoBusto.Clear();
            txtContornoCintura.Clear();
            txtContornoCadera.Clear();
            txtAnchoEspalda.Clear();
            txtTalleDelantero.Clear();
            txtTalleEspalda.Clear();
            txtLargoBrazo.Clear();
            txtMuñeca.Clear();
            txtBiceps.Clear();
            this.documento = -1;
        }
    }
}
