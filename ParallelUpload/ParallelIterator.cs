using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public class ParallelIterator : IParallelIterator
    {        
        private readonly IMessageFormatter _formatter;

        public ParallelIterator(IMessageFormatter formatter)
        {            
            _formatter = formatter;
        }

        #region Implementation of IParallelIterator

        public Task ForEachAsync<T>(
            BlockingCollection<ILogMessage> messages,
            IEnumerable<T> source, 
            int numberOfThreads, 
            Func<T, Task> iterate)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(numberOfThreads)
                select Task.Run(async delegate
                {
                    using (partition)
                        while (partition.MoveNext())
                        {
                            await iterate(partition.Current);
                            messages.Add(_formatter.Format(partition.Current));
                        }
                }));
        }

        #endregion
    }
}