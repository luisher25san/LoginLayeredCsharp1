using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;
namespace Presentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Cyan;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
                if (txtuser.Text == "")
                {
                    txtuser.Text = "USUARIO";
                    txtuser.ForeColor = Color.Cyan;
                }
           
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Cyan;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.Cyan;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "USUARIO")
            {
                if (txtpass.Text != "CONTRASEÑA")
                {
                    UserModel user = new UserModel();
                    var validlogin = user.LoginUser(txtuser.Text,txtpass.Text);
                    if (validlogin == true)
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        msgError("La contraseña o el usuario son incorrectos. \n Por favor intentelo de nuevo.");
                        txtpass.Clear();
                        txtuser.Focus();
                    }
                }
                else msgError("Ingrese su contraseña");
            }
            else msgError("Ingrese su nombre de usuario");
        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "      "+msg;
            lblErrorMessage.Visible = true;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
