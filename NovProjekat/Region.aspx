<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Region.aspx.cs" Inherits="NovProjekat.Region" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Signup</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Regioncss.css" />
</head>
    <body>
         <div> 
    <form id="formular" runat="server" method="post" style="background-color:black;">
        <div id="greska"></div>
        <br />
        <br />
        <br />
        <br />
            <fieldset class="form-group">
                <legend>Licni podaci</legend>
                <div>
                <div class="form-group col-6">
                    <label for="ime">Korisnicko ime</label>
                    <input type="text" id="ime" class="form-control col-6" placeholder="Username" name="ime" />
               
                    </div>
                    <br />
                    <br />
                <div class="form-group col-6">
                    <label for="Adresa">Adresa</label>
                    <input type="text" id="adresa" class="form-control col-6" placeholder="Address" name="adresa" />
                    <div class="invalid-feedback">
                    </div>
                    <br />
                    <br />
                </div>
                <div class="form-group col-6">
                    <label for="telefon">Broj Telefona</label>
                    <input type="text" id="telefon" class="form-control col-6" placeholder="##########" name="telefon" />
                    </div>
                    <br />
                    <br />
                </div>
            </fieldset>
        <br />
        <br />
                        <div class="form-group text-center">
                    <button id="posalji" type="submit" class="btn-primary btn" runat="server">Potvrdi</button>
                </div>
        </form>
        <div>
            <script src="Jafat.js"></script>
        </div>
        </body>
</html>