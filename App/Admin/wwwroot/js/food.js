$(document).ready(function () {
    var _foodId = $("#hid-id").text();

    Init();

    function Init() {
        if (_foodId == "") {
            Add()
        } else {
            Update();
        }
    }

    function Add() {

    }
    function Update() {
        $.ajax({
            type: 'post',
            url: '/Food/GetById',
            dataType: 'json',
            data: { foodId: _foodId },
            success: function (response) {
                var data = response.result;
                $('#txt-name').val(data.name);
                $('#txt-price').val(data.price);
                $('#txt-desc').val(data.description);
                $('#img').val(data.image);
                $('#txt-content').val(data.content);
                $('#status').val(data.status);
                $('#sub-name').val(data.subCategoryId);
            }
        })
    }
    $('#frm-food').validate({
        rules: {
            Name: {
                required: true,
            },
            Price: {
                required: true,
            },
            Description: {
                required: true,
            }
        },
        messages: {
            Name: {
                required: 'Bạn phải nhập tên món ăn',
            },
            Price: {
                required: 'Bạn phải nhập giá món ăn',
            },
            Description: {
                required: 'Bạn phải nhập mô tả ngắn',
            }
        },
    })
    $('body').off('click', '.save').on('click', '.save', Save);
    function Save() {
        if ($('#frm-food').valid()) {
            var model = new Object();
            model.FoodId = _foodId;
            model.Name = $('#txt-name').val();
            model.Price = parseFloat($('#txt-price').val());
            model.Description = $('#txt-desc').val();
            model.Content = $('#txt-content').val();
            model.Image = $('#img').val();
            model.Status = parseInt($('#status').val());
            model.SubCategoryId = $('#sub-name').val();
            model.DateCreated = "2022-05-20T14:52:27.177Z";

            console.log(model);

            $.ajax({
                type: 'post',
                url: '/Food/Save',
                dataType: 'json',
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    console.log(response);
                    if (response.statusCode == 1) {
                        console.log("Thêm");
                        alert("Thêm mới thành công", function () {
                            window.location.href= "/Food/Index";
                        })
                    } else if (response.statusCode == 2) {
                        console.log("status 2");
                        alert("Cập nhật thành công", function () {
                            window.location.href = "/Food/Index";
                        })
                    } else {
                        console.log("status else");
                        alert("Đã xảy ra lỗi");
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
    }
    $('body').off('click', '.delete').on('click', '.delete', ConfirmDelete);

    

    function ConfirmDelete() {
        var tranferId = $(this).data('id');
        var result = confirm("Bạn có muốn xóa đồ ăn này ");
        if (result) {
            Delete(tranferId);
        }
        
    }
    function Delete(tranferId) {
        console.log("BẤm vào nút delete")
        $.ajax({
            type: 'post',
            url: '/Food/Delete',
            dataType: 'json',
            data: { foodId: tranferId },
            success: function (response) {
                var data = response.statusCode;
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