import axiosClient from "./axiosClient";

export class regionApi {
  getRegionByParentId = (params) => {
    try {
        params = {parentId : params};
      return axiosClient.post("/Region/",params);
    } catch (error) {
      console.log(error);
    }
  };
}

export default regionApi;
