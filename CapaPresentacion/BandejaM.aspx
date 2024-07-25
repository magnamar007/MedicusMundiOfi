<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BandejaM.aspx.cs" Inherits="CapaPresentacion.BandejaM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link rel="stylesheet" href="css/fullcalendar.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
   <div class="card shadow mb-4">
       <div class="card-header py-3 bg-second-primary">
           <h6 class="m-0 font-weight-bold text-white">Bandeja de Tareas</h6>
       </div>
   </div>
    <div class="card-body">
        <div class="row">
            <div class="col-lg-2">
                <h6 class="m-0 font-weight-bold">Eventos</h6>
            </div>
            <div id="calendar" class="col-lg-10"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="vendor/calen/moment.min.js"></script>
    <script src="vendor/calen/jquery.min.js"></script>
    <script src="vendor/calen/fullcalendar.min.js"></script>
    <script src="vendor/calen/es.js"></script>
    <script src="jsfr/BandejaM.js" type="text/javascript"></script>
</asp:Content>
