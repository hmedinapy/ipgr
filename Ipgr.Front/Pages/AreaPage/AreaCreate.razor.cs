using API.Data.Entities;
using CurrieTechnologies.Razor.SweetAlert2;
using Ipgr.Front.Repository;
using Microsoft.AspNetCore.Components;

namespace Ipgr.Front.Pages.AreaPage
{
    public partial class AreaCreate
    {
        private Area area = new Area();
        private AreaForm? areaForm;
        [Inject] private IRepository repository { get; set; } = null!;
        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager navigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await repository.PostAsync("api/Areas", area);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message);
                return;
            }

            Return();

            var toast = sweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito.");
        }
        private void Return()
        {
            areaForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo("Areas");
        }
    }
}
