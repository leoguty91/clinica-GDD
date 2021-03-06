﻿using ClinicaFrba.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClinicaFrba.Logica.Entidades;

namespace ClinicaFrba.Logica.Entidades
{
    public class LogInHelper
    {
        public string UserName { get; set; }
        public string password { get; set; }
        //public TipoUsuarioEnum TipoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PreguntaSecreta { get; private set; }
        public string RespuestaSecreta { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaUltimaModificacion { get; private set; }
        public int CantidadIntentosFallidos { get; private set; }
        public bool Inhabilitado { get; private set; }

        public UsuarioLogeado GetUsuario(string usuarioIngresado, string passwordIngresada)
        {
            string passEncriptada = StaticUtils.Encriptar(passwordIngresada);
            //1- defino la query con los @parametros
            //const string query = "select * from GRUPOSA.Usuario where Usuario_Username= '@username' and Usuario_Password= '@password'";
            string query = "SELECT * FROM [GD2C2016].[GRUPOSA].[Usuario] where [Usuario_Username] = @username";
            //2- creo la conexion con la db
            Conexion con = new Conexion();
            //3- creo el comando SQL y le asigno los parametros que hice con @
            SqlCommand comando = con.CrearComandoQuery(query);
            comando.Parameters.Add(new SqlParameter("@username", usuarioIngresado));
            //4- hago la consulta a la db y me devuelve una tabla.
            DataTable usuarios = con.ExecConsulta(comando);
            //DataTable usuarios = con.SimpleQuery(query);

            //5- me fijo que haya traido uno solo por las dudas
            if (usuarios.Rows.Count > 1)
                throw new Exception("mas de un usuario encontrado");
            if (usuarios.Rows.Count == 0)
                return null;
            
            //6- mapeo la row a la clase  UsuarioLogeado
             UsuarioLogeado user = MapearDataTableLista(usuarios);

            //7 me fijo si esta inhabilitado se verifica en login
            //if (user.Inhabilitado)
            //{
            //    MessageBox.Show("este usuario esta inhabilitado para iniciar sesion", "inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            //    return user;
            //}
            // 8 chequeo password
            if (user.password != passEncriptada)
            {
                IncrementarIntentosFallidos(user);
                return null;
            }
            asociarUsuarioConMedico(user);
            asociarUsuarioConPaciente(user);
            return user;

        }

        internal void asociarUsuarioConPaciente(UsuarioLogeado usuarioLogeado)
        {
            Conexion con = new Conexion();
            string s = @"SELECT [Paci_Matricula] ,[Paci_Plan_Med_Cod_FK]
                        FROM [GRUPOSA].[Paciente]
                        where Paci_Usuario = @username";
            SqlCommand cmd =  con.CrearComandoQuery(s);
            cmd.Parameters.Add(new SqlParameter("@username", usuarioLogeado.UserName));
            DataTable dt = con.ExecConsulta(cmd);
            if (dt.Rows.Count == 0) {
                usuarioLogeado.PacienteMatricula = "0";
                return; //si no hay, retorno
            } 
            usuarioLogeado.PacienteMatricula = getUniqueValueFrom(dt);
            usuarioLogeado.planMedico = dt.Rows[0].ItemArray[1].ToString(); //segundo valor


        }
        public void asociarUsuarioConMedico(UsuarioLogeado usuarioLogeado)
        {
            string s = @"SELECT  [Medi_Id]
                        FROM [GD2C2016].[GRUPOSA].[Medico]
                        where Medi_Usuario = @username";
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(s);
            cmd.Parameters.Add(new SqlParameter("@username", usuarioLogeado.UserName));
            DataTable dt = con.ExecConsulta(cmd);
            if (dt.Rows.Count ==0) return; //si no hay, retorno
            usuarioLogeado.MedicoMatricula = getUniqueValueFrom(dt);

        }

        public string getUniqueValueFrom(DataTable d)
        {
            string field = d.Rows[0].Field<string>(0);
            if(field == null)
            {
                return "0";
            }
            return field;
        }

        private void IncrementarIntentosFallidos(UsuarioLogeado user)
        {
            
            sumarIntento(user);

        }

        private void sumarIntento(UsuarioLogeado u)
        {
            if (u.CantidadIntentosFallidos == 2)
                inhabilitarUsuario(u);
            Conexion con = new Conexion();
            
            string s = @" update [GD2C2016].[GRUPOSA].[Usuario]
                            set Usuario_Intentos_Fallidos = @intentos
                            where Usuario_Username = @username";
            SqlCommand cmd = con.CrearComandoQuery(s);
            var intentosNuevo = u.CantidadIntentosFallidos + 1;
            cmd.Parameters.Add(new SqlParameter("@username", u.UserName));
            cmd.Parameters.Add(new SqlParameter("@intentos", intentosNuevo));
            DataTable dt = con.ExecConsulta(cmd);
        }

        private void inhabilitarUsuario(UsuarioLogeado u)
        {
            Conexion con = new Conexion();
            string s = @" update [GD2C2016].[GRUPOSA].[Usuario]
                            set Usuario_Habilitado = 1
                            where Usuario_Username = @username";
            SqlCommand cmd = con.CrearComandoQuery(s);
            cmd.Parameters.Add(new SqlParameter("@username", u.UserName));
            DataTable dt = con.ExecConsulta(cmd);
            MessageBox.Show("¡Usuario inhabilitado!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private UsuarioLogeado MapearDataTableLista(DataTable dtUsuarios)
        {
            List<UsuarioLogeado> lstUsuarios = new List<UsuarioLogeado>();
            try
            {
                
                lstUsuarios = (from x in dtUsuarios.AsEnumerable()
                               select new UsuarioLogeado
                               {
                                   UserName = Convert.ToString(x["Usuario_Username"] ?? string.Empty),
                                   password = Convert.ToString(x["Usuario_Password"] ?? string.Empty),
                                   //PreguntaSecreta = Convert.ToString(x["Usuario_Pregunta_Secreta"] ?? string.Empty),
                                   //RespuestaSecreta = Convert.ToString(x["Usuario_Respuesta_Secreta"] ?? string.Empty),
                                   //FechaCreacion = Convert.ToDateTime(Convert.ToString(x["Usuario_Fecha_Creacion"] ?? string.Empty)),
                                   //FechaUltimaModificacion = (x["Usuario_Fecha_Ultima_Modificacion"] == DBNull.Value || Convert.ToDateTime(x["Usuario_Fecha_Ultima_Modificacion"]) == SqlDateTime.MinValue.Value) ? DateTime.MinValue : Convert.ToDateTime(Convert.ToString(x["Usuario_Fecha_Ultima_Modificacion"])),
                                   CantidadIntentosFallidos = Convert.ToInt32(Convert.ToString(x["Usuario_Intentos_Fallidos"])),
                                   Inhabilitado = Convert.ToBoolean(x["Usuario_Habilitado"])
                                   
                               }).ToList();

                lstUsuarios = lstUsuarios.GroupBy(a => a.UserName).Select(g => g.First()).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar el logueo. Por favor, intente nuevamente.", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstUsuarios.First();
        }




        public UsuarioLogeado GetUsuario(string userName)
        {
            string query = "SELECT * FROM [GD2C2016].[GRUPOSA].[Usuario] where [Usuario_Username] = @username";
            Conexion con = new Conexion();
            SqlCommand comando = con.CrearComandoQuery(query);
            comando.Parameters.Add(new SqlParameter("@username", userName));
            DataTable usuarios = con.ExecConsulta(comando);
            UsuarioLogeado user = MapearDataTableLista2(usuarios);
            asociarUsuarioConPaciente(user);
            asociarUsuarioConMedico(user);
            return user;

        }
        private UsuarioLogeado MapearDataTableLista2(DataTable dtUsuarios)
        {
            List<UsuarioLogeado> lstUsuarios = new List<UsuarioLogeado>();
            try
            {
                lstUsuarios = (from x in dtUsuarios.AsEnumerable()
                               select new UsuarioLogeado
                               {
                                   UserName = Convert.ToString(x["Usuario_Username"] ?? string.Empty),
                               }).ToList();

                lstUsuarios = lstUsuarios.GroupBy(a => a.UserName).Select(g => g.First()).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar el logueo. Por favor, intente nuevamente.", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstUsuarios.First();
        }



    }

}
