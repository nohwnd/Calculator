namespace Calculator.Core
{
    public interface INumberCruncher
    {
        /// <summary>
        ///     Applies all the queued operations to the given value.
        /// </summary>
        /// <param name="value">Intial value of the operation.</param>
        decimal Apply(decimal value);

        /// <summary>
        ///     Adds an ADD operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that will be added to the current value.</param>
        NumberCruncher Add(decimal value);

        /// <summary>
        ///     Adds a SUBTRACT operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that will be subtracted from the current value.</param>
        NumberCruncher Subtract(decimal value);

        /// <summary>
        ///     Adds a MULTIPLY operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that the current value will be multiplied by.</param>
        NumberCruncher Multiply(decimal value);

        /// <summary>
        ///     Adds a DIVIDE operation to the operation queue.
        /// </summary>
        /// <param name="value">Value that the current value will be divided by.</param>
        NumberCruncher Divide(decimal value);
    }
}