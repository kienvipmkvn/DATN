import axiosClient from "./axiosClient";

export class statisticApi {
  /**
   * Lấy các nhân viên theo bộ lọc
   */
  StatisticDefault = () => {
    try {
      return axiosClient.get("Statistic/statistic-default");
    } catch (error) {
      console.log(error);
    }
  };
  SellingProductToMonthNow = (params) => {
    try {
      return axiosClient.post("Statistic/SellingProductToMonthNow",params);
    } catch (error) {
      console.log(error);
    }
  };

  StatisticRevenue = (params) => {
    try {
      return axiosClient.post("Statistic/StatisticRevenue",params);
    } catch (error) {
      console.log(error);
    }
  };
}
export default statisticApi;
