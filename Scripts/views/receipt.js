$(document).ready(function () {

});

class Ref extends Base {
    constructor() {
        super();
        this.loadData();
        this.InitEvents();
    }

    InitEvents() {
        $('.main-table tbody').on('click', 'tr', {
            'jsObject': 123456,
            'name': 'Vũ Đức Thắng'
        }, this.RowOnClick);
        $(document).on('click', 'button.delete', { 'jsObject': this }, this.ClickButton);
        $(document).on('click', 'td.icon-tick', this.TickRow);
        $(document).on('click', 'button.add-new', this.OpenDialogAdd);
        $(document).on('click', 'button.save', this.SaveRef.bind(this));
        $(document).on('click', 'button.cancel', this.CloseDialogAdd);
        $(document).on('click', 'button.edit', this.OpenDialogEdit.bind(this));
    }

    /**
     * Hàm thực hiện sửa phiếu thu lựa chọn
     * Người tạo: VDThang
     * Ngày tạo: 24/07/2019
     * */
    OpenDialogEdit() {
        var me = this;
        $("#dialog").dialog({
            title: "Sửa phiếu thu",
            width: 500,
            height: 300
        });
        var refID = me.GetRowID();
        $.ajax({
            method: 'GET',
            url: '/refs/' + refID,
            success: function (res) {
                if (res.Success) {
                    var listRow = $('input[property]');
                    $.each(listRow, function (index, item) {
                        var propertyName = item.getAttribute('property');
                        var value = res.Data[propertyName];
                        $(item).val(value);
                    });
                } else {
                    alert(res.Message);
                }
            },
            error: function (res) {
                alert("Lỗi cấu hình ajax!");
            }
        });

        $('#mode').val("sửa");
    }

    /**
     * Hàm thực hiện lấy ID của phiếu thu
     * Người tạo VDThang
     * Ngày tạo 01/08/2019
     * */

    GetRowID() {
        var refID = $('.selected,.tick').data('recordid');
        debugger
        return refID;
    }

    /**
     * Hàm thực hiện đóng của sổ thêm mới
     * Người tạo: VDThang
     * Ngày tạo: 26/07/2019
     * */
    CloseDialogAdd() {
        $('#dialog').dialog('close');
    }

    /**
     * Hàm thực hiện thêm mới phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 26/07/2019
     * */
    SaveRef() {
        var me = this;
        var listRow = $('input[property]');
        var object = {};

        $.each(listRow, function (index, item) {
            var propertyName = item.getAttribute('property');
            var value = $(this).val();
            object[propertyName] = value;
        });
        var mode = $('#mode').val();
        var method = "POST";

        if (mode === "sửa") {
            method = "PUT";
            var refID = $('.selected').data('recordid');
            object["RefID"] = refID;
        }
        $.ajax({
            method: method,
            url: '/refs',
            data: JSON.stringify(object),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res === 1) {
                    $('#dialog').dialog('close');
                    me.loadData();
                } else {
                    alert("Chức năng xóa đang bị lỗi! Vui lòng liên hệ MISA");
                }
            }
        });
    }

    /**
     * Hàm thực hiện mở dialog thêm mới
     * Người tạo VDThang
     * Ngày tạo 26/07/2019
     * */
    OpenDialogAdd() {
        $('#dialog').dialog({
            modal: true,
            height: 300,
            width: 500,
            resizable: false,
            dialogClass: "dialog-data"
        });
        $('input').val("");
        $('#mode').val("thêm");
    }

    /**
     * Hàm thực hiện chọn từng hàng khi tick vào cột đầu tiên
     * Người tạo VDThang
     * Ngày tạo 25/07/2019
     * @param {any} event
     */

    TickRow(event) {
        var currCls = event.currentTarget.classList[1];
        if (currCls === "uncheck") {
            $(this).removeClass('uncheck');
            $(this).addClass('check');
            $(this).parent().addClass('tick');
        } else {
            $(this).removeClass('check');
            $(this).addClass('uncheck');
            $(this).parent().removeClass('tick');
            $(this).parent().removeClass('selected');
        }
    }

    /**
     * Hàm thực hiện thông báo khi click vào 1 hàng
     * Người tạo: VDTHANG
     * Ngày tạo: 18/07/2019
     * Người sửa: NVMANH
     * Ngày sửa: 22/07/2019
     * Nội dung sửa: sửa lại nội dung thông báo
     * */

    RowOnClick(event) {
        var jsObject = event.data['jsObject'];
        var name = event.data['name'];
        $('.main-table tbody tr').removeClass('selected');
        $(this).addClass('selected');
        $('button.delete').removeAttr('disabled');
        $('button.duplicate').removeAttr('disabled');
        $('button.edit').removeAttr('disabled');
        $('button.view').removeAttr('disabled');
    }


    /**
     * Hàm thực hiện xóa dữ liệu phiếu thu
     * Người tạo: VDThang 
     * Ngày tạo: 25/07/2019
     * @param {any} event
     */

    ClickButton(event) {
        var me = event.data['jsObject'];
        var listRefID = [];
        var listRow = $('.tick,.selected');
        $.each(listRow, function (index, item) {
            var refid = $(item).data('recordid');
            listRefID.push(refid);
        });

        $.ajax({
            method: 'DELETE',
            url: '/refs',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(listRefID),
            success: function (res) {
                me.loadData();
            },
            error: function (res) {
                alert("Chức năng xóa đang bị lỗi! Vui lòng liên hệ MISA");
            }
        });
    }

    DemoParam() {
        var code = arguments[0];
        var name = arguments[1];
        debugger
    }
    //loadData() {
    //    super.loadData();
    //}
}

var refJS = new Ref();

