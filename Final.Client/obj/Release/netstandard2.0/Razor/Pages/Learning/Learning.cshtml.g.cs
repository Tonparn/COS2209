#pragma checksum "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44c5a8ad2e5fe9cf1f04c080dcd28e067c2e4bd2"
// <auto-generated/>
#pragma warning disable 1591
namespace Final.Client.Pages.Learning
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.Layouts;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.JSInterop;
    using Final.Client;
    using Final.Client.Shared;
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Components.RouteAttribute("/learning")]
    public class Learning : LearningModel
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "container-fluid learning-position");
            builder.AddContent(2, "\r\n    ");
            builder.OpenElement(3, "div");
            builder.AddAttribute(4, "class", "row no-gutters");
            builder.AddContent(5, "\r\n\r\n");
#line 8 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
         if (LearningState.Learning.Editor)
        {

#line default
#line hidden
            builder.AddContent(6, "            ");
            builder.OpenElement(7, "div");
            builder.AddAttribute(8, "class", "col-6 col-md-5 learning-position-row");
            builder.AddContent(9, "\r\n\r\n                ");
            builder.AddContent(10, (MarkupString)LearningState.Learning.Html);
            builder.AddContent(11, "\r\n\r\n");
#line 14 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
                 if (!string.IsNullOrEmpty(LearningState.Learning.Hint))
                {

#line default
#line hidden
            builder.AddContent(12, "                    ");
            builder.OpenElement(13, "button");
            builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, () => SubmitHint()));
            builder.AddAttribute(15, "class", "btn btn-danger learning-submit-hint");
            builder.AddContent(16, "\r\n                        Hint\r\n                    ");
            builder.CloseElement();
            builder.AddContent(17, "\r\n");
#line 19 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
                }

#line default
#line hidden
            builder.AddContent(18, "\r\n");
#line 21 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
                 if (LearningState.Learning.HintFlag)
                {

#line default
#line hidden
            builder.AddContent(19, "                    ");
            builder.OpenElement(20, "div");
            builder.AddAttribute(21, "class", "container lead");
            builder.AddAttribute(22, "style", "padding: 10px;");
            builder.AddContent(23, "\r\n                        ");
            builder.AddContent(24, (MarkupString)LearningState.Learning.Hint);
            builder.AddContent(25, "\r\n                    ");
            builder.CloseElement();
            builder.AddContent(26, "\r\n");
#line 26 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
                }

#line default
#line hidden
            builder.AddContent(27, "\r\n            ");
            builder.CloseElement();
            builder.AddContent(28, "\r\n            ");
            builder.OpenElement(29, "div");
            builder.AddAttribute(30, "class", "col-12 col-sm-6 col-md-7 learning-container-iframe");
            builder.AddContent(31, "\r\n                ");
            builder.OpenElement(32, "iframe");
            builder.AddAttribute(33, "id", "Iframe");
            builder.AddAttribute(34, "class", "learning-iframe");
            builder.AddAttribute(35, "scrolling", "no");
            builder.AddAttribute(36, "src", LearningState.Jupyter);
            builder.CloseElement();
            builder.AddContent(37, "\r\n            ");
            builder.CloseElement();
            builder.AddContent(38, "\r\n");
#line 32 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
        }
        else
        {

#line default
#line hidden
            builder.AddContent(39, "            ");
            builder.OpenElement(40, "div");
            builder.AddAttribute(41, "class", "learning-position-row");
            builder.AddContent(42, "\r\n\r\n                ");
            builder.AddContent(43, (MarkupString)LearningState.Learning.Html);
            builder.AddContent(44, "\r\n\r\n            ");
            builder.CloseElement();
            builder.AddContent(45, "\r\n");
#line 40 "E:\COS2209\Final\Final.Client\Pages\Learning\Learning.cshtml"
        }

#line default
#line hidden
            builder.AddContent(46, "\r\n    ");
            builder.CloseElement();
            builder.AddContent(47, "\r\n");
            builder.CloseElement();
            builder.AddContent(48, "\r\n\r\n");
            builder.OpenElement(49, "footer");
            builder.AddAttribute(50, "class", "navbar-expand-sm bg-dark text-white mt-5 p-2 text-center learning-position-footer");
            builder.AddContent(51, "\r\n    ");
            builder.OpenElement(52, "div");
            builder.AddAttribute(53, "class", "learning-lesson-name");
            builder.AddContent(54, "\r\n        ");
            builder.AddContent(55, LearningState.Learning.Lesson);
            builder.AddContent(56, "\r\n    ");
            builder.CloseElement();
            builder.AddContent(57, "\r\n    ");
            builder.OpenElement(58, "div");
            builder.AddAttribute(59, "class", "container learning-container-submit ");
            builder.AddContent(60, "\r\n        ");
            builder.OpenElement(61, "button");
            builder.AddAttribute(62, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, () => BackLesson()));
            builder.AddAttribute(63, "class", "btn btn-danger learning-submit-back");
            builder.AddContent(64, "Back");
            builder.CloseElement();
            builder.AddContent(65, "\r\n        ");
            builder.OpenElement(66, "button");
            builder.AddAttribute(67, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, () => NextLesson()));
            builder.AddAttribute(68, "class", "btn btn-danger learning-submit-next");
            builder.AddContent(69, "Next");
            builder.CloseElement();
            builder.AddContent(70, "\r\n    ");
            builder.CloseElement();
            builder.AddContent(71, "\r\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
