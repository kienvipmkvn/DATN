
import axiosClient from "./axiosClient";
import baseApi from "./baseApi";
/**
 * Các API liên quan đến dữ liệu
 */
class addressReceiveApi extends baseApi {
  constructor() {
    super("AddressReceive");
  }
  setDefault = (params) => {
    try {
      return axiosClient.put(this.baseUrl + "set-default", params);
    } catch (error) {
      console.log(error);
    }
  };
  
}

export default addressReceiveApi;
