import axiosClient from "./axiosClient";

export class productApi {
  MassDiscount = (param) => {
    try {
      return axiosClient.put("Product/Mass-Discount", param);
    } catch (error) {
      console.log(error);
    }
  };
  GetMassDiscount = () => {
    try {
      return axiosClient.get("Product/Get-Mass-Discount");
    } catch (error) {
      console.log(error);
    }
  };
}

export default productApi;
