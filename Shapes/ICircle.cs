namespace ShapeSquareProcesser
{
    /// <summary>
    /// Круг
    /// </summary>
    public interface ICircle : IShape
    {
        /// <summary>
        /// Радиус
        /// </summary>
        double Radius { get; set; }
    }
}