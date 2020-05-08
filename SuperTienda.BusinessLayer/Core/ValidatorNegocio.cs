using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Core;
using System.Net.Mail;
using System.Reflection;

namespace SuperTienda.BusinessLayer.Core
{
    public class ValidatorNegocio
    {

        public CheckStatus Validar<T>(T entidad, string accion = "") where T : class
        {
            CheckStatus checkstatus = new CheckStatus();
            string mensaje = string.Empty;
            int tipoPrenda = 0;

            if (entidad != null)
            {
                foreach (PropertyInfo propertyInfo in entidad.GetType().GetProperties())
                {
                    string nombreAtributo = propertyInfo.Name;

                    object[] attribute = propertyInfo.GetCustomAttributes(typeof(Validator), true);

                    if (attribute.Length > 0)
                    {
                        Validator validador = (Validator)attribute[0];

                        if (validador.obligatorio)
                        {
                            if (nombreAtributo.Equals("tipo"))
                            {

                                int tipo = (int)propertyInfo.GetValue(entidad);

                                if (tipo <= 0)
                                {
                                    mensaje += string.Format(Mensaje.DebeSeleccionar, Mensaje.Tipo);
                                }
                            }


                            if (nombreAtributo.Equals("respuesta"))
                            {
                                int respuesta = (int)propertyInfo.GetValue(entidad);

                                if (respuesta <= 0)
                                {
                                    mensaje += string.Format(Mensaje.DebeSeleccionarUna, Mensaje.Respuesta);
                                }
                            }

                            if (nombreAtributo.Equals("identificador"))
                            {

                                string identificadorUno = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(identificadorUno))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Identificador);
                                }
                            }

                            if (nombreAtributo.Equals("correo"))
                            {
                                string correo = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(correo))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Correo);
                                }
                                else
                                {

                                    try
                                    {
                                        MailAddress m = new MailAddress(correo);

                                    }
                                    catch (FormatException)
                                    {
                                        mensaje += Mensaje.ErrorCorreoFormato;
                                        // string.Format("");
                                    }

                                }
                            }

                            if (nombreAtributo.Equals("usuario"))
                            {

                                string usuario = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(usuario))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Usuario);
                                }
                            }

                            if (nombreAtributo.Equals("contenido"))
                            {

                                string contenido = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(contenido))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Usuario);
                                }
                            }

                            if (nombreAtributo.Equals("contrasenia"))
                            {

                                string contrasenia = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(contrasenia))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Contrasenia);
                                }
                            }

                            if (nombreAtributo.Equals("repetirContrasenia"))
                            {
                                string repetirContrasenia = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(repetirContrasenia))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.RepetirContrasenia);
                                }
                            }

                            if (nombreAtributo.Equals("idTipo"))
                            {
                                int tipo = (int)propertyInfo.GetValue(entidad);
                                tipoPrenda = tipo;
                                if (tipo <= 0)
                                {
                                    mensaje += string.Format(Mensaje.DebeSeleccionar, Mensaje.Tipo);
                                }
                            }

                            if (nombreAtributo.Equals("nombre"))
                            {

                                string nombre = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(nombre))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Nombre);
                                }
                            }

                            if (nombreAtributo.Equals("apellido"))
                            {
                                string apellido = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(apellido))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Apellido);

                                }
                            }

                            if (nombreAtributo.Equals("abreviatura"))
                            {
                                string abreviatura = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(abreviatura))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Abreviatura);

                                }
                            }

                            if (nombreAtributo.Equals("entidad"))
                            {
                                string entidade = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(entidade))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Entidad);

                                }
                            }

                            if (nombreAtributo.Equals("dia"))
                            {
                                int dia = (int)propertyInfo.GetValue(entidad);

                                if (dia <= 0)
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.DiaMayorCero);
                                }
                            }

                            if (nombreAtributo.Equals("direccion"))
                            {
                                string valorEntidad = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(valorEntidad))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Direccion);
                                }

                            }

                            if (nombreAtributo.Equals("estado"))
                            {

                                int estado = (int)propertyInfo.GetValue(entidad);

                                if (estado <= 0)
                                {
                                    mensaje += string.Format(Mensaje.DebeSeleccionarUn, Mensaje.Estado);
                                    //mensaje += "Debe seleccionar un estado valido.";
                                }
                            }

                            //Nuevo

                            if (nombreAtributo.Equals("codigo"))
                            {
                                string codigo = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(codigo))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Codigo);
                                    //  mensaje += "Debe ingresar un codigo valido";
                                }
                            }

                            if (nombreAtributo.Equals("valor"))
                            {
                                string valor = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(valor))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Valor);
                                }
                            }

                            if (nombreAtributo.Equals("descripcion"))
                            {
                                string descripcion = propertyInfo.GetValue(entidad) as string;

                                if (string.IsNullOrWhiteSpace(descripcion))
                                {
                                    mensaje += string.Format(Mensaje.DebeIngresar, Mensaje.Descripcion);
                                }
                            }

                        }
                    }
                }

                if (mensaje.Length != 0)
                {
                    checkstatus.apiEstado = Status.Error;
                    checkstatus.apiMensaje = mensaje;
                }
                else
                {
                    checkstatus.apiEstado = Status.Ok;
                }
            }
            else
            {
                checkstatus.apiEstado = Status.Error;
                checkstatus.apiMensaje = Mensaje.DebeIngresarDato;
            }

            return checkstatus;
        }

    }
}
