
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
$('#btnEntregarTarea').on('click', function (e) {
    e.preventDefault();
    alert('Se realizo la accion');  
    var url = 'BandejaM.aspx';

    window.location.href = url;
})