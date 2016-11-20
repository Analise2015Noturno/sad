<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HomeAdmin.aspx.cs" Inherits="HomeAdmin" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <h2>Administrador</h2>
        <hr />

        <div class="row ">
            <div class="col-md-4 text-center bottom20">
                <a runat="server" href="~/Views/CadastrarProblema.aspx" class="btn btn-primary btn-lg btn-block">Manutenção de Problemas</a>
            </div>
            <div class="col-md-4 text-center bottom20">
                <a runat="server" href="~/Views/CadastrarSolucoes.aspx" class="btn btn-primary btn-lg btn-block">Manutenção de Soluções</a>
            </div>
            <div class="col-md-4 text-center bottom20">
                <a runat="server" href="~/Views/CadastrarQuestoes.aspx" class="btn btn-primary btn-lg btn-block">Manutenção de Questões</a>
            </div>
        </div>
    </div>
</asp:Content>
