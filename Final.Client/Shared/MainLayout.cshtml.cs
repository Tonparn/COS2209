using Final.Client.AppState;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using Microsoft.AspNetCore.Components.Services;
using System.Threading.Tasks;

namespace Final.Client.Shared
{
    public class MainLayoutModel : LayoutComponentBase
    {
        [Inject] protected UserState UserState { get; set; }
        [Inject] protected LearningState LearningState { get; set; }
        [Inject] protected IUriHelper UriHelper { get; set; }

        protected override async Task OnInitAsync()
        {
            await UserState.CheckToken();
        }

        protected async Task Logout()
        {
            await UserState.Logout();

            UriHelper.NavigateTo("/reload");
            UriHelper.NavigateTo("/");
        }
    }
}
