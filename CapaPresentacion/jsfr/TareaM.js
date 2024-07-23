

$(document).ready(function () {

    
    $.datepicker.setDefaults($.datepicker.regional["es"])

    $("#txtPresupuesto").val("0");
    $("#txtFechaInicio").datepicker({ dateFormat: "dd/mm/yy" });
    $("#txtFechaFin").datepicker({ dateFormat: "dd/mm/yy" });
    $("#txtFechaInicio").val(ObtenerFecha());
    $("#txtFechaFin").val(ObtenerFecha());
    dtProyect();
})


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


function registerDataAjax() {
    //parseFloat($("#txtPresupuesto").val())

    var request = {
        oTarea: {
            IdUsuario: parseInt($("#txtIdusu").val()),
            IdProyecto: parseInt($("#txtIdproy").val()),
            DescripcionTarea: $("#txtDescripcion").val()
        },
        fechaEntrega: $("#txtfechaentreg").val()
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
                $("#txtIdusu").val("0");
                $("#txtIdproy").val("0");
                $("#txtNombreUsuario").val("");
                $("#txtCargo").val("");
                $("#txtNombreProyecto").val("");
                $("#txtPresupuesto").val("");

                $("#txtDescripcion").val("");

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