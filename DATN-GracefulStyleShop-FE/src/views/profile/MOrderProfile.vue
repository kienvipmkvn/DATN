<template>
  <div
    class="order-profile"
    v-if="isShow && !showDetail"
    :style="{ display: hidden || showDetail ? 'none' : 'unset' }"
  >
    <div class="order-status">
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.TatCa}"
        @click="changeTab(enumStatus.TatCa)"
      >
        Tất cả
      </div>
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.ChoXacNhan}"
        @click="changeTab(enumStatus.ChoXacNhan)"
      >
        Chờ xác nhận
      </div>
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.DaXacNhan}"
        @click="changeTab(enumStatus.DaXacNhan)"
      >
        Chờ lấy hàng
      </div>
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.DangGiao}"
        @click="changeTab(enumStatus.DangGiao)"
      >
        Đang vận chuyển
      </div>
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.DaNhanHang}"
        @click="changeTab(enumStatus.DaNhanHang)"
      >
        Đã nhận hàng
      </div>
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.HoanThanh}"
        @click="changeTab(enumStatus.HoanThanh)"
      >
        Hoàn thành
      </div>
      <div
        class="status-item"
        :class="{active : tabActive == enumStatus.DaHuy}"
        @click="changeTab(enumStatus.DaHuy)"
      >
        Đã hủy
      </div>
    </div>
    <div class="order-search">
      <m-input classIcon="icon-search" v-model="textSearch" @update:modelValue="searchData" placeholder="Tìm kiếm đơn hàng" />
    </div>
    <div class="order-tab-item">
      <m-order-item v-for="order,index in orders" :key="index" :item="order" @show-detail="showOrderDetail" />
    </div>
  </div>
  <m-order-item-detail :isShow="showDetail" :OrderId="OrderId"  @close="showDetail = fasle" />
</template>
<script>
import MInput from "@/components/input/MInput.vue";
import enumD from "@/common/enum";
import MOrderItem from "@/components/Order/MOrderItem.vue";
import baseApi from '@/api/baseApi';
import MOrderItemDetail from '@/components/Order/MOrderItemDetail.vue';
export default {
  name: "MOrderProfile",
  components: {
    MInput,
    MOrderItem,
    MOrderItemDetail
  },
  props: {
    isShow: Boolean,
    hidden: Boolean,
  },
  created: async function(){
    try {
      await this.getData();
      if(this.$state.OrderId){
        this.OrderId = this.$state.OrderId;
        this.showDetail = true;
      }
    } catch (error) {
      console.log(error);
    }
  },
  data() {
    return {
      enumStatus: enumD.enumStatusOrder,
      tabActive: 0,
      showDetail : false,
      OrderId : null,
      orders :[],
      textSearch: ""
    };
  },

  methods: {
    async changeTab(tab) {
      this.tabActive = tab;
      await this.getData();
    },
    showOrderDetail(id){
      this.OrderId = id;
      this.showDetail = true;
    },
    /**
     * Hàm search
     */
    async searchData() {
      try {
        if (this.timeout) clearTimeout(this.timeout);
        // Xét thời gian tìm kiếm 0,5s
        this.timeout = setTimeout(async () => {
        await this.getData();
        }, 500); // delay
      } catch (error) {
        console.log("Lỗi search data : ", error);
      }
    },
    async getData(){
      const res =await new baseApi("Order").getByFilter({ Status : this.tabActive,TextSearch : this.textSearch });
      this.orders = res.Data;
    }
  },
  watch:{
     '$state.tabProfile'(){
        this.showDetail = false;
     }
  }
};
</script>
<style></style>
