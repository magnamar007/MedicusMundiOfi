

$(document).ready(function () {
    $('#calendar').fullCalendar({
        header: {
            left: 'today, prev, next',
            center: 'title',
            right: 'month, basicWeek, basicDay, agendaWeek, agendaDay'
        },
        dayClick: function (date, jsEvent, view) {
            alert("Valor seleccionado: " + date.format());
            alert("Vista actual: " + view.name);
            $(this).css('background-color', 'red');
            $("#exampleModal").modal();
        },
        eventSources: [{
            events: [
                {
                    title: 'Primera prueba de evento',
                    start: '2024-07-25',
                    color: "red",
                    textColor: "white"
                },
                {
                    title: 'Segunda prueba de evento el cual tiene 2 dias',
                    start: '2024-07-15',
                    end: '2024-07-18'
                },
                {
                    title: 'Tercera prueba de evento con hora',
                    start: '2024-07-28T12:30:00',
                    allDay: false,
                    color: "pink",
                    textColor: "green"
                }
            ],
            color: "black",
            textColor: "yellow" 

        }]
        
    });
});
