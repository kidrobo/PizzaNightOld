<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LASERDiscs.aspx.cs" Inherits="PizzaNight.LASERDIscs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1, h3 {
            font-family: 'Blade-Runner-Movie-Font';
            text-align:center;

        }
        .wrapper{
            width:1440px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="container container-fluid">
            
            <h1>pizza shack laserdiscs</h1>
            <div class="row">
                <div class="col-md-6">
                    <h3>count: <asp:Literal ID="litCount" runat="server"></asp:Literal></h3>
                    <asp:GridView ID="gvLaserdiscs" runat="server" CssClass="table table-hover"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
