namespace ReportIT.Infrastructure.Base.Adapter
{
    public class TypeAdapterFactory
    {
        #region Members

        static ITypeAdapterFactory _typeAdapterFactory;

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the factory to use
        /// </summary>
        public static void SetCurrent(ITypeAdapterFactory typeAdapterFactory)
        {
            _typeAdapterFactory = typeAdapterFactory;
        }

        /// <summary>
        /// Creates a new ILogger
        /// </summary>
        /// <returns>Created ILogger</returns>
        public static ITypeAdapter Create()
        {
            return _typeAdapterFactory?.Create();
        }

        #endregion
    }
}
