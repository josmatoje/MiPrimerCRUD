#pragma checksum "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1555d1bf51d4781e6bdd60282668ec15c749938d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personas_Details), @"mvc.1.0.view", @"/Views/Personas/Details.cshtml")]
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
#line 1 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\_ViewImports.cshtml"
using CRUD_Personas_BBDD_Azure_ASP.NET_MVC_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\_ViewImports.cshtml"
using CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1555d1bf51d4781e6bdd60282668ec15c749938d", @"/Views/Personas/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60e4609ae51e87dab7b1ac409a76baed61c7679", @"/Views/_ViewImports.cshtml")]
    public class Views_Personas_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels.PersonaNombreDepartamentoVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalles</h1>\r\n\r\n<div>\r\n    <h4>Personsa</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellidos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellidos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Fecha de Nacimiento\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n");
            WriteLiteral("            <label>");
#nullable restore
#line 30 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
              Write(Model.FechaNacimiento.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Foto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n");
#nullable restore
#line 48 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
             if(Model.Foto is not null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img");
            BeginWriteAttribute("src", "  src=\"", 1571, "\"", 1636, 2);
            WriteAttributeValue("", 1578, "data:image/jpg;base64,", 1578, 22, true);
#nullable restore
#line 50 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
WriteAttributeValue(" ", 1600, Convert.ToBase64String(Model.Foto), 1601, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"100\" width=\"200\"/>\r\n");
#nullable restore
#line 51 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 54 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NombreDepartamento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 57 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
       Write(Html.DisplayFor(model => model.NombreDepartamento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 62 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
Write(Html.ActionLink("Editar", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 63 "D:\jmmata\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_ASP.NET(MVC)\Views\Personas\Details.cshtml"
Write(Html.ActionLink("Volver", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels.PersonaNombreDepartamentoVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
