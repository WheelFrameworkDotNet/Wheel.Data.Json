using Newtonsoft.Json;
using Wheel.Data.Json.Exceptions;

namespace Wheel.Data.Json
{
    /// <summary>
    /// Representa el componente encargado de transformar objetos en Json y biseversa.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <h2 class="groupheader">Registro de versiones</h2>
    ///         <ul>
    ///             <li>1.0.0</li>
    ///             <table>
    ///                 <tr style="font-weight: bold;">
    ///                     <td>Autor</td>
    ///                     <td>Fecha</td>
    ///                     <td>Descripción</td>
    ///                 </tr>
    ///                 <tr>
    ///                     <td>Marcos Abraham Hernández Bravo.</td>
    ///                     <td>10/11/2016</td>
    ///                     <td>Versión Inicial.</td>
    ///                 </tr>
    ///             </table>
    ///         </ul>
    ///     </para>
    /// </remarks>
    public static class JsonConverter
    {
        /// <summary>
        /// Método que permite transformar objetos serializables en Json.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <exception cref="JsonConvertException"></exception>
        /// <param name="objeto">Objeto a transformar.</param>
        /// <returns>Json.</returns>
        public static string ToJson(this object objeto)
        {
            return ToJson(objeto, true);
        }

        /// <summary>
        /// Método que permite transformar objetos serializables en Json.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <exception cref="JsonConvertException"></exception>
        /// <param name="objeto">Objeto a transformar.</param>
        /// <param name="incluirTipo">Incluir información sobre el tipo del objeto.</param>
        /// <returns>Json.</returns>
        public static string ToJson(this object objeto, bool incluirTipo)
        {
            if (objeto == null) return null;

            try
            {
                if (incluirTipo)
                {
                    return JsonConvert.SerializeObject(objeto, GetJsonSettings());
                }

                return JsonConvert.SerializeObject(objeto);
            }
            catch (JsonSerializationException e)
            {
                throw new JsonConvertException(e.Message, e);
            }
        }

        /// <summary>
        /// Método que permite deserializar un json en el objeto original.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <typeparam name="T">Tipo del objeto original.</typeparam>
        /// <exception cref="JsonConvertException"></exception>
        /// <param name="json">Json que representa el objeto original.</param>
        /// <returns>El objeto original contenido en el Json.</returns>
        public static T ToObject<T>(this string json)
        {
            return ToObject<T>(json, true);
        }

        /// <summary>
        /// Método que permite deserializar un json en el objeto original.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <typeparam name="T">Tipo del objeto original.</typeparam>
        /// <param name="json">Json que representa el objeto original.</param>
        /// <param name="incluirTipo">Incluir información sobre el tipo del objeto.</param>
        /// <returns>El objeto original contenido en el Json.</returns>
        /// <exception cref="JsonConvertException"></exception>
        public static T ToObject<T>(this string json, bool incluirTipo)
        {
            if (json == null) return default(T);

            try
            {
                if (incluirTipo)
                {
                    return JsonConvert.DeserializeObject<T>(json, GetJsonSettings());
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonSerializationException e)
            {
                throw new JsonConvertException(e.Message, e);
            }
        }

        /// <summary>
        /// Método que permite deserializar un json en el objeto original.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <exception cref="JsonConvertException"></exception>
        /// <param name="json">Json que representa el objeto original.</param>
        /// <returns>El objeto original contenido en el Json.</returns>
        public static object ToObject(this string json)
        {
            return ToObject(json, true);
        }

        /// <summary>
        /// Método que permite deserializar un json en el objeto original.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="json">Json que representa el objeto original.</param>
        /// <param name="incluirTipo">Incluir información sobre el tipo del objeto.</param>
        /// <returns>El objeto original contenido en el Json.</returns>
        /// <exception cref="JsonConvertException"></exception>
        public static object ToObject(this string json, bool incluirTipo)
        {
            if (json == null) return null;

            try
            {
                if (incluirTipo)
                {
                    return JsonConvert.DeserializeObject(json, GetJsonSettings());
                }

                return JsonConvert.DeserializeObject(json);
            }
            catch (JsonSerializationException e)
            {
                throw new JsonConvertException(e.Message, e);
            }
        }

        /// <summary>
        /// Método que retorna la configuración de serialización a utilizar para la transformación.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <returns>Configuración de serialización.</returns>
        private static JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }
    }
}
