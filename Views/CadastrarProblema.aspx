<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarProblema.aspx.cs" Inherits="CadastrarProblema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="invisible" runat="server" id="alerta"></div>
        <div class="row">
            <input type="hidden" id="txtCodigoProblema" runat="server" />
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
                <div class="form-group">
                    <asp:Button CssClass="btn btn-default" ID="btnGravarProblema" runat="server" OnClick="btnGravarProblema_Click" Text="Gravar Problema" />
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <asp:Panel runat="server" ID="panelProblemas"></asp:Panel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function apagarProblema(codigoProblema) {
            if (confirm("Tem certeza que deseja apagar este problema ?")) {
                var xmlhttp2 = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");
                xmlhttp2.onreadystatechange = function () {
                    if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                        if (xmlhttp2.responseText.includes("DEL-PROB-OK")) {
                            location.assign("<%Response.Write(ResolveUrl("~/Views/CadastrarProblema.aspx"));%>");
                        } else {
                            alerta = document.getElementById("<%Response.Write(alerta.ClientID);%>"); alerta.innerText = xmlhttp2.responseText; alerta.className = "alert alert-danger";
                        }
                    }
                }

                xmlhttp2.open("GET", "<%Response.Write(ResolveUrl("~/Views/ajax/apagarProblema.aspx"));%>?p=" + codigoProblema, true);
                xmlhttp2.send();
            }
        }
    </script>
    <script type="text/javascript">
        function editarProblema(codigo) {
            txtCodigoProblema = document.getElementById("<%Response.Write(txtCodigoProblema.ClientID);%>");
            txtTitulo = document.getElementById("<%Response.Write(txtTitulo.ClientID);%>");
            txtDescricao = document.getElementById("<%Response.Write(txtDescricao.ClientID);%>");

            txtCodigoProblema.value = codigo;
            txtTitulo.value = document.getElementById("MainContent_titulo" + codigo).innerText;
            txtDescricao.value = document.getElementById("MainContent_descricao" + codigo).innerText;
        }
    </script>
</asp:Content>
