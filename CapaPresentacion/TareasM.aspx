<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TareasM.aspx.cs" Inherits="CapaPresentacion.TareasM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/jquery-ui/jquery-ui.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-5">
            <div class="col-sm-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3 bg-second-primary">
                        <h6 class="m-0 font-weight-bold text-white">Area de seleccion</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="form-group col-sm-6">
                                <label for="cboUsuarios">Seleccion de usuarios</label>
                                <select class="form-control form-control-sm" id="cboUsuarios"></select>
                            </div>
                            <div class="form-group col-sm-6">
                                <label for="cboProyectos">Seleccion de proyectos</label>
                                <select class="form-control form-control-sm" id="cboProyectos"></select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="card shadow mb-4" id="loadTar">
                    <div class="card-header py-3 bg-second-primary">
                        <h6 class="m-0 font-weight-bold text-white">Tarea</h6>
                    </div>
                    <div class="card-body">
                        <input type="hidden" value="0" id="txtIdTarea">
                        <div class="container-center">
                            <label for="txtTarea">Descripcion de tarea</label>
                            <textarea class="form-control" id="txtTarea" name="DescripcionTarea" cols="40" rows="3" placeholder="Escriba la descripcion de la Tarea"></textarea>
                        </div>
                        <hr />
                        <div class="input-group input-group-sm mb-3">
                            <label for="txtFechadeEntrega">
                                Fecha de Entrega
                             <input class="form-control col-sm-11" id="txtFechadeEntrega" type="text" name="fechaentrega" /></label>
                        </div>
                        <hr />
                        <div class="form-row">
                            <div class="form-group col-sm-6">
                                <label for="cboEstado">Estado</label>
                                <select class="form-control form-control-sm" id="cboEstado">
                                    <option value="">en ejecucion</option>
                                    <option value="">retrasado</option>
                                    <option value="">finalizado</option>
                                </select>
                            </div>
                            <div class="col-md-6 ml-md-auto text-center">
                                <div class="form-control-user">
                                    <br />
                                    <button class="btn btn-success btn-sm" type="button" id="btnResgistrarTarea">Registrar Tarea</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-7">
            <div class="col-sm-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3 bg-second-primary">
                        <h6 class="m-0 font-weight-bold text-white">Tarea asignada</h6>
                    </div>
                    <div class="card-body">
                        <div class="col-sm-12">
                            <table class="table table-striped table-sm" id="tbTarea">
                                <thead>
                                    <tr>
                                        <th>ID Tarea</th>
                                        <th>Proyecto</th>
                                        <th>fecha</th>
                                        <th>Estado</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                            <div class="modal fade" id="detalleModal" tabindex="-1" role="dialog" aria-labelledby="detalleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="detalleModalLabel">Detalles de la Tarea</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <p id="detalleProyecto"></p>
                <p id="detalleFecha"></p>
                <p id="detalleEstado"></p>
            </div>
            <div class="modal-footer">
                
                <button type="button" class="btn-secondary" id="descargarPdf">Descargar pdf</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="vendor/jquery-ui/jquery-ui.js"></script>
    <script src="vendor/jquery-ui/idioma/datepicker-es.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="jsfr/TareaM.js" type="text/javascript"></script>    
</asp:Content>
