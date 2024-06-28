

namespace Tempo.Knight.WebApp.Components.Pages.KnightForm
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResponse<T> where T : new()
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

        public PagedResponse(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
        {

            Items = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public PagedResponse()
        {

            Items = new List<T>();
            PageNumber = 0;
            PageSize = 0;
            TotalCount = 0;
        }

    }
}

