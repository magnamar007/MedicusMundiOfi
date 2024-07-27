
$(document).ready(function () {
    oBtenerDetalleUsuarioR();
    //cargarMenu();
});

function oBtenerDetalleUsuarioR() {

    $.ajax({
        type: "POST",
        url: "InicioMedicus.aspx/ObtenerDetalleUsuario",
        data: {},
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            if (response.d.estado) {
                $("#NombreUsuario").text(response.d.objeto.Nombres);
                $("#ApellidoUsuario").text(response.d.objeto.Apellidos);
                $("#imgUsuario").attr("src", response.d.objeto.ImageFull);
                //$("#rolusuario").html("<i class='fa fa-circle text-success'></i> " + response.d.objeto.oRol.Descripcion);
            } else {
                window.location.href = 'IniciodeSesionM.aspx';
            }

        }
    });
}