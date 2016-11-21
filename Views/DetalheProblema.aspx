<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DetalheProblema.aspx.cs" Inherits="DetalheProblema" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="invisible" role="alert" runat="server" id="alerta">
    </div>
    <div class="invisible" runat="server" id="linha">
        <div class="container-fluid bottom20" style="background-color: #dcdcdc">
            <div class="container">
                <div class="col-md-12">
                    <h1 runat="server" id="titulo"></h1>
                    <p class="lead" runat="server" id="descricao"></p>
                </div>
                <div class="invisible" runat="server" id="sectionAtualizacao">
                    <span>Última Atualização : </span>
                    <span runat="server" id="atualizacao"></span>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="col-md-12" runat="server" id="sectionSolucoes">
            </div>
            <div class="col-md-12">
                <asp:Panel ID="panelQuestoes" runat="server"></asp:Panel>
            </div>
            <div class="col-md-12" runat="server">
                <h3>Sua Opinião</h3>
                <div class="form-group" runat="server" id="sectionFeedBack">
                    <asp:DropDownList runat="server" ID="selSolucoes" CssClass="form-control bottom20"></asp:DropDownList>
                    <textarea placeholder="sua opinião..." rows="5" class="form-control bottom20" runat="server" id="txtFeedBack" maxlength="255"></textarea>
                    <asp:Button runat="server" ID="btnGravaFeedBack" OnClick="btnGravaFeedBack_Click" Text="Gravar FeedBack" />
                </div>
            </div>
            <div class="col-md-12">
                <asp:Panel ID="panelFeedBacks" runat="server"></asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
