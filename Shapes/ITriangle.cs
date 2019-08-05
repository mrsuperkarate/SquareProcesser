namespace ShapeSquareProcesser
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public interface ITriangle : IShape
    {
        /// <summary>
        /// Катет 1
        /// </summary>
        double Cathet1 { get; set; }
        
        /// <summary>
        /// Катет 2
        /// </summary>
        double Cathet2 { get; set; }
        
        /// <summary>
        /// Гипотенуза
        /// </summary>
        double Hypotenuse { get; set; }
    }
}