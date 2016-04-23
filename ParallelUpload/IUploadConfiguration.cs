namespace ParallelUpload
{
    public interface IUploadConfiguration
    {
        string SourceDir { get; }

        string TargetDir { get; }
    }
}