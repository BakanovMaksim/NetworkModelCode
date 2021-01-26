using AutoMapper;

using System.Collections.Generic;

namespace NetworkModelCode.Desktop.Infrastructure
{
    public class Mapper
    {
        public static TDestiantion Map<TSource,TDestiantion>(TSource source) 
            where TSource : class 
            where TDestiantion : class
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestiantion>());
            var mapper = new AutoMapper.Mapper(configuration);

            return mapper.Map<TDestiantion>(source);
        }

        public static TCollectionDestination MapCollection<TSource, TDestination, TCollectionSource, TCollectionDestination>(TCollectionSource source)
            where TSource : class
            where TDestination : class
            where TCollectionSource : class
            where TCollectionDestination: class
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = new AutoMapper.Mapper(configuration);

            return mapper.Map<TCollectionDestination>(source);
        }
    }
}
