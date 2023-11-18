import enumD from "@/assets/js/enum";
class colorConfig {
    constructor() {
        this.tableName = 'Color';
        this.titleForm = "Màu sắc";
        this.formName = enumD.formName.color;
        this.columns = [
            {
                name : "ColorCode",
                title : "Mã màu",
                textAlign : "left",
                width : 100,
            },
            {
                name :"ColorName",
                title : "Tên màu",
                textAlign : "left",
                width : 200,
            },
        ];
        this.placeholder = "Tìm kiếm theo màu";
    }
  }
  export default colorConfig;
  