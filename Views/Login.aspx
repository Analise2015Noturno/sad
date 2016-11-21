<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <h4>Insira sua conta</h4>
        <hr />
        <div class="form">
            <div id="dvLoginInvalido" runat="server" class="alert alert-danger alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                    &times;
                </button>
                <strong>Erro!</strong> Usuário ou senha inválidos..
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" AssociatedControlID="txtEmail">Usuário/E-mail</asp:Label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
        </div>
        <div class="bottom20">
            <asp:Label runat="server" AssociatedControlID="txtSenha">Senha</asp:Label>
            <asp:TextBox runat="server" ID="txtSenha" TextMode="Password" CssClass="form-control" />
        </div>
        <div>
            <div class="form-group">
                <asp:Button runat="server" Text="Entrar" CssClass="btn btn-primary btn-lg" OnClick="Login_Click" />
                <asp:LinkButton ID="lkCadastre" runat="server" CssClass="btn btn-default btn-lg " PostBackUrl="~/Views/Cadastrar.aspx">Criar Conta</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

