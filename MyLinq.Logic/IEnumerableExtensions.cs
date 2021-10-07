using System;
using System.Collections.Generic;

namespace MyLinq.Logic
{
    static public class IEnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            source.CheckArgument(nameof(source));
            predicate.CheckArgument(nameof(predicate));

            var result = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source.CheckArgument(nameof(source));

            if (action != null)
            {
                foreach (var item in source)
                {
                    action(item);
                }
            }

            return source;
        }

        

        public static IEnumerable<TResult> Map<T, TResult> (this IEnumerable<T> source, Func<T, TResult> mapping)
        {
            source.CheckArgument(nameof(source));
            mapping.CheckArgument(nameof(source));

            var result = new List<TResult>();

            foreach (var item in source)
            {
                result.Add(mapping(item));
            }

            return result;
        }

        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            source.CheckArgument(nameof(source));
            return new List<T>(source).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToList<T>(this T[] source)
        {
            source.CheckArgument(nameof(source));
            var result = new List<T>();

            foreach (var item in source)
            {
                result.Add(item);
            }

            return result;
        }

        public static double Sum<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            transform.CheckArgument(nameof(transform));
            double sum = 0;
            foreach (var item in source)
            {
                sum += transform(item);
            }
            return sum;
        }

        public static double Min<T>(this IEnumerable<T> source, Func<T,double> transform)
        {
            source.CheckArgument(nameof(source));
            transform.CheckArgument(nameof(transform));
            double result = double.MaxValue;
            double puffer;
            foreach (var item in source)
            {
                puffer = transform(item);
                if (puffer<result)
                {
                    result = puffer;
                }
            }
            return result;
        }

        public static double Max<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            transform.CheckArgument(nameof(transform));
            double result = double.MinValue;
            double puffer;
            foreach (var item in source)
            {
                puffer = transform(item);
                if (puffer > result)
                {
                    result = puffer;
                }
            }
            return result;
        }

        public static double Average<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            transform.CheckArgument(nameof(transform));
            double avg = 0;
            double cnt = 0;
            foreach (var item in source)
            {
                avg += transform(item);
                cnt++;
            }
            avg = avg / cnt;
            return avg;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<int, T> action)
        {
            source.CheckArgument(nameof(source));
            
            int index = 0;
            if (action != null)
            {
                foreach (var item in source)
                {
                    action(index, item);
                    index++;
                }
            }

            return source;
        }

        // public static IEnumerable<T> SortBy<T,Tkey>(this IEnumerable<T> source, )
    }
}
