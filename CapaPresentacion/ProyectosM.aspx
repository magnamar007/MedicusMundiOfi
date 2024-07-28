<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ProyectosM.aspx.cs" Inherits="CapaPresentacion.ProyectosM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/jquery-ui/jquery-ui.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-5">
            <div class="card shadow mb-4" id="loaddd">
                <div class="card-header py-3 bg-second-primary">
                    <h6 class="m-0 font-weight-bold text-white"><i class="fa fa-pen fa-lg"></i>Proyecto</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                        <input type="hidden" value="0" id="txtIdProyecto">
                        <div class="col-sm-12">
                            <div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-row">
                                            <div class="form-group col-sm-6">
                                                <label for="txtNombreProyecto">Nombre del Proyecto</label>
                                                <input type="text" class="form-control form-control-sm input-validar" id="txtNombreProyecto" name="Numero Documento">
                                            </div>
                                            <div class="form-group col-sm-6">
                                                <label for="txtPresupuesto">Presupuesto</label>
                                                <input type="text" class="form-control form-control-sm input-validar" id="txtPresupuesto" name="Razon Social">
                                            </div>
                                        </div>
                                        <div class="container-center">
                                            <label for="txtDescripcion">Descripcion</label>
                                            <textarea class="form-control" id="txtDescripcion" name="DescripcionProyecto" cols="40" rows="3" placeholder="Escriba la descripcion del proyecto"></textarea>
                                        </div>
                                        <br />
                                        <div class="form-row">
                                            <div class="form-group col-sm-6">
                                                <label for="txtFechaInicio">
                                                    FechaIni
                                    <input class="form-control col-sm-11" id="txtFechaInicio" type="text" name="fechaini" /></label>
                                            </div>
                                            <div class="form-group col-sm-6">
                                                <label for="txtFechaFin">
                                                    FechaFin
                                    <input class="form-control col-sm-11" id="txtFechaFin" type="text" name="fechafin" /></label>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="form-group col-sm-6" id="OcultarEs">
                                                <label for="cboEstado">Estado</label>
                                                <select class="form-control col-sm-9" id="cboEstado">
                                                    <option value="1">Activo</option>
                                                    <option value="0">No Activo</option>
                                                </select>
                                            </div>
                                            <div class="col-md-6 ml-md-auto text-center">

                                                <div class="form-control-user">
                                                    <br />
                                                    <button class="btn btn-success btn-sm" type="button" id="btnGuardarCambios">Guardar Cambios</button>
                                                </div>
                                            </div>
                                        </div>
                                        <div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-7">
            <div class="card shadow mb-4">
                <div class="card-header py-3 bg-second-primary">
                    <h6 class="m-0 font-weight-bold text-white"><i class="fa-clipboard fa-lg"></i>Lista de Proyectos</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <table class="table table-bordered" id="tbProyecto" cellspacing="0" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th>Nombre</th>
                                                <th>Presupuesto</th>
                                                <th>Activo</th>
                                                <th>Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalData" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h6>Detalle Usuario</h6>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <input type="hidden" value="0" id="txtIdUsuario">
                    <div class="row">
                        <div class="col-sm-8">
                            <div class="form-row">
                                <div class="form-group col-sm-6">
                                    <label for="txtNombre">Nombres</label>
                                    <input type="text" class="form-control form-control-sm input-validar" id="txtNombre" name="Nombre">
                                </div>
                                <div class="form-group col-sm-6">
                                    <label for="txtapellido">Apellidos</label>
                                    <input type="text" class="form-control form-control-sm input-validar" id="txtapellido" name="Apellidos">
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-6">
                                    <label for="txtCorreo">Correo</label>
                                    <input type="email" class="form-control form-control-sm input-validar" id="txtCorreo" name="Correo">
                                </div>
                                <div class="form-group col-sm-6">
                                    <label for="txtClave">Contraseña</label>
                                    <input type="text" class="form-control form-control-sm input-validar" id="txtClave" name="Contraseña">
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-6">
                                    <label for="txtTelefono">Celular</label>
                                    <input type="text" class="form-control form-control-sm input-validar" id="txtTelefono" name="Celular">
                                </div>
                                <div class="form-group col-sm-6">
                                    <label for="cboRol">Cargo</label>
                                    <select class="form-control form-control-sm" id="cboRol">
                                    </select>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-6">
                                    <label for="cboEstado">Estado</label>
                                    <select class="form-control form-control-sm" id="cboEstadoM">
                                        <option value="1">Activo</option>
                                        <option value="0">No Activo</option>
                                    </select>
                                </div>
                                <div class="form-group col-sm-6">
                                    <label for="txtFoto">Foto</label>
                                    <input class="form-control-file" type="file" id="txtFoto" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnGuardarCambioM" class="btn btn-primary btn-sm" type="button">Guardar</button>
                    <button class="btn btn-danger btn-sm" type="button" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="vendor/jquery-ui/jquery-ui.js"></script>
    <script src="vendor/jquery-ui/idioma/datepicker-es.js"></script>
    <script src="jsfr/ProyectosM.js" type="text/javascript"></script>
</asp:Content>
