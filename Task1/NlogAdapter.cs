using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    /// <summary>
    /// Adapter for using NLog for writing logs.
    /// </summary>
    public class NlogAdapter : ILogger
    {

        #region private fields

        /// <summary>
        /// 
        /// </summary>
        private readonly Logger log;

        #endregion


        #region Constructor

        public NlogAdapter(Logger log)
        {
            if (ReferenceEquals(log, null))
                throw new ArgumentNullException(nameof(log));

            this.log = log;
        }

        #endregion


        #region ILoggerMethods

        /// <summary>
        /// write information about regular actions
        /// </summary>
        /// <param name="message">message</param>
        void ILogger.Debug(string message) => log.Debug(message);

        /// <summary>
        /// write fatal error
        /// </summary>
        /// <param name="message">message</param>
        void ILogger.Fatal(string message) => log.Fatal(message);

        /// <summary>
        /// write information about single operation
        /// </summary>
        /// <param name="message">message</param>
        void ILogger.Info(string message) => log.Info(message);

        /// <summary>
        /// write all information
        /// </summary>
        /// <param name="message">message</param>
        void ILogger.Trace(string message) => log.Trace(message);

        /// <summary>
        /// write surprised information
        /// </summary>
        /// <param name="message">message</param>
        void ILogger.Warn(string message) => log.Warn(message);

        /// <summary>
        /// write error
        /// </summary>
        /// <param name="message">message</param>
        void ILogger.Error(string message) => log.Error(message);

        #endregion
    }
}