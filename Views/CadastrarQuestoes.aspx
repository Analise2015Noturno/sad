<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarQuestoes.aspx.cs" Inherits="Views_CadastrarQuestoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="invisible" runat="server" id="alerta"></div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <label>Escolha o Problema</label>
                <asp:DropDownList AutoPostBack="true" runat="server" ID="selProblema" class="form-control" OnSelectedIndexChanged="selProblema_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div runat="server" class="col-md-12" id="sectionQuestoes"></div>
    </div>
    <div class="row">
        <div class="col-md-10">
            <div class="form-group" runat="server" id="formTitulo">
                <label for="txtQuestao">Questão</label>
                <input runat="server" class="form-control" type="text" id="txtQuestao" placeholder="questão do problema..." />
                <span runat="server" id="helpBlockQuestao" class="help-block"></span>
            </div>
        </div>
        <div class="col-md-2">
            <div class="form-group" runat="server" id="formDescricao">
                <label for="txtDescricao">Resposta</label>
                <input runat="server" type="text" id="txtResposta" class="form-control" placeholder="resposta do problema..." />
                <span runat="server" id="helpBlockResposta" class="help-block"></span>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Button CssClass="btn btn-default" ID="btnGravarQuestao" runat="server" OnClick="btnGravarQuestao_Click" Text="Gravar Questão" />
            </div>
        </div>
    </div>
</asp:Content>

