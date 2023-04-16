﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="PROGIII_TP3.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tabla">
                <tbody>
                    <tr> <!-- Título "Localidad" -->
                        <td></td>
                        <td>Localidad</td>
                    </tr>
                    <tr><!-- Nombre de localidad -->
                        <td><span>Nombre de localidad: </span></td>
                        <td><asp:TextBox ID="tbLocalidad" runat="server" ValidationGroup="LocalidadGrupo"></asp:TextBox></td>
                        <td><!-- Introducir validaciones acá. -->
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbLocalidad">Ingresá un valor.</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><!-- Botón "Guardar localidad -->
                        <td></td>
                        <td><asp:Button ID="btnGuardarLocalidad" runat="server" Text="Guardar localidad" UseSubmitBehavior="False" OnClick="btnGuardarLocalidad_Click" ValidationGroup="LocalidadGrupo" /></td>
                        <td><asp:Label ID="lbResultadoLocalidad" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><h3>Usuarios</h3></td>
                    </tr>
                    <tr> <!-- Nombre de usuario -->
                        <td><span>Nombre de usuario: </span></td>
                        <td><asp:TextBox ID="tbUsuario" runat="server" ValidationGroup="UsuarioGrupo"></asp:TextBox></td>
                        <td><!-- Introducir validaciones acá. --></td>
                    </tr>
                    <tr> <!-- Contraseña -->
                        <td><span>Contraseña: </span></td>
                        <td><asp:TextBox ID="tbClave" runat="server" TextMode="Password" ValidationGroup="UsuarioGrupo"></asp:TextBox></td>
                        <td><!-- Introducir validaciones acá. -->
                            <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="tbClave" ErrorMessage="Ingrese una contraseña.">Ingrese una contraseña.</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr> <!-- Repetir contraseña -->
                        <td><span>Repetir contraseña: </span></td>
                        <td><asp:TextBox ID="tbRepetirClave" runat="server" TextMode="Password" ValidationGroup="UsuarioGrupo"></asp:TextBox></td>
                        <td><!-- Introducir validaciones acá. -->
                            <asp:RequiredFieldValidator ID="rfvRepetirClave" runat="server" ControlToValidate="tbRepetirClave" ErrorMessage="Debe repetir su contraseña.">Debe repetir su contraseña.</asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="cvRepetirClave" runat="server" ControlToCompare="tbClave" ControlToValidate="tbRepetirClave" ErrorMessage="La contraseña debe coincidir con la ingresada previamente.">La contraseña debe coincidir con la ingresada previamente.</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr> <!-- Correo electrónico -->
                        <td><span>Correo electrónico: </span></td>
                        <td><asp:TextBox ID="tbCorreo" runat="server" ValidationGroup="UsuarioGrupo"></asp:TextBox></td>
                        <td><!-- Introducir validaciones acá. -->
                            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="tbCorreo">Ingrese un correo</asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="tbCorreo" ValidationExpression="^[a-zA-Z0-9_-]{1,256}\@[a-zA-Z0-9_-]{1,256}(\.[a-zA-Z0-9_-]{1,6})+$">Correo no valido</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr> <!-- Código Postal -->
                        <td><span>Código Postal: </span></td>
                        <td><asp:TextBox ID="tbCodigoPostal" runat="server" ValidationGroup="UsuarioGrupo"></asp:TextBox></td>
                        <td><!-- Introducir validaciones acá. --></td>
                    </tr>
                    <tr> <!-- Localidades -->
                        <td><span>Localidades</span></td>
                        <td><asp:DropDownList ID="ddlLocalidades" runat="server" ValidationGroup="UsuarioGrupo">
                            <asp:ListItem>Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                        <td><!-- Introducir validaciones acá. -->
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlLocalidades" InitialValue="Seleccionar">Seleccione una localidad</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr> <!-- Botón "Guardar Usuario" -->
                        <td></td>
                        <td><asp:Button ID="btnGuardarUsuario" runat="server" Text="Guardar usuario" UseSubmitBehavior="False" OnClick="btnGuardarUsuario_Click" ValidationGroup="UsuarioGrupo" /></td>
                        <td><asp:Label ID="lbResultadoUsuario" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr> <!-- Botón "Ir a Inicio.aspx" -->
                        <td></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
