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
            var rowHTML = $('<tr></tr>').data("recordid", item["RefID"]);
            $.each(fields, function (fieldIndex, fieldItem) {
                var fieldName = fieldItem.getAttribute('fieldName');
                var fieldValue = item[fieldName];
                var cls = 'text-left';
                if (fieldName === "RefDate") {
                    fieldValue = new Date(fieldValue);
                }
                //Xác định kiểu dữ liệu của giá trị cột tương ứng
                var type = $.type(fieldValue);
                switch (type) {
                    //Kiểu ngày thì căn giữa và định dạng lại hiển thị ngày
                    case "date":
                        cls = 'text-center';
                        fieldValue = fieldValue.formatddMMyyyy();
                        break;
                    //Kiểu tiền thì căn phải và định dạng lại hiển thị tiền tệ
                    case "number":
                        cls = 'text-right';
                        fieldValue = fieldValue.formatMoney();
                        break;
                }
                if (fieldName) {
                    rowHTML.append('<td class = "{1}">{0}</td>'.format(fieldValue, cls));
                } else {
                    rowHTML.append('<td class = "{0}"></td>'.format("icon-tick uncheck"));
                }
            });
            $('.main-table tbody').append(rowHTML);
        });
    }
}