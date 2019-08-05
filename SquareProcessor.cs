namespace ShapeSquareProcesser
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Процессор получения площади фигуры
    /// </summary>
    public static class SquareProcesser
    {
        /// <summary>
        /// Получить площадь фигуры
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <returns>Площадь</returns>
        public static double GetSquare(IShape shape)
        {
            if (!shape.IsValid())
            {
                throw new ArgumentException();
            }
            
            return (double)ReflectionHelper.CallStaticGenericMethod(
                typeof(SquareProcesser),
                nameof(GetSquareGeneric),
                BindingFlags.Static | BindingFlags.NonPublic,
                new[] { shape.GetType() },
                shape);
        }

        private static double GetSquareGeneric<TShape>(TShape shape)
        where TShape : IShape
        {
            return ReflectionHelper.GetResolvedProcesser<TShape>(shape).GetSquare(shape);
        }

        /// <summary>
        /// Получить площадь треугольника
        /// </summary>
        /// <param name="cathet1">Катет1</param>
        /// <param name="cathet2">Катет2</param>
        /// <param name="hypotinuse">Гипотенуза</param>
        /// <returns>Площадь треугольника</returns>
        public static double GetSquareOfTringale(double cathet1, double cathet2, double hypotinuse)
        {
            var triangle = new SimpleTriangle()
            {
                Cathet1 = cathet1,
                Cathet2 = cathet2,
                Hypotenuse = hypotinuse
            };

            return GetSquare(triangle);
        }
        
        /// <summary>
        /// Получить площадь треугольника
        /// </summary>
        /// <param name="radius">Радиус</param>
        /// <returns>Площадь круга</returns>
        public static double GetSquareOfCircle(double radius)
        {
            var circle = new SimpleCircle()
            {
                Radius = radius
            };

            return GetSquare(circle);
        }
    }
}