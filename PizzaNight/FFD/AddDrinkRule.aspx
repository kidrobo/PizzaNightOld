<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddDrinkRule.aspx.cs" Inherits="PizzaNight.FFD.AddDrinkingRule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <label for="ddGameType">Game Type</label>
                <asp:DropDownList ID="ddGameType" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="tbRule">Rule Text</label>
                <asp:TextBox ID="tbRule" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbPenalty">Penalty</label>
                <asp:TextBox ID="tbPenalty" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="AddRule" runat="server" CssClass="btn btn-primary" Text="Add Rule" OnClick="AddRule_Click" />
        </div>
    </div>
</asp:Content>
