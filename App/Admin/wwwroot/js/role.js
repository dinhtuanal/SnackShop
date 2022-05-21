$(document).ready(function () {
    Load();
    $('body').off('click', '.delete').on('click', '.delete', ConfirmDelete);
    $('body').off('click', '.save').on('click', '.save', Save);
    $('body').off('click', '.add').on('click', '.add', Add);
    $('body').off('click', '.update').on('click', '.update', Update);
    function Load() {

        $.ajax({
            type: 'post',
            url: '/role/GetAll_Pta',
            success: function (data) {
                $("#table-content").html(data);
            }
        })
    }
    function ConfirmDelete() {
        var tranferId = $(this).data('id');
        var result = window.confirm("Bạn chắc chắn muốn xóa ");
        if (result) {
            Delete(tranferId);
        }
    }
    function Delete(tranferId) {
        $.ajax({
            type: 'post',
            url: '/Role/Delete',
            dataType: 'json',
            data: { id: tranferId },
            success: function (response) {
                var data = response.statusCode;
                if (data.statusCode == 200) {
                    alert("Xóa thành công");
                } else {
                    alert("Xóa không thành công");
                }
            }
        });
    }
    function Add() {
        console.log('thêm mới');
        $('#hid-id').text('');
        $('#txt-RoleName').val('');
    }
    $('body').off('click', '.update').on('click', '.update', Update);
    function Update() {
        var tranferId = $(this).data('id');
        console.log(tranferId);
        $.ajax({
            type: 'post',
            url: '/Role/GetById',
            dataType: 'json',
            data: { id: tranferId },
            success: function (response) {
                var data = response.result;
                $('#hid-id').text(data.id);
                $('#txt-RoleName').val(data.name);
            },
            error: function () {
                alert("Error")
            }
        })
    }

    $('#frm-save').validate({
        rules: {
            RoleName: {
                required: true,
            },
        },
        messages: {
            RoleName: {
                required: "Bạn phải nhập tên quyền",
            },
        }
    })

    function Save() {
        if ($('#frm-save').valid()) {
            var model = new Object();
            model.RoleId = $('#hid-id').text();
            model.RoleName = $('#txt-RoleName').val();
            $.ajax({
                type: 'post',
                url: '/Role/Save',
                dataType: 'json',
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response.statusCode == 1) {
                        alert("Thêm mới thành công");
                        Load();
                    } else if (response.statusCode == 2) {
                        alert("Cập nhật thành công");
                        Load();
                    }
                },
                error: function () {
                    console.log("Thêm không thành công");
                }
            })
            $('#modal-add').modal('hide');
        }
    }
})

