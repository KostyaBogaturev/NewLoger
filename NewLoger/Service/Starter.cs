namespace NewLogger
{
    using System;
    using NewLoger.Actions;
    using NewLoger.Enum;
    using NewLoger.Helper;
    using NewLoger.Logger;

    /// <summary>
    /// Starter class .
    /// </summary>
    public class Starter
    {
        private readonly Actions actions;
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Starter"/> class.
        /// </summary>
        public Starter()
        {
            this.actions = new Actions();
            this.logger = Logger.GetInstance();
        }

        /// <summary>
        /// funk for random call testing functions.
        /// </summary>
        public void Run()
        {
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (rand.Next(0, 3))
                    {
                        case 0:
                            this.actions.InfoMessage();
                            break;
                        case 1:
                            this.actions.ExeptionMessage();
                            break;
                        case 2:
                            this.actions.BusinessExeptionMessage();
                            break;
                    }
                }
                catch (BusinessExeption businessEx)
                {
                    this.logger.Log(LogType.Warning, "Custom exception ", businessEx);
                }
                catch (Exception exeption)
                {
                    this.logger.Log(LogType.Error, "Stundart exeption", exeption);
                }
            }
        }
    }
}