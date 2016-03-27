namespace ParallelUpload
{
    public class UploadConfiguration : IUploadConfiguration
    {
        #region Implementation of IUploadConfiguration

        public string SourceDir { get { return StringConstants.SourceDir; } }

        public string TargetFir { get { return StringConstants.TargetDir; } }

        #endregion
    }
}
