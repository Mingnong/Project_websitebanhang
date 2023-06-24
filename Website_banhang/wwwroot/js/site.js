// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    // lưu giá trị search hiện tại
    var currentSearchData = '';

    $('#searchInput').on('input', function () {

        // lấy value từ input
        var searchData = $(this).val();
        console.log(searchData)
        if (searchData === '') {
            $('#searchList').empty();
        } else {

            // dùng ajax gọi hàm lấy dữ liệu từ controller Search 
            $.ajax({
                url: '/Home/Search',
                type: 'GET',
                data: { searchData: searchData },
                success: function (searchResults) {

                    // so sánh giá trị search hiện tại và giá trị trước đó
                    if (searchData !== currentSearchData) {
                        $('#searchList').empty();
                        currentSearchData = searchData;
                    }


                    // lặp qua phần tử trong kết quả trả về từ ajax và thêm vào tag trong html
                    $.each(searchResults, function (index, result) {
                        var productId = result.productId;
                        var productName = result.productName;
                        var productPrice = result.productPrice;

                        var search = `<li><a href="/Product/Details?ProductId=${productId}">${productName} ${productPrice}</a></li>`;
                        $('#searchList').append(search);
                    });

                }
            })
        }

    })

})