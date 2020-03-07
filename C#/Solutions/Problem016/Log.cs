using System.Collections.Generic;

namespace DailyCodingProblems.Solutions.Problem016
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
