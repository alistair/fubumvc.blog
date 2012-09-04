using System;
using AutoMapper;

namespace Blog.Core.Extensions
{
    public static class MapperExtensions
    {
         public static T DynamicMap<T>(this object source)
         {
             if (source == null)
                 return default(T);
             try
             {
                return (T) Mapper.DynamicMap(source, source.GetType(), typeof (T));
             }
             catch (Exception)
             {
                 throw;
                 //TODO: log and return default(T);
             }
         }
    }
}