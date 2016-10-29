<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HomeCliente.aspx.cs" Inherits="HomeCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    <asp:Button ID="btPesquisar" runat="server" Text="Pesquisar" />
        <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="id_problema" HeaderText="Id Problema" ItemStyle-Width="100" />
                <asp:BoundField DataField="titulo_problrma" HeaderText="Titulo" ItemStyle-Width="250" />
                <asp:BoundField DataField="descricao_problema" HeaderText="Descrição" ItemStyle-Width="350" />
                <asp:BoundField DataField="dt_criacao" HeaderText="Data da Criação" ItemStyle-Width="250" />
                <asp:BoundField DataField="dt_hr_atualizacao" HeaderText="Data da Atualização" ItemStyle-Width="250" />
                <asp:BoundField DataField="usuario_solucao" HeaderText="Usuario da solução" ItemStyle-Width="150" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="detalhes" runat="server" PostBackUrl='ProblemaDetalhe.aspx' Text="Detalhes" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
