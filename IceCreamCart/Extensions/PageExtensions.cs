using IceCreamCart.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IceCreamCart.Extensions
{
    public static class PageExtensions
    {
        public static void Dosomething<TEntity>(this TEntity entity) where TEntity : class
        {
            Console.WriteLine(entity.ToString());
        }
    }
}
