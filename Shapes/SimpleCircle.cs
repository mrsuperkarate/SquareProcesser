namespace ShapeSquareProcesser
{
    /// <summary>
    /// Круг
    /// </summary>
    internal class SimpleCircle : ICircle
    {
        /// <summary>
        /// Радиус
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Проверить фигуру на возможность расчета
        /// </summary>
        /// <returns>Возможность расчета</returns>
        bool IShape.IsValid()
        {
            return Radius > 0;
        }
    }
}