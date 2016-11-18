<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarSolucoes.aspx.cs" Inherits="Views_CadastrarSolucoes" %>

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
        <div runat="server" class="col-md-12" id="sectionSolucoes"></div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group" runat="server" id="formTitulo">
                <label for="txtNome">Nome</label>
                <input runat="server" class="form-control" type="text" id="txtTitulo" placeholder="título do problema..." />
                <span runat="server" id="helpBlockTitulo" class="help-block"></span>
            </div>
            <div class="form-group" runat="server" id="formDescricao">
                <label for="txtDescricao">Descrição</label>
                <textarea runat="server" id="txtDescricao" rows="5" class="form-control" placeholder="descrição do problema..."></textarea>
                <span runat="server" id="helpBlockDescricao" class="help-block"></span>
            </div>
            <div class="form-group" runat="server" id="formUrl">
                <label for="txtUrl">Endereço na Internet (url)</label>
                <input runat="server" class="form-control" type="text" id="txtUrl" placeholder="http://..." />
                <span runat="server" id="helpBlockUrl" class="help-block"></span>
            </div>
            <div class="form-group">
                <asp:Button CssClass="btn btn-default" ID="btnGravarSolucao" runat="server" OnClick="btnGravarSolucao_Click" Text="Gravar Solução" />
            </div>
        </div>
    </div>
</asp:Content>

