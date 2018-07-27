<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StartGame.aspx.cs" Inherits="PizzaNight.FFD.StartGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
        <h1>Start a new drunk game</h1>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <h2>Continue a Game</h2>
            <asp:GridView ID="gvContinue" runat="server" CssClass="table" OnRowDataBound="gvContinue_RowDataBound"></asp:GridView>
        </div>
        <div class="col-lg-4">
            <h2>Start New Game</h2>
            <div class="form-group">
                <label for="ddGameType">Game Type</label>
                <asp:DropDownList ID="ddGameType" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="tbCharacterName">Character Name</label>
                <asp:TextBox ID="tbCharacterName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="AddGame" runat="server" CssClass="btn btn-primary" Text="Add Game" OnClick="AddGame_Click" />
        </div>
    </div>
</asp:Content>
