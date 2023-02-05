<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pekara.aspx.cs" Inherits="NovProjekat.Pekara" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Ubuntu:wght@300;400;500&display=swap" rel="stylesheet"> 
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Document</title>
</head>
<body>
    
<section class="header">
    <nav>
<a href="index.html"><img src="Slike/logo.png" height="120" width="175"></a><p id="Bogner">Bognerovi</p>
<div class="nav-links" id="navlinks">
    <i class="fa fa-times" onclick="hide()"></i>

<ul>
<li><a href="Account/Login.aspx">Login</a></li>
</ul>
</div>
<i class="fa fa-bars" onclick="show()"></i>

    </nav>

<div class="text-box">
<h1>World's Best Online Bakery</h1>
<p>Signup Page</p>
<a href="" class="btn">Visit us to know more</a>
</div>

</section>
<section class="Prijava">
    <h1>Job positions we are looking for</h1>
    <p>And their respective requirements</p>
    <div class="row">
        <div class="job-column">
            <h3>Part-Time Job</h3>
            <p>This position is for all the people that are interested in starting their baking career.
                You will be given detailed explanation of the basics if needed and will be payed accordingly.
                More Information on the requirements on this job on the forums page.
            </p>
            <button type="button" onclick="region()" class="dugmad">Check In</button>
        </div>
        <div class="job-column">
            <h3>Full-Time Job</h3>
            <p>This is where you will be able to send in the application to work full-time in one of our bakeries.
                Prior experience with the company is required and you will be payed accordingly to your success.
                You can get more information through contacting your superiors that you've met during your Part-Time escapades.
            </p>
            <button type="button" onclick="region()" class="dugmad">Check In</button>
        </div>
        <div class="job-column">
            <h3>Bakery Manager</h3>
            <p>If you've made successful work during your full-time job, you will be allowed to sign up for the manager role.
                This role will give you control of one of our bakeries, you will be required to keep track of the bakeries statistics,
                and will report to us accordingly, any and all blame for the bakery falls onto you, so be sure you are prepared for this Job.
            </p>
            <button type="button" onclick="region()" class="dugmad">Check In</button>
        </div>
    </div>
</section>
<section class="footer">
<h4>About us</h4>
<p>Topics regarding our privacy policy can be found </p><a href="">here.</a>
<div class="simboli">
<i class="fa fa-facebook"></i>
<i class="fa fa-twitter"></i>
<i class="fa fa-linkedin"></i>
</div>
</section>  
<script>
    var navlinks = document.getElementById("navlinks");
    function show() {
        navlinks.style.right = "0";
    }
    function hide() {
        navlinks.style.right = "-200px";
    }
    function region() {
        window.location.href = "Region.aspx"
    }

</script>
</body>
</html>