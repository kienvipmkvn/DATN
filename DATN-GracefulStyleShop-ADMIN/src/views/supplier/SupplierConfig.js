import enumD from "@/assets/js/enum";
class supplierConfig {
    constructor() {
        this.tableName = 'Supplier';
        this.titleForm = "Nhà cung cấp";
        this.formName = enumD.formName.supplier;
        this.columns = [
            {
                name : "SupplierCode",
                title : "Mã nhà cung cấp",
                textAlign : "left",
                type : "text",
                width : 120,
            },
            {
                name : "SupplierName",
                title : "Tên nhà cung cấp",
                textAlign : "left",
                type : "text",
                width : 400,
            },
            {
                name : "Phone",
                title : "Số điện thoại",
                textAlign : "right",
                type : "text",
                width : 100,
            },
            {
                name : "Address",
                title : "Địa chỉ",
                textAlign : "left",
                type : "text",
                width : 500,
            },
            {
                name : "CreatedAt",
                title : "Thời gian tạo",
                textAlign : "center",
                type : "date",
                width : 150,
            },
            {
                name : "ModifiedAt",
                title : "Thời gian sửa",
                textAlign : "center",
                type : "date",
                width : 150,
            },
        ];
        this.placeholder = "Tìm kiếm ";
    }
  }
  export default supplierConfig;
  