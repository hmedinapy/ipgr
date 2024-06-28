using API.Data.Entities;
using Ipgr.Front.Repository;
using Microsoft.AspNetCore.Components;

namespace Ipgr.Front.Pages.AreaPage
{
    public partial class AreaIndex
    {
        [Inject] private IRepository Repository { get; set; }
        public List<Area>? Areas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var responseHttp = await Repository.GetAsync<List<Area>>("api/Area");
            Areas = responseHttp.Response;
        }
    }
}
