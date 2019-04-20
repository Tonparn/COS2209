using Final.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using System.Threading.Tasks;

namespace Final.Client.Pages.Login
{
    public class LoginModel : ComponentBase
    {
        [Inject] protected UserState UserState { get; set; }
        [Inject] protected IUriHelper UriHelper { get; set; }

        protected Credentials Credens { get; set; } = new Credentials();
        protected bool ShowLoginFailed { get; private set; }
        protected string ShowStatus { get; private set; }

        protected override async Task OnInitAsync()
        {
            await UserState.CheckToken();
        }

        protected async Task Login()
        {
            await UserState.Login(Credens);

            if (UserState.IsLoggedIn)
            {
                UriHelper.NavigateTo("/reload");
            }
            else
            {
                ShowStatus = UserState.Status;
                ShowLoginFailed = true;
            }
        }

    }
}