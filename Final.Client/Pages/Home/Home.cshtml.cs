using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using System.Threading.Tasks;

namespace Final.Client.Pages.Home
{
    public class HomeModel : ComponentBase
    {
        [Inject] protected UserState UserState { get; set; }
        [Inject] protected IUriHelper UriHelper { get; set; }

        protected override async Task OnInitAsync()
        {
            await UserState.CheckToken();
        }
    }
}