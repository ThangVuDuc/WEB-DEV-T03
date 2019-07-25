﻿$(document).ready(function () {

});

class Ref extends Base {
    constructor() {
        super();
        this.loadData();
        this.InitEvents();
    }

    InitEvents() {
        $('tbody').on('click', 'tr', {
            'jsObject': 123456,
            'name': 'Vũ Đức Thắng'
        }, this.RowOnClick);
        $(document).on('click', 'button.delete', { 'jsObject': this }, this.ClickButton);
        $(document).on('click', 'td.icon-tick', this.TickRow);
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
                alert("Chức năng xóa đang bị lỗi! Vui lòng liên hệ MISA")
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

