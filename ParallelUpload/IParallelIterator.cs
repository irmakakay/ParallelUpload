using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public interface IParallelIterator
    {
        Task ForEachAsync<T>(
            BlockingCollection<string> messages,
            IEnumerable<T> source, 
            int numberOfThreads, 
            Func<T, Task> iterate);
    }
}