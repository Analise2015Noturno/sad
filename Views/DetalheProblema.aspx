<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DetalheProblema.aspx.cs" Inherits="DetalheProblema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<body>
<div class="container">
  <form>
    <div class="container">
    </div>
    <div class="form-group">
      <label for="FeedBack">Relate seu FeedBack:</label>
      <textarea class="form-control"  rows="3" id="txtdetalhe_feedback"></textarea>
    </div>
  </form>
</div>     
  <div class="container">    
  <asp:Button runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="Enviar_Click" />
</div>
</body>
</asp:Content>