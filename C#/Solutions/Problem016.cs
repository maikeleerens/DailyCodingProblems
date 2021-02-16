using System.Collections.Generic;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Twitter.
    /// 
    /// You run an e-commerce website and want to record the last N order ids in a log. Implement a data structure to accomplish this, with the following API:
    /// 
    /// record(order_id): adds the order_id to the log
    /// 
    /// get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
    /// 
    /// You should be as efficient with time and space as possible.
    /// </summary>
    public static class Problem016
    {
        /// <summary>
        /// Log that contains the orderIds
        /// </summary>
        public class Log
        {
            private readonly IList<int> _log;

            public int Size { get; }

            public Log(int size)
            {
                _log = new List<int>();
                Size = size;
            }

            /// <summary>
            /// Adds the order_id to the log
            /// </summary>
            /// <param name="orderId"></param>
            public void Record(int orderId)
            {
                if (_log.Count == Size)
                    _log.RemoveAt(0);

                _log.Add(orderId);
            }

            /// <summary>
            /// Gets the ith last element from the log
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public int GetLast(int i)
            {
                return _log[^i];
            }
        }
    }
}
