#pragma checksum "C:\Users\WIN 10 TRIAL\Desktop\Bootcamp Metrodata\SourceCode C#\API\StCORS\Views\Home\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb09141533d6cf0e94485b471f1004b99561ee0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Profile), @"mvc.1.0.view", @"/Views/Home/Profile.cshtml")]
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
#line 1 "C:\Users\WIN 10 TRIAL\Desktop\Bootcamp Metrodata\SourceCode C#\API\StCORS\Views\_ViewImports.cshtml"
using StCORS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\WIN 10 TRIAL\Desktop\Bootcamp Metrodata\SourceCode C#\API\StCORS\Views\_ViewImports.cshtml"
using StCORS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb09141533d6cf0e94485b471f1004b99561ee0f", @"/Views/Home/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b857dee8de30add89f044311daac01012e2404a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:insertProfile()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/profile.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\WIN 10 TRIAL\Desktop\Bootcamp Metrodata\SourceCode C#\API\StCORS\Views\Home\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "~/Views/Shared/_Layout2.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<a class=\"btn btn-primary mb-2\" data-toggle=\"modal\" data-target=\"#createModal\"");
            BeginWriteAttribute("href", " href=\"", 173, "\"", 180, 0);
            EndWriteAttribute();
            WriteLiteral(@">Insert</a>
<table id=""tableProf"" class=""table table-striped table-bordered"" style=""width:100%"">
    <thead>
        <tr>
            <td>No</td>
            <td>Nama Depan</td>
            <td>Email</td>
            <td>Phone</td>
            <td>Degree</td>

            <td>Action</td>
        </tr>
    </thead>
    <tbody id=""bodyProf"">
    </tbody>
</table>


<div class=""modal fade"" id=""createModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-md"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalCenterTitle"">Insert New Data</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>

            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb09141533d6cf0e94485b471f1004b99561ee0f5747", async() => {
                WriteLiteral(@"
                <div class=""modal-body m-3"">

                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">FirstName</label>
                            <input type=""text"" class=""form-control is-valid"" id=""firstname"" required placeholder=""FirstName"">

                        </div>

                        <div class=""form-group col-md-6"">
                            <label for=""inputPassword4"">Last Name</label>
                            <input type=""text"" class=""form-control"" id=""lastname"" required placeholder=""LastName"">
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">Email</label>
                            <input type=""email"" class=""form-control"" id=""email"" required placeholder=""Email"">
                        </div>

        ");
                WriteLiteral(@"                <div class=""form-group col-md-6"">
                            <label for=""inputPassword4"">Password</label>
                            <input type=""password""  minlength=""6"" maxlength=""20"" class=""form-control"" id=""password"" required placeholder=""Password"">
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">Phone</label>
                            <input type=""number"" class=""form-control"" id=""phone"" required placeholder=""Phone"">
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">BirthDate</label>
                            <input type=""date"" class=""form-control"" id=""birthdate"" required placeholder=""BirthDate"">
                        </div>
                 ");
                WriteLiteral(@"   </div>

                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">Salary</label>
                            <input type=""number"" class=""form-control"" id=""salary"" required placeholder=""Salary"">
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">Degree</label>
                            <input type=""text"" class=""form-control"" id=""degree"" required placeholder=""Degree"">
                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""inputPassword4"">GPA</label>
                            <input type=""number"" class=""form-control"" id=""gpa"" required placeholder=""GPA"">
                        </div>
                    </div>

                    <div class=""form-row"">
     ");
                WriteLiteral(@"                   <div class=""form-group col-md-6"">
                            <label for=""inputEmail4"">University ID</label>
                            <input type=""number"" class=""form-control"" id=""universityid"" required placeholder=""UniversityID"">
                        </div>
                    </div>

                    <button type=""submit"" class=""btn btn-primary"">Sign in</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb09141533d6cf0e94485b471f1004b99561ee0f11031", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 212 "C:\Users\WIN 10 TRIAL\Desktop\Bootcamp Metrodata\SourceCode C#\API\StCORS\Views\Home\Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
