﻿$(document).ready(function () {
    _common.createToolbar(
        [
            {
                type: 'add',
                action: actionToolBar.ActionAdd
            },
            {
                type: 'delete',
                action: actionToolBar.ActionDelete
            }
            /*'add', 'delete'*/
        ],
        'card-taskbar'
    );

    //hiển thị form upload ảnh
    $("#dialog").dialog({
        autoOpen: false,
        show: "fade",
        hide: "fade",
        modal: true,
        height: '600',
        width: '700',
        resizable: true,
        title: 'Quản lý ảnh sản phẩm',
        //close: function () {
        //    window.location.reload();
        //}
    });
    $('body').on("click", ".imgproduct", function () {
        var proid = $(this).attr("data-id");
        $("#dialog #myIframe").attr("src", "/admin/ProductImage/Index?id=" + proid);
        $('#dialog').dialog('open');
        return false;
    });
    $('body').on('click', '#BtnDeleteAll', function (e) {
        e.preventDefault();
        var str = "";
        var checkbox = $(this).parents('.card').find('tr td input:checkbox');
        var i = 0;
        checkbox.each(function () {
            if (this.checked) {
                var _id = $(this).val();
                if (i === 0) {
                    str += _id;
                } else {
                    str += "," + _id;
                }
                i++;
            } else {
                checkbox.attr('selected', '');
            }
        });
        if (str.length > 0) {
            var conf = confirm('Bạn có muốn xóa các bản ghi này hay không?');
            if (conf === true) {
                $.ajax({
                    url: '/admin/products/deleteAll',
                    type: 'POST',
                    data: { ids: str },
                    success: function (rs) {
                        if (rs.success) {
                            location.reload();
                        }
                    }
                });
            }
        }
    });

    $('body').on('change', '#SelectAll', function () {
        var checkStatus = this.checked;
        var checkbox = $(this).parents('.card-body').find('tr td input:checkbox');
        checkbox.each(function () {
            this.checked = checkStatus;
            if (this.checked) {
                checkbox.attr('selected', 'checked');
            } else {
                checkbox.attr('selected', '');
            }
        });
    });
    $('body').on('click', '.btnDelete', function () {
        var id = $(this).data("id");
        var conf = confirm('Bạn có muốn xóa bản ghi này không?');
        if (conf === true) {
            $.ajax({
                url: '/admin/Products/delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.success) {
                        $('#trow_' + id).remove();
                    }
                }
            });
        }
    });
});

actionToolBar = new function () {
    this.ActionAdd = function () {
        window.open('/admin/products/add', '_self');
    }

    this.ActionDelete = function () {
        var str = "";
        var checkbox = $(this).parents('.card').find('tr td input:checkbox');
        var i = 0;
        checkbox.each(function () {
            if (this.checked) {
                var _id = $(this).val();
                if (i === 0) {
                    str += _id;
                } else {
                    str += "," + _id;
                }
                i++;
            } else {
                checkbox.attr('selected', '');
            }
        });
        if (str.length > 0) {
            var conf = confirm('Bạn có muốn xóa các bản ghi này hay không?');
            if (conf === true) {
                $.ajax({
                    url: '/admin/products/deleteAll',
                    type: 'POST',
                    data: { ids: str },
                    success: function (rs) {
                        if (rs.success) {
                            location.reload();
                        }
                    }
                });
            }
        }
    }
}