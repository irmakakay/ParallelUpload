﻿namespace ParallelUpload
{
    public class UploadConfiguration : IUploadConfiguration
    {
        #region Implementation of IUploadConfiguration

        public string SourceDir { get { return StringConstants.SourceDir; } }

        public string TargetDir { get { return StringConstants.TargetDir; } }

        #endregion
    }
}
