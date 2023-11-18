import enumD from "@/assets/js/enum";
class productConfig {
    constructor() {
        this.tableName = 'Product';
        this.titleForm = "Sản phẩm";
        this.formName = enumD.formName.product;
        this.level = 1;
        this.columns = [
            {
                name : "ProductCode",
                title : "Mã sản phẩm",
                textAlign : "left",
                type : "text",
                width : 150,
            },
            {
                name : "ProductName",
                title : "Tên sản phẩm",
                textAlign : "left",
                type : "text",
                width : 300,
            },
            {
                name : "Sold",
                title : "Đã bán",
                textAlign : "right",
                type   : "number",
                width : 150,
            },
            {
                name : "Quantity",
                title : "Lượng có",
                textAlign : "right",
                type : "number",
                width : 150,
            },
            {
                name : "PriceSale",
                title : "Giá bán",
                textAlign : "right",
                type : "Price",
                width : 150,
            },
            {
                name : "Discount",
                title : "% giảm giá",
                textAlign : "right",
                type : "number",
                width : 150,
            },
            {
                name : "PublicDate",
                title : "Ngày ra mắt",
                textAlign : "center",
                type : "date",
                width : 150,
            },
            {
                name : "TypeName",
                title : "Thể loại",
                textAlign : "left",
                type : "text",
                width : 150,
            },
            {
                name : "BrandName",
                title : "Thương hiệu",
                textAlign : "left",
                type : "text",
                width : 150,
            },
        ];
        this.placeholder = "Tìm kiếm ";
    }
  }
  export default productConfig;
  