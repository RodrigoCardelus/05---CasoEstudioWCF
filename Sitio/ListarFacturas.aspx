<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeFile="ListarFacturas.aspx.cs" Inherits="ListarFacturas" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Filtrar por Usuario:
        <asp:TextBox ID="TxtUsu" runat="server"></asp:TextBox>
        <asp:Button ID="BtnFiltro1" runat="server" OnClick="BtnFiltro1_Click" Text="Filtrar Usuarios" />
        <br />
        <br />
        Filtrar por Articulo:
        <asp:TextBox ID="TxtArt" runat="server"></asp:TextBox>
        <asp:Button ID="BtnFiltro2" runat="server" OnClick="BtnFiltro2_Click" Text="Filtro x Articulo" />
        <br />
        <br />
        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Filtros" />
        <br />
    <div class="auto-style11">
    
        <strong>Las Facturas del Sistema
        
        </strong></div>
        
        <asp:GridView ID="dgvFacturas" runat="server" Height="145px" Width="702px" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvFacturas_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nro" HeaderText="Numero" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="UnUsu.UsuLog" HeaderText="Usuario" />
                <asp:CommandField SelectText="Ver Lineas" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
         <div class="auto-style12">
    
             <strong>Las lineas de la Factura Seleccionada</strong></div>
        
        <asp:GridView ID="dgvLineas" runat="server" Height="145px" Width="416px" AutoGenerateColumns="False">
            <Columns>
                 <asp:BoundField DataField="UnArt.CodAr" HeaderText="Articulo" />
               <asp:BoundField DataField="UnArt.NomAr" HeaderText="Nombre" />
                <asp:BoundField DataField="UnArt.Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cant" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style11 {
            width: 414px;
            text-decoration: underline;
            color: #00FFFF;
            font-size: xx-large;
        }
    .auto-style12 {
        width: 589px;
        text-decoration: underline;
        color: #00FFFF;
        font-size: xx-large;
    }
    </style>
</asp:Content>
