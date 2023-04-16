using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI.WebControls;

namespace PROGIII_TP3 {
    /// <summary>
    /// Clase que representa una lista de localidades.
    /// </summary>
    [Serializable]
    public class Localidad : ISerializable {
        private List<string> Localidades;
        /// <summary>
        /// Constructor de la clase Localidad.
        /// </summary>
        public Localidad() {
            Localidades = new List<string>();
        }

        protected Localidad(SerializationInfo info, StreamingContext context) {
            Localidades = (List<string>)info.GetValue("Localidades", typeof(List<string>));
        }
        /// <summary>
        /// Implementación del método GetObjectData de la interfaz ISerializable para la serialización de la clase Localidad.
        /// </summary>
        /// <param name="info">Objeto SerializationInfo que contendrá los datos serializados.</param>
        /// <param name="context">Objeto StreamingContext que especifica el contexto de la serialización.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Localidades", Localidades);
        }
        /// <summary>
        /// Verifica si una cadena de texto dada tiene al menos una letra.
        /// </summary>
        /// <param name="str">La cadena a verificar.</param>
        /// <returns>True si la cadena contiene al menos una letra, False en caso contrario.</returns>
        public static bool ContieneLetra(string str) {
            foreach (char c in str) {
                if (Char.IsLetter(c)) return true;
            }
            return false;
        }
        /// <summary>
        /// Formatea un texto en formato de título capitalizado (Nombre de localidad).
        /// </summary>
        /// <param name="input">Texto a formatear.</param>
        /// <returns>Texto formateado en formato de título capitalizado. </returns>
        public static string FormatearTexto(string input) {
            string[] palabras = input.Trim().Split(' ');
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            for (int i = 0; i < palabras.Length; i++) {
                palabras[i] = ti.ToTitleCase(palabras[i].ToLower());
            }
            string resultado = string.Join(" ", palabras);
            return resultado;
        }
        private string RemoveDiacritics(string input) {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString) {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        /// <summary>
        /// Compara dos cadenas de texto para determinar si son iguales, ignorando mayúsculas y espacios. 
        /// </summary>
        /// <param name="a">Primera cadena de texto a comparar.</param>
        /// <param name="b">Segunda cadena de texto a comparar.</param>
        /// <returns>True si las cadenas son iguales, False en caso contrario.</returns>
        protected bool sonIguales(string a, string b) {
            a = RemoveDiacritics(a.ToLower().Replace(" ", ""));
            b = RemoveDiacritics(b.ToLower().Replace(" ", ""));
            return String.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Verifica si una localidad existe en la lista de localidades.
        /// </summary>
        /// <param name="key">Nombre de la localidad a verificar.</param>
        /// <returns>True si la localidad existe en la lista, False en caso contrario.</returns>
        public bool Existe(string key) {
            foreach (string localidad in Localidades) {
                if (sonIguales(localidad, key))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Carga los elementos de la lista de localidades en un control DropDownList.
        /// </summary>
        /// <param name="ddl">Control DropDownList en el que se cargarán los elementos.</param>
        public void CargarDropDownList(DropDownList ddl) {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Seleccionar"));
            foreach (string item in Localidades) {
                ddl.Items.Add(new ListItem(item));
            }
        }
        /// <summary>
        /// Agrega una localidad a la lista de localidades.
        /// </summary>
        /// <param name="localidad">Nombre de la localidad a agregar.</param>
        /// <returns>True si se agregó la localidad a la lista, False si no, ya sea porque ya existía o no contenía letras.</returns>
        public bool Agregar(string nombre, out string msj, object control = null) {
            msj = "Error desconocido. ";
            bool existe = Existe(nombre);
            bool contieneletras = ContieneLetra(nombre);
            if (!existe && contieneletras) {
                string nombreAdecuado = FormatearTexto(nombre);
                Localidades.Add(nombreAdecuado);
                if (control != null) {
                    CargarDropDownList((DropDownList)control);
                }
                msj = "Localiddad agregada con éxito. ";
                return true;
            }
            if (existe) msj = "La localidad ya existe en la lista. Intente con otra. ";
            if (!contieneletras) msj = "El nombre de la localidad debe contener al menos una letra. ";
            return false;
        }
        /// <summary>
        /// Obtiene la lista de localidades como una lista de strings.
        /// </summary>
        /// <returns>Lista de localidades como una lista de strings.</returns>
        public List<string> GetAsList() {
            return Localidades;
        }
    }
}
