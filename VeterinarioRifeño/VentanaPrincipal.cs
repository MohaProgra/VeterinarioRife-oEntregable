using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;//esto es para poder mover la página
using System.Web.UI.Design;

namespace VeterinarioRifeño
{
    public partial class VentanaPrincipal : Form
    {
        Conexion conexion = new Conexion();
        


        public object DataTime { get; private set; }

        public VentanaPrincipal()
        {
            InitializeComponent();
            dataGridView1.DataSource = conexion.getmascota();
            dataGridView2.DataSource = conexion.getvacuna();
            dataGridView3.DataSource = conexion.getpeluquería();
            dataGridView5.DataSource = conexion.getguarderia();



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        

        //Esto es para mover la página por la pantalla pinchando en cualquier tabcontrol y arrastras

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void insertaUsuario_Click(object sender, EventArgs e)
        {
           MessageBox.Show(conexion.insertaUsuario(textBoxUSUARIO.Text, textBoxCONTRASEÑA.Text, textBoxNOMBRE.Text));
        }
        //Este código es para la hora y la fecha actualizada
        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            VentanaPrincipal v = new VentanaPrincipal();
                v.Show();
        }

        private void guardarmascota_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.guardarmascota(textBoxMascota.Text, textBoxEspecie.Text, textBoxRaza.Text, textBoxAñoNacimiento.Text, textBoxPropietario.Text));
        }

        private void registrarvacuna_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.registrarvacuna(textBoxNombre1.Text, textBoxTipoVacuna.Text, textBoxSemana.Text, textBoxPropietario1.Text));
        }
    }
}
