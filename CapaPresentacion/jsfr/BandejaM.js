

$(document).ready(function () {

    //$('#calendar').fullCalendar({
    //    header: {
    //        left: 'today, prev, next',
    //        center: 'title',
    //        right: 'month, basicWeek, basicDay, agendaWeek, agendaDay'
    //    }

    //})
    cargarTareas();
})
let estadoTarea = false;
 function cargarTareas() {
     /*var request = { IdPer: 1 };*/
        $.ajax({
            type: "POST",
            url: "BandejaM.aspx/Obtener",
            data: {},
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                if (data.d.estado) {
                    var events = [];

                    //console.log(data.d.objeto);
                    $.each(data.d.objeto, function (i, row) {
                        events.push({
                            id: row.Idtarea,
                            title: 'Datos: ' + row.oEUsuario.Nombres + ' - ' + row.oEProyecto.Nombre,
                            start: row.FeEntregaStrCalend,
                            descripcion: row.DescripcionTarea,
                            activo: row.Activo,
                            color: row.Color
                        });
                    });

                    $('#calendar').fullCalendar('destroy');
                    $('#calendar').fullCalendar({
                        header: {
                            left: 'prev,next today',
                            center: 'title',
                            right: 'month, basicWeek, basicDay'
                        },
                        /*navLinks: true,*/
                        /*selectable: true,*/
                        editable: true,
                        events: events,
                        eventClick: function (calEvent, jsEvent, view) {
                            $("#txtIdTarea").val(calEvent.id);
                            $("#txtTituloTarea").val(calEvent.title);
                            $("#txtFechaTarea").val(calEvent.start);
                            $("#txtTarea").val(calEvent.descripcion);
                            $("#modalTareas").modal();
                            //$("#txtDocumentoClienteat").val(calEvent.descripcion);
                            //$("#txtcelu").val(calEvent.id);
                            //$("#modalrol").modal("show");
                            //$("#txtIdTarea").val("0");
                            estadoRese = calEvent.activo;
                            console.log(calEvent.activo);
                            detalleTarea(calEvent.id);
                        }
                        //eventRender: function (event, element) {
                        //    element.attr('title', event.descripcion);
                        //}
                    });
                }

            }
        });
}

function detalleTarea($idTar) {


    var request = {
        Idtarea: $idTar
    };

    $.ajax({
        type: "POST",
        url: "BandejaM.aspx/DetalleTarea",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d.estado) {

                $("#txtIdTarea").val($idTar);

                $("#txtNombreUsu").val(data.d.objeto.oEUsuario.Nombre);
                $("#txtNombreProy").val(data.d.objeto.oEProyecto.NumeroDocumento);
                $("#txtDescripcionTarea").val(data.d.objeto.DescripcionTarea);
                
                

                //var idresevi = parseInt($("#txtIdReserrr").val());
                // Validar estadoRese y habilitar o deshabilitar el botón
                if (estadoTarea) {
                    $("#btnEntregar").show();
                    //$("#btnGuardarCambiosat").removeAttr("disabled");
                } else {
                    $("#btnEntregar").hide();
                    //$("#btnGuardarCambiosat").attr("disabled", "disabled");
                }

                
            } else {
                alert("Mensaje", data.d.valor, "success");
            }
        }
    });
}

$('#btnEntregar').on('click', function (e) {
    e.preventDefault();
    //var idresevi = parseInt($("#txtIdReserrr").val());
    var Idtarea = $("#txtIdTarea").val();
    //var url = 'frmVentaReserva.aspx?id=' + encodeURIComponent(idreser);
    var url = 'EntregarTarea.aspx?id=' + Idtarea;

    window.location.href = url;
})