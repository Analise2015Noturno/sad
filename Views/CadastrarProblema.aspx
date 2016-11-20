<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarProblema.aspx.cs" Inherits="CadastrarProblema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="invisible" runat="server" id="alerta"></div>
        <div class="row">
            <div class="col-md-12">
                <h3>Dados do problema</h3>
                <div class="form-group" runat="server" id="formTitulo">
                    <label for="txtTitulo">Título</label>
                    <input runat="server" class="form-control" type="text" id="txtTitulo" placeholder="título do problema..." maxlength="80" />
                    <span runat="server" id="helpBlockTitulo" class="help-block"></span>
                </div>
                <div class="form-group" runat="server" id="formDescricao">
                    <label for="txtDescricao">Descrição</label>
                    <textarea runat="server" id="txtDescricao" rows="5" class="form-control" placeholder="descrição do problema..." maxlength="800"></textarea>
                    <span runat="server" id="helpBlockDescricao" class="help-block"></span>
                </div>
                <hr />
                <div class="form-group">
                    <asp:Button CssClass="btn btn-default" ID="btnGravarProblema" runat="server" OnClick="btnGravarProblema_Click" Text="Gravar Problema" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
