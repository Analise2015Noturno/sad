<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HomeCliente.aspx.cs" Inherits="HomeCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <!--PESQUISAR-->
    <div class="row">
        <div class="col-md-2">
            <asp:Label runat="server" AssociatedControlID="txtPesquisa" CssClass="control-label">Pesquisar Problema</asp:Label>
        </div>
        <div class="col-md-5">
            <asp:TextBox runat="server" ID="txtPesquisa" CssClass="form-control"   />
        </div>
        <div class="col-md-5">
            <asp:Button ID="btPesquisa" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btPesquisa_Click" />
        </div>
    </div>
    <hr />
    <!---->
    <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false" CssClass="table footable table-responsive table-hover table-striped table-bordered table-checkable table-highlight-head table-no-inner-border table-hover table-condensed">
        <Columns>
            <asp:BoundField DataField="CÓDIGO DO PROBLEMA" HeaderText="CÓD. DO PROBLEMA" ItemStyle-Width="200" />
            <asp:BoundField DataField="PROBLEMA" HeaderText="TÍTULO DO PROBLEMA" ItemStyle-Width="250" />
            <asp:BoundField DataField="CRIADO EM" HeaderText="CRIADO EM" ItemStyle-Width="150" />
            <asp:BoundField DataField="ATUALIZADO EM" HeaderText="ATUALIZADO EM" ItemStyle-Width="250" />
            <asp:BoundField DataField="CRIADO POR" HeaderText="CRIADO POR" ItemStyle-Width="250" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Detalhes" class="btn btn-primary"  PostBackUrl='<%# String.Format("DetalheProblema.aspx?codigo={0}", Eval("CÓDIGO DO PROBLEMA"))%>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
