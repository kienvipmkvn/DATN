import enumD from "@/assets/js/enum";
class supplyConfig {
    constructor() {
        this.tableName = 'Supply';
        this.titleForm = "Thông tin nhập hàng";
        this.formName = enumD.formName.supply;
        this.mode = enumD.enumMode.view;
        this.lock = enumD.enumLock.notAllowLock;
        this.delete = enumD.enumDelete.notAllowDelete;
        this.columns = [
            {
                name : "ProductCode",
                title : "Mã sản phẩm",
                textAlign : "left",
                type : "text",
                width : 120,
            },
            {
                name : "ProductName",
                title : "Tên sản phẩm",
                textAlign : "left",
                type : "text",
                width : 500,
            },
            {
                name : "SizeCode",
                title : "Kích cỡ",
                textAlign : "left",
                type : "text",
                width : 100,
            },
            {
                name : "ColorName",
                title : "Màu sắc",
                textAlign : "left",
                type : "text",
                width : 100,
            },
            {
                name : "SupplyDate",
                title : "Ngày nhập",
                textAlign : "center",
                type : "date",
                width : 150,
            },
            {
                name : "Quantity",
                title : "Số lượng nhập",
                textAlign : "right",
                type : "number",
                width : 110,
            },
            {
                name : "PriceSupply",
                title : "Giá nhập",
                textAlign : "right",
                type : "Price",
                width : 100,
            },
            {
                name : "SupplierName",
                title : "Nhà cung cấp",
                textAlign : "left",
                type : "text",
                width : 400,
            },
        ];
        this.placeholder = "Tìm kiếm ";
    }
  }
  export default supplyConfig;
  