using System;
using System.Collections.Generic;

namespace Calculator.Core
{
    /// <summary>
    ///     Provides a simple fluent API to queue operations and apply them on a given value.
    /// </summary>
    public class NumberCruncher : INumberCruncher
    {
        private readonly List<Action> _commandQueue = new List<Action>();
        private decimal _intermediateResult;

        /// <summary>
        ///     Applies all the queued operations to the given value.
        /// </summary>
        /// <param name="value">Intial value of the operation.</param>
        public decimal Apply(decimal value)
        {
            _intermediateResult = value;
            foreach (var command in _commandQueue)
            {
                command.Invoke();
            }
            return _intermediateResult;
        }


        /// <summary>
        ///     Adds an ADD operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that will be added to the current value.</param>
        public NumberCruncher Add(decimal value)
        {
            _commandQueue.Add(() => _intermediateResult += value);
            return this;
        }

        /// <summary>
        ///     Adds a SUBTRACT operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that will be subtracted from the current value.</param>
        public NumberCruncher Subtract(decimal value)
        {
            _commandQueue.Add(() => _intermediateResult -= value);
            return this;
        }

        /// <summary>
        ///     Adds a MULTIPLY operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that the current value will be multiplied by.</param>
        public NumberCruncher Multiply(decimal value)
        {
            _commandQueue.Add(() => _intermediateResult *= value);
            return this;
        }

        /// <summary>
        ///     Adds a DIVIDE operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that the current value will be divided by.</param>
        public NumberCruncher Divide(decimal value)
        {
            _commandQueue.Add(() => _intermediateResult /= value);
            return this;
        }
    }
}