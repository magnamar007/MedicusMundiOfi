
$(document).ready(function () {

    cargarUsuariosN();
    cargarProyectosN();
    cargarProyectos();
    dtListaTransancionesId();
    $.datepicker.setDefaults($.datepicker.regional["es"])

    
    $("#txtFechaTransa").datepicker({ dateFormat: "dd/mm/yy" });
    
    $("#txtFechaTransa").val(ObtenerFecha());
    
    //dtProyect();
})
function cargarUsuariosN() {
    $("#cboUsuariosN").html("");

    $.ajax({
        type: "POST",
        url: "PersonalM.aspx/ObtenerUsuario",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d.estado) {
                $.each(data.d.objeto, function (i, row) {
                    $("<option>").attr({ "value": row.IdUsuario }).text(row.Nombres + " " + row.Apellidos).appendTo("#cboUsuariosN");

                })
            }

        }
    });
}
function cargarProyectosN() {
    $("#cboProyectosN").html("");

    $.ajax({
        type: "POST",
        url: "ProyectosM.aspx/ObtenerProyectos",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d.estado) {
                $.each(data.d.objeto, function (i, row) {
                    if (row.Activo == true) {
                        $("<option>").attr({ "value": row.IdProyecto }).text(row.Nombre).appendTo("#cboProyectosN");
                    }

                })
            }

        }
    });
}
function cargarProyectos() {
    $("#cboProyectos").html("");

    $.ajax({
        type: "POST",
        url: "ProyectosM.aspx/ObtenerProyectos",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d.estado) {
                $.each(data.d.objeto, function (i, row) {
                    if (row.Activo == true) {
                        $("<option>").attr({ "value": row.IdProyecto }).text(row.Nombre).appendTo("#cboProyectos");
                    }

                })
            }

        }
    });
}
function dtListaTransancionesId() {
    console.log("Función dtListaTransancionesId ejecutada");
    if ($.fn.DataTable.isDataTable("#tbTransaccion")) {
        $("#tbTransaccion").DataTable().destroy();
        $('#tbTransaccion tbody').empty();
    }

    //var request = { IdPer: $("#cboUsuarios").val() }

    var request = { idPro: $("#cboProyectos").val() == null ? 0 : $("#cboProyectos").val() }

    table = $("#tbTransaccion").DataTable({
        responsive: true,
        "ajax": {
            "url": 'TransaccionesM.aspx/ListTransaccionId',
            "type": "POST",
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "data": function () {
                return JSON.stringify(request);
            },
            "dataSrc": function (json) {
                if (json.d.estado) {
                    return json.d.objeto;
                } else {
                    return [];
                }
            }
        },
        "columns": [
            { "data": "Idtransaccion", "visible": false, "searchable": false },
            { "data": "oEProyecto.Nombre" },
            { "data": "FechaTransa"},
            { "data": "TipoPago" },
            {
                "data": "Monto"
            },
            {
                //"data": "Activo", render: function (data) {
                //    let editarButon = '';
                //    if (data == true) {
                //        editarButon = '<button class="btn btn-danger btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>';
                //    }
                //    return `'<button class="btn btn-info btn-detalle btn-sm" title="Ver Detalle"><i class="fas fa-eye"></i></button>'
                //            ${editarButon}`;
                //},
                "orderable": false,
                "searchable": false,
                "width": "80px"
            },

        ],
        "dom": "rt",
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },

    });
    //$('#tbTarea tbody').on('click', '.btn-editar', function (e) {
    //    e.preventDefault();
    //    var Estado = ;
    //    if (Estado == "Sin Entregar") {
    //        $(".btn-editar").show();
    //    } else {
    //        $(".btn-editar").hide();
    //    }
    //});
    //$('#tbTarea tbody').on('click', '.btn-detalle', function (e) {
    //    e.preventDefault();
    //    let filaSeleccionada;
    //    if ($(this).closest("tr").hasClass("child")) {
    //        filaSeleccionada = $(this).closest("tr").prev();
    //    } else {
    //        filaSeleccionada = $(this).closest("tr");
    //    }
    //    const data = table.row(filaSeleccionada).data();
    //    //var data = table.row($(this).parents('tr')).data();
    //    $('#txtIdTarea').val(data.Idtarea);
    //    $('#detalleProyecto').text('Nombre del Proyecto: ' + data.oEProyecto.Nombre);
    //    $('#detalleFecha').text('Fecha de Entrega: ' + data.FeEntregaStrList);
    //    $('#detalleEstado').text('Estado: ' + data.Estado);
    //    $('#detalleModal').modal('show');
    //});

}
function sendDataToServer(request) {
    $.ajax({    
        type: "POST",
        url: "TransaccionesM.aspx/GuardarTransaccion",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            // Mostrar overlay de carga antes de enviar la solicitud modal-content
            $("#loadTransa").LoadingOverlay("show");
        },
        success: function (response) {
            $("#loadTransa").LoadingOverlay("hide");
            if (response.d.estado) {
                //dtProyect();

                //$('#txtNombreProyecto').val("");
                //$('#txtDescripcion').val("");
                //$('#txtPresupuesto').val("0");

                alert(response.d.valor);

            } else {
                alert(response.d.valor);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#loadTransa").LoadingOverlay("hide");
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
}
function registerDataAjax() {


    var request = {
        oTransaccion: {
            IdUsuario: parseInt($("#cboUsuariosN").val()),
            IdProyecto: parseInt($("#cboProyectosN").val()),
            DescripcionPago: $("#txtDescripciondePago").val(),
            TipoPago: $("#cboMetodoPago").val(),
            Monto: parseFloat($("#txtMonto").val())
        },
        fechaTransa: $("#txtFechaTransa").val()
        
    };

    sendDataToServer(request);

}
function ObtenerFecha() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();

    return output;
}
$("#btnNuevaTransa").on("click", function (e) {
    e.preventDefault();
    let filaSeleccionada;

    if ($(this).closest("tr").hasClass("child")) {
        filaSeleccionada = $(this).closest("tr").prev();
    } else {
        filaSeleccionada = $(this).closest("tr");
    }
    $("#modalTransaccion").modal();

})
$('#btnGuardarTransaccion').on('click', function () {

    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")

    if (inputs_sin_valor.length > 0) {
        const mensaje = `Debe completar el campo : "${inputs_sin_valor[0].name}"`;
        toastr.warning("", mensaje)
        $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
        return;
    }


    if (parseInt($("#txtIdtransaccion").val()) == 0) {
        //swal("Mensaje", "Guardado.", "success")
        //registerDataAjax();
        registerDataAjax();
    } else {
        alert("Falta para Actualizar.");
        //editarDataAjaxU();
        //UpdateUserDataAjax();
    }
})