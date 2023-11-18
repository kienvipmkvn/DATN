import axiosClient from "./axiosClient";

export class orderApi {
  /**
   * Lấy các nhân viên theo bộ lọc
   */
  updateStatus = (param) => {
    try {
      return axiosClient.post("Order/update-status", param);
    } catch (error) {
      console.log(error);
    }
  };
}

export default orderApi;
