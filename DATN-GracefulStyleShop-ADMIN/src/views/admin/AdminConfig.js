import enumD from "@/assets/js/enum";
class adminConfig {
    constructor() {
        this.tableName = 'Admin';
        this.titleForm = "Quản trị viên";
        this.formName = enumD.formName.admin;
        this.columns = [
            {
                name : "FullName",
                title : "Tên quản trị viên",
                textAlign : "left",
                type : "text",
                width : 150,
            },
            {
                name : "Email",
                title : "Email",
                textAlign : "left",
                type : "text",
                width : 150,
            },
            {
                name : "Phone",
                title : "Số điện thoại",
                textAlign : "right",
                type : "text",
                width : 150,
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
  export default adminConfig;
  