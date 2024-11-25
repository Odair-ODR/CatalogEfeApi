namespace InterfaceAdapters.Utils
{
    internal static class ConvertDataType
    {
        /// <summary>
        /// Convierte el objeto a string. Si el objeto es nulo, entonces, devuelve una cadena vacía
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToStringNull(this object? s) => Convert.ToString(s)!;
        /// <summary>
        /// Convierte el objeto a string. Lanza una excepción si el objeto es nulo
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToSString(this object s) => s == null ? throw new ArgumentNullException("parameters 's' ToSString method") : s.ToString()!;
        /// <summary>
        /// Convierte el objeto a boolean. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ToBoolean(this object b) => Convert.ToBoolean(b);
        /// <summary>
        /// Convierte el objeto a boolean. Si el dato es nulo o vacío retorna false
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ToBooleanNull(this object? b) => !string.IsNullOrEmpty(b.ToStringNull()) && int.TryParse(b.ToStringNull(), out _) && Convert.ToBoolean(Convert.ToInt32(b));
        /// <summary>
        /// Convierte el objeto a int32. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int ToInt32(this object i) => Convert.ToInt32(i);
        /// <summary>
        /// Convierte el objeto a int32. Si el dato es nulo o vacío retorna 0
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int ToInt32Null(this object? i) => !string.IsNullOrEmpty(i.ToStringNull()) ? Convert.ToInt32(i) : 0;
        /// <summary>
        /// Convierte el objeto a boolean. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static long ToInt64(this object i) => Convert.ToInt64(i);
        /// <summary>
        /// Convierte el objeto a int64|long. Si el dato es nulo o vacío retorna 0
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static long ToInt64Null(this object? i) => !string.IsNullOrEmpty(i.ToStringNull()) ? Convert.ToInt64(i) : 0;

        /// <summary>
        /// Convierte el objeto a double. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double ToDouble(this object d) => Convert.ToDouble(d);
        /// <summary>
        /// Convierte el objeto a double. Si el dato es nulo o vacío retorna 0
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double ToDoubleNull(this object? d) => !string.IsNullOrEmpty(d.ToStringNull()) ? Convert.ToDouble(d) : 0;

        /// <summary>
        /// Convierte el objeto a dateTime. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object d) => Convert.ToDateTime(d);

        /// <summary>
        /// Convierte el objeto a dateTime. Si el dato es nulo o vacío retorna null
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(this object? d) => !string.IsNullOrEmpty(d.ToStringNull()) ? Convert.ToDateTime(d) : null;

        /// <summary>
        /// Convierte el objeto a float. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static float ToFloat(this object d) => Convert.ToSingle(d);

        /// <summary>
        /// Convierte el objeto a float|single. Si el dato es nulo o vacío retorna 0
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static float ToFloatNull(this object? d) => !string.IsNullOrEmpty(d.ToStringNull()) ? Convert.ToSingle(d) : 0;

        /// <summary>
        /// Convierte el objeto a decimal. Se produce un error si el objeto es nulo o vacío
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object d) => Convert.ToDecimal(d);

        /// <summary>
        /// Convierte el objeto a decimal. Si el dato es nulo o vacío retorna 0
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ToDecimalNull(this object? d) => !string.IsNullOrEmpty(d.ToStringNull()) ? d!.ToDecimal() : 0;
    }
}
