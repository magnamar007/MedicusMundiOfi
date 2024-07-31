

$(document).ready(function () {

    cargarUsuarios();
    cargarProyectos();
    
    $.datepicker.setDefaults($.datepicker.regional["es"])

    
    $("#txtFechadeEntrega").datepicker({ dateFormat: "dd/mm/yy" });
   
    $("#txtFechadeEntrega").val(ObtenerFecha());
    //dtListaTareasId();
    
})

function ObtenerFecha() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();

    return output;
}
function dtTarea() {
    // Verificar si el DataTable ya está inicializado
    if ($.fn.DataTable.isDataTable("#tbTarea")) {
        // Destruir el DataTable existente
        $("#tbTarea").DataTable().destroy();
        // Limpiar el contenedor del DataTable
        $('#tbTarea tbody').empty();
    }

    var request = { IdPer: $("#cboUsuarios").val()}

    table = $("#tbTarea").DataTable({
        responsive: true,
        "ajax": {
            "url": 'TareasM.aspx/usp_ObtenerTareasId',
            "type": "POST", // Cambiado a POST
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "data": function () {
                return JSON.stringify(request);
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
            { "data": "Idtarea", "visible": false, "searchable": false },
            {
                "data": "Proyecto"
            },
            { "data": "FeEntregaStrList" },
            { "data": "Estado" },            
            {
                "data": "Activo", render: function (data) {
                    if (data == true)
                        return '<span class="badge badge-info">Activo</span>';
                    else
                        return '<span class="badge badge-danger">No Activo</span>';
                }
            },
            {
                "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
                    '<button class="btn btn-danger btn-eliminar btn-sm"><i class="fas fa-trash-alt"></i></button>',
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

function dtListaTareasId() {
    console.log("Función dtListaTareasId ejecutada");
    if ($.fn.DataTable.isDataTable("#tbTarea")) {
        $("#tbTarea").DataTable().destroy();
        $('#tbTarea tbody').empty();
    }

    //var request = { IdPer: $("#cboUsuarios").val() }

    var request = { IdPer: $("#cboUsuarios").val() == null ? 0 : $("#cboUsuarios").val() }

    table = $("#tbTarea").DataTable({
        responsive: true,
        "ajax": {
            "url": 'TareasM.aspx/ListTareasId',
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
            { "data": "Idtarea", "visible": false, "searchable": false },
            { "data": "oEProyecto.Nombre" },
            { "data": "FeEntregaStrList" },
            {
                "data": "Estado"
            },
            {
                "data": "Activo", render: function (data) {
                    let editarButon = '';
                    if (data == true) {
                        editarButon = '<button class="btn btn-danger btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>';
                    }
                    return `'<button class="btn btn-info btn-detalle btn-sm" title="Ver Detalle"><i class="fas fa-eye"></i></button>'
                            ${editarButon}`;
                },
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
    $('#tbTarea tbody').on('click', '.btn-detalle', function (e) {
        e.preventDefault();
        let filaSeleccionada;
        if ($(this).closest("tr").hasClass("child")) {
            filaSeleccionada = $(this).closest("tr").prev();
        } else {
            filaSeleccionada = $(this).closest("tr");
        }
        const data = table.row(filaSeleccionada).data();
        //var data = table.row($(this).parents('tr')).data();
        $('#txtIdTarea').val(data.Idtarea);
        $('#detalleProyecto').text('Nombre del Proyecto: ' + data.oEProyecto.Nombre);
        $('#detalleFecha').text('Fecha de Entrega: ' + data.FeEntregaStrList);
        $('#detalleEstado').text('Estado: ' + data.Estado);
        $('#detalleModal').modal('show');
    });

}
function registerDataAjax() {
    //parseFloat($("#txtPresupuesto").val())

    var request = {
        oTarea: {
            IdUsuario: parseInt($("#cboUsuarios").val()),
            IdProyecto: parseInt($("#cboProyectos").val()),
            DescripcionTarea: $("#txtTarea").val()
        },
        fechaEntrega: $("#txtFechadeEntrega").val()
    }

    $.ajax({
        type: "POST",
        url: "TareasM.aspx/GuardarTarea",
        data: JSON.stringify(request),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        beforeSend: function () {
            // Mostrar overlay de carga antes de enviar la solicitud modal-content
            $("#loadTar").LoadingOverlay("show");
        },
        success: function (response) {
            $("#loadTar").LoadingOverlay("hide");
            if (response.d.estado) {
                //dtProyectos();

                //verificar si borrmos id usua
                
                $("#txtTarea").val("");
                


                alert(response.d.valor);

            } else {
                alert(response.d.valor);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#loadTar").LoadingOverlay("hide");
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
}

function cargarUsuarios() {
    $("#cboUsuarios").html("");

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
                    $("<option>").attr({ "value": row.IdUsuario }).text(row.Nombres + " " + row.Apellidos).appendTo("#cboUsuarios");

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

$('#btnResgistrarTarea').on('click', function () {

    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")

    

    if ($("#txtTarea").val().trim() == "") {
        toastr.warning("", "Debe completar el campo Tarea");
        $("#txtTarea").focus();
        return;
    }

    
    if (parseInt($("#txtIdTarea").val()) == 0) {
        //swal("Mensaje", "Guardado.", "success")
        //registerDataAjax();
        registerDataAjax();
    } else {
        alert("para actualizar");
        //editarDataAjaxU();
        //editarDataAjax();
    }




})

//$("#cboUsuarios").change(dtListaTareasId());

$("#cboUsuarios").change(function () {
    console.log("Cambio detectado en cboUsuarios")
    try {
        dtListaTareasId();
    } catch (error) {
        console.error("Error en dtListaTareasId ", error);
    }

});
$("#descargarPdf").on('click', function () {
    console.log('se ejecuto este boton');
    var idTarea = $("#txtIdTarea").val();
    var url = 'visualizarPdf.aspx?id=' + idTarea;
    window.open(url, '');

});