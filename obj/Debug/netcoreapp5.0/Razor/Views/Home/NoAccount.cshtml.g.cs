#pragma checksum "H:\MedTimers\MedTimers\Views\Home\NoAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7d41521b61b67c9b534396ca0c1f3cfff8957f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_NoAccount), @"mvc.1.0.view", @"/Views/Home/NoAccount.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7d41521b61b67c9b534396ca0c1f3cfff8957f7", @"/Views/Home/NoAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce9ad2485a459c122a249d82d77112f8e012015f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NoAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "H:\MedTimers\MedTimers\Views\Home\NoAccount.cshtml"
  
    ViewData["Title"] = "MedTimers";
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h2>This user does not exist</h2>\r\n\r\n<button class=\"btn btn-lg btn-block loginBtn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 153, "\"", 207, 3);
            WriteAttributeValue("", 163, "location.href=\'", 163, 15, true);
#nullable restore
#line 11 "H:\MedTimers\MedTimers\Views\Home\NoAccount.cshtml"
WriteAttributeValue("", 178, Url.Action("Login", "Home"), 178, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 206, "\'", 206, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Back</button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591