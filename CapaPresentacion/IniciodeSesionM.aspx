<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciodeSesionM.aspx.cs" Inherits="CapaPresentacion.IniciodeSesionM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css"/>
    <link rel="stylesheet" href="css/Estilo.css"/>
    <title>Inicio de Sesion</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
    <div class="container" id="container">
        <div class="form-container sign-up">
            <formR>
                <h2>Recuperar Contraseña</h2>
                
                <span> ingrese los datos de recuperacion.!</span>
                <input type="text" placeholder="Nombre"/>
                <input type="email" placeholder="Correo"/>
                
                <button id="EnviarCorreoM">Enviar correo</button>
                <br/>
                <aText><i class="fa-brands fa-mailchimp"></i>  Revisa tu Bandeja</aText>
            </formR>
        </div>
        <div class="form-container sign-in">
            <formR id="login">
                <h1>Iniciar Sesion</h1>
                <div class="social-icons">
                    <a href="#" class="icon"><i class="fa-brands fa-google-plus-g"></i></a>
                    <a href="#" class="icon"><i class="fa-brands fa-facebook-f"></i></a>
                    <a href="#" class="icon"><i class="fa-brands fa-github"></i></a>
                    <a href="#" class="icon"><i class="fa-brands fa-twitter"></i></a>
                </div>
                <span>o usa tu correo y contraseña.!</span>
                <input type="email" id="emailM" placeholder="Correo"/>
                <input type="password" id="passwordM" placeholder="Contraseña"/>
                
                <button type="button" id="InicioM">Iniciar Sesion</button>
                <p id="message"></p>
            </formR>
        </div>
        <div class="toggle-container">
            <div class="toggle">
                <div class="toggle-panel toggle-left">
                    <h1><img src="imagenesU/main-logo-transparent recortada.png" alt="MedicusMundi" class="responsive-image"/>Ingrese sus datos personales para acceder al sistema!</h1>
                    
                    <button class="hidden" id="InicioSesion">Iniciar Sesion</button>
                </div>
                <div class="toggle-panel toggle-right">
                    <h1><img src="imagenesU/main-logo-transparent recortada.png" alt="MedicusMundi" class="responsive-image"/>¿Olvidaste tu contraseña?</h1>
                    
                    <button class="hidden" id="recuperar">Recuperar contraseña</button>
                </div>
            </div>
        </div>
    </div>


    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="jsfr/IniciodeSesionM.js"></script>
        </div>
    </form>
</body>
</html>
