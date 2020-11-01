
var vgControladorName;
var vgFunctionName;
function SetControlador(nombre) {

    switch (nombre) {
        case "1":
            vgControladorName = "Plantilla";
            vgFunctionName = 'Index';
            break;
        //case "1":
        //    vgControladorName = "GestionRevistas";
        //    vgFunctionName = 'AgregarRevistas';
        //    break;
        //case "CompraServicio":
        //    vgFunctionName = 'Solicitud';
        //    break;
    }
    Load();
}

function Load() {
    $("#app_main").hide();
    var url = "/Plantilla/" + vgControladorName + "/" + vgFunctionName; //+ vgFunctionParams;
    var jqxhr = $.post(url, function () {
        console.log("success");
        console.log("url: ", url);
    })
        .done(function (data) {
            $("#app_contenido_ppal").html(data);
        })
        .fail(function () {
            $("#app_contenido_ppal").html("<h4>Error</h4>");
        })
        .always(function () {
            $("#app_main").show();
        });
}