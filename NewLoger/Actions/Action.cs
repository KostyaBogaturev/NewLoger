namespace NewLoger.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NewLoger.Enum;
    using NewLoger.Helper;
    using NewLoger.Logger;

    /// <summary>
    /// Class when we will throw exeptions and info messages.
    /// </summary>
    public class Action
    {
        private readonly Loger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        public Action()
        {
            this.logger = Loger.GetInstance();
        }

        /// <summary>
        /// Method with throw info message.
        /// </summary>
        public void InfoMessage()
        {
            this.logger.Log(LogType.Info, $"Info message{nameof(this.InfoMessage)}");
        }

        /// <summary>
        /// Method with throw exeption message.
        /// </summary>
        public void ExeptionMessage()
        {
            throw new Exception("I broke a toilet(((");
        }

        /// <summary>
        /// Method with throw Business exeption message.
        /// </summary>
        public void BusinessExeptionMessage()
        {
            throw new BusinessExeption($"{nameof(this.BusinessExeptionMessage)}");
        }
    }
}
