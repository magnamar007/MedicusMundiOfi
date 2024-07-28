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
    <!--modal-->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content" id="exampleModalInput">
      <div class="modal-header">
        <h5 class="modal-title" id="tituloModal"></h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div id="descripcionModal"></div>
      </div>
      <div class="modal-footer">

            <button type="button" class="btn btn-success" >agregar</button>
            <button type="button" class="btn btn-secondary" >modificar</button>
            <button type="button" class="btn btn-danger" >eliminar</button>
            <button type="button" class="btn btn-default" data-dismiss="modal">cerrar</button>

      </div>
    </div>
  </div>
</div>

    <div class="modal fade" id="modalTareas" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" id="tareasModalInput">
                <div class="modal-header">
                    <h5 class="modal-title" id="tituloTarea"></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <input id="txtIdTarea" class="model" name="IdTarea" value="0" type="hidden" />
                    <div class="form-row">
                        <div class="form-group col-sm-5">
                            <input type="text" class="form-control input-sm" disabled id="txtTituloTarea">
                        </div>
                        <div class="form-group col-sm-3">
                            <input type="text" class="form-control input-sm" disabled id="txtFechaTarea">
                        </div>
                    </div>
                    <div class="container-center">
                    <label for="txtTarea">Descripcion de tarea</label>
                    <textarea class="form-control" id="txtTarea" name="DescripcionTarea" cols="40" rows="3"></textarea>
                    </div>
                </div>
                <div class="modal-footer">

                    <button type="button" class="btn btn-success" id="btnEntregar">agregar</button>                    
                    <button type="button" class="btn btn-default" data-dismiss="modal">cerrar</button>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="vendor/calen/moment.min.js"></script>
    <script src="vendor/calen/jquery.min.js"></script>
    <script src="vendor/calen/fullcalendar.min.js"></script>
    <script src="vendor/calen/es.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="jsfr/BandejaM.js" type="text/javascript"></script>
</asp:Content>
