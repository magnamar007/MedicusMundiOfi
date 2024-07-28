<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EntregarTarea.aspx.cs" Inherits="CapaPresentacion.EntregarTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendor/jquery-ui/jquery-ui.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-6">
            <div class="card shadow mb-4">
                <div class="card-header py-4 bg-second-primary">
                <h6 class="m-0 font-weight-bold text-white"><i class="fa fa-pen fa-lg"></i>Detalles de tarea</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                        <input type="hidden" value="0" id="txtIdTarea" />
                        <div class="form-row">
                            <div class="form-group col-sm-6">
                                <label for="txtNombreUsu">Nombre</label>
                                <input type="text" class="form-control input-group-sm" disabled id="txtNombreUsu"/>
                            </div>
                            <div class="form-group col-sm-6">
                                <label for="txtNombreProy">Proyecto</label>
                                <input type="text" class="form-control input-group-sm" disabled id="txtNombreProy"/>
                            </div>
                            <div class="form-group col-sm-12">
                                <label for="txtDescripcionTarea">Descripcion de la tarea</label>
                                <textarea class="form-control" id="txtDescripcionTarea" name="DescripcionTarea" cols="40" rows="3" disabled></textarea>
                                <label for="txtComentario">Comentario</label>
                                <textarea class="form-control" id="txtComentario" name="ComentarioTarea" cols="40" rows="3"></textarea>
                                <label for="docPdf">Subir pdf</label>
                                <input type="file" class="form-control-file" id="pdfFile" name="pdfFile" required />
                                <br />
                                <div class="text-center">
                                <button class="btn btn-success btn-sm" type="button" id="btnEntregarTarea">Entregar tarea</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class=" card shadow mb-4">
                <div class="card-header py-4 bg-second-primary">
                    <h6 class="m-0 font-weight-bold text-white"><i class="fas fa-desktop"></i> Vista Previa</h6>
                </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-row col-sm-12">
                                    <embed id="vistaPrevia" type="application/pdf" width="400" height="450"/>
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
    <script src="jsfr/EntregarTareaM.js" type="text/javascript"></script>
</asp:Content>
