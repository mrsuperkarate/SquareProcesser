namespace ShapeSquareProcesser
{
    /// <summary>
    /// Расчет площади фигуры
    /// </summary>
    /// <typeparam name="TShape">Тип фигуры</typeparam> 
    internal interface IShapeProcesser<in TShape>
    where TShape : IShape
    {
        /// <summary>
        /// Получить площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        double GetSquare(TShape shape);
    }
}