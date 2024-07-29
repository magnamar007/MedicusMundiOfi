
$(document).ready(function () {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const idreseee = urlParams.get('id');
    console.log(idreseee);
    if (idreseee !== null) {
        detalleTarea(idreseee);
    } else {
        //swal("Mensaje", "No hay parametro de busqueda por url.", "warning");
        window.location.href = 'BandejaM.aspx';
        //window.close();
    }
    

})


document.querySelector('#pdfFile').addEventListener('change', () => {

    var pdffFile = document.querySelector('#pdfFile').files[0];
    var pdffFileURL = URL.createObjectURL(pdffFile) + "#toolbar=0";

    document.querySelector('#vistaPrevia').setAttribute('src', pdffFileURL);
})

function detalleTarea($idTarea) {
    var fileInput = document.getElementById('pdfFile');
    var file = fileInput.files[0];

    var request = {
        Idtarea: $idTarea
    };

    $.ajax({
        type: "POST",
        url: "BandejaM.aspx/DetalleTareaID",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d.estado) {
                console.log(data.d.objeto.oEUsuario.Nombres);
                $("#txtIdTarea").val($idTarea);

                $("#txtNombreUsu").val(data.d.objeto.oEUsuario.Nombres);
                $("#txtNombreProy").val(data.d.objeto.oEProyecto.Nombre);
                $("#txtDescripcionTarea").val(data.d.objeto.DescripcionTarea);
                


            } else {
                alert("Mensaje", data.d.valor, "success");
            }
        }
    });
}
function sendDataToServer(request) {
    $.ajax({
        type: "POST",
        url: "EntregarTarea.aspx/RegistrarTareaEntregada",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            // Mostrar overlay de carga antes de enviar la solicitud modal-content
            $(".card-body").LoadingOverlay("show");
        },
        success: function (response) {
            $(".card-body").LoadingOverlay("hide");
            if (response.d.estado) {
                var url = 'BandejaM.aspx';

                window.location.href = url;
                //alert(response.d.valor);
                //swal("Mensaje", "Registro Exitoso credenciales enviado al correo Registrado", "success");
            } else {
                alert(response.d.valor);
                //swal("Mensaje", "Error al registrar ingrese otro correo", "warning");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(".card-body").LoadingOverlay("hide");
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
}
function registerDataAjax() {

    var fileInput = document.getElementById('pdfFile');
    var file = fileInput.files[0];
    console.log('llego register');
    if (file) {
        var maxSize = 2 * 1024 * 1024; // 2 MB en bytes
        if (file.size > maxSize) {
            alert("La imagen seleccionada es demasiado grande max 1.5 Mb.");
            //swal("Error", "La imagen seleccionada es demasiado grande max 1.5 Mb.", "error");pdfFile
            return;
        }
        var reader = new FileReader();
        reader.onload = function (e) {
            var arrayBuffer = e.target.result;
            var bytes = new Uint8Array(arrayBuffer);

            var request = {
                oETareaEntregada: {
                    Idtarea: parseInt($("#txtIdTarea").val()),
                    Comentario: $("#txtComentario").val()
                },
                    pdfBytes: Array.from(bytes)
            };

            sendDataToServer(request);
        };
        reader.readAsArrayBuffer(file);
    } else {
        var request = {
            oETareaEntregada: {
                Idtarea: parseInt($("#txtIdTarea").val()),
                Comentario: $("#txtComentario").val()
            },
                pdfBytes: null
        };

        sendDataToServer(request);

    }

}
$('#btnEntregarTarea').on('click', function () {

    registerDataAjax();
    //alert('llego');
})