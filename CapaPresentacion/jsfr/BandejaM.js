

$(document).ready(function () {

    $('#calendar').fullCalendar({
        header: {
            left: 'today, prev, next',
            center: 'title',
            right: 'month, basicWeek, basicDay, agendaWeek, agendaDay'
        }

    })
    /*cargarTareas();*/
})
 //function cargarTareas() {

 //       $.ajax({
 //           type: "POST",
 //           url: "BandejaM.aspx/Obtener",
 //           data: {},
 //           contentType: 'application/json; charset=utf-8',
 //           error: function (xhr, ajaxOptions, thrownError) {
 //               console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
 //           },
 //           success: function (data) {
 //               if (data.d.estado) {
 //                   var events = [];

 //                   //console.log(data.d.objeto);
 //                   $.each(data.d.objeto, function (i, row) {
 //                       events.push({
 //                           id: row.Idtarea,
 //                           title: 'Datos: ' + row.oUsuario.Nombre + ' - ' + row.oProyecto.Nombre,
 //                           start: row.FeEntregaStrCalend,
 //                           descripcion: row.DescripcionTarea,
 //                           activo: row.Activo,
 //                           color: row.Color
 //                       });
 //                   });

 //                   $('#calendar').fullCalendar('destroy');
 //                   $('#calendar').fullCalendar({
 //                       header: {
 //                           left: 'prev,next today',
 //                           center: 'title',
 //                           right: 'month, basicWeek, basicDay'
 //                       },
 //                       /*navLinks: true,*/
 //                       /*selectable: true,*/
 //                       editable: true,
 //                       events: events,
 //                       eventClick: function (calEvent, jsEvent, view) {
 //                           $("#txtIdTarea").val(calEvent.id);
 //                           $("#txtTituloTarea").val(calEvent.title);
 //                           $("#txtFechaTarea").val(calEvent.start);
 //                           $("#txtTarea").val(calEvent.descripcion);
 //                           $("#modalTareas").modal();
 //                           //$("#txtDocumentoClienteat").val(calEvent.descripcion);
 //                           //$("#txtcelu").val(calEvent.id);
 //                           //$("#modalrol").modal("show");
 //                           //$("#txtIdTarea").val("0");
 //                           estadoRese = calEvent.activo;
 //                           console.log(calEvent.activo);
 //                           //detalleReserva(calEvent.id);
 //                       }
 //                       //eventRender: function (event, element) {
 //                       //    element.attr('title', event.descripcion);
 //                       //}
 //                   });
 //               }

 //           }
 //       });
 //   }
