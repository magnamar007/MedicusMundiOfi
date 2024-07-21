<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ProyectosM.aspx.cs" Inherits="CapaPresentacion.ProyectosM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <div class="card shadow mb-4">
    <div class="card-header py-3 bg-second-primary">
        <h6 class="m-0 font-weight-bold text-white"><i class="fa fa-pen fa-lg"></i>Proyecto</h6>
    </div>
    <div class="card-body">
        
        <div class="row">
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
                            <div class="form-row">
                                    <div class="form-group col-sm-12">
                                        <label for="txtDescripcion">Descripcion</label>
                                    </div>
                                    <div class="row justify-content-center justify-content-md-start">
                                        <textarea id="txtDescripcion" name="DescripcionProyecto" cols="" rows="5" placeholder="Escriba la descripcion del proyecto" required></textarea>                                                         
                                    </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-6">
                                    <label for="txtFechaInicio">FechaIni <input type="date" name="fechaini" /></label>
                                    <input type="text" class="form-control form-control-sm input-validar" id="txtFechaInicio" name="FechaInicio">
                                </div>
                                <div class="form-group col-sm-6">
                                    <label for="txtFechaFin">FechaFin <input type="date" name="fechafin" /></label>
                                    <input type="text" class="form-control form-control-sm input-validar" id="txtFechafin" name="FechaFin">
                                </div>
                            </div>
                            <div class="form-row">
                                    <div class="col-md-6 ml-md-auto">
                                        <label for="cboEstado">Estado</label>
                                        <select class="form-control form-control-sm" id="cboEstado">
                                            <option value="1">Activo</option>
                                            <option value="0">No Activo</option>
                                        </select>
                                    </div>
                                    <div class="col-md-6 ml-md-auto">
                                        <div class="col-sm-12">
                                        <button class="btn btn-success btn-sm" type="button" id="btnGuardarCambios">Guardar Cambios</button>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <div class="row justify-content-center justify-content-md-start">
                                    <label for="prueba">prueba</label>
                                    <textarea id="txtprueba" name="DescripcionProyecto" cols="47" rows="3" placeholder="Escriba la descripcion del proyecto" required></textarea>
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
            <div class="col-sm-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3 bg-second-primary">
                        <h6 class="m-0 font-weight-bold text-white"><i class="fas fa-fw fa-clipboard-list"></i>Lista de Proyectos</h6>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-bordered" id="tbUsuario" cellspacing="0" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Nombre  </th>
                                        <th>Descripcion</th>
                                        <th>Presupuesto</th>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
</asp:Content>
