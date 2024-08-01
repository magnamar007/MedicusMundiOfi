

var table;

const MODELO_BASE = {
    IdProyecto: 0,
    Nombre: "",
    Descripcion: "",
    FechaIni: "",
    FechaFin: "",
    Presupuesto: "",
    Activo: true
}

$(document).ready(function () {

    $("#OcultarEs").hide();
    $.datepicker.setDefaults($.datepicker.regional["es"])

    $("#txtPresupuesto").val("0");
    $("#txtFechaInicio").datepicker({ dateFormat: "dd/mm/yy" });
    $("#txtFechaFin").datepicker({ dateFormat: "dd/mm/yy" });
    $("#txtFechaInicio").val(ObtenerFecha());
    $("#txtFechaFin").val(ObtenerFecha());
    dtProyect();
})

function ObtenerFecha() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();

    return output;
}

let transaccionButon = '';
function dtProyect() {
    // Verificar si el DataTable ya está inicializado
    if ($.fn.DataTable.isDataTable("#tbProyecto")) {
        // Destruir el DataTable existente
        $("#tbProyecto").DataTable().destroy();
        // Limpiar el contenedor del DataTable
        $('#tbProyecto tbody').empty();
    }

    table = $("#tbProyecto").DataTable({
        responsive: true,
        "ajax": {
            "url": 'ProyectosM.aspx/ObtenerProyectos',
            "type": "POST", // Cambiado a POST
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "data": function (d) {
                return JSON.stringify(d);
            },
            "dataSrc": function (json) {
                //console.log("Response from server:", json.d.objeto);
                if (json.d.estado) {
                    return json.d.objeto; // Asegúrate de que esto apunta al array de datos
                } else {
                    return [];
                }
            }
        },
        "columns": [
            { "data": "IdProyecto", "visible": false, "searchable": false },
            {
                "data": "Nombre"
            },            
            { "data": "Presupuesto" },
            {
                "data": "Activo", render: function (data) {    
                    
                    if (data == true) {
                        transaccionButon = '<button class="btn btn-primary btn-guardar btn-sm"><i class="fas fa-comment-dollar"></i></button>'

                        return '<span class="badge badge-info">Activo</span>';
                    }
                    else
                    {
                        transaccionButon.disabled = true;
                        return '<span class="badge badge-danger">No Activo</span>';      
                    }
                }            
            },            
            {   
                "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
                    '<button class="btn btn-primary btn-guardar btn-sm"><i class="fas fa-comment-dollar"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": "80px"
            }
        ],
        "order": [[0, "desc"]],
        "dom": "Bfrtip",
        "buttons": [
            {
                text: 'Exportar Excel',
                extend: 'excelHtml5',
                title: '',
                filename: 'Reporte Productos',
                exportOptions: {
                    columns: [2, 3, 4, 5] // Ajusta según las columnas que desees exportar
                }
            },
            'pageLength'
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        }
    });
}

