﻿using ClinicaFrba.AbmRol;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.Logica.Roles;
using ClinicaFrba.UI._05___Abm_Profesional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.UI.MenuPrincipal
{
    public partial class PantallaPrincipal : EspecialidadesHandler
    {

        public UsuarioLogeado usuario { get; set; }
        public PantallaPrincipal(UsuarioLogeado user)
        {
            usuario = user;
            label1.Visible = false;
            InitializeComponent();
            Principal_Load();
            Show();
        }


          private void Principal_Load()
        {
            DataTable dtUsuario;
            Conexion con = new Conexion();
            string q = @"SELECT * FROM [GD2C2016].[GRUPOSA].[RolesUsuario]
                                            where RolUsu_Usuario_Username = @nombre";
            SqlCommand cmd3 = con.CrearComandoQuery(q);
            cmd3.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = usuario.UserName;
            dtUsuario = con.ExecConsulta(cmd3);

            List<Rol> numRol = dtUsuario.AsEnumerable().Select(row =>
            new Rol {Codigo = Convert.ToInt32(Convert.ToString(row["RolUsu_Rol_Codigo"])),}).ToList();

            Rol r = Rol.rolConSusFuncionalidadesCodigo((numRol.Find(x => x.Codigo != 0).Codigo));

            listadoEstadisticoToolStripMenuItem.Visible = true;
            administradorToolStripMenuItem.Visible = false;
            mediocToolStripMenuItem.Visible = false;
            afiliadosToolStripMenuItem.Visible = false;
            pedirTurnoToolStripMenuItem.Visible = false;
            comprarBonoToolStripMenuItem.Visible = false;
            cancelarTurnoToolStripMenuItem1.Visible = false;
            registrarAgendaToolStripMenuItem.Visible = false;
            registrarResultadoToolStripMenuItem.Visible = false;
            cancelarTurnoToolStripMenuItem.Visible = false;
            aBMAfiliadoToolStripMenuItem.Visible = false;
            aBMRolToolStripMenuItem.Visible = false;
            registroDeLlegadaToolStripMenuItem.Visible = false;

            foreach (Funcionalidad unaFunc in r.Funcionalidades)
            {
                switch (Funcionalidad.obtenerPorNombre(unaFunc))
                {
                    case Funcionalidades.ABM_Rol:
                        administradorToolStripMenuItem.Visible = true;
                        aBMRolToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.ABM_Afiliado:
                        administradorToolStripMenuItem.Visible = true;
                        aBMAfiliadoToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.RegistroLlegada:
                        administradorToolStripMenuItem.Visible = true;
                        registroDeLlegadaToolStripMenuItem.Visible = true;
                        break;

                    case Funcionalidades.PedirTurno:
                        afiliadosToolStripMenuItem.Visible = true;
                        pedirTurnoToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.CompraBono:
                        afiliadosToolStripMenuItem.Visible = true;
                        comprarBonoToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.CancerlarTurno:
                        afiliadosToolStripMenuItem.Visible = true;
                        cancelarTurnoToolStripMenuItem1.Visible = true;
                        break;

                    case Funcionalidades.RegistrarAgenda:
                        mediocToolStripMenuItem.Visible = true;
                        registrarAgendaToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.RegistroResultado:
                        mediocToolStripMenuItem.Visible = true;
                        registrarResultadoToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.CancelarAtencion:
                        mediocToolStripMenuItem.Visible = true;
                        cancelarTurnoToolStripMenuItem.Visible = true;
                        break;

                    case Funcionalidades.Listados:
                        listadoEstadisticoToolStripMenuItem.Visible = true;
                        break;
                }
            }
        }


        private void listadoEstadisticoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void mediocToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
        private void afiliadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void pedirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        } 
        private void comprarBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void cancelarTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        } 
        private void registrarAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void registrarResultadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void cancelarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void aBMAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void aBMRolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void registroDeLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }







        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaDeRoles rol = new ListaDeRoles();
        }
        private void afiliadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void mediocToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

        }
        private void rolToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// este metodo es el utilizado por AbmAfiliadoListar cuando el administrador 
        /// desea seleccionar una afiliado para realizar una accion en su nombre
        /// </summary>
        /// <param name="ua"></param>
        public void afiliadoSeleccionado(UsuarioLogeado usuarioAfiliado)
        {
            throw new NotImplementedException();
        }
    }


}