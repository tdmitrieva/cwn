using AutoMapper;

namespace Income.DataTransferObjects.MappingEngine
{
    public static class ModelMapper
    {
        private static IMapper mapper;
        internal static void Initialize(IMapper mapperInstance)
        {
            mapper = mapperInstance;
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TDestination>(source);
        }

        public static TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
