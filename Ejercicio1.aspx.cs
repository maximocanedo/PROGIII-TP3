using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROGIII_TP3 {
    public partial class Ejercicio1 : System.Web.UI.Page {
        protected Localidad localidades;
        protected void Page_Load(object sender, EventArgs e) {
            // Esta línea de código desactiva la validación no intrusiva en el lado del cliente.
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack) {
                localidades = new Localidad();
                ViewState["Localidades"] = localidades; // Guardar la instancia de localidades en ViewState
            } else localidades = (Localidad)ViewState["Localidades"]; // Recuperar la instancia de localidades desde ViewState
            
        }

        protected void btnGuardarLocalidad_Click(object sender, EventArgs e) {
            string nombre = tbLocalidad.Text;
            DropDownList i = (DropDownList)ddlLocalidades;
            string msj = "";
            localidades.Agregar(nombre, out msj, i);
            lbResultadoLocalidad.Text = msj;
            
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e) {
            lbResultadoUsuario.Text = "Cambios guardados. ";
        }
    }
}