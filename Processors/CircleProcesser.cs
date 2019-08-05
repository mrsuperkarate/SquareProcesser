namespace ShapeSquareProcesser
{
    using System;

    /// <summary>
    /// Расчет площади круга
    /// </summary>
    internal class CircleProcesser : IShapeProcesser<ICircle>
    {
        /// <summary>
        /// Получить площадь круга
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <returns></returns>
        public double GetSquare(ICircle shape)
        {
            return Math.PI * shape.Radius * shape.Radius;
        }
    }
}