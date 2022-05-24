$(document).ready(function () {
    $('body').off('click', '.delete').on('click', '.delete', ConfirmDelete);
    function ConfirmDelete() {
        var tranferId = $(this).data('id');
        var result = confirm("Bạn có muốn xóa người dùng này");
        if (result) {
            Delete(tranferId);
        }
    }
    function Delete(id) {
        console.log(id);
        $.ajax({
            type: 'post',
            url: '/account/delete',
            dataType: 'json',
            data: { userId: id },
            success: function (response) {
                var data = response.statusCode;
                console.log(data);
                if (data.statusCode == 200) {
                    alert("Xóa thành công");
                } else {
                    alert("Xóa không thành công");
                }
            },
            error: function () {
                alert("Loi");
            }
        })
    }
});