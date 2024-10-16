const buttonTypes = {
    'add': {
        icon: "fas fa-plus",
        label: "Thêm mới",
        id : "add-btn",
        action: function () { alert("Thêm mới được nhấn!"); }
    },
    'edit': {
        icon: "fas fa-edit",
        label: "Chỉnh sửa",
        id: "edit-btn",
        action: function () { alert("Chỉnh sửa được nhấn!"); }
    },
    'delete': {
        icon: "fas fa-trash",
        label: "Xóa",
        id: "delete-btn",
        action: function () { alert("Xóa được nhấn!"); }
    },
    'save': {
        icon: "fas fa-save",
        label: "Lưu",
        id: "save-btn",
        action: function () { alert("Lưu được nhấn!"); }
    },
    'import': {
        icon: "fas fa-file-import",
        label: "Import",
        id: "import-btn",
        action: function () { alert("Import được nhấn!"); }
    },
    'export': {
        icon: "fas fa-file-export",
        label: "Export",
        id: "export-btn",
        action: function () { alert("Export được nhấn!"); }
    },
    'undo': {
        icon: "fas fa-undo",
        label: "Undo",
        id: "undo-btn",
        action: function () { alert("Hoàn tác"); }
    }
};

_common = new function () {
    this.createToolbar = function (buttonConfigs, containerId) {
        // Xóa toolbar cũ nếu có
        $(`#${containerId}`).empty();

        var taskbar = $('<div class="taskbar"></div>');

        // Duyệt qua từng nút trong cấu hình đầu vào
        buttonConfigs.forEach(function (config) {
            let buttonType, buttonAction;

            if (typeof config === 'string') {
                buttonType = config;
                buttonAction = buttonTypes[buttonType].action;
            } else {
                buttonType = config.type;
                buttonAction = config.action || buttonTypes[buttonType].action;
            }

            if (buttonTypes[buttonType]) {
                var buttonElement = $(`<a href="javascript:void(0);" class="taskbar-button" id="${buttonTypes[buttonType].id}" title="${buttonTypes[buttonType].label}">
                                                <i class="${buttonTypes[buttonType].icon}"></i>
                                            </a>`);

                buttonElement.click(buttonAction);

                taskbar.append(buttonElement);
            }
        });

        $(`#${containerId}`).append(taskbar);
    }

    this.disableButton = function (buttons) {
        Object.keys(buttonTypes).forEach(function (key) {
            $(`#${buttonTypes[key].id}`).attr("aria-disabled", false);
        });
        buttons.forEach(function (btnType) {
            if (buttonTypes.hasOwnProperty(btnType)) {
                $(`#${buttonTypes[btnType].id}`).attr("aria-disabled", true);
            }
        });
    }

    this.PostWithJsonData = function (url, data, contentType, successFunc, errorFunc) {
        $.ajax({
            type: 'POST',
            url: url,
            contentType: contentType,
            data: data,
            //contentType: false,
            //processData: false,
            success: function (res) {
                successFunc(res);
            },
            error: function (xhr, status, error) {
                console.error("Error: ", xhr.responseText);
                errorFunc(xhr, status, error);
            }
        });
    }

    this.PostWithFormData = function (url, data, successFunc, errorFunc = null) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            contentType: false,
            processData: false,
            success: function (res) {
                successFunc(res);
            },
            error: function (xhr, status, error) {
                console.error("Error: ", xhr.responseText);
                if (errorFunc != null && typeof (errorFunc) == 'function')
                    errorFunc(xhr, status, error);
            }
        });
    }

    /**
     * sử dụng cho các màn hình thao tác và nội dung xử lý bên trong thẻ có id là: card-action
     */
    this.StartLoading = function () {
        if ($('#card-action').find('.overlay').length == 0) {
            $('#card-action').append(`<div class="overlay">
                                  <i class="fas fa-2x fa-sync-alt fa-spin"></i>
                                </div>`);
        }
    }

    this.StopLoading = function () {
        if ($('#card-action').find('.overlay').length != 0) {
            $('#card-action').find('.overlay').remove();
        }
    }

    /**
     * Hiển thị message box thông báo lỗi
     * @param {any} title
     * @param {any} content
     */
    this.ShowMessageBoxError = function (title, content) {
        Swal.fire({
            title: title,
            text: content,
            icon: "error"
        });
    }

    /**
     * Hiển thị message box xác nhận hoặc hủy
     * @param {any} title Tiêu đề box
     * @param {any} content Nội dung message
     * @param {any} funcOk Hàm xử lý nếu chọn Xác nhận
     * @param {any} funcCancel Hàm xử lý nếu chọn hủy
     */
    this.ShowConfirm = function (title, content, funcOk, funcCancel = null) {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-confirm",
                cancelButton: "btn btn-confirm"
            },
            buttonsStyling: false
        });
        swalWithBootstrapButtons.fire({
            title: title,
            text: content,
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Xác nhận",
            cancelButtonText: "Hủy",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                funcOk();
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
                && funcCancel != null && typeof (funcCancel) == 'function'
            ) {
                funcCancel();
            }
        });
    }

    this.ShowToastSuccess = function (content, timer = 3000) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: timer,
            timerProgressBar: false,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "success",
            title: content
        });
    }

    this.ShowToastError = function (content, timer = 3000) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: timer,
            timerProgressBar: false,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "error",
            title: content
        });
    }

    this.ShowToastInfo = function (content, timer = 3000) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: timer,
            timerProgressBar: false,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "info",
            title: content
        });
    }
}

/**
 * 
 * @param {any} value
 * @param {any} style
 * @param {any} language
 * @param {any} currency
 * @param {any} numberZero
 * @returns
 */
function NumberFormat(value, style, language, currency, numberZero) {
	var gasPrice = new Intl.NumberFormat(language, {
		style: style,
		currency: currency,
		minimumFractionDigits: numberZero
	});

	if (typeof value == "string") {
		return gasPrice.format(0);
	}
	return gasPrice.format(value);
}

function formatString(template, ...args) {
    return template.replace(/{(\d+)}/g, (match, index) => {
        return typeof args[index] !== 'undefined' ? args[index] : match;
    });
}

function IsNullOrEmpty(value) {
    if (value == null || value == "" || value == undefined) {
        return true;
    }
    return false;
}