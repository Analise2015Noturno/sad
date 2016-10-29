<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Views_Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link runat="server" href="~/Style/sad.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-md-10">
        <section id="loginForm">
            <div class="form-horizontal">
                <h4>Manutenção do Cadastro</h4>
                <hr />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <div id="dvCadastroSucesso" runat="server" class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                        &times;
                    </button>
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
                <!--CampoNome-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtNome" CssClass="col-md-2 control-label">Nome</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="ErroNome" runat="server" ControlToValidate="txtNome" ForeColor="#FF3300" ErrorMessage="O campo Nome é obrigatório."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!--CampoCPF-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtCpf" CssClass="col-md-2 control-label">CPF</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtCpf" CssClass="form-control"   OnTextChanged="txtCpf_TextChanged" AutoPostBack="True" />
                        <asp:RequiredFieldValidator ID="ErroCpf" runat="server" ControlToValidate="txtCpf" ForeColor="#FF3300" ErrorMessage="Informe seu CPF!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!--CampoCEP/Número-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtCep" CssClass="col-md-2 control-label">CEP</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtCep" CssClass="form-control-2" TextMode="Number" OnTextChanged="txtCep_TextChanged" AutoPostBack="True" />
                        <!-- aqui começa o Número-->
                        <asp:Label runat="server" AssociatedControlID="txtNumero" CssClass="col-md control-label" Style="margin-left: 2px" Width="83px">N°</asp:Label>
                        <asp:TextBox runat="server" ID="txtNumero" CssClass="auto-style1" Width="109px" TextMode="Number">0</asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="help-block" ID="ErroCep" runat="server" ControlToValidate="txtCep" ForeColor="#FF3300" ErrorMessage="Informe um CEP válido!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!--CampoEndereco/Bairro-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtEndereco" CssClass="col-md-2 control-label">Endereço</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtEndereco" CssClass="disabled auto-style4" Enabled="False" Width="166px" />
                        <!-- aqui começa o Bairro-->
                        <asp:Label runat="server" AssociatedControlID="txtBairro" CssClass="col-md control-label" Style="margin-left: 29px" Width="85px">Bairro</asp:Label>
                        <asp:TextBox runat="server" ID="txtBairro" CssClass="auto-style1" Enabled="False" Width="181px" />
                    </div>
                </div>
                <!--CampoCidade/UF-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtCidade" CssClass="col-md-2 control-label">Cidade</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtCidade" CssClass="auto-style4" Enabled="False" Width="165px" />
                        <!-- aqui começa o UF-->
                        <asp:Label runat="server" AssociatedControlID="txtUf" CssClass="col-md control-label" Height="18px" Style="margin-left: 47px" Width="69px">UF</asp:Label>
                        <asp:TextBox runat="server" ID="txtUf" CssClass="auto-style2" Enabled="False" />
                    </div>
                </div>
                <!--CampoE-mail-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">E-mail</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="O campo E-mail é obrigatório." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!--CampoSenhaAtual-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtSenhaAtual" CssClass="col-md-2 control-label">Senha Atual</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtSenhaAtual" CssClass="form-control" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSenhaAtual" ErrorMessage="Digite sua senha atual!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!--CampoSenha-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtSenhaNova" CssClass="col-md-2 control-label">Nova Senha</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtSenhaNova" CssClass="form-control" TextMode="Password" />
                    </div>
                </div>
                <!--CampoConfirmarSenha-->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtConfirmaSenhaNova" CssClass="col-md-2 control-label">Confirmar Nova Senha</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtConfirmaSenhaNova" CssClass="form-control" TextMode="Password" />
                    </div>
                </div>
                <!--Validação-->
                <!--Botãolegal-->
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-default btn-lg" OnClick="Cancelar_Click" UseSubmitBehavior="False" ValidateRequestMode="Disabled" CausesValidation="False" />
                        <asp:Button runat="server" Text="Enviar" CssClass="btn btn-primary btn-lg" OnClick="Cadastrar_Click" />
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

