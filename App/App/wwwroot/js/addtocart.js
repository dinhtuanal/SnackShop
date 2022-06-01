$(document).ready(function () {

    $('body').off('click','.addtocart').on('click', '.addtocart', AddToCart());

    function AddToCart() {
        alert("Oke");
    }
})