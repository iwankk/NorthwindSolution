#pragma checksum "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97c88d6fb68fea82f76ffbc96f9af49cff58c41c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductsPagedServer_Create), @"mvc.1.0.view", @"/Views/ProductsPagedServer/Create.cshtml")]
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
#line 1 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\_ViewImports.cshtml"
using Northwind.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\_ViewImports.cshtml"
using Northwind.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97c88d6fb68fea82f76ffbc96f9af49cff58c41c", @"/Views/ProductsPagedServer/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dad76091869ede8adbd28e701c0fcdceb8678800", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ProductsPagedServer_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Northwind.Contracts.Dto.Product.ProductPhotoGroupDto>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
 using (Html.BeginForm("CreateProductPhoto","ProductsPagedServer",
FormMethod.Post, new { @enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4 class=\"mb-3\">Create Product Photos</h4>\r\n    <hr/>\r\n");
#nullable restore
#line 13 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
Write(Html.ValidationSummary(true,"",new {@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row g-3\">\r\n        <div class=\"col-md-4\">\r\n            ");
#nullable restore
#line 16 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.LabelFor(model=> model.ProductForCreateDto.ProductName, htmlAttributes:new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 17 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.TextBox("ProductForCreateDto.ProductName",string.Empty,new{@placeholder="Product Name",@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 18 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.ValidationMessage("ProductForCreateDto.ProductName",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            ");
#nullable restore
#line 21 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.LabelFor(model=> model.ProductForCreateDto.CategoryId, htmlAttributes:new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 22 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.DropDownList("ProductForCreateDto.CategoryId",ViewBag.CategoryId,"--Pilih--",new{@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 23 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.ValidationMessage("ProductForCreateDto.CategoryId",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            ");
#nullable restore
#line 26 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.LabelFor(model=> model.ProductForCreateDto.SupplierId, htmlAttributes:new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 27 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.DropDownList("ProductForCreateDto.SupplierId",ViewBag.SupplierId,"--Pilih--",new{@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 28 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.ValidationMessage("ProductForCreateDto.SupplierId",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n         <div class=\"col-md-4\">\r\n             ");
#nullable restore
#line 31 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
        Write(Html.LabelFor(model=> model.ProductForCreateDto.UnitsInStock, htmlAttributes:new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 32 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.TextBox("ProductForCreateDto.UnitsInStock",string.Empty,new{@placeholder="UnitsInStock",@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 33 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.ValidationMessage("ProductForCreateDto.UnitsInStock",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n         <div class=\"col-md-4\">\r\n             ");
#nullable restore
#line 36 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
        Write(Html.LabelFor(model=> model.ProductForCreateDto.UnitPrice, htmlAttributes:new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 37 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.TextBox("ProductForCreateDto.UnitPrice",string.Empty,new{@placeholder="UnitPrice",@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 38 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.ValidationMessage("ProductForCreateDto.UnitPrice",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n          <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.CheckBox("ProductForCreateDto.Discontinued",false,new{@placeholder="Discontinued",@class="form-check-input"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 42 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.LabelFor(model=> model.ProductForCreateDto.Discontinued, htmlAttributes:new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 43 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
       Write(Html.ValidationMessage("ProductForCreateDto.Discontinued",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>

            <div class=""col-9"">
                <div class=""row text-center text-lg-start"">
                    <div class=""col-lg-4 col-md-4 col-6"">
                        <img id=""preview1"" src=""../Resources/Images/icon.png"" style=""width:100px;height:100px;"" />
");
            WriteLiteral("                    ");
#nullable restore
#line 51 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
               Write(Html.TextBoxFor(model => model.AllPhoto,"",
                    new{@type="file",@accept="image/*", @onchange="previewImage(this,'preview1')"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <button type=\"button\" onclick=\"clearPhoto(\'AllPhoto\',\'preview1\')\" style=\"width:100px\">Clear</button>\r\n                    ");
#nullable restore
#line 54 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
               Write(Html.ValidationMessage("Photo1",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                    <div class=\"col-lg-4 col-md-4 col-6\">\r\n                        <img id=\"preview2\" src=\"../Resources/Images/icon.png\" style=\"width:100px;height:100px;\" />\r\n");
            WriteLiteral("                    ");
#nullable restore
#line 60 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
               Write(Html.TextBoxFor(model => model.AllPhoto,"",
                    new{@type="file",@accept="image/*", @onchange="previewImage(this,'preview2')"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <button type=\"button\" onclick=\"clearPhoto(\'AllPhoto\',\'preview2\')\" style=\"width:100px\">Clear</button>\r\n                    ");
#nullable restore
#line 63 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
               Write(Html.ValidationMessage("Photo2",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n                </div>\r\n                    <div class=\"col-lg-4 col-md-4 col-6\">\r\n                        <img id=\"preview3\" src=\"../Resources/Images/icon.png\" style=\"width:100px;height:100px;\" />\r\n");
            WriteLiteral("                    ");
#nullable restore
#line 68 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
               Write(Html.TextBoxFor(model => model.AllPhoto,"",
                    new{@type="file",@accept="image/*", @onchange="previewImage(this,'preview3')"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <button type=\"button\" onclick=\"clearPhoto(\'AllPhoto\',\'preview3\')\" style=\"width:100px\">Clear</button>\r\n                    ");
#nullable restore
#line 71 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
               Write(Html.ValidationMessage("Photo3",new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n                </div>\r\n                </div>\r\n            </div>\r\n\r\n    </div>\r\n");
            WriteLiteral("    <button type=\"submit\" class=\"btn-primary\">Create</button>\r\n");
#nullable restore
#line 79 "C:\Users\User\Documents\Iwan\NorthwindSolution\Northwind.Web\Views\ProductsPagedServer\Create.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

    function clearPhoto(photo,preview)
    {
        //isi element input type 
        document.getElementById(photo).value='';
        document.getElementById(preview).src = ""../Resources/Images/icon.png""
    }
    

    function previewImage(el,value){
        //store file image to variable files
        const files = el.files[0];
        //create object File Reader
        const fileReader = new FileReader();
        //read files from element input type
        fileReader.readAsDataURL(files);
        //send result base64 image to element html image preview1 
        fileReader.onload = function (event){
            document.getElementById(value).src = event.target.result;
        }
    }

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Northwind.Contracts.Dto.Product.ProductPhotoGroupDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
