#pragma checksum "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d35d0922b16f6ca3c6da475a83f69416dbe178f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CtrlP.Pages.Pages_Medidores), @"mvc.1.0.razor-page", @"/Pages/Medidores.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Medidores.cshtml", typeof(CtrlP.Pages.Pages_Medidores), @"{handler?}")]
namespace CtrlP.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\_ViewImports.cshtml"
using CtrlP;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d35d0922b16f6ca3c6da475a83f69416dbe178f3", @"/Pages/Medidores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3939ee865382c89239da7161a2c35c27397e1a4e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Medidores : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Medidores/Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("box"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Medidores/Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Medidores/Use", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Experimentos/Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
  
    ViewData["Title"] = "Gerenciar Medidores";

#line default
#line hidden
            BeginContext(98, 750, true);
            WriteLiteral(@"
<div class=""text-center"">
    <div class=""text-center""><h1 class=""display-4"" style=""font-weight:bold"">Medidores</h1>
    
    <h2>Visualize, Edite e Adicione Medidores</h2>
    <p>Medidores Detectados</p>
     <table class=""table table-responsive"" style=""width:auto"">  
            <tr>  
                <th>  
                    Medidor
                </th>  
                <th>  
                    IP
                </th>  
                <th>  
                    Tipo
                </th>  
                <th>  
                    Estado
                </th>  
                <th >  
                    <div >Op&ccedil;&otilde;es</div>
                </th>  
                  
            </tr>  
  
");
            EndContext();
#line 32 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
             foreach (var item in MedidoresModel.Medidores)
            {

#line default
#line hidden
            BeginContext(924, 76, true);
            WriteLiteral("                <tr>  \r\n                    <td>  \r\n                        ");
            EndContext();
            BeginContext(1001, 39, false);
#line 36 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                   Write(Html.DisplayFor(modelItem => item.HWID));

#line default
#line hidden
            EndContext();
            BeginContext(1040, 85, true);
            WriteLiteral("  \r\n                    </td>  \r\n                    <td>  \r\n                        ");
            EndContext();
            BeginContext(1126, 39, false);
#line 39 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                   Write(Html.DisplayFor(modelItem => item.HWIP));

#line default
#line hidden
            EndContext();
            BeginContext(1165, 85, true);
            WriteLiteral("  \r\n                    </td>  \r\n                    <td>  \r\n                        ");
            EndContext();
            BeginContext(1251, 48, false);
#line 42 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                   Write(Html.DisplayFor(modelItem => item.OperationType));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 57, true);
            WriteLiteral("  \r\n                    </td>  \r\n                        ");
            EndContext();
            BeginContext(1357, 40, false);
#line 44 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                   Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(1397, 55, true);
            WriteLiteral("\r\n                    <td >  \r\n                        ");
            EndContext();
            BeginContext(1452, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d35d0922b16f6ca3c6da475a83f69416dbe178f37849", async() => {
                BeginContext(1527, 8, true);
                WriteLiteral("Detalhes");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-HWIP", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                                                                          WriteLiteral(item.HWIP);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["HWIP"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-HWIP", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["HWIP"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1539, 27, true);
            WriteLiteral("|\r\n                        ");
            EndContext();
            BeginContext(1566, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d35d0922b16f6ca3c6da475a83f69416dbe178f310335", async() => {
                BeginContext(1638, 6, true);
                WriteLiteral("Editar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-HWIP", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 47 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                                                                       WriteLiteral(item.HWIP);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["HWIP"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-HWIP", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["HWIP"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1648, 27, true);
            WriteLiteral("|\r\n                        ");
            EndContext();
            BeginContext(1675, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d35d0922b16f6ca3c6da475a83f69416dbe178f312817", async() => {
                BeginContext(1746, 4, true);
                WriteLiteral("Usar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-HWIP", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
                                                                      WriteLiteral(item.HWIP);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["HWIP"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-HWIP", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["HWIP"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1754, 56, true);
            WriteLiteral("\r\n                    </td>  \r\n                </tr>  \r\n");
            EndContext();
#line 51 "C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\CtrlP\Pages\Medidores.cshtml"
            }

#line default
#line hidden
            BeginContext(1825, 65, true);
            WriteLiteral("            <tr>\r\n                <td></td><td></td><td></td><td>");
            EndContext();
            BeginContext(1890, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d35d0922b16f6ca3c6da475a83f69416dbe178f315639", async() => {
                BeginContext(1928, 16, true);
                WriteLiteral("Novo Experimento");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1948, 54, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </table>  \r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MedidoresModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MedidoresModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MedidoresModel>)PageContext?.ViewData;
        public MedidoresModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
