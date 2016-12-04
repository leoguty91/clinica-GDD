﻿using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.UI;
using ClinicaFrba.UI._04___Abm_Afiliado;
using ClinicaFrba.UI._05___Abm_Profesional;
using ClinicaFrba.UI.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class LoginForm : Form
    {

        public UsuarioLogeado  usuarioLogeado { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            labelFecha.Text = StaticUtils.getDate();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (ValidateChildren())
            {
                ObtenerUsuarioPorUsername();
                //AbmAfiliadoListar a = new AbmAfiliadoListar();
            }
        }

        private void ObtenerUsuarioPorUsername()
        {
            try
            {
                LogInHelper helper = new LogInHelper();
                usuarioLogeado = helper.GetUsuario(usernameTextBox.Text, PasswordTextBox.Text);
                

                if (usuarioLogeado.Inhabilitado == true)
                {
                    MessageBox.Show("El usuario [" + usernameTextBox.Text + "] se encuentra Inhabilitado para usar el sistema. Por favor comuniquese con el Administrador del sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (usuarioLogeado == null)
                {
                    MessageBox.Show("Combinacion de Usuario/password incorrecta", " Login erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                PantallaPrincipal pp = new PantallaPrincipal(usuarioLogeado);

            }
            catch(Exception ex)
            {

            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
