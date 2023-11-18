import enumD from "@/assets/js/enum";
class orderConfig {
    constructor() {
        this.tableName = 'Order';
        this.titleForm = "Đơn hàng";
        this.formName = enumD.formName.order;
        this.lock = enumD.enumLock.notAllowLock;
        // this.mode = enumD.enumMode.view;        
        this.level = 1;
        this.columns = [
            {
                name : "OrderCode",
                title : "Mã đơn hàng",
                textAlign : "left",
                type : "text",
                width : 150,
            },
            {
                name : "Receiver",
                title : "Tên khách hàng",
                textAlign : "left",
                type : "text",
                width : 150,
            },
            {
                name : "TotalAmount",
                title : "Số lượng",
                textAlign : "right",
                type   : "number",
                width : 150,
            },
            {
                name : "TotalPrice",
                title : "Tổng tiền",
                textAlign : "right",
                type : "Price",
                width : 150,
            },
            {
                name : "IsPaid",
                title : "Trạng thái thanh toán",
                textAlign : "center",
                type : "paid-type",
                width : 150,
                class : "paid"
            },
            {
                //Cột các button
                name : "Status",
                title : "Trạng thái đơn hàng",
                textAlign : "center",
                type : "StatusOrder",
                width : 150,
            },
            {
                name : "CreatedAt",
                title : "Ngày tạo",
                textAlign : "center",
                type : "date",
                width : 150,
            },
            {
                name : "ModifiedAt",
                title : "Ngày cập nhật",
                textAlign : "center",
                type : "date",
                width : 150,
            },
        ];
        this.placeholder = "Tìm kiếm ";
    }
  }
  export default orderConfig;
  