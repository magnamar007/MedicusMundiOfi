<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TransaccionesM.aspx.cs" Inherits="CapaPresentacion.TransaccionesM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/jquery-ui/jquery-ui.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card shadow mb-4">
                <div class="card-header py-3 bg-second-primary">
                <h6 class="m-0 font-weight-bold text-white">Detalles de las transacciones</h6>
                </div>
            </div>
            <div class="card-body">
                <div class="form-row col-sm-6">
                <input type="hidden" id="txtIdtransaccionR">
                <div class="form-group col-sm-6">
                    <label for="cboProyectos">Seleccion de proyectos</label>
                    <select class="form-control form-control-sm" id="cboProyectos"></select>
                </div>
                    <div class="col-md-6 ml-md-auto text-center">
                        <button type="button" id="btnNuevaTransa" class="btn btn-success"><i class="fas fa-user-plus"></i>Nuevo Transaccion</button>
                    </div>
                </div>
                <hr />
                <div class="col-sm-12">
                    <table class="table table-striped table-sm" id="tbTransaccion">
                        <thead>
                            <tr>
                                <th>ID Transaccion</th>
                                <th>Proyecto</th>                                
                                <th>Fecha</th>
                                <th>Tipo de pago</th>
                                <th>Monto</th>
                                <th>Archivo adj.</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalTransaccion" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h6>Detalle Transaccion</h6>
                <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
            </div>
            <div class="modal-body" id="loadTransa">
                <input type="hidden" value="0" id="txtIdtransaccion">
                <div class="row">
                    <div class="col-sm-8">
                        <div class="form-row">
                            <div class="form-group col-sm-6">
                                <label for="cboUsuariosN">Seleccion de usuarios</label>
                                <select class="form-control form-control-sm" id="cboUsuariosN"></select>
                            </div>
                            <div class="form-group col-sm-6">
                                <label for="cboProyectosN">Seleccion de proyectos</label>
                                <select class="form-control form-control-sm" id="cboProyectosN"></select>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-sm-12">
                                <label for="txtDescripciondePago">Descripcion de pago</label>
                                <textarea class="form-control form-control-sm input-validar" id="txtDescripciondePago" name="DescripciondePago" cols="40" rows="3"></textarea>
                            </div>                               
                        </div>
                        <div class="form-row">
                            <div class="form-group col-sm-6">
                                <label for="txtFechaTransa">Fecha de Transaccion</label>
                                <input type="text" class="form-control form-control-sm input-validar" id="txtFechaTransa" name="FechaTransa">
                            </div>
                            <div class="form-group col-sm-6">
                                 <label for="cboMetodoPago">Metodo de pago</label>
                                    <select class="form-control form-control-sm" id="cboMetodoPago">
                                    <option>QR virtual, Transferencia</option>
                                    <option>Moneda Fisico</option>
                                    </select>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-sm-6">
                                <label for="txtMonto">Monto de Pago</label>
                                <input type="text" class="form-control form-control-sm input-validar" id="txtMonto" name="Celular">                                    
                            </div>
                        </div>
                    </div>

                <div class="col-sm-4 text-center">
                     <%--<img id="imgUsuario" style="max-width:200px;" src="https://images.unsplash.com/photo-1519648023493-d82b5f8d7b8a?w=300" class="rounded mx-auto d-block" alt="Foto usuario">--%>
                    <img id="imgUsuarioM" src="imagenesU/main-logo-transparent recortada.png" alt="Foto usuario" style="height: 200px; max-width: 200px; border-radius: 50%;">
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button id="btnGuardarTransaccion" class="btn btn-primary btn-sm" type="button">Guardar</button>
                <button class="btn btn-danger btn-sm" type="button" data-dismiss="modal">Cancel</button>
            </div>
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="vendor/jquery-ui/jquery-ui.js"></script>
    <script src="vendor/jquery-ui/idioma/datepicker-es.js"></script>
    <script src="jsfr/TransaccionesM.js" type="text/javascript"></script>
</asp:Content>
