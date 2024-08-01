
$(document).ready(function () {

    cargarUsuariosN();
    cargarProyectosN();
    cargarProyectos();
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