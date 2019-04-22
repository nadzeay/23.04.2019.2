- Как альтернативу классу EnumerableExtension создать класс Enumerable, содержащий 
  - методы для фильтрации и трансформации, использующие в качестве параметров версии типа делегат [`Func<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=netframework-4.8), перегруженные по параметрам;
  - метод SortBy, использующий стратегию сортировки по ключу (сортировка по возрастанию);
  - метод SortBy, использующий стратегию сравнения двух ключу (сортировка по возрастанию);
  - Добавить метод SortByDescending, который реализует сортировку по убыванию по ключу. 
      
            public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource> predicate) { }
            
            public static IEnumerable<TResult> Transform<TSource,TResult>(this IEnumerable<TSource>, Func<TSource, TResult> transformer) { }
            
            public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource>, Func<TSource,TKey> comparer) { }
            
            public static IEnumerable<TSource> SortByDescending<TSource>(this IEnumerable<TSource>, Func<TSource,TKey> comparer) { }
  
- (deadline - 23.04.2019, 24.00) Разработать (использовать код [Day 1 - 19.03.2019](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%201%20-%2019.03.2019) и [Day 11 - 11.04.2019](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%2011%20-%2011.04.2019)) статичесикий класс-хэлпер для поддержки операций с обобщенными массивами (методы сортировки - быстрая и слиянием, метод бинарного поиска). Предусмотреть возможность настройки логики сравнения, используя подходы, как на основе интерфейсов, так и на основе делегатов ([делегат](https://docs.microsoft.com/en-us/dotnet/api/system.comparison-1?view=netframework-4.8)). Продумать возможный набор удобных для использования перегруженных версий методов. Продемонстрировать работу разработанных методов, используя разработанные тесты [Day 1 - 19.03.2019](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%201%20-%2019.03.2019) и пользовательские типы (класс книга [Day 8 - 04.04.2019](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%208%20-%2004.04.2019)).
