class Base {
    constructor() {

    }
    //Hàm thực hiện lấy dữ liệu ra từ services
    //Người tạo: VDThang 25/07/2019
    getData() {
        var fakeData = [];
        $.ajax({
            method: 'GET',
            url: '/refs',
            async: false,
            success: function (res) {
                fakeData = res;
            },
            error: function (res) {
                alert("Dịch vụ đang có lỗi. Vui lòng liên hệ MISA");
            }
        });
        return fakeData;
    }
    //Hàm thực hiện lấy dữ liệu ra HTML
    //Người tạo: VDThang 25/07/2019
    loadData() {
        var me = this;
        var data = this.getData();
        var fields = $('th[fieldName]');
        $('tbody').empty();
        $.each(data, function (index, item) {
            var rowHTML = $('<tr></tr>');
            $.each(fields, function (fieldIndex, fieldItem) {
                var fieldName = fieldItem.getAttribute('fieldName');
                var fieldValue = item[fieldName];
                if (fieldName) {
                    rowHTML.append('<td>' + fieldValue + '</td>');
                } else {
                    rowHTML.append('<td></td>');
                }
            });
            $('.main-table tbody').append(rowHTML);
        });
    }
}