#pragma checksum "C:\Users\alith\source\repos\hofre\Hofre\Hofre\Areas\Admin\Pages\Tickets\Room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1eafd8be0de181dc961d6fe54542369c48556eb1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Hofre.Pages.Tickets.Areas_Admin_Pages_Tickets_Room), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/Tickets/Room.cshtml")]
namespace Hofre.Pages.Tickets
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
#line 1 "C:\Users\alith\source\repos\hofre\Hofre\Hofre\Areas\Admin\Pages\_ViewImports.cshtml"
using Hofre;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1eafd8be0de181dc961d6fe54542369c48556eb1", @"/Areas/Admin/Pages/Tickets/Room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe0427b5474b3986a0b8ac344c9488707bf4383a", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Pages_Tickets_Room : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/SignalrClient.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""content-body"">

    <!-- Page Headings Start -->
    <div class=""row justify-content-between align-items-center mb-10"">

        <!-- Page Heading Start -->
        <div class=""col-12 col-lg-auto mb-20"">
            <div class=""page-heading"">
                <h3>برنامه <span>/ چت</span></h3>
            </div>
        </div><!-- Page Heading End -->

    </div><!-- Page Headings End -->

    <div class=""row"">
        <!-- Chat App Start -->
        <div class=""col-12"">
            <div class=""chat-app-wrap"">

                <button class=""chat-contacts-open""><i class=""zmdi zmdi-accounts-alt""></i></button>

                <!--Chat Contacts Start-->
                <div class=""chat-contacts"">

                    <button class=""chat-contacts-close""><i class=""zmdi zmdi-close""></i></button>

                    <!--Chat Contact Search Start-->
                    <div class=""contact-search-form"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1eafd8be0de181dc961d6fe54542369c48556eb15386", async() => {
                WriteLiteral("\r\n                            <input type=\"text\" placeholder=\"Search Contact\">\r\n                        ");
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
            WriteLiteral(@"
                    </div>
                    <!--Chat Contact Search End-->
                    <!--Contact List Start-->
                    <ul class=""chat-contact-list custom-scroll"">

                        <li>
                            <a href=""#"">
                                <div class=""image""><img src=""assets/images/comment/comment-9.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 1532, "\"", 1538, 0);
            EndWriteAttribute();
            WriteLiteral("><span class=\"status online\"></span></div>\r\n                                <div class=\"content\">\r\n                                    <h5 class=\"name\">");
#nullable restore
#line 46 "C:\Users\alith\source\repos\hofre\Hofre\Hofre\Areas\Admin\Pages\Tickets\Room.cshtml"
                                                Write(Model.Ticket.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <p class=\"last-message\">");
#nullable restore
#line 47 "C:\Users\alith\source\repos\hofre\Hofre\Hofre\Areas\Admin\Pages\Tickets\Room.cshtml"
                                                       Write(Model.Ticket.LastMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!--Contact List End-->

                </div>
                <!--Chat Contacts End-->
                <!--Chat Active Contact Start-->
                <div class=""chat-active-contact"">
                    <div class=""chat-contact"">
                        <div class=""image""><img src=""assets/images/avatar/avatar-1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 2292, "\"", 2298, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                        <div class=\"info\">\r\n                            <h5>");
#nullable restore
#line 61 "C:\Users\alith\source\repos\hofre\Hofre\Hofre\Areas\Admin\Pages\Tickets\Room.cshtml"
                           Write(Model.Ticket.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                            <span>آخرین بار دیده شده: 1 ساعت پیش</span>
                        </div>
                    </div>
                    <div class=""chat-contact-actions"">
                        <button class=""button button-box button-round button-primary""><i class=""zmdi zmdi-phone""></i></button>
                        <button class=""button button-box button-round button-primary""><i class=""zmdi zmdi-videocam""></i></button>
                    </div>
                </div>
                <!--Chat Active Contact End-->
                <!-- Chat Start -->
                <div class=""chat-wrap custom-scroll mr-0"">
                    <ul class=""chat-list"">

                        <li>
                            <div class=""chat"">
                                <div class=""head"">
                                    <h5 id=""usernameLabel""></h5>
                                    <span id=""dateLabel""></span>
                                    <a href=""#""><i class=""zmdi z");
            WriteLiteral("mdi-replay\"></i></a>\r\n                                </div>\r\n                                <div class=\"body\">\r\n                                    <div class=\"image\"><img src=\"assets/images/comment/comment-1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 3645, "\"", 3651, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
                                    <div class=""content"">
                                        <p id=""messages""></p>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>

                <div class=""chat-submission"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1eafd8be0de181dc961d6fe54542369c48556eb110945", async() => {
                WriteLiteral(@"
                        <input id=""messageInput"" type=""text"" placeholder=""چیزی را تایپ کنید"">
                        <div class=""buttons"">
                            <label class=""file-upload button button-box button-round button-primary"" for=""chat-file-upload"">
                                <input type=""file"" id=""chat-file-upload"" multiple>
                                <i class=""zmdi zmdi-attachment-alt""></i>
                            </label>
                            <button id=""sendButton"" class=""submit button button-box button-round button-primary""><i class=""zmdi zmdi-mail-send""></i></button>
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
            WriteLiteral(@"
                </div><!-- Chat End -->

            </div>
        </div><!-- Chat End Start -->
    </div>

</div><!-- Content Body End -->
<!-- ---------------- -->


<div class=""row"">
    <div class=""col-2"">Sender</div>
    <div class=""col-4""><input type=""hidden"" id=""senderInput"" value=""Admin"" /></div>
</div>


<div class=""row"">
    <div class=""col-2"">Receiver</div>
    <div class=""col-4""><input type=""hidden"" id=""receiverInput""");
            BeginWriteAttribute("value", " value=\"", 5210, "\"", 5240, 1);
#nullable restore
#line 122 "C:\Users\alith\source\repos\hofre\Hofre\Hofre\Areas\Admin\Pages\Tickets\Room.cshtml"
WriteAttributeValue("", 5218, Model.Ticket.Username, 5218, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" /></div>
</div>

<!-- Global Vendor, plugins & Activation JS -->
<script src=""assets/js/vendor/modernizr-3.6.0.min.js""></script>
<script src=""assets/js/vendor/jquery-3.3.1.min.js""></script>
<script src=""assets/js/vendor/popper.min.js""></script>
<script src=""assets/js/vendor/bootstrap.min.js""></script>
<!--Plugins JS-->
<script src=""assets/js/plugins/perfect-scrollbar.min.js""></script>
<script src=""assets/js/plugins/tippy4.min.js.js""></script>
<!--Main JS-->
<script src=""assets/js/main.js""></script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1eafd8be0de181dc961d6fe54542369c48556eb114347", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1eafd8be0de181dc961d6fe54542369c48556eb115387", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hofre.Areas.Admin.Pages.Tickets.RoomModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hofre.Areas.Admin.Pages.Tickets.RoomModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hofre.Areas.Admin.Pages.Tickets.RoomModel>)PageContext?.ViewData;
        public Hofre.Areas.Admin.Pages.Tickets.RoomModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
