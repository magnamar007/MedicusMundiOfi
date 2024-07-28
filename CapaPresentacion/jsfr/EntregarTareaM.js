
$(document).ready(function () {

    detalleTarea();

})




document.querySelector('#pdfFile').addEventListener('change', () => {

    var pdffFile = document.querySelector('#pdfFile').files[0];
    var pdffFileURL = URL.createObjectURL(pdffFile) + "#toolbar=0";

    document.querySelector('#vistaPrevia').setAttribute('src', pdffFileURL);
})

function detalleTarea($idTarea) {


    var request = {
        Idtarea: $idTarea
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

                $("#txtIdTarea").val($idTarea);

                $("#txtNombreUsu").val(data.d.objeto.oEUsuario.Nombre);
                $("#txtNombreProy").val(data.d.objeto.oEProyecto.NumeroDocumento);
                $("#txtDescripcionTarea").val(data.d.objeto.DescripcionTarea);



                //var idresevi = parseInt($("#txtIdReserrr").val());
                // Validar estadoRese y habilitar o deshabilitar el botón
                if (estadoTarea) {
                    $("#btnEntregarTarea").show();
                    //$("#btnGuardarCambiosat").removeAttr("disabled");
                } else {
                    $("#btnEntregarTarea").hide();
                    //$("#btnGuardarCambiosat").attr("disabled", "disabled");
                }


            } else {
                alert("Mensaje", data.d.valor, "success");
            }
        }
    });
}
$('#btnEntregarTarea').on('click', function (e) {
    e.preventDefault();
    alert('Se realizo la accion');  
    var url = 'BandejaM.aspx';

    window.location.href = url;
})