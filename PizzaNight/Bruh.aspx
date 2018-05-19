<%@ Page Title="Sign Up | Pizza" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bruh.aspx.cs" Inherits="PizzaNight.bruh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Masthead -->
    <header class="masthead text-white text-center">
      <div class="overlay"></div>
      <div class="container">
        <div class="row">
          <div class="col-xl-9 mx-auto">
            <h1 class="mb-5">Sign up for pizza night updates</h1>
          </div>
          <div class="col-md-10 col-lg-8 col-xl-7 mx-auto">
            <div class="form-row">
                <div class="col-12 col-md-9 mb-2 mb-md-0">
                    <asp:TextBox ID="email" type="email" CssClass=" form-control form-control-lg" placeholder="Enter your email..." runat="server"></asp:TextBox>
                    <div class="alert alert-danger" id="LoginError" runat="server" visible="false">
                        <strong>Oh snap!</strong> Change a few things up and try submitting again.
                    </div>
                </div>
                <div class="col-12 col-md-3">
                    <asp:Button type="submit" class="btn btn-block btn-lg btn-primary" ID="SignUp" runat="server" Text="Send Digits" OnClick="SignUp_Click" />
                </div>
            </div>
          </div>
        </div>
      </div>
    </header>

    <!-- Icons Grid -->
    <section class="features-icons bg-light text-center" style="padding-bottom:0;">
      <div class="container">
        <div class="row">
          <div class="col-lg-4">
            <div class="features-icons-item mx-auto mb-5 mb-lg-0 mb-lg-3">
              <div class="features-icons-icon d-flex">
                <i class="icon-fire m-auto text-primary"></i>
              </div>
              <h3>It's Fucking Lit</h3>
              <p class="lead mb-0">Please don't start fires</p>
            </div>
          </div>
          <div class="col-lg-4">
            <div class="features-icons-item mx-auto mb-5 mb-lg-0 mb-lg-3">
              <div class="features-icons-icon d-flex">
                <i class="icon-ghost m-auto text-primary"></i>
              </div>
              <h3>No Ghost Policy</h3>
              <p class="lead mb-0">Ghost free usually</p>
            </div>
          </div>
          <div class="col-lg-4">
            <div class="features-icons-item mx-auto mb-0 mb-lg-3">
              <div class="features-icons-icon d-flex">
                <i class="icon-present m-auto text-primary"></i>
              </div>
              <h3>Take Some Home</h3>
              <p class="lead mb-0">If we make extra you can use my christmas wrapping paper</p>
            </div>
          </div>
        </div>
      </div>
    </section>

     <!-- Testimonials -->
    <section class="testimonials text-center bg-light">
      <div class="container">
        <h2 class="mb-5">What people are saying...</h2>
        <div class="row">
          <div class="col-lg-4">
            <div class="testimonial-item mx-auto mb-5 mb-lg-0">
              <img class="img-fluid rounded-circle mb-3" src="img/BlackGuy.jpg" alt="">
              <h5>HARRISON TANNENBAUM</h5>
              <h6>CANDLE INSPECTOR</h6>
              <p class="font-weight-light mb-0">"This is fantastic! More LaserDisc please!!"</p>
            </div>
          </div>
          <div class="col-lg-4">
            <div class="testimonial-item mx-auto mb-5 mb-lg-0">
              <img class="img-fluid rounded-circle mb-3" src="img/OldWhiteGuy.jpg" alt="">
              <h5>DOUG TYSON</h5>
              <h6>MAGICIAN AUDITOR</h6>
              <p class="font-weight-light mb-0">"It’s fine. My wife took the kids anyways."</p>
            </div>
          </div>
          <div class="col-lg-4">
            <div class="testimonial-item mx-auto mb-5 mb-lg-0">
              <img class="img-fluid rounded-circle mb-3" src="img/MexicanGuy.jpg" alt="">
              <h5>COLIN NORTH</h5>
              <h6>TEA COOLER</h6>
              <p class="font-weight-light mb-0">"I’ll just have a glass of water, please."</p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- SHOW CASE SECTION -->
    <section class="showcase">
      <div class="container-fluid p-0">
        <div class="row no-gutters">
          <div class="col-lg-6 order-lg-2 text-white showcase-img" style="background-image: url('img/MetalPizza.png');"></div>
          <div class="col-lg-6 order-lg-1 my-auto showcase-text">
            <h2>This pizza is pretty crazy</h2>
            <p class="lead mb-0">Sign up to receive Pizza Night updates or <a href="/Deets">check here for the next Pizza Night</a>. </p>
          </div>
        </div>
        <div class="row no-gutters">
          <div class="col-lg-6 text-white showcase-img" style="background-image: url('img/cage-yoda.jpg');"></div>
          <div class="col-lg-6 my-auto showcase-text">
            <h2>Prepare your butts for some Cage</h2>
            <p class="lead mb-0">Nicolas Cage has 92 acting credits. That's a lotta pizza nights.</p>
          </div>
        </div>
        <div class="row no-gutters">
          <div class="col-lg-6 order-lg-2 text-white showcase-img" style="background-image: url('img/heartbeat.jpg');"></div>
          <div class="col-lg-6 order-lg-1 my-auto showcase-text">
            <h2>I'm not sure what's going on here</h2>
            <p class="lead mb-0">Your food should definitely not have a heartbeat.</p>
          </div>
        </div>
      </div>
    </section>

</asp:Content>
