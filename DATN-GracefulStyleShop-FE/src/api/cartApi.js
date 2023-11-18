import axiosClient from "./axiosClient";

export class cartApi{
  cartNumber = () => {
    try {
      return axiosClient.get("Cart/cart-number");
    } catch (error) {
      console.log(error);
    }
  };
  updateQuantity = (param) => {
    try {
      return axiosClient.put("Cart/update-quantity/"+ param.Id,param.Quantity);
    } catch (error) {
      console.log(error);
    }
  };
}

export default cartApi;
