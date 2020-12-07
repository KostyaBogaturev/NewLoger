namespace NewLoger.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// New custom exeption.
    /// </summary>
    public class BusinessExeption : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessExeption"/> class.
        /// </summary>
        /// <param name="methodName">text of smessage.</param>
        public BusinessExeption(string methodName)
        : base($"Skipped logic in method:{methodName}")
        {
        }
    }
}
