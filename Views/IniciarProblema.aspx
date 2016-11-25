<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IniciarProblema.aspx.cs" Inherits="Views_IniciarProblema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid bottom20 border15" style="background-color: #dbdbdb">
        <div class="container">
            <asp:Panel runat="server" ID="header"></asp:Panel>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12 bottom20">
                <div class="progress">
                    <div class="progress-bar" role="progressbar" aria-valuemin="0" aria-valuemax="100" runat="server" id="progressbar">
                    </div>
                </div>
            </div>
            <div class="col-md-12 bottom20">
                <asp:Panel runat="server" ID="panelQuestao" CssClass="invisible">
                    <h3 runat="server" id="hrQuestao"></h3>
                    <div class="col-md-1 text-center col-md-offset-5">
                        <div class="form-group">
                            <input type="number" id="txtResposta" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="col-md-12">
                <asp:Panel runat="server" ID="panelProximo"></asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

