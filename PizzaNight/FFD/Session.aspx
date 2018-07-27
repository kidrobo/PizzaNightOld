<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="PizzaNight.FFD.Session" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h3><asp:Label ID="lblGameType" runat="server"></asp:Label></h3>
        <h4><asp:Label ID="lblCharacterName" runat="server"></asp:Label></h4>
        <div class="col-lg-6">
            <asp:GridView ID="gvGameInfo" runat="server" CssClass="table"></asp:GridView>
        </div>
        <asp:Button ID="EndSession" runat="server" CssClass="btn btn-danger" Text="End Session" OnClick="EndSession_Click" />
    </div>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-8">
                <asp:GridView ID="gvDrinks" runat="server" CssClass="table" OnRowDataBound="gvDrinks_RowDataBound"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
