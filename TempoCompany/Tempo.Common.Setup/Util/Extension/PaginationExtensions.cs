namespace Tempo.Common.Setup.Util.Extension
{
    public static class PaginationExtensions
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, int? pageNumber, int? pageSize)
        {
            var defaultPageSize = pageSize ?? 10;
            var defaultPage = (pageNumber > 0 ? pageNumber - 1 : 0) ?? 0;

            return source.Skip(defaultPage * defaultPageSize)
                         .Take(defaultPageSize)
                         .ToList();
        }

        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, int? pageNumber, int? pageSize)
        {
            var defaultPageSize = pageSize ?? 10;
            var defaultPage = (pageNumber > 0 ? pageNumber - 1 : 0) ?? 0;

            return source.Skip(defaultPage * defaultPageSize)
                         .Take(defaultPageSize);
        }

        public static int DefaultPageSize()
        {

            return 10;
        }
    }
}
