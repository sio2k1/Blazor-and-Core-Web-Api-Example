/*
 * Author: Oleg Sivers
 * Date: 06.06.2020
 * Desc: Back button navigation handler
*/

using Microsoft.AspNetCore.Components;
using WebClientWASM.infrastructure;

namespace WebClientWASM
{
    public class backHandler:ComponentBase
    {
        protected void NavigateWithHistory(string url, string fromPage, NavigationManager manager)
        {
            State.previousPage = fromPage;
            manager.NavigateTo(url);
        }
    }
}
