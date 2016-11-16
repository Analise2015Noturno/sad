<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DetalheProblema.aspx.cs" Inherits="DetalheProblema" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        table.superFancyTable {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            table.superFancyTable td, table.superFancyTable th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            table.superFancyTable tr:nth-child(even) {
                background-color: #f2f2f2;
            }

 

            table.superFancyTable th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #2c2c2c;
                color: white;
            }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="invisible" role="alert" runat="server" id="alerta"></div>

    <div class="invisible" runat="server" id="linha">
        <div class="col-md-12">
            <h1 runat="server" id="titulo"></h1>
        </div>
        <div class="col-md-12">
            <h3>Descrição</h3>
            <p class="lead" runat="server" id="descricao"></p>
        </div>
        <div class="col-md-12">
            <h3>Última Atualização</h3>
            <p class="lead" runat="server" id="atualizacao"></p>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="panelQuestoes" runat="server"></asp:Panel>
        </div>
    </div>

</asp:Content>
