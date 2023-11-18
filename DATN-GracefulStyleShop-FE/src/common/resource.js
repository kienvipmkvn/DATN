/**
 * Các msg thông báo
 */
const resources = {
  vi: {
    /**
     * msg validate form nhan vien
     */
    FORM_MESSAGE: {
      SUCCESS: {
        ADD: "Thêm mới nhân viên thành công!",
        EDIT: "Sửa nhân viên thành công!",
        DELETE: "Xóa nhân viên thành công",
      },
      ERROR: {
        NOT_EMPTY: (name) => `${name} không được để trống.`,
        UNIQUE: (name) => `${name} đã tồn tại.`,
        ADULT: (name) => `${name} không hợp lệ.`,
        HAS_FORMAT: (name) => `${name} chưa đúng định dạng.`,
        MAX_LENGTH: (name, length) =>
          `${name} không được vượt quá ${length} ký tự.`,
        INVALID: (name) => `${name} không hợp lệ.`,
        NOT_EXIST: (name) => `${name} không tồn tại.`,
      },
    },
    /**
     * Tên trường của input
     */
    FORM_FIELD: {
      Address: "Địa chỉ",
      PhoneNumber: "Số điện thoại",
      Email: "Email",
      BrandCode: "Mã thương hiệu",
      BrandName: "Tên thương hiệu",
      ColorCode: "Mã màu",
      ColorName: "Tên màu",
      StarNumber: "Số sao",
      Comment: "Đánh giá",
      Name: "Tên",
      Password: "Mật khẩu",
      Receiver: "Người nhận",
      Country: "Quốc gia",
      Province: "Tỉnh/Thành phố",
      District: "Quận/Huyện",
      Commune: "Xã/Phường",
      AddressDetail: "Địa chỉ cụ thể",
      Size: "Kích cỡ",
      ProductCode: "Mã sản phẩm",
      ProductName: "Tên sản phẩm",
      Discount: "Giảm giá",
      Sold: "Số lượng bán",
      Quantity: "Số lượng",
      Description: "Mô tả",
      PublicDate: "Ngày ra mắt",
      ImageLink: "Link ảnh",
      PriceSale: "Giá bán",
      PriceSupply: "Giá nhập",
      SupplyDate: "Ngày nhập",
      SupplyQuantity: "Số lượng nhập",
      SupplierCode: "Mã nhà cung cấp",
      SupplierName: "Tên nhà cung cấp",
      TypeCode: "Mã loại sản phẩm",
      TypeName: "Tên loại sản phẩm",
      ShipmentCode: "Mã phương thức",
      Method: "Tên phương thức",
      DateFrom: "Trường dữ liệu",
      DateTo: "Trường dữ liệu",
      PriceShip: "Phí ship",
      FullName: "Tên",
      Phone: "Số điện thoại",
      FirstName : "Tên",
      LastName : "Họ",
      ComfirmPassword: "Mật khẩu nhập lại"
    },
    /**
     * Các thông báo toast-msg
     */

    TOAST_MESSAGE: {
      SUCCESS: function (name) {
        var message = {
          messageType: "Thành công!",
          messageContent: `${name} thành công.`,
          colorMsg: "green",
          classIcon: "icon-success-small",
        };
        return message;
      },
      ERROR: function (name) {
        var message = {
          messageType: "Lỗi!",
          messageContent: `${name}`,
          colorMsg: "red",
          classIcon: "icon-error-round-small",
        };
        return message;
      },
    },
    /**
     * Tên file
     */
    nameFile: {
      templateImport: "Mau_danh_muc_nhan_vien.xlsx",
      fileExport: "Danh_sach_nhan_vien.xlsx",
      fileImportValidate:"Kết quả kiểm tra.xlsx"  
    },
    /**
     * Trạng thái dòng import
     */
    statusRowImport: {
      valid: "Hợp lệ.",
      invalid: "Không hợp lệ.",
    },
    /**
     * Tiêu đề chức năng
     */
    ACTION: {
      ADD: "Thêm",
      EDIT: "Sửa",
      DELETE: "Xóa",
    },
    /**
     * Các thông báo lỗi api
     */
    errorMessageAPI:{
      ERROR_NETWORK: "Có lỗi phản hồi từ máy chủ vui lòng thử lại sau.",
      ERROR_AUTHENTICATE: "Bạn không có quyền.",
      ERROR_SERVER: "Lỗi máy chủ vui lòng thử lại.",
      ERROR_CLENT: "Có lỗi vui lòng thử lại sau.",
    },
    messageImport: {
      fileNotSelected: "Bạn chưa chọn tệp dữ liệu. Vui lòng kiểm tra lại." ,    
    }
  },
  /**
   * Các rules validate
   */
  FORM_RULES: {
    NOT_EMPTY: "NOT_EMPTY",
    HAS_FORMAT: "HAS_FORMAT",
    UNIQUE: "UNIQUE",
    ADULT: "ADULT",
    MAX_LENGTH: "MAX_LENGTH",
  },
};
export default resources;
