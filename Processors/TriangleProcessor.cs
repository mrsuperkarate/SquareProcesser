namespace ShapeSquareProcesser
{
    using System;

    /// <summary>
    /// Расчет площади триугольника
    /// </summary>
    internal class TriangleProcessor : IShapeProcesser<ITriangle>
    {
        /// <summary>
        /// Получить площадь
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <returns>Площадь фигуры</returns>
        public double GetSquare(ITriangle shape)
        {
            ////Не совсем понятно зачем в задаче плюс за проверку на прямоугольность?
            var perimeter = shape.Cathet1 + shape.Cathet2 + shape.Hypotenuse;

            var formulaResult = (perimeter * 
                           (perimeter - shape.Cathet1) * 
                           (perimeter - shape.Cathet2) *
                           (perimeter - shape.Hypotenuse));
            
            return Math.Sqrt(formulaResult);
        }
    }
}