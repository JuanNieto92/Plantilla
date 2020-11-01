using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace Plantilla.Areas.Class
{
    public class ConnectionBuilder
    {
        private string usuario;
        private string pass;
        private string servidor;
        private List<Tuple<string, string>> modelos = new List<Tuple<string, string>> {
            new Tuple<string, string>("Models.BD_REVISTAS.Modelo_BD_REVISTAS", "BD_REVISTAS")
        };

        private string[] configuracion = {
            "metadata=res://*/",
            "",
            ".csdl|res://*/",
            "",
            ".ssdl|res://*/",
            "",
            ".msl;provider=System.Data.SqlClient;provider connection string=\"data source=",
            "",
            ";initial catalog=",
            "",
            ";user id=",
            "",
            ";password=",
            "",
            ";MultipleActiveResultSets=True;App=Dashboard\""
        };

        public ConnectionBuilder(HttpSessionStateBase session)
        {
            usuario = (string)session["usuario"];
            pass = (string)session["pass"];
            servidor = (string)session["servidor"];
        }

        public ConnectionBuilder(string usuario, string pass, string servidor)
        {
            this.usuario = usuario;
            this.pass = pass;
            this.servidor = servidor;
        }

        private string GenerarStringBuilder(int modelo)
        {
            var strBuilder = new StringBuilder("");
            strBuilder.Append(configuracion[0]);
            strBuilder.Append(modelos[modelo].Item1);
            strBuilder.Append(configuracion[2]);
            strBuilder.Append(modelos[modelo].Item1);
            strBuilder.Append(configuracion[4]);
            strBuilder.Append(modelos[modelo].Item1);
            strBuilder.Append(configuracion[6]);
            strBuilder.Append(servidor);
            strBuilder.Append(configuracion[8]);
            strBuilder.Append(modelos[modelo].Item2);
            strBuilder.Append(configuracion[10]);
            strBuilder.Append(usuario);
            strBuilder.Append(configuracion[12]);
            strBuilder.Append(pass);
            strBuilder.Append(configuracion[14]);
            return strBuilder.ToString();
        }

        public Models.BD_REVISTAS.BD_REVISTASEntities GetBD_REVISTAS()
        {
            return new Models.BD_REVISTAS.BD_REVISTASEntities(GenerarStringBuilder(0));
        }
    }
}

namespace Plantilla.Models.BD_REVISTAS
{
    public partial class BD_REVISTASEntities : DbContext
    {
        public BD_REVISTASEntities(string conexion)
            : base(conexion)
        {
        }
    }
}