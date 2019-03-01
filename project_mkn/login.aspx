<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title> Login Form</title>

    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500">
    <link rel="stylesheet" href="assets1/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets1/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets1/css/form-elements.css">
    <link rel="stylesheet" href="assets1/css/style.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="assets1/ico/favicon.png">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets1/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets1/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets1/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="assets1/ico/apple-touch-icon-57-precomposed.png">
</head>
<body>

    <!-- Top menu -->
    <nav class="navbar navbar-inverse navbar-no-bg" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#top-navbar-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">Login Form </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
          <!--  <div class="collapse navbar-collapse" id="top-navbar-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <span class="li-text">Put some text or
							</span>
                        <a href="#"><strong>links</strong></a>
                        <span class="li-text">here, or some icons: 
							</span>
                        <span class="li-social">
                            <a href="#"><i class="fa fa-facebook"></i></a>
                            <a href="#"><i class="fa fa-twitter"></i></a>
                            <a href="#"><i class="fa fa-envelope"></i></a>
                            <a href="#"><i class="fa fa-skype"></i></a>
                        </span>
                    </li>
                </ul>
            </div> -->
        </div>
    </nav>

    <!-- Top content -->
    <div class="top-content">

        <div class="inner-bg">
            <div class="container">
                <div class="row">
                 
                </div>
                <div class="row">
                    <div class="col-sm-6 phone">
                        <img src="assets1/img/iphone.png" alt="">
                    </div>
                    <div class="col-sm-5 form-box">
                        <div class="form-top">
                            <div class="form-top-left">
                                <h3>Login to our App</h3>
                                <p>Fill in the form below to get instant access:</p>
                            </div>
                            <div class="form-top-right">
                                <i class="fa fa-pencil"></i>
                            </div>
                        </div>
                        <div class="form-bottom">
                            <form role="form" runat="server" id="form2" class="registration-form">

                                <div class="form-group">
                                    <label class="sr-only" for="form-email">Email</label>
                                    <asp:TextBox type="text" name="form-email" runat="server" placeholder="Email..." class="form-email form-control" ID="email_id"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="sr-only" for="form-last-name">Password</label>
                                    <asp:TextBox type="text" name="form-last-name" placeholder="Password..." class="form-last-name form-control" TextMode="Password" runat="server" ID="password"></asp:TextBox>
                                </div>
                                
                                <asp:Button OnClick="click1" runat="server" Text="Sign me up!" class="btn-primary btn" ID="signup2" />

                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>


    <!-- Javascript -->
    <script src="assets1/js/jquery-1.11.1.min.js"></script>
    <script src="assets1/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets1/js/jquery.backstretch.min.js"></script>
    <script src="assets1/js/retina-1.1.0.min.js"></script>
    <script src="assets1/js/scripts.js"></script>

    <!--[if lt IE 10]>
            <script src="assets1/js/placeholder.js"></script>
        <![endif]-->



    <div style="left: 0px; top: 0px; overflow: hidden; margin: 0px; padding: 0px; height: 335px; width: 1343px; z-index: -999999; position: fixed;" class="backstretch">
        <img src="assets1/img/backgrounds/2.jpg" style="position: absolute; margin: 0px; padding: 0px; border: medium none; width: 1343px; height: 1007.25px; max-height: none; max-width: none; z-index: -999999; left: 0px; top: -336.125px;">
    </div>
</body>

</html>