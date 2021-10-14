using System;
using System.Collections.Generic;

namespace MyLinq.Logic
{
    static public class IEnumerableExtensions
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The filtered collection.</returns>
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

        /// <summary>
        /// Executes a action for every item in a collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to execute a action from.</param>
        /// <param name="action">The action that will be executed for every item in the collection.</param>
        /// <returns>The source sequence.</returns>
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


        /// <summary>
        /// Converts every item of a <T> Collection to a <TResult> Collection with a mapping Function
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result.</typeparam>
        /// <param name="source">An IEnumerable<T> to convert to An IEnumerable<TResult></param>
        /// <param name="mapping">The function that converts an item from <T> to <TResult></param>
        /// <returns>A collection with the type TResult</returns>
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

        /// <summary>
        /// Creates an array from a IEnumerable<T>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to create an array from.</param>
        /// <returns>An array that contains the elements from the input sequence.</returns>
        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            source.CheckArgument(nameof(source));
            
            return new List<T>(source).ToArray();
        }

        /// <summary>
        /// Creates a List from an Array<T>
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to create a list from.</param>
        /// <returns>A List that contains the elements from the input sequence.</returns>
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

        /// <summary>
        /// Calculates the sum of every item in a collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to calculate the sum from.</param>
        /// <param name="transform">A function that can transform every item in the collection.</param>
        /// <returns>Sum</returns>
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

        /// <summary>
        /// Calculates the Minimum of the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to calculate the minimum from.</param>
        /// <param name="transform">A function that can transform every item in the collection.</param>
        /// <returns>Minimum</returns>
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

        /// <summary>
        /// Calculates the Maximum of the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to calculate the minimum from.</param>
        /// <param name="transform">A function that can transform every item in the collection.</param>
        /// <returns>Maximum</returns>
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

        /// <summary>
        /// Calculates the Average of the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An IEnumerable<T> to calculate the average from.</param>
        /// <param name="transform">A function that can transform every item in the collection.</param>
        /// <returns>Average</returns>
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

        /// <summary>
        /// Executes a action for every item in a collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the source.</typeparam>
        /// <param name="source">An IEnumerable<T> to execute a action from.</param>
        /// <param name="action">The action that will be executed for every item in the collection.</param>
        /// <returns>The source sequence.</returns>
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

    }
}
