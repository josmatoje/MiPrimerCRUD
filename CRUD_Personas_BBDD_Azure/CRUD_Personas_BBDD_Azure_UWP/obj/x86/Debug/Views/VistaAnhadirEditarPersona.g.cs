﻿#pragma checksum "D:\GS DAM\Repositorios\MiPrimerCRUD\CRUD_Personas_BBDD_Azure\CRUD_Personas_BBDD_Azure_UWP\Views\VistaAnhadirEditarPersona.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C7FC75214F06324578773238428982EBE4A7EFB10D0A962E1DAAE7F4A129A3E"
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
    partial class VistaAnhadirEditarPersona : 
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
            case 2: // Views\VistaAnhadirEditarPersona.xaml line 13
                {
                    this.vm = (global::CRUD_Personas_BBDD_Azure_UWP.ViewModels.VistaAnhadirEditarPersonaVM)(target);
                }
                break;
            case 3: // Views\VistaAnhadirEditarPersona.xaml line 18
                {
                    this.main = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 4: // Views\VistaAnhadirEditarPersona.xaml line 19
                {
                    this.titulo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Views\VistaAnhadirEditarPersona.xaml line 20
                {
                    this.tituloNombre = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Views\VistaAnhadirEditarPersona.xaml line 21
                {
                    this.tituloApellido = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\VistaAnhadirEditarPersona.xaml line 23
                {
                    this.borde = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 8: // Views\VistaAnhadirEditarPersona.xaml line 26
                {
                    this.back = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.back).Click += this.back_Click;
                }
                break;
            case 9: // Views\VistaAnhadirEditarPersona.xaml line 27
                {
                    this.tabla = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 10: // Views\VistaAnhadirEditarPersona.xaml line 83
                {
                    this.guardar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.guardar).Click += this.guardar_ClickAsync;
                }
                break;
            case 11: // Views\VistaAnhadirEditarPersona.xaml line 84
                {
                    this.advertencia = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Views\VistaAnhadirEditarPersona.xaml line 43
                {
                    this.nombre = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // Views\VistaAnhadirEditarPersona.xaml line 48
                {
                    this.apellidos = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Views\VistaAnhadirEditarPersona.xaml line 53
                {
                    this.fechaNacimiento = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // Views\VistaAnhadirEditarPersona.xaml line 58
                {
                    this.direccion = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Views\VistaAnhadirEditarPersona.xaml line 63
                {
                    this.telefono = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Views\VistaAnhadirEditarPersona.xaml line 69
                {
                    this.departamento = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Views\VistaAnhadirEditarPersona.xaml line 70
                {
                    this.departamentoPersona = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 19: // Views\VistaAnhadirEditarPersona.xaml line 78
                {
                    this.foto = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // Views\VistaAnhadirEditarPersona.xaml line 79
                {
                    this.fotoPersona = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 21: // Views\VistaAnhadirEditarPersona.xaml line 80
                {
                    this.seleccionaFoto = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 23: // Views\VistaAnhadirEditarPersona.xaml line 65
                {
                    this.telefonoPersona = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 24: // Views\VistaAnhadirEditarPersona.xaml line 66
                {
                    this.telefonoError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // Views\VistaAnhadirEditarPersona.xaml line 67
                {
                    this.telefonoFormatError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // Views\VistaAnhadirEditarPersona.xaml line 60
                {
                    this.direccionPersona = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 27: // Views\VistaAnhadirEditarPersona.xaml line 61
                {
                    this.direccionError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // Views\VistaAnhadirEditarPersona.xaml line 55
                {
                    this.fechaNacimientoPersona = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 29: // Views\VistaAnhadirEditarPersona.xaml line 56
                {
                    this.fechaError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 30: // Views\VistaAnhadirEditarPersona.xaml line 50
                {
                    this.apellidosPersona = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.apellidosPersona).TextChanged += this.nombreApellido_TextChanged;
                }
                break;
            case 31: // Views\VistaAnhadirEditarPersona.xaml line 51
                {
                    this.apellidosError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 32: // Views\VistaAnhadirEditarPersona.xaml line 45
                {
                    this.nombrePersona = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.nombrePersona).TextChanged += this.nombreApellido_TextChanged;
                }
                break;
            case 33: // Views\VistaAnhadirEditarPersona.xaml line 46
                {
                    this.nombreError = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

