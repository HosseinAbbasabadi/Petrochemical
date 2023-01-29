var SinglePage = {};
var ModalId = "#MainModal";
var ModalContentId = "#ModalContent";

SinglePage.LoadModal = function () {
    var hasLocation = window.location.hash.toLowerCase();
    if (!hasLocation.startsWith("#showmodal")) {
        return;
    }

    const splited = hasLocation.split("showmodal=");
    const url = splited[1];
    const isModalBig = splited[2] == 'big';
    if (isModalBig) {
        ModalId = "#BigMainModal";
        ModalContentId = "#BigModalContent";
    } else {
        ModalId = "#MainModal";
        ModalContentId = "#ModalContent";
    }

    $.get(url,
        null,
        function (htmlPage) {
            $(ModalContentId).html(htmlPage);
            const container = document.getElementById(ModalContentId.replace("#", ""));
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            //$('.select2InModal').select2();
            showModal(ModalId);
            //initPersianDatePicker();
            //$('.price-mask').each(function (index, item) {
            //    priceMask(`#${item.id}`);
            //});
        }).fail(function (error) {
            window.location.hash = "##";
        });
};

function showModal() {
    $(ModalId).modal("show");
}

function hideModal() {
    $(ModalId).modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function (e) {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
        });

    $("#BigMainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");
            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                    }
                });
                //$.post(url,
                //    data,
                //    "application/json; charset=utf-8",
                //    "json",
                //    function (data) {
                //        debugger;
                //        CallBackHandler(data, action, form);
                //    }).fail(function (error) {
                //        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                //    });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSucceeded) {
                window.location.reload();
            } else {
                alert(data.message);
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $(refereshDiv).html(result);
        });
}
