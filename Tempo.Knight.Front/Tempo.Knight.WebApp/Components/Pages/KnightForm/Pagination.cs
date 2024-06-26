using Microsoft.AspNetCore.Components;

namespace Tempo.Knight.WebApp.Components.Pages.KnightForm
{
    public partial class Pagination
    {
        [Parameter] public int TotalItems { get; set; }
        [Parameter] public int ItemsPerPage { get; set; } = 10;
        [Parameter] public EventCallback<int> OnPageChanged { get; set; }

        private int CurrentPage { get; set; } = 1;

        private int TotalPages => (int)Math.Ceiling((double)TotalItems / ItemsPerPage);

        private   void SelectPageAsync(int page)
        {
            if (page >= 1 && page <= TotalPages)
            {
                CurrentPage = page;
                 OnPageChanged.InvokeAsync(CurrentPage);
                StateHasChanged();

            }
        }
    }
}
