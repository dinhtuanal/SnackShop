$(document).ready(function () {
    Init();

    function Init() {
        if ($('#hid-id').text() == '') {
            Add();
        } else {
            Update();
        }
    }

    function Add() {

    }
    function Update() {
        var tranferId = $('#hid-id').text();
        $.ajax({
            type: 'post',
            url: '/SubCategory/GetById',
            dataType: 'json',
            data: { subCategoryId: tranferId },
            success: function (response) {
                var data = response.result;
                console.log(data);
                $('#txt-subcategoryname').val(data.subCategoryName);
                $('#txt-description').val(data.description);
                $('#categoryname').val(data.categoryId);
            }
        })
    }
    $('body').off('click', '.save').on('click', '.save', Save);
    function Save() {
        //alert("Add");
        var model = new Object();
        model.SubCategoryId = '';
        model.SubCategoryName = $('#txt-subcategoryname').val();
        model.Description = $('#txt-description').val();
        model.CategoryId = $('#categoryname').val();
        model.DateCreated = null;

        $.ajax({
            type: 'post',
            url: '/subcategory/save',
            dataType: 'json',
            data: JSON.stringify(model),
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                var data = response.statusCode;
                console.log(data);
            },
            error: function (response) {
                console.log(response);
            }
        })
    }
    $('body').off('click', '.delete').on('click', '.delete', ConfirmDelete);
    function ConfirmDelete() {
        var tranferId = $(this).data('id');
        var result = confirm("Bạn có chắc muốn xóa loại sản phẩm này");
        if (result) {
            Delete(tranferId);
        }
    }
    function Delete(tranferId) {
        $.ajax({
            type: 'post',
            url: '/SubCategory/Delete',
            dataType: 'json',
            data: { subCategoryId: tranferId },
            success: function (response) {
                var data = response.statusCode;
                console.log(data);
                if (data == 200) {
                    console.log(data);
                    alert("Xóa thành công");
                } else {
                    alert("Xóa không thành công");
                }
            },
            error: function () {
                console.log("Lỗi");
            }
        })
    }
});