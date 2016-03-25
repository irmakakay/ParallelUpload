namespace ParallelUpload
{
    public class DefaultMessageFormatter : IMessageFormatter
    {
        #region Implementation of IMessageFormatter

        public string Format<T>(T message, params object[] @params)
        {
            return string.Format(message.ToString(), @params);
        }

        #endregion
    }
}