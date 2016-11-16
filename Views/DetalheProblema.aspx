<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DetalheProblema.aspx.cs" Inherits="DetalheProblema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="invisible" role="alert" runat="server" id="alerta"></div>

    <div class="invisible" runat="server" id="linha">
        <div class="col-md-12">
            <h1 runat="server" id="titulo"></h1>
        </div>
        <div class="col-md-12">
            <h3>Descrição</h3>
            <p class="lead" runat="server" id="descricao"></p>
        </div>
        <div class="col-md-12">
            <h3>Última Atualização</h3>
            <p class="lead" runat="server" id="atualizacao"></p>
        </div>
    </div>

</asp:Content>
