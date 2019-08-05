namespace ShapeSquareProcesser
{
    /// <summary>
    /// Фигура
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Проверить фигуру на возможность расчета
        /// </summary>
        /// <returns>Возможность расчета</returns>
        bool IsValid();
    }
}