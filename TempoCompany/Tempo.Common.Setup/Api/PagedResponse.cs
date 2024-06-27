using Tempo.Common.Setup.Error;
using Tempo.Common.Setup.Util.Extension;

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / PageSize);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return PageNumber < TotalPages;
            }
        }
        public bool HasPreviousPage
        {
            get
            {
                return PageNumber > 1;
            }
        }

        public PagedResponse(IEnumerable<T> data, int pageNumber, int? pageSize, int totalCount)
        {

            Items = data;
            PageNumber = pageNumber;
            PageSize = pageSize.GetValueOrDefault(PaginationExtensions.DefaultPageSize());
            TotalCount = totalCount;
        }
    }
}

