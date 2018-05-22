<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PizzaNight.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="signup">
        <div class="container" id="signup" runat="server">
            <div class="col-lg-6 mx-auto">
                <div class="panel-body">

                    <p>PIZZA NIGHT!!!</p>

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
    <section class="complete">
        <div class="container" id="complete" runat="server" visible="false">
            <div class="col-lg-6 mx-auto">
                <div class="panel-body">
                    <h2>Signup Complete!</h2>
                    <p>
                        You should get an email from info@pizzanight.fyi letting you know things worked out. Periodically Pizza Night 
                        will happen and you'll get an email with a link that will let you RSVP.
                    </p>
                    <p>
                        It's gonna be neat.
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
