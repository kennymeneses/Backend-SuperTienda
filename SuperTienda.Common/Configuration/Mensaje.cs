using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperTienda.Common.Configuration
{
    public class Mensaje
    {
        private static IConfigurationRoot Configuration { get; } =
           ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());

        #region Configuracion
        public static string TimeZone { get; } = Configuration.GetSection("Configuracion")["TimeZone"];
        #endregion

        #region Mensaje Defectos

        public static string NoExiste { get; } = Configuration.GetSection("Mensajes")["NoExiste"];

        public static string Guardar { get; } = Configuration.GetSection("Mensajes")["Guardar"];
        public static string Mover { get; } = Configuration.GetSection("Mensajes")["Mover"];
        public static string Copiar { get; } = Configuration.GetSection("Mensajes")["Copiar"];

        public static string Eliminar { get; } = Configuration.GetSection("Mensajes")["Eliminar"];

        public static string Eliminado { get; } = Configuration.GetSection("Mensajes")["Eliminado"];

        public static string NoEliminar { get; } = Configuration.GetSection("Mensajes")["NoEliminar"];

        public static string NoEliminarColaborador { get; } = Configuration.GetSection("Mensajes")["NoEliminarColaborador"];


        public static string Envio { get; } = Configuration.GetSection("Mensajes")["Envio"];

        public static string AprobacionEnvio { get; } = Configuration.GetSection("Mensajes")["AprobacionEnvio"];

        public static string CotizacionVersion { get; } = Configuration.GetSection("Mensajes")["CotizacionVersion"];
        public static string Finalizo { get; } = Configuration.GetSection("Mensajes")["Finalizo"];

        public static string Rechazo { get; } = Configuration.GetSection("Mensajes")["Rechazo"];

        public static string NoExisteDefecto { get; } = Configuration.GetSection("Mensajes")["NoExisteDefecto"];

        public static string SinImplementacion { get; } = Configuration.GetSection("Mensajes")["SinImplementacion"];

        public static string TokenInvalido { get; } = Configuration.GetSection("Mensajes")["TokenInvalido"];

        public static string DebeIngresarDato { get; } = Configuration.GetSection("Mensajes")["DebeIngresarDato"];

        public static string DebeSeleccionar { get; } = Configuration.GetSection("Mensajes")["DebeSeleccionar"];

        public static string DebeSeleccionarAlmenosUn { get; } = Configuration.GetSection("Mensajes")["DebeSeleccionarAlmenosUN"];

        public static string DebeSeleccionarAlmenosUna { get; } = Configuration.GetSection("Mensajes")["DebeSeleccionarAlmenosUNA"];

        public static string DebeSeleccionarUn { get; } = Configuration.GetSection("Mensajes")["DebeSeleccionarUN"];

        public static string DebeSeleccionarUna { get; } = Configuration.GetSection("Mensajes")["DebeSeleccionarUNA"];

        public static string DebeIngresar { get; } = Configuration.GetSection("Mensajes")["DebeIngresar"];

        public static string DebeAgregarAlmenosUn { get; } = Configuration.GetSection("Mensajes")["DebeAgregarAlmenosUN"];

        public static string DebeAgregarAlmenosDos { get; } = Configuration.GetSection("Mensajes")["DebeAgregarAlmenosDOS"];

        public static string DebeAgregarAlmenosUna { get; } = Configuration.GetSection("Mensajes")["DebeAgregarAlmenosUNA"];

        public static string DebeIngresarUn { get; } = Configuration.GetSection("Mensajes")["DebeIngresarUN"];
        public static string DebeIngresarUna { get; } = Configuration.GetSection("Mensajes")["DebeIngresarUNA"];

        public static string Nombre { get; } = Configuration.GetSection("Mensajes")["Nombre"];

        public static string NombreEs { get; } = Configuration.GetSection("Mensajes")["NombreES"];

        public static string NombreEn { get; } = Configuration.GetSection("Mensajes")["NombreEN"];

        public static string Abreviatura { get; } = Configuration.GetSection("Mensajes")["Abreviatura"];

        public static string Respuesta { get; } = Configuration.GetSection("Mensajes")["Respuesta"];

        public static string Tipo => Configuration.GetSection("Mensajes")["Tipo"];

        public static string Identificador => Configuration.GetSection("Mensajes")["Identificador"];

        public static string Estado => Configuration.GetSection("Mensajes")["Estado"];

        public static string Entidad => Configuration.GetSection("Mensajes")["Entidad"];

        public static string DiaMayorCero => Configuration.GetSection("Mensajes")["DiaMayorCero"];

        public static string Apellido { get; set; } = Configuration.GetSection("Mensajes")["Apellido"];
        public static string Contrasenia { get; } = Configuration.GetSection("Mensajes")["Contrasenia"];
        public static string RepetirContrasenia { get; } = Configuration.GetSection("Mensajes")["RepetirContrasenia"];
        public static string Token { get; } = Configuration.GetSection("Mensajes")["Token"];
        public static string SinToken { get; } = Configuration.GetSection("Mensajes")["SinToken"];
        public static string SinPermisoMenu { get; } = Configuration.GetSection("Mensajes")["SinPermisoMenu"];

        //nuevo

        public static string Codigo { get; } = Configuration.GetSection("Mensajes")["Codigo"];
        public static string Valor { get; } = Configuration.GetSection("Mensajes")["Valor"];

        public static string Descripcion { get; } = Configuration.GetSection("Mensajes")["Descripcion"];
        public static string Motivo { get; } = Configuration.GetSection("Mensajes")["Motivo"];

        public static string SinAtributos { get; } = Configuration.GetSection("Mensajes")["SinAtributos"];

        public static string SinAtributosCodigo { get; } = Configuration.GetSection("Mensajes")["SinAtributosCodigo"];
        public static string SinAtributosDescripcion { get; } = Configuration.GetSection("Mensajes")["SinAtributosDescripcion"];
        public static string ErrorContrasenia { get; } = Configuration.GetSection("Mensajes")["ErrorContrasenia"];

        public static string ErrorCorreoFormato { get; } = Configuration.GetSection("Mensajes")["ErrorCorreoFormato"];
        public static string Correo { get; } = Configuration.GetSection("Mensajes")["Correo"];

        public static string PersonaCompartido => Configuration.GetSection("Mensajes")["PersonaCompartido"];

        public static string EntidadValida => Configuration.GetSection("Mensajes")["entidadValida"];
        public static string EntidadFeValida => Configuration.GetSection("Mensajes")["entidadFeValida"];
        public static string ConEste => Configuration.GetSection("Mensajes")["ConEste"];
        public static string ConEsta => Configuration.GetSection("Mensajes")["ConEsta"];

        public static string Direccion => Configuration.GetSection("Mensajes")["Direccion"];
        public static string SinAcceso { get; } = Configuration.GetSection("Mensajes")["SinAcceso"];

        public static string RolMenuCero { get; } = Configuration.GetSection("Mensajes")["RolMenuCero"];
        public static string RolMenuDuplicado { get; } = Configuration.GetSection("Mensajes")["RolMenuDuplicado"];

        public static string UsuarioRolCero { get; } = Configuration.GetSection("Mensajes")["UsuarioRolCero"];
        public static string UsuarioRolDuplicado { get; } = Configuration.GetSection("Mensajes")["UsuarioRolDuplicado"];

        public static string CorreoDuplicado { get; } = Configuration.GetSection("Mensajes")["CorreoDuplicado"];
        public static string UsuarioNombreDuplicado { get; } = Configuration.GetSection("Mensajes")["UsuarioNombreDuplicado"];

        public static string TipoDocumentalAtributoInvalido { get; } = Configuration.GetSection("Mensajes")["TipoDocumentalAtributoInvalido"];
        public static string TipoDocumentalAtributoNombreBlanco { get; set; } = Configuration.GetSection("Mensajes")["TipoDocumentalAtributoNombreBlanco"];
        public static string TipoDocumentalAtributoNombreDuplicado { get; set; } = Configuration.GetSection("Mensajes")["TipoDocumentalAtributoNombreDuplicado"];

        public static string TipoDocumentalAtributoTipoInvalido { get; set; } = Configuration.GetSection("Mensajes")["TipoDocumentalAtributoTipoInvalido"];
        public static string TipoDocumentalAtributoFormaInvalido { get; set; } = Configuration.GetSection("Mensajes")["TipoDocumentalAtributoFormaInvalido"];
        public static string AgrupacionTipoDocumentalAtributoInvalido { get; set; } = Configuration.GetSection("Mensajes")["AgrupacionTipoDocumentalAtributoInvalido"];
        public static string AgrupacionTipoDocumentalInvalido { get; set; } = Configuration.GetSection("Mensajes")["AgrupacionTipoDocumentalInvalido"];

        public static string AgrupacionNombreDuplicado { get; } = Configuration.GetSection("Mensajes")["AgrupacionNombreDuplicado"];
        public static string AgrupacionTipoDocumentalAtributoNombreDuplicado { get; } = Configuration.GetSection("Mensajes")["AgrupacionTipoDocumentalAtributoNombreDuplicado"];
        public static string AgrupacionTipoDocumentalDuplicado { get; } = Configuration.GetSection("Mensajes")["AgrupacionTipoDocumentalDuplicado"];

        public static string TipoDocumentalEnUso { get; } = Configuration.GetSection("Mensajes")["TipoDocumentalEnUso"];

        public static string AgrupacionItemNombreDuplicado { get; } = Configuration.GetSection("Mensajes")["AgrupacionItemNombreDuplicado"];


        public static string TrabajoAtributoEnlazadoDuplicado { get; } = Configuration.GetSection("Mensajes")["TrabajoAtributoEnlazadoDuplicado"];
        public static string TrabajoAtributoFaltanEnlazar { get; } = Configuration.GetSection("Mensajes")["TrabajoAtributoFaltanEnlazar"];
        public static string TrabajoAtributosFaltanEnlazar { get; } = Configuration.GetSection("Mensajes")["TrabajoAtributosFaltanEnlazar"];

        public static string InputInvalido { get; } = Configuration.GetSection("Mensajes")["InputInvalido"];
        public static string DebeCargarUn { get; } = Configuration.GetSection("Mensajes")["DebeCargarUn"];

        public static string TrabajoAtributoNoPerteneceTipoDocumental { get; } = Configuration.GetSection("Mensajes")["TrabajoAtributoNoPerteneceTipoDocumental"];
        public static string TrabajoImportacionHojaColumnaNoPerteneceImportacionHoja { get; } = Configuration.GetSection("Mensajes")["TrabajoImportacionHojaColumnaNoPerteneceImportacionHoja"];
        public static string DebeSeleccionarUNValido { get; set; } = Configuration.GetSection("Mensajes")["DebeSeleccionarUNValido"];
        public static string ArchivoNoPertenecePersona { get; set; } = Configuration.GetSection("Mensajes")["ArchivoNoPertenecePersona"];
        public static string DebeSeleccionarUNAValido { get; set; } = Configuration.GetSection("Mensajes")["DebeSeleccionarUNAValido"];
        public static string Formato { get; set; } = Configuration.GetSection("Mensajes")["Formato"];
        public static string Patron { get; set; } = Configuration.GetSection("Mensajes")["Patron"];
        public static string Accion { get; set; } = Configuration.GetSection("Mensajes")["Accion"];
        public static string TipoUsuario { get; set; } = Configuration.GetSection("Mensajes")["TipoUsuario"];

        public static string UsuarioBloqueado { get; } = Configuration.GetSection("Mensajes")["UsuarioBloqueado"];
        public static string UsuarioContraseniaIncorrecta { get; } = Configuration.GetSection("Mensajes")["UsuarioContraseniaIncorrecta"];
        public static string UsuarioCambioContrasenia { get; } = Configuration.GetSection("Mensajes")["UsuarioCambioContrasenia"];
        public static string UsuarioCambioContraseniaExito { get; } = Configuration.GetSection("Mensajes")["UsuarioCambioContraseniaExito"];

        public static string ServicioContenedorBlanco { get; } = Configuration.GetSection("Mensajes")["ServicioContenedorBlanco"];
        public static string ServicioContenedorBlancoDuplicado { get; } = Configuration.GetSection("Mensajes")["ServicioContenedorBlancoDuplicado"];
        public static string ComentarioMesaPartes { get; } = Configuration.GetSection("Mensajes")["ComentarioMesaPartes"];
        public static string VisorCarpetaInvalido { get; } = Configuration.GetSection("Mensajes")["VisorCarpetaInvalido"];
        public static string VisorCarpetaNombreBlanco { get; } = Configuration.GetSection("Mensajes")["VisorCarpetaNombreBlanco"];
        public static string VisorCarpetaNombreDuplicado { get; } = Configuration.GetSection("Mensajes")["VisorCarpetaNombreDuplicado"];
        public static string VisorCarpetaItemInvalido { get; } = Configuration.GetSection("Mensajes")["VisorCarpetaItemInvalido"];
        public static string CentroCostoNombreDuplicadoPorCliente { get; } = Configuration.GetSection("Mensajes")["CentroCostoNombreDuplicadoPorCliente"];
        public static string AreaNombreDuplicadoPorCliente { get; } = Configuration.GetSection("Mensajes")["CentroCostoNombreDuplicadoPorCliente"];
        public static string ColaboradorIdentificadorDuplicadoPorCliente { get; } = Configuration.GetSection("Mensajes")["ColaboradorIdentificadorDuplicadoPorCliente"];
        public static string ColaboradorNombreDuplicadoPorCliente { get; } = Configuration.GetSection("Mensajes")["ColaboradorNombreDuplicadoPorCliente"];

        public static string TieneColaboradorSolicitud { get; } = Configuration.GetSection("Mensajes")["TieneColaboradorSolicitud"];
        public static string TieneColaboradorUsuario { get; } = Configuration.GetSection("Mensajes")["TieneColaboradorUsuario"];


        public static string NoExisteAreaPorCliente { get; } = Configuration.GetSection("Mensajes")["NoExisteAreaPorCliente"];
        public static string NoExisteUnidadOrganizativaPorCliente { get; } = Configuration.GetSection("Mensajes")["NoExisteUnidadOrganizativaPorCliente"];

        public static string UnidadOrganizativaDuplicadaPorCliente { get; } = Configuration.GetSection("Mensajes")["CentroCostoNombreDuplicadoPorCliente"];
        public static string CentroCostoCodigoDuplicadoPorCliente { get; } = Configuration.GetSection("Mensajes")["CentroCostoCodigoDuplicadoPorCliente"];
        public static string UnidadOrganizativaSinMesaPartes { get; } = Configuration.GetSection("Mensajes")["UnidadOrganizativaSinMesaPartes"];
        public static string DebeIngresarUNValido { get; set; } = Configuration.GetSection("Mensajes")["DebeIngresarUNValido"];
        public static string TipoSolicitud => Configuration.GetSection("Mensajes")["TipoSolicitud"];
        public static string RecogerDe => Configuration.GetSection("Mensajes")["RecogerDe"];
        public static string DireccionRecogerDe => Configuration.GetSection("Mensajes")["DireccionRecogerDe"];
        public static string EnviarA => Configuration.GetSection("Mensajes")["EnviarA"];
        public static string DireccionEnviarA => Configuration.GetSection("Mensajes")["DireccionEnviarA"];
        public static string Telefono => Configuration.GetSection("Mensajes")["Telefono"];
        public static string CambioEstadoSolicitud => Configuration.GetSection("Mensajes")["CambioEstadoSolicitud"];
        public static string UsuarioEliminaSolicitud => Configuration.GetSection("Mensajes")["UsuarioEliminaSolicitud"];
        public static string SolicitudYaEnviada => Configuration.GetSection("Mensajes")["SolicitudYaEnviada"];
        public static string DebeSeleccionarUnColaboradorValidoEn => Configuration.GetSection("Mensajes")["DebeSeleccionarUnColaboradorValidoEn"];
        public static string CampoSolicitante => Configuration.GetSection("Mensajes")["CampoSolicitante"];
        public static string CampoRecojo => Configuration.GetSection("Mensajes")["CampoRecojo"];
        public static string CampoEnvio => Configuration.GetSection("Mensajes")["CampoEnvio"];
        public static string PersonaNoPerteneceCliente => Configuration.GetSection("Mensajes")["PersonaNoPerteneceCliente"];
        public static string UnidadOrganizativaEnUso { get; } = Configuration.GetSection("Mensajes")["UnidadOrganizativaEnUso"];
        public static string CentroCostoEnUso { get; } = Configuration.GetSection("Mensajes")["CentroCostoEnUso"];
        public static string AreaEnUso { get; } = Configuration.GetSection("Mensajes")["AreaEnUso"];
        public static string CentroCostoNoCliente { get; } = Configuration.GetSection("Mensajes")["CentroCostoNoCliente"];
        public static string TipoDocumentalAtributoObligatorio { get; set; } = Configuration.GetSection("Mensajes")["TipoDocumentalAtributoObligatorio"];
        public static string NoHazCompartido { get; } = Configuration.GetSection("Mensajes")["NoHazCompartido"];
        public static string NoMoverEnMismaCarpeta { get; } = Configuration.GetSection("Mensajes")["NoMoverEnMismaCarpeta"];

        public static string EliminarCompartido { get; } = Configuration.GetSection("Mensajes")["EliminarCompartido"];
        #endregion

        #region Configuracion

        public static string DirCaptura { get; } = Configuration.GetSection("Configuracion")["DirCaptura"];

        public static bool SubirDropbox => bool.Parse(Configuration.GetSection("Configuracion")["SubirDropbox"]);
        public static bool SubirFileServer => bool.Parse(Configuration.GetSection("Configuracion")["SubirFileServer"]);

        public static string DirCuenta { get; } = Configuration.GetSection("Configuracion")["DirCuenta"];
        public static string DirCliente { get; } = Configuration.GetSection("Configuracion")["DirCliente"];
        public static string DirLogo { get; } = Configuration.GetSection("Configuracion")["DirLogo"];
        public static string DirLote { get; } = Configuration.GetSection("Configuracion")["DirLote"];
        public static string DirUpload { get; } = Configuration.GetSection("Configuracion")["DirUpload"];

        public static string UrlLogo { get; } = Configuration.GetSection("Configuracion")["UrlLogo"];
        public static string UrlCuenta { get; } = Configuration.GetSection("Configuracion")["UrlCuenta"];
        public static string UrlLote { get; } = Configuration.GetSection("Configuracion")["UrlLote"];
        public static string UrlUpload { get; } = Configuration.GetSection("Configuracion")["UrlUpload"];
        public static string ftpUserAPP { get; } = Configuration.GetSection("Configuracion")["ftpUserAPP"];
        public static string ftpPassAPP { get; } = Configuration.GetSection("Configuracion")["ftpPassAPP"];
        public static string ftpServerAPP { get; } = Configuration.GetSection("Configuracion")["ftpServerAPP"];
        #endregion


        #region Administracion Plural
        public static string CatalogoEstadoPlural => Configuration.GetSection("TituloPlural")["CatalogoEstado"];
        public static string NomenclaturaPlural => Configuration.GetSection("TituloPlural")["Nomenclatura"];
        public static string PaisPlural => Configuration.GetSection("TituloPlural")["Pais"];
        public static string DepartamentoPlural => Configuration.GetSection("TituloPlural")["Departamento"];
        public static string ProvinciaPlural => Configuration.GetSection("TituloPlural")["Provincia"];
        public static string DistritoPlural => Configuration.GetSection("TituloPlural")["Distrito"];
        public static string PaquetePlural => Configuration.GetSection("TituloPlural")["Paquete"];

        #endregion

        #region Seguridad Plural
        public static string UsuarioPlural => Configuration.GetSection("TituloPlural")["Usuario"];
        public static string RolPlural => Configuration.GetSection("TituloPlural")["Rol"];
        public static string MenuPlural => Configuration.GetSection("TituloPlural")["Menu"];
        public static string CategoriaPlural => Configuration.GetSection("TituloPlural")["Categoria"];
        public static string SubCategoriaPlural => Configuration.GetSection("TituloPlural")["SubCategoria"];
        public static string SubSubCategoriaPlural => Configuration.GetSection("TituloPlural")["SubSubCategoria"];
        public static string ProductoPlural => Configuration.GetSection("TituloPlural")["Producto"];
        #endregion        


        #region Administracion

        public static string CatalogoEstado => Configuration.GetSection("TituloSingular")["CatalogoEstado"];
        public static string Nomenclatura => Configuration.GetSection("TituloSingular")["Nomenclatura"];
        public static string Persona => Configuration.GetSection("TituloSingular")["Persona"];
        public static string Atributo { get; } = Configuration.GetSection("TituloSingular")["Atributo"];
        public static string Pais => Configuration.GetSection("TituloSingular")["Pais"];
        public static string Departamento => Configuration.GetSection("TituloSingular")["Departamento"];
        public static string Provincia => Configuration.GetSection("TituloSingular")["Provincia"];
        public static string Distrito => Configuration.GetSection("TituloSingular")["Distrito"];
        public static string Paquete => Configuration.GetSection("TituloSingular")["Paquete"];
        public static string NomenclaturaCliente => Configuration.GetSection("TituloSingular")["NomenclaturaCliente"];

        #endregion


        #region Seguridad

        public static string Usuario { get; } = Configuration.GetSection("TituloSingular")["Usuario"];
        public static string Categoria { get; } = Configuration.GetSection("TituloSingular")["Categoria"];
        public static string SubCategoria { get; } = Configuration.GetSection("TituloSingular")["SubCategoria"];
        public static string SubSubCategoria { get; } = Configuration.GetSection("TituloSingular")["SubSubCategoria"];
        public static string Producto { get; } = Configuration.GetSection("TituloSingular")["Producto"];
        public static string Rol { get; } = Configuration.GetSection("TituloSingular")["Rol"];
        public static string Login { get; } = Configuration.GetSection("Mensajes")["Login"];
        public static string Incorrecto { get; } = Configuration.GetSection("Mensajes")["Incorrecto"];
        public static string UnRol { get; } = Configuration.GetSection("Mensajes")["UnRol"];
        public static string Menu { get; } = Configuration.GetSection("TituloSingular")["Menu"];
        public static string Perfil { get; } = Configuration.GetSection("TituloSingular")["Perfil"];
        #endregion

        #region JWT
        public static string JWTKey { get; } = Configuration.GetSection("Jwt")["Key"];
        public static string JWTIssuer { get; } = Configuration.GetSection("Jwt")["Issuer"];

        #endregion



        #region TiempoEspera
        public static string TiempoEsperaBuscador { get; } = Configuration.GetSection("TiempoEspera")["TiempoEsperaBuscador"];
        #endregion
    }
}

