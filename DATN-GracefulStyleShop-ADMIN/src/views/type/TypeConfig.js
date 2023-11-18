import enumD from "@/assets/js/enum";
class typeConfig {
    constructor() {
        this.tableName = 'Type';
        this.formName = enumD.formName.type;
        this.titleForm = "Thể loại";
        this.columns = [
            {
                name : "TypeCode",
                title : "Mã thể loại",
                textAlign : "left",
                width : 120,
            },
            {
                name :"TypeName",
                title : "Tên thể loại",
                textAlign : "left",
                width : 300,
            },
            {
                name :"Description",
                title : "Mô tả",
                textAlign : "left",
                width : 800,
            },
            
        ];
        this.placeholder = "Tìm kiếm ";
    }
  }
  export default typeConfig;
  