

$('#InicioM').on('click', function (e) {
    e.preventDefault();
    //loginUsuario();
    if ($("#emailM").val().trim() == "") {
        alert('ingrese un correo');
        return;
    }
    loginUsuarioLoad();
})

const container = document.getElementById('container');

const recoverBtn = document.getElementById('recuperar');

const loginBtn = document.getElementById('InicioSesion');

recoverBtn.addEventListener('click', (e) => {
    e.preventDefault();
    container.classList.add("active");
});

loginBtn.addEventListener('click', (e) => {
    e.preventDefault();
    container.classList.remove("active");
});

//document.getElementById('login').addEventListener('submit', function (event) {
//    event.preventDefault();
//    const username = document.getElementById('emailM').value;
//    const password = document.getElementById('passwordM').value;

//    fetch('IniciarSesion.aspx/Iniciar', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({ username, password })
//    })
//        .then(response => response.json())
//        .then(data => {
//            if (data.success) {
//                window.location.href = '/InicioMedicus.aspx';
//            } else {
//                document.getElementById('message').innerText = data.message;
//            }
//        })
//        .catch(error => {
//            console.error('Error:', error);
//            document.getElementById('message').innerText = 'Ocurrió un error. Por favor, inténtelo de nuevo.';
//        });
//});


function loginUsuarioLoad() {

    $.ajax({
        type: "POST",
        url: "IniciodeSesionM.aspx/Iniciar",
        data: JSON.stringify({ correo: $("#emailM").val(), clave: $("#passwordM").val() }),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            //$.LoadingOverlay("show");
            console.log("Antes de enviar la solicitud");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$.LoadingOverlay("hide");
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            //$.LoadingOverlay("hide");
            if (response.d.estado) {
                window.location.href = 'InicioMedicus.aspx';
            } else {
                alert("No se encontro el usuario")
            }
        }
    });
}

