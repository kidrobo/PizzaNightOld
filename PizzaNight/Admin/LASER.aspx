<%@ Page Title="" Language="C#" MasterPageFile="/Master.Master" AutoEventWireup="true" CodeBehind="LASER.aspx.cs" Inherits="PizzaNight.Admin.LASER" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>LASER Disc Editor</h1>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label for="tbTitle">Title</label>
                <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbEdition">Edition</label>
                <asp:TextBox ID="tbEdition" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="AddMove" runat="server" CssClass="btn btn-primary" Text="Add Movie" OnClick="AddMove_Click" />
        </div>
        <div class="col-md-5">
            <asp:GridView ID="gvDiscs" runat="server" CssClass="table" OnRowDataBound="gvDiscs_RowDataBound"></asp:GridView>
        </div>
    </div>
</asp:Content>
