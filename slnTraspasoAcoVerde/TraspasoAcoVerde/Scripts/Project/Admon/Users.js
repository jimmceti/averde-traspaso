var jsproosis = window.jsproosis || {};

jsproosis.Project.AdmonUsers = (function ($, window, document, navigator, localStorage) {

    var URLApp = localStorage.getItem("urlApp");

    var InitWindow = function () {
        loadUsers();
    };

    var loadUsers = function () {
        $.ajax(
            {
                type: 'POST',
                url: URLApp + 'Administration/LoadUsers',
                dataType: "json"
            }).done(function (dataUsers) {
                FillGridUsers(dataUsers);
            });
    };


    var FillGridUsers = function (data) {
        $("#grdUsers").jsGrid('destroy');
        console.log('Aqui despues de destruid el grid');
        $("#grdUsers").jsGrid({
            height: "99%",
            width: "100%",
            sorting: true,
            paging: false,
            autoload: true,
            selecting: true,
            inserting: false,
            filtering: true,
            editing: false,
            pageSize: 15,
            invalidMessage: "Información inválida!",
            noDataContent: "Sin registros.",
            deleteConfirm: "Estas seguro de eliminar el registro?",
            pagerFormat: "Paginas: {first} {prev} {pages} {next} {last} &nbsp;&nbsp; {pageIndex} de {pageCount}",
            pagePrevText: "Anterior",
            pageNextText: "Siguiente",
            pageFirstText: "Primera",
            pageLastText: "Ultima",
            loadMessage: "Por favor, espera...",
            updateOnResize: true,
            //autowith: true,
            shrinkToFit: false,
            controller: {
                loadData: function (parametros) {
                    if (data != null) {
                        var gridLoadData = data;
                        return $.grep(gridLoadData, function (parametro) {
                            return (!parametro.NombreCompleto || parseInt(parametro.NombreCompleto) == parametros.NombreCompleto);
                        });
                    }
                }
            },
            fields: [
                { name: "IdUsuario", type: "number", title: "ID USUARIO", width: 200, editing: false, align: "center", filtering: false, fixed: true },
                { name: "NombreCompleto", type: "text", title: "NOMBRE COMPLETO", width: 550, editing: false, align: "center", filtering: false, fixed: true },
                { name: "Correo", type: "text", title: "CORREO", width: 350, editing: false, align: "center", filtering: false, fixed: false },
                { name: "TipoUsuario", type: "text", title: "TIPO USUARIO", width: 200, editing: false, align: "center", filtering: false, fixed: true },
                { name: "Activo", type: "text", title: "ACTIVO", width: 100, editing: false, align: "center", filtering: false, fixed: true }
            ]
            //,rowClick: function (args) {
            //    InicializarGridDocumentos(args.item.Pago_DocumentosRelacionado);
            //
            //}
        });

    };



    return {
        InitWindow: InitWindow
    };
}(jQuery, window, document, navigator, localStorage));