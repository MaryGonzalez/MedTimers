#pragma checksum "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceb84c94a5fd25160068251f3604dad152239537"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__ReadyTablePartialPD), @"mvc.1.0.view", @"/Views/Home/_ReadyTablePartialPD.cshtml")]
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
#line 1 "H:\MedTimers\MedTimers\Views\_ViewImports.cshtml"
using MedTimers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\MedTimers\MedTimers\Views\_ViewImports.cshtml"
using MedTimers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceb84c94a5fd25160068251f3604dad152239537", @"/Views/Home/_ReadyTablePartialPD.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce9ad2485a459c122a249d82d77112f8e012015f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__ReadyTablePartialPD : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MedTimers.Models.AllEdit>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Transfers.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/SmallScreen/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/SmallScreen/Transfers.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
  
    ViewData["Title"] = "MedTimers";
    Layout = "";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
 if (ViewBag.userType == "1" || ViewBag.userType == "2" || ViewBag.userType == "3" || ViewBag.userType == "4")
{


    

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ceb84c94a5fd25160068251f3604dad1522395375081", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ceb84c94a5fd25160068251f3604dad1522395376124", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ceb84c94a5fd25160068251f3604dad1522395377242", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-4"">
                <table class=""table table-bordered table-striped"" id=""waitingTable"">
                    <thead>
                        <tr>
                            <th colspan=""4"" class=""tableTitle"">Patients Ready</th>
                        </tr>
                        <tr>
                            <th scope=""col"" class=""columnName"">Name</th>
                            <th scope=""col"" class=""columnName"">Sex</th>
                            <th scope=""col"" class=""columnName"">Wait Time</th>
                            <th scope=""col"" class=""columnName"">Type</th>
                        </tr>
                    </thead>
                    <tbody>



");
#nullable restore
#line 40 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                         if (Model != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                             foreach (var item in Model)

                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 46 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.fullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n");
#nullable restore
#line 49 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                                     if (item.Patient_Sex == "Male")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>M</td>\r\n");
#nullable restore
#line 52 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>F</td>\r\n");
#nullable restore
#line 56 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n                                    <td>20 Minutes</td>\r\n                                    <td>");
#nullable restore
#line 63 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Track_ArrivalType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 65 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>No patients waiting</td>\r\n                            </tr>\r\n");
#nullable restore
#line 72 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>


            <!--Patient Count Data-->
            <div class=""col-sm-7"">
                <div class=""grid-container shadow-sm p-3 mb-5 bg-white rounded"">

                    <div class=""grid-child"">
                        <button type=""button"" class=""btn btn-link patientCount"">Lobby</button>
                        <span>5</span>
                    </div>

                    <div class=""grid-child"">
                        <button type=""button"" class=""btn btn-link patientCount"">Transfers</button>

                        <span>2</span>
                    </div>

                    <div class=""grid-child"">
                        <button type=""button"" class=""btn btn-link patientCount"">Cert</button>

                        <span>
                            3
                        </span>
                    </div>

                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 106 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h3>Access Denied</h3>\r\n        <p>You do not have permission to view this page.</p>\r\n        <p>Please check your credentials and try again</p>\r\n    </div>\r\n");
#nullable restore
#line 115 "H:\MedTimers\MedTimers\Views\Home\_ReadyTablePartialPD.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MedTimers.Models.AllEdit>> Html { get; private set; }
    }
}
#pragma warning restore 1591
