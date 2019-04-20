using Final.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using System.Threading.Tasks;

namespace Final.Client.Pages.Register
{
    public class RegisterModel : ComponentBase
    { 
        [Inject] protected UserState UserState { get; set; }
        [Inject] protected IUriHelper UriHelper { get; set; }

        protected UserParam RegisterDetails { get; set; } = new UserParam();
        protected bool ShowRegisterFailed { get; set; }
        protected string ShowStatus { get; set; }

        protected override async Task OnInitAsync()
        {
            await UserState.CheckToken();
        }

        protected async Task Register()
        {
            await UserState.Register(RegisterDetails);

            if (UserState.IsRegister)
            {
                UriHelper.NavigateTo("/login");
            }
            else
            {
                ShowStatus = UserState.Status;
                ShowRegisterFailed = true;
            }
        }
    }
}