function sendDataToServer(request) {
    $.ajax({
        type: "POST",
        url: "ProyectosM.aspx/GuardarProyect",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            // Mostrar overlay de carga antes de enviar la solicitud modal-content
            $("#loaddd").LoadingOverlay("show");
        },
        success: function (response) {
            $("#loaddd").LoadingOverlay("hide");
            if (response.d.estado) {
                dtProyect();

                $('#txtNombreProyecto').val("");
                $('#txtDescripcion').val("");
                $('#txtPresupuesto').val("0");

                alert(response.d.valor);

            } else {
                alert(response.d.valor);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#loaddd").LoadingOverlay("hide");
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
}

function registerDataAjax() {
    

    var request = {
        oProyecto: {            
            Nombre: $("#txtNombreProyecto").val(),
            Descripcion: $("#txtDescripcion").val(),
            Presupuesto: parseFloat($("#txtPresupuesto").val())
        },
        fechainicio: $("#txtFechaInicio").val(),
        fechafin: $("#txtFechaFin").val()
    };
    
    sendDataToServer(request);
    
}

function sendDataToServerEdit(request) {
    $.ajax({
        type: "POST",
        url: "ProyectosM.aspx/ActualizarProyecto",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            // Mostrar overlay de carga antes de enviar la solicitud modal-content
            $("#loaddd").LoadingOverlay("show");
        },
        success: function (response) {
            $("#loaddd").LoadingOverlay("hide");
            if (response.d.Estado) {
                dtProduc();

                $('#txtIdProyecto').val("0");
                $('#txtNombreProyecto').val("");
                $('#txtDescripcion').val("");
                //$('#txtFechaInicio').val("");
                //$('#txtFechaFin').val("");
                $('#txtPresupuesto').val("0");
                //$("#cboEstado").val() == "1" ? true : false;
                $("#OcultarEs").hide();
                alert(response.d.valor);
            } else {
                alert(response.d.valor);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#loaddd").LoadingOverlay("hide");
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
}

function editarDataAjax() {
    
    //const modelo = structuredClone(MODELO_BASE);
    //modelo["IdProyecto"] = parseInt($("#txtIdProyecto").val());
    //modelo["Nombre"] = $("#txtNombreProyecto").val();
    //modelo["Descripcion"] = $("#txtDescripcion").val();
    //modelo["FechaIni"] = $("#txtFechaInicio").val();
    //modelo["FechaFin"] = $("#txtFechaFin").val();
    //modelo["Presupuesto"] = parseFloat($("#txtPresupuesto").val()); // Convertir a float
    //modelo["Activo"] = ($("#cboEstado").val() == "1" ? true : false);
    
    var request = {
        oProyecto: {
            IdProyecto: parseInt($("#txtIdProyecto").val()),
            Nombre: $("#txtNombreProyecto").val(),
            Descripcion: $("#txtDescripcion").val(),
            Presupuesto: parseFloat($("#txtPresupuesto").val()),
            Activo: ($("#cboEstado").val() == "1" ? true : false)
        },
        fechainicio: $("#txtFechaInicio").val(),
        fechafin: $("#txtFechaFin").val()
    };

    sendDataToServerEdit(request);
    
}

//function mostrarModal(modelo, cboEstadoDeshabilitado = true) {
//    // Verificar si modelo es null
//    modelo = modelo ?? MODELO_BASE;

//    $("#txtIdUsuario").val(modelo.IdUsuario);
//    $("#txtNombre").val(modelo.Nombres);
//    $("#txtapellido").val(modelo.Apellidos);
//    $("#txtCorreo").val(modelo.Correo);
//    $("#txtClave").val(modelo.Clave);
//    $("#txtTelefono").val(modelo.Celular);
//    $("#cboRol").val(modelo.IdArea == 0 ? $("#cboRol option:first").val() : modelo.IdArea);
//    $("#cboEstado").val(modelo.Activo == true ? 1 : 0);
//    $("#imgUsuarioM").attr("src", modelo.ImageFull == "" ? "imagenesU/usuaricon.png" : modelo.ImageFull);

//    // Configurar el estado de cboEstado según cboEstadoDeshabilitado jquery v 1.11.1
//    $("#cboEstado").prop("disabled", cboEstadoDeshabilitado);

//    //$("#txtCorreo").prop("disabled", !cboEstadoDeshabilitado);
//    $("#txtFoto").val("");

//    $("#modalData").modal("show");
//}
//$('#btnGuardarCambioM').on('click', function () {

//    const inputs = $("input.model").serializeArray();
//    const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")

//    if (inputs_sin_valor.length > 0) {
//        const mensaje = `Debe completar el campo : "${inputs_sin_valor[0].name}"`;
//        toastr.warning("", mensaje)
//        $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
//        return;
//    }


//    if (parseInt($("#txtIdProyecto").val()) == 0) {
//        registerDataAjax();
//    } else {
//        //swal("Mensaje", "Falta para Actualizar personal.", "warning")
//        editarDataAjax();
//    }
//})
$("#tbProyecto tbody").on("click", ".btn-editar", function (e) {
    e.preventDefault();
    let filaSeleccionada;

    if ($(this).closest("tr").hasClass("child")) {
        filaSeleccionada = $(this).closest("tr").prev();
    } else {
        filaSeleccionada = $(this).closest("tr");
    }

    const model = table.row(filaSeleccionada).data();

    $('#txtIdProyecto').val(model.IdProyecto);
    $('#txtNombreProyecto').val(model.Nombre);
    $('#txtDescripcion').val(model.Descripcion);
    $('#txtFechaInicio').val(model.Fechainistrin);
    $('#txtFechaFin').val(model.Fechainistrfin);
    $('#txtPresupuesto').val(model.Presupuesto);
    $("#cboEstado").val() == "1" ? true : false;
    $("#OcultarEs").show();

})
$("#tbProyecto tbody").on("click", ".btn-guardar", function (e) {
    e.preventDefault();
    let filaSeleccionada;

    if ($(this).closest("tr").hasClass("child")) {
        filaSeleccionada = $(this).closest("tr").prev();
    } else {
        filaSeleccionada = $(this).closest("tr");
    }
    $("#modalTransaccion").modal();
    

})
$('#btnGuardarCambios').on('click', function () {

    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item) => item.value.trim() =="")

    if (inputs_sin_valor > 0) {
        const mensaje = `Debe completar el campo : "${inputs_sin_valor[0].name}"`;
        toast.warning("", mensaje)
        $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
        return;
    }

    if ($("#txtDescripcion").val().trim() == "") {
        toastr.warning("", "Debe completar el campo Descripcion");
        $("#txtDescripcion").focus();
        return;
    }

    var montoPresupuesto = parseFloat($("#txtPresupuesto").val().trim());
    if (isNaN(montoPresupuesto) || montoPresupuesto === 0) {
        toastr.warning("", "Debe ingresar un presupuesto valido");
        $("#txtPresupuesto").focus();
        return;

    }
    if (parseInt($("#txtIdProyecto").val()) == 0) {
        //swal("Mensaje", "Guardado.", "success")
        //registerDataAjax();
        registerDataAjax();
    } else {
        //alert("para actualizar");
        //editarDataAjaxU();
        editarDataAjax();
    }
    



})