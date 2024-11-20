using Microsoft.JSInterop;

namespace TelegramMiniApp.Services
{
    public class TelegramService
    {
        private readonly IJSRuntime _jsRuntime;

        public TelegramService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            await _jsRuntime.InvokeVoidAsync("Telegram.WebApp.ready");
        }

        public async Task<string> GetUserName()
        {
            return await _jsRuntime.InvokeAsync<string>("eval", "window.Telegram.WebApp.initDataUnsafe.user.username");
        }

        public async Task ShowAlert(string message)
        {
            await _jsRuntime.InvokeVoidAsync("Telegram.WebApp.showAlert", message);
        }
    }
}