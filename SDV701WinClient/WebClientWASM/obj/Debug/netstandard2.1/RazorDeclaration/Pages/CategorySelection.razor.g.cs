#pragma checksum "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\Pages\CategorySelection.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "350946152ccc7cd38d6a900a5356e53a87b44023"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebClientWASM.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using WebClientWASM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using WebClientWASM.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\_Imports.razor"
using BlazorStyled;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\Pages\CategorySelection.razor"
using grpcCalls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\Pages\CategorySelection.razor"
using SDV701common;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/category")]
    public partial class CategorySelection : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "E:\@SkyDrive\SkyDrive\@backup\@nmit\SDV701\A2\SDV701WinClient\WebClientWASM\Pages\CategorySelection.razor"
       
    private string styleContainer;
    private string navLinkStyle;
    private string lastError = "";
    private List<Category> lst = new List<Category>();

    protected override async void OnInitialized()
    {
        WebClientWASM.infrastructure.State.previousPage = "/";
        lastError = "";
        try
        {
            lst = await gRPCClient.GetListOfCategories();
        }
        catch (Exception e)
        {
            lastError = e.GetBaseException().Message;
        }
        this.StateHasChanged();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
