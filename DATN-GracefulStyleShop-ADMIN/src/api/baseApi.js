import axiosClient from "./axiosClient";
/**
 * Các API liên quan đến dữ liệu
 */
class baseApi {
  constructor(table) {
    this.baseUrl = table + "/";
  }
  baseUrl = ""
  /**
   * Lấy các item theo bộ lọc
   */
  getByFilter = (params) => {
    try {
      return axiosClient.post(this.baseUrl + "filter", params);
    } catch (error) {
      console.log(error);
    }
  };
  getAll = () => {
    try {
      return axiosClient.get(this.baseUrl);
    } catch (error) {
      console.log(error);
    }
  };
  /**
   * Lấy mã item mới
   */
  getNewCode = () => {
    try {
      return axiosClient.get(this.baseUrl + "GetNewCode");
    } catch (error) {
      console.log(error);
    }
  };
  /**
   * Lấy 1 item theo Id
   */
  getById = (id) => {
    try {
      return axiosClient.get(this.baseUrl + id);
    } catch (error) {
      console.log(error);
    }
  };
  /**
   * Thêm dữ liệu
   */
  create = (item) => {
    try {
      return axiosClient.post(this.baseUrl, item);
    } catch (error) {
      console.log(error);
    }
  };
  /**
   * Sửa dữ liệu
   */
  update = (id, newItem) => {
    try {
      return axiosClient.put(this.baseUrl + id, newItem);
    } catch (error) {
      console.log(error);
    }
  };
  /**
   * Xóa dữ liệu theo Id
   */
  remove = (ids) => {
    try {
      return axiosClient.post(this.baseUrl + "Delete-Records", ids);
    } catch (error) {
      console.log(error);
    }
  };
  /**
   * Khóa
   */
  lockup = (ids) => {
    try {
      return axiosClient.post(this.baseUrl + "Lock-Up", ids);
    } catch (error) {
      console.log(error);
    }
  };
}

export default baseApi;
