

//khai báo ở đây để global vì layout import file này
$(document).ready(function () {
    $('.frmAddToCart').submit(function (e) {
        //bỏ qua các xử lí mặc định
        e.preventDefault();
        //custom riêng sau khi bỏ qua các xử lí trên
        //let data = $(this).serialize();// phân tích data và trả về tất cả các input của nó có 2 cái : serialize trả về 1 cái và serializeArray để trả về dạng mảng
        //console.log(data);
        let productId = $(this).find('input[name=ProductId]').val();//find tìm phần tử cha trong phần tử con this: forrm là submit
        let quantity = $(this).find('input[name=Quantity]').val();
        const data = { ProductId: productId, Quantity: quantity };//const ko phải hằng
        console.log(data);

        const btn = $(this).find('button[type=submit]');
        $.ajax({
            url: '/Cart/AddToCartJson',
            type: "POST",//nếu là post hay put thì cần dât neesu get thì ko cần
            data: data,
            //HTTP STATUS 200
            beforeSend: function (res) {
                $(btn).text('Loading...');
                $(btn).addClass('disabled');
            },
            complete: function (res) {
                $(btn).text('Add to cart');
                $(btn).removeClass('disabled');
            },
            success: function (res) {
                console.log(res);
                if (res.state) {
                    //raise 1 custom event (emit event) (bắn event)
                    $(document).trigger('addToCartEvent');
                    alert('them thanh cong' + data.ProductId + ": " + data.Quantity);
                }
                else {
                    alert('that bai');
                }
            },
            //HTTP STATUS != 200 (500: inter er backend có vấn đề model invalid, 404 : url có vấn đề, 400: request ko hợp lệ dât gởi len ko đsung chuẩn dât thiếu gì đó)
            error: function (err) {

            }
        })
    });
    $(document).on('addToCartEvent', function () { //ở đây toàn bộ đều add event này nếu thay đổi doccumetn bằng h1 thì chỉ có h1 mới nghe event này
        //console.log('add to cart');
        $.ajax({
            url: '/Cart/CartSummary',
            type: 'GET',
            success: function (res) {
                $('.cart-summary').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        })
    })
    //$(document).on('addToCartEvent', function () {
    //    $.get({
    //        url: '/Cart/CartSummary',
    //        data: {},
    //        suscess: function (res) {
    //            $('.cart-summary').html(res);
    //        },
    //        dataType: "text"
    //    })
    //})
    //$(document).on('addToCartEvent', function(){
    //    $.load({
    //        url: '/Cart/CartSummary',
    //        data: {},
    //        suscess: function (res) {
    //            $('.cart-summary').html(res);
    //        }
    //        })
    //})
    
    $('.frmRemoveFromCart').submit(function (e) {
        //bỏ qua các xử lí mặc định của e
        e.preventDefault();
        let productId = $(this).find('input[name=productId]').val();
        const data = { ProductId: productId };
        console.log(data);
        $.ajax({
            url: '/Cart/RemoveFromCartJson',
            type: "POST",
            data: data,
            success: function (res) {
                console.log(res);
                if (res.state) {
                    $(document).trigger('removeFromCartEvent');// nếu remove thành công thì rain 1 cái event
                    alert('xóa thành công' + data.ProductId);
                }
            },
            error: function (err) {
                alert('failt');
            }
        })
    });
    $(document).on('removeFromCartEvent', function () {
        $.ajax({
            url: "/Cart/BodySummary",
            type: 'GET',
            suscess: function (res) {
                $('.body-summary').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        })
        
        $.ajax({
            url: '/Cart/CartSummary',
            type: 'GET',
            success: function (res) {   
                $('.cart-summary').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        });
    })
    



    $('.frmUpdateToCart').submit(function (e) {
        e.preventDefault();
        let ProductId = $(this).find('input[name="ProductId"]').val();
        let Quantity = $(this).find('input[name="Quantity"]').val();
        const data = { 'ProductId': ProductId, 'Quantity': Quantity };
        console.log(JSON.stringify(data));
        $.ajax({
            type: 'POST',
            url: '/Cart/UpdateToCartJson',
            data: data,
            success: function (res) {
                $(document).trigger('updateToCartEvent');
                alert(JSON.stringify(res))
            },
            error: function (err) {
                alert('loi roi');
            }
        });
    });

    $(document).on('updateToCartEvent', function () {
        $.ajax({
            url: '/Cart/CartSummary',
            type: 'GET',
            suscess: function (res) {
                $('cart-summary').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        })
        $.ajax({
            url: '/Cart/BodySummary',
            type: 'GET',
            success: function (res) {
                $('.body-summary').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        });
    })
})


