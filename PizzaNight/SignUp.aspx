<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PizzaNight.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="signup">
        <div class="container">
            <div class="col-lg-6 mx-auto">
                <div class="panel-body">

                    <p>Fill in the info to sign up and start managing your rocket inventory</p>

                    <div class="alert alert-danger" id="LoginError" runat="server" visible="false">
                        <strong>Oh snap!</strong> Change a few things up and try submitting again.
                    </div>
                    
                    <div class="form-group">
                        <label>Email Address</label>
                        <asp:TextBox ID="tbEmail" placeholder="Your email please" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Username</label>
                        <asp:TextBox ID="tbUsername" placeholder="Be original" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Password</label>
                        <asp:TextBox ID="tbPassword" placeholder="Whatever length you want" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Type your password again</label>
                        <asp:TextBox ID="tbPasswordCheck" placeholder="Try typing it again" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>First Name</label>
                        <asp:TextBox ID="tbFistName" placeholder="If you want" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Last Name</label>
                        <asp:TextBox ID="tbLastName" placeholder="You don't need to" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="submit" runat="server" UseSubmitBehavior="true" CssClass="btn btn-default" Text="Create New User" OnClick="submit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
