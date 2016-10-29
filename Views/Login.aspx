<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Insira sua conta</h4>
                <hr />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <div id="dvLoginInvalido" runat="server" class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                        &times;
                    </button>
                    <strong>Erro!</strong> Usuário ou senha inválidos..
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Usuário/E-mail</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtSenha" CssClass="col-md-2 control-label">Senha</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtSenha" TextMode="Password" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Entrar" CssClass="btn btn-primary btn-lg" OnClick="Login_Click" />
                        <p></p>
                        <asp:LinkButton ID="lkCadastre" runat="server" PostBackUrl="~/Views/Cadastrar.aspx">Criar Conta</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

