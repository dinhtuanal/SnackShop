$(document).ready(function () {
    $('body').off('click','.addtocart').on('click', '.addtocart', AddToCart);

    function AddToCart() {
        var dataid = $(this).data("id");
        $.ajax({
            type: 'post',
            url: '/cart/addtocart',
            data: {id : dataid},
            dataType: 'json',
            success: function (response) {
                var data = response.result;
                if (data == 1) {
                    alert("Thêm thành công")
                    window.location.reload()
                }
            },
            error: function () {
                bootbox.alert("Lỗi")
            }
        });
    }
})