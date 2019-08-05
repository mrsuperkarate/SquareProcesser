namespace ShapeSquareProcesser
{
    /// <summary>
    /// Треугольник
    /// </summary>
    internal class SimpleTriangle : ITriangle
    {
        /// <summary>
        /// Катет 1
        /// </summary>
        public double Cathet1 { get; set; }
        
        /// <summary>
        /// Катет 2
        /// </summary>
        public double Cathet2 { get; set; }
        
        /// <summary>
        /// Гипотенуза
        /// </summary>
        public double Hypotenuse { get; set; }

        /// <summary>
        /// Проверить фигуру на возможность расчета
        /// </summary>
        /// <returns>Возможность расчета</returns>
        public bool IsValid()
        {
            return Cathet1 > 0
                   && Cathet2 > 0
                   && Hypotenuse > 0;
        }
    }
}