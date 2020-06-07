using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
