<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Views_Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link runat="server" href="~/Style/sad.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="form">
            <h4>Manutenção do Cadastro</h4>
            <hr />
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div id="dvCadastroSucesso" runat="server" class="alert alert-success alert-dismissable" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <strong>Sucesso! </strong>Alteração realizada.
            </div>
            <div id="dvCadastroAtencao" runat="server" class="alert alert-warning alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                    &times;
                </button>
                <strong>Atenção! </strong>CPF ou E-mail já cadastrados.
            </div>
            <div id="dvCadastroSenha" runat="server" class="alert alert-warning alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                    &times;
                </button>
                <strong>Atenção! </strong>Senhas não coincidem..
            </div>
            <div id="dvSenhaIncorreta" runat="server" class="alert alert-warning alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                    &times;
                </button>
                <strong>Atenção! </strong>Senha Atual Incorreta!
            </div>
        </div>
        <!--CampoNome-->
        <div class="form-group">
            <label runat="server" for="txtNome">Nome</label>
            <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="ErroNome" runat="server" ControlToValidate="txtNome" ForeColor="#FF3300" ErrorMessage="O campo Nome é obrigatório."></asp:RequiredFieldValidator>
            </br>
                            <label runat="server" for="txtCpf">CPF</label>
            <asp:TextBox runat="server" ID="txtCpf" CssClass="form-control" OnTextChanged="txtCpf_TextChanged" AutoPostBack="True" />
            <asp:RequiredFieldValidator ID="ErroCpf" runat="server" ControlToValidate="txtCpf" ForeColor="#FF3300" ErrorMessage="Informe seu CPF!"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label runat="server" for="txtCep">CEP</label>
                    <asp:TextBox runat="server" ID="txtCep" CssClass="form-control" TextMode="Number" OnTextChanged="txtCep_TextChanged" AutoPostBack="True" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label runat="server" for="txtNumero">N°</label>
                    <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control auto-style1" TextMode="Number">0</asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="help-block" ID="ErroCep" runat="server" ControlToValidate="txtCep" ForeColor="#FF3300" ErrorMessage="Informe um CEP válido!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label runat="server" for="txtEndereco">Endereço</label>
                    <asp:TextBox runat="server" ID="txtEndereco" CssClass="form-control disabled" Enabled="False" />
                    <!-- aqui começa o Bairro-->
                    <label runat="server" for="txtBairro">Bairro</label>
                    <asp:TextBox runat="server" ID="txtBairro" CssClass="form-control disabled" Enabled="False" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label runat="server" for="txtCidade">Cidade</label>
                    <asp:TextBox runat="server" ID="txtCidade" CssClass="form-control disabled" Enabled="False" />
                    <!-- aqui começa o UF-->
                    <label runat="server" for="txtUf">UF</label>
                    <asp:TextBox runat="server" ID="txtUf" CssClass="form-control disabled" Enabled="False" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label runat="server" for="txtEmail">E-mail</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="O campo E-mail é obrigatório." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <!--CampoSenhaAtual-->
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label runat="server" for="txtSenhaAtual" style="width: 100%;">Senha Atual</label>
                    <asp:TextBox runat="server" ID="txtSenhaAtual" CssClass="form-control" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSenhaAtual" ErrorMessage="Digite sua senha atual!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label runat="server" for="txtSenhaNova" style="width: 100%;">Nova Senha</label>
                    <asp:TextBox runat="server" ID="txtSenhaNova" CssClass="form-control" TextMode="Password" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label runat="server" for="txtConfirmaSenhaNova" style="width: 100%;">Confirmar Nova Senha</label>
                    <asp:TextBox runat="server" ID="txtConfirmaSenhaNova" CssClass="form-control" TextMode="Password" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Button runat="server" Text="Enviar" CssClass="btn btn-primary btn-lg" OnClick="Cadastrar_Click" />
                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-default btn-lg" OnClick="Cancelar_Click" UseSubmitBehavior="False" ValidateRequestMode="Disabled" CausesValidation="False" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


