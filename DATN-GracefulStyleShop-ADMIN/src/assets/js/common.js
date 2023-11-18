
import constants from "./constants";
import enumD from "./enum";
import resources from "./resource";
/**
 * Các hàm dùng chung
 */
const common = {
  /**
   * Format date (DD/MM/YYYY)
   */
  formatDate: (dateTime) => {
    try {
      if (dateTime) {
        dateTime = new Date(dateTime);
        let date =
          dateTime.getDate() < 10
            ? "0" + dateTime.getDate()
            : dateTime.getDate();
        let month =
          dateTime.getMonth() < 9
            ? `0${dateTime.getMonth() + 1}`
            : dateTime.getMonth() + 1;
        let year = dateTime.getFullYear();
        return `${date}/${month}/${year}`;
      }
      return "";
    } catch (error) {
      return "";
    }
  },
  /**
   * Hàm chuyển từ enum giới tính ra tên
   */
  getTitleGender: (gender) => {
    var title = "Khác";
    switch (gender) {
      // Nam
      case enumD.enumGender.male:
        title = "Nam";
        break;
      // Nữ
      case enumD.enumGender.female:
        title = "Nữ";
        break;
      // Khác
      case enumD.enumGender.other:
        title = "Khác";
        break;
      default:
        title = "";
        break;
    }
    return title;
  },
  /**
   * Format tiền VN
   */
  formatSalaryVN: (salary) => {
    return salary
      ? new Intl.NumberFormat("vi-VN", {
          style: "currency",
          currency: "VND",
        }).format(salary)
      : "";
  },
  getTitleStatusOrder(status) {
    switch (status) {
      case enumD.enumStatusOrder.ChoXacNhan:
        return "Chờ xác nhận";
      case enumD.enumStatusOrder.DaXacNhan:
        return "Đã xác nhận";
      case enumD.enumStatusOrder.DangGiao:
        return "Đang giao";
      case enumD.enumStatusOrder.DaNhanHang:
        return "Đã nhận hàng";
      case enumD.enumStatusOrder.HoanThanh:
        return "Hoàn thành";
      case enumD.enumStatusOrder.DaHuy:
        return "Đã hủy";
      case enumD.enumStatusOrder.TraHang:
        return "Trả hàng";
    }
  },
  /**
   * Hàm validate input
   */
  inputValidation: (rules, name, value) => {
    const FORM_FIELD = resources.vi.FORM_FIELD;
    const { NOT_EMPTY, UNIQUE, ADULT, HAS_FORMAT, MAX_LENGTH } =
      resources.FORM_RULES;
    const ERROR = resources.vi.FORM_MESSAGE.ERROR;
    const regexConstants = constants.regexConstants;
    for (const rule of rules) {
      var arrRule = rule.split("|");
      var nameRule = arrRule[0];
      var keyRule = arrRule[1];
      switch (nameRule) {
        case NOT_EMPTY: {
          if (!value && value != 0) return ERROR[nameRule](FORM_FIELD[name]);
          break;
        }
        case UNIQUE: {
          break;
        }
        case ADULT: {
          if (value) {
            const date = new Date(value).getTime();
            const dateNow = new Date().getTime();
            if (date > dateNow) {
              return ERROR[nameRule](FORM_FIELD[name]);
            }
          }
          break;
        }
        case HAS_FORMAT: {
          if (value && !regexConstants[name].test(value))
            return ERROR[nameRule](FORM_FIELD[name]);
          break;
        }
        case MAX_LENGTH: {
          if (value && value.length > keyRule)
            return ERROR[nameRule](FORM_FIELD[name], keyRule);
          break;
        }
        default:
          break;
      }
    }
  },
};

export default common;
