<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarSolucoes.aspx.cs" Inherits="Views_CadastrarSolucoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
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
            <input type="hidden" id="txtCodigoSolucao" runat="server" />
            <div class="col-md-12">
                <div class="form-group" runat="server" id="formTitulo">
                    <label for="txtNome">Nome</label>
                    <input runat="server" class="form-control" type="text" id="txtTitulo" placeholder="título da solução..." maxlength="80" />
                    <span runat="server" id="helpBlockTitulo" class="help-block"></span>
                </div>
                <div class="form-group" runat="server" id="formDescricao">
                    <label for="txtDescricao">Descrição</label>
                    <textarea runat="server" id="txtDescricao" rows="5" class="form-control" placeholder="descrição da solução..." maxlength="255"></textarea>
                    <span runat="server" id="helpBlockDescricao" class="help-block"></span>
                </div>
            </div>
            <div class="col-md-8">
                <div class="form-group" runat="server" id="formUrl">
                    <label for="txtUrl">Endereço na Internet~/URL (opcional)</label>
                    <input runat="server" class="form-control" type="text" id="txtUrl" placeholder="http://..." maxlength="255" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group" runat="server" id="Div1">
                    <label for="txtUrl">Imagem da Solução (opcional)</label>
                    <asp:FileUpload ID="imagemSolucao" class="form-control" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <asp:Button CssClass="btn btn-default" ID="btnGravarSolucao" runat="server" OnClick="btnGravarSolucao_Click" Text="Gravar Solução" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function apagarSolucao(codigoSolucao, codigoProblema) {
            if (confirm("Tem certeza que deseja apagar esta solução ?")) {
                var xmlhttp2 = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");
                xmlhttp2.onreadystatechange = function () {
                    if (xmlhttp2.responseText.includes("DEL-SOL-OK")) {
                        <%Response.Write(selProblema.ClientID);%>.onchange();
                    } else { alerta = document.getElementById("<%Response.Write(alerta.ClientID);%>"); alerta.innerText = xmlhttp2.responseText; alerta.className = "alert alert-danger"; }
                }
                xmlhttp2.open("GET", "<%Response.Write(ResolveUrl("~/Views/ajax/apagarSolucao.aspx"));%>?s=" + codigoSolucao + "&p=" + codigoProblema, true);
                xmlhttp2.send();
            }
        }
        function editarSolucao(codigo) {
            txtCodigoSolucao = document.getElementById("<%Response.Write(txtCodigoSolucao.ClientID);%>");
            txtTitulo = document.getElementById("<%Response.Write(txtTitulo.ClientID);%>");
            txtDescricao = document.getElementById("<%Response.Write(txtDescricao.ClientID);%>");
            txtUrl = document.getElementById("<%Response.Write(txtUrl.ClientID);%>");

            txtCodigoSolucao.value = codigo;
            txtTitulo.value = document.getElementById("MainContent_header" + codigo).innerText;
            txtDescricao.value = document.getElementById("MainContent_texto" + codigo).innerText;
            txtUrl.value = document.getElementById("MainContent_link" + codigo).innerText;
        }
    </script>
</asp:Content>

