﻿#pragma checksum "D:\GS DAM\Repositorios\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_UWP\Views\VistaAnhadirEditarDepartamento.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CA77777ADA7F30B0600F560FE7CBE84459D4BC0C3681DCCE5709D30997231D38"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Personas_BBDD_Azure_UWP.Views
{
    partial class VistaAnhadirEditarDepartamento : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\VistaAnhadirEditarDepartamento.xaml line 16
                {
                    this.back = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.back).Click += this.back_Click;
                }
                break;
            case 3: // Views\VistaAnhadirEditarDepartamento.xaml line 18
                {
                    this.Titulo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\VistaAnhadirEditarDepartamento.xaml line 19
                {
                    this.id = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Views\VistaAnhadirEditarDepartamento.xaml line 20
                {
                    this.idDepartamento = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Views\VistaAnhadirEditarDepartamento.xaml line 21
                {
                    this.nombre = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\VistaAnhadirEditarDepartamento.xaml line 22
                {
                    this.nombreDepartamentonding = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.nombreDepartamentonding).TextChanged += this.departamento_TextChanged;
                }
                break;
            case 8: // Views\VistaAnhadirEditarDepartamento.xaml line 23
                {
                    this.guardar = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 9: // Views\VistaAnhadirEditarDepartamento.xaml line 24
                {
                    this.advertencia = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

