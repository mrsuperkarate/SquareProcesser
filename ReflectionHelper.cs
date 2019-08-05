using System;
using System.Linq;
using System.Reflection;

namespace ShapeSquareProcesser
{
    /// <summary>
    /// Вспомогательные методы для рефлексии
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Получить процессор по типу объекта
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <typeparam name="TShape">Тип объекта</typeparam>
        /// <returns>Процессор по типу объекта</returns>
        internal static IShapeProcesser<TShape> GetResolvedProcesser<TShape>(IShape shape)
        where TShape : IShape
        {
            //// Можно было бы использовать IoC, и это было бы суперлегко, я бы так и делал на проекте, но не хотелось лишних зависимостей в такой простой либе, когда начинал это писать. Работает так себе, с ограничениями.
            var interfaceType = typeof(IShapeProcesser<>);
            
            ////Можно закешировать конечно все что ниже.
            var allGenericTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass && IsSubclassOfOpenGenericInterface(interfaceType, p));

            var shapeInterface = shape.GetType().GetInterfaces().Single(z => z != typeof(IShape) 
                                                                             && typeof(IShape).IsAssignableFrom(z));
            var creatingType = allGenericTypes.Single(z =>
                z.GetInterfaces()
                    .FirstOrDefault(a => a.IsGenericType
                                         && a.GetGenericTypeDefinition() == interfaceType)
                    .GetGenericArguments()[0] == shapeInterface);
            
            return (IShapeProcesser<TShape>)Activator.CreateInstance(creatingType);
        }
        
        /// <summary>
        /// Является ли тип наследником базового с проверкой на открытый дженерик
        /// </summary>
        /// <param name="baseType">базовый тип</param>
        /// <param name="derived">Проверяемый тип</param>
        /// <returns>Является наследником</returns>
        internal static bool IsSubclassOfOpenGenericInterface(Type baseType, Type derived)
        {
            foreach (var inter in derived.GetInterfaces())
            {
                var current = inter.IsGenericType 
                    ? inter.GetGenericTypeDefinition() 
                    : inter;
                
                if (baseType == current) 
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Вызвать дженерик метод зная его тип
        /// </summary>
        /// <param name="type">Тип</param>
        /// <param name="method">Метод</param>
        /// <param name="genericAgruments">Дженерик метод</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>Результат метода</returns>
        internal static object CallStaticGenericMethod(Type type, string methodName, BindingFlags bindingFlags, Type[] genericAgruments, params object[] parameters)
        {
            var method = type.GetMethod(methodName, bindingFlags);
            var closedGenericMethod = method.MakeGenericMethod(genericAgruments);
            return closedGenericMethod.Invoke(null, parameters);
        }
    }
}