<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HomeAdmin.aspx.cs" Inherits="HomeAdmin" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
      <h2>Administrador</h2><hr/>
      <a href="/Views/CadastrarProblema.aspx" ><button type="button" class="btn btn-primary btn-lg btn-block">Cadastrar Problema</button></a>
      <a href="/Views/ManutencaoProblema.aspx" ><button type="button" class="btn btn-default btn-lg btn-block">Manutenção de Problema</button></a>
    </div>
</asp:Content>
