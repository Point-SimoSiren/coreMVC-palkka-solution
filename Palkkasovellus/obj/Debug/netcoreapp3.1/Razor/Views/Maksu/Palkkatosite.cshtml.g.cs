#pragma checksum "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1830eb2d19b079d57656f9928afc088226bf3509"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maksu_Palkkatosite), @"mvc.1.0.view", @"/Views/Maksu/Palkkatosite.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\CoreMVC\Palkkasovellus\Views\_ViewImports.cshtml"
using Palkkasovellus;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CoreMVC\Palkkasovellus\Views\_ViewImports.cshtml"
using Palkkasovellus.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1830eb2d19b079d57656f9928afc088226bf3509", @"/Views/Maksu/Palkkatosite.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f1119ffc6ac47076a39ce9f07c0ffe75a711b0c", @"/Views/_ViewImports.cshtml")]
    public class Views_Maksu_Palkkatosite : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MaksuDetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
   ViewBag.Title = "Palkkatosite";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
   Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1830eb2d19b079d57656f9928afc088226bf35094190", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12 grid-margin"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""container-fluid d-flex justify-content-between"">
                    <div class=""col-md-3 pl-0"">
                        <p class=""mt-5 mb-2""><b>Yritys Oy</b></p>
                        <p>Uutelantie 1 E 12<br />06100<br />Porvoo</p>
                    </div>
                    <div class=""col-md-3 pr-0"">
                        <p class=""mt-5 mb-2 text-right""><b>Maksupäivä: ");
#nullable restore
#line 19 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                                                                  Write(Model.Maksupaiva.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                    </div>\r\n                </div><br /><br />\r\n\r\n                <div class=\"col-md-12 row\">\r\n                    <div class=\"col-md-8\"><h5>Maksun saajan nimi : ");
#nullable restore
#line 24 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                                                              Write(Model.Kokonimi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></div>\r\n                    <div class=\"col-md-4\"><h5>Sotu : ");
#nullable restore
#line 25 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                                                Write(Model.Sotu);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5></div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-12 table-responsive-md"">
                    <table class=""table table-striped"">
                        <thead class=""table-dark"">
                            <tr>
                                <th>Ansiotulo</th>
                                <th>Tunnit</th>
                                <th>Tuntipalkka</th>
                                <th>Summa</th>
                                <th>Pidätykset</th>
                                <th>Summa</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><b>Säännöllinen työaika :</b></td>
                                <td>");
#nullable restore
#line 44 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.SaannolTunnit.ToString("f"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 45 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Tuntipalkka.ToString("f"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 46 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.SaannolPalkka.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><b>Veronpidätys :</b></td>\r\n                                <td>");
#nullable restore
#line 48 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Vero.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><b>Eläkemaksu :</b></td>\r\n                                <td>");
#nullable restore
#line 50 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Elakemaksu.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                \r\n\r\n                            </tr>\r\n                            <tr>\r\n                                <td><b>Ylityöt :</b></td>\r\n                                <td>");
#nullable restore
#line 56 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Ylityotunnit.ToString("f"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 57 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.YlityoTuntipalkka.ToString("f2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 58 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Ylityopalkka.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><b>Sosiaaliturvamaksu :</b></td>\r\n                                <td>");
#nullable restore
#line 60 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Sotumaksu.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><b>Sosiaaliturvamaksu :</b></td>\r\n                                <td>");
#nullable restore
#line 62 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Sotumaksu.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td><b>Työttömyysvakuutusmaksu :</b></td>
                                <td>");
#nullable restore
#line 68 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Tyottomuusvakuutus.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><b>Liiton maksu :</b></td>\r\n                                <td>");
#nullable restore
#line 70 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.Jasenmaksu.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><b>Varalla :</b></td>
                                <td>Varalla 1000</td>
                            </tr>
                            <tr>
                                <td><b>Yhteensä :</b></td>
                                <td>");
#nullable restore
#line 82 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.TehdytTunnit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td></td>\r\n                                <td>");
#nullable restore
#line 84 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.PalkkaYhteensa.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td></td>\r\n                                <td>");
#nullable restore
#line 86 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                               Write(Model.VahennuksetYhteensa.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td class=""table-dark""><b>Nettomaksu :</b></td>
                                <td class=""table-dark"">");
#nullable restore
#line 96 "C:\CoreMVC\Palkkasovellus\Views\Maksu\Palkkatosite.cshtml"
                                                  Write(Model.Nettopalkka.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                        </tfoot>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MaksuDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591