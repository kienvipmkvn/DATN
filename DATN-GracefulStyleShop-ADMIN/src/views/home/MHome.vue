<template>
  <div class="home">
    <div class="row">
      <div class="card">
        <div class="card-block">
          <div class="row align-items-center">
            <h4 class="text-c-yellow f-w-600">
              {{ $state.formatPrice(statisticDefault.Revenue) }}
            </h4>
          </div>
        </div>
        <div class="card-footer bg-c-green">
          <div class="align-items-center">
            <i class="fa-solid fa-dollar-sign"></i> Doanh thu
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-block">
          <div class="row align-items-center">
            <h4 class="text-c-yellow f-w-600">
              {{ statisticDefault.OrderNumber }}
            </h4>
          </div>
        </div>
        <div class="card-footer bg-c-blue">
          <div class="align-items-center">
            <i class="fa-solid fa-receipt"></i>Đơn hàng
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-block">
          <div class="row align-items-center">
            <h4 class="text-c-yellow f-w-600">
              {{ statisticDefault.ProductNumber }}
            </h4>
          </div>
        </div>
        <div class="card-footer bg-c-pink">
          <div class="align-items-center">
            <i class="fa-solid fa-shirt"></i>Sản phẩm
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-block">
          <div class="row align-items-center">
            <h4 class="text-c-yellow f-w-600">
              {{ statisticDefault.CustomerNumber }}
            </h4>
          </div>
        </div>
        <div class="card-footer bg-c-yellow">
          <div class="align-items-center">
            <i class="fa-solid fa-users"></i> Khách hàng
          </div>
        </div>
      </div>
    </div>
    <div class="home-char">
      <div class="char-left">
        <VueApexCharts
          width="500"
          type="bar"
          :options="options1"
          :series="series1"
        ></VueApexCharts>
      </div>
      <div class="char-right">
        <VueApexCharts
          width="500"
          type="donut"
          :options="options2"
          :series="series2"
        ></VueApexCharts>
      </div>
      <div></div>
    </div>
    <h2 class="title-order-home">Đơn hàng mới nhất</h2>
    <div class="m__e-fixed-table">
    <table class="m__e-table">
      <tr class="m__e-table-row">
        <MTableColumn tag="th" minWidth="100px" maxWidth="150px"
          >MÃ ĐƠN HÀNG</MTableColumn
        >
        <MTableColumn tag="th" minWidth="250px" maxWidth="250px"
          >TÊN KHÁCH HÀNG</MTableColumn
        >
        <MTableColumn tag="th" minWidth="100px" maxWidth="100px"
          >TỔNG TIỀN</MTableColumn
        >
        <MTableColumn
          tag="th"
          minWidth="200px"
          textAlign="left"
          >TRẠNG THÁI THANH TOÁN</MTableColumn
        >
        <MTableColumn
          tag="th"
          minWidth="200px"
          maxWidth="200px"
          >TRẠNG THÁI ĐƠN HÀNG</MTableColumn
        >
        <MTableColumn tag="th" minWidth="150px" maxWidth="150px"
          >NGÀY TẠO</MTableColumn
        >
      </tr>
      <tr
        class="m__e-table-row"
        v-for="item in orders"
        :key="item.OrderId"
      >
        <MTableColumn>{{ item.OrderCode }}</MTableColumn>
        <MTableColumn  :dataTip="item.FullName" >{{ item.FullName }}</MTableColumn>
        <MTableColumn>{{
         $state.formatPrice(item.TotalPrice)
        }}</MTableColumn>
        <MTableColumn textAlign="left">{{
          item.IsPaid? 'Đã thanh toán' : "Chưa thanh toán"
        }}</MTableColumn>
        <MTableColumn>{{ getTitleStatusOrder(item.Status) }}</MTableColumn>
        <MTableColumn>{{ formatDate(item.CreatedAt)}}</MTableColumn>
      </tr>
    </table>
    <div class="m__e-list-empty" v-if="isShowImgNoData">
      <img src="@/assets/img/bg_report_nodata.76e50bd8.svg" alt="Không có dữ liệu">
      <span>Không có dữ liệu</span>
    </div>
  </div>
  </div>
</template>
<script>
import VueApexCharts from "vue3-apexcharts";
import statisticApi from "@/api/statisticApi";
import MTableColumn from '@/components/table-column/MTableColumn.vue';
import baseApi from '@/api/baseApi';
import common from '@/assets/js/common';
import enumD from '@/assets/js/enum';
export default {
  name: "MHome",
  components: {
    VueApexCharts,
    MTableColumn,
  },
  created: async function () {
    this.$state.nameTable = "Home";
    let res = await new statisticApi().StatisticDefault();
    this.statisticDefault = res;

    res = await new statisticApi().SellingProductToMonthNow({
      Year: new Date().getFullYear(),
      Month: new Date().getMonth() + 1,
    });
    res.forEach((product) => {
      this.options2.labels.push(product.ProductName);
    });
    const totalQuantity = res.reduce((acc, cur) => acc + cur.totalQuantity, 0);
    res.forEach((product) => {
      const percentage = (product.totalQuantity / totalQuantity) * 100;
      this.series2.push(percentage);
    });
    // Doanh thu
    res = await new statisticApi().StatisticRevenue({
      Year: new Date().getFullYear(),
    });

    res.forEach((item) => {
      this.options1.xaxis.categories.push(item.MonthTitle);
    });

    res.forEach((item) => {
      this.series1[0].data.push(item.TotalPrice);
    });

    res = await new baseApi("Order").getByFilter({PageSize : 10});
    this.orders = res.Data;
  },
  data: function () {
    return {
      orders :[],
      statisticDefault: {},
      options1: {
        chart: {
          id: "vuechart-example",
        },
        xaxis: {
          categories: [],
        },
        title: {
          text: "Doanh thu theo năm",
          floating: true,
          align: "center",
          style: {
            color: "#444",
          },
        },
      },
      series1: [
        {
          name: "Doanh thu",
          data: [],
        },
      ],

      series2: [],
      options2: {
        chart: {
          width: 300,
          type: "donut",
        },
        title: {
          text: "Top 5 sản phẩm bán chạy",
          floating: true,
          align: "center",
          style: {
            color: "#444",
          },
        },
        labels: [],
        responsive: [
          {
            breakpoint: 2000,
            options: {
              chart: {
                width: 550,
              },
              legend: {
                position: "right",
              },
            },
          },
        ],
      },
    };
  },
  methods:{
    formatDate(date){
      return common.formatDate(date);
    },
    getTitleStatusOrder(status) {
    switch (status) {
      case enumD.enumStatusOrder.ChoXacNhan:
        return "Chờ xác nhận";
      case enumD.enumStatusOrder.DaXacNhan:
        return "Chờ lấy hàng";
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
  }
};
</script>
<style scoped>
@import url(./home.css);
.m-main-content{
}
.home{
  height: 100%;
  overflow: auto !important;
  width: 100%;
  overflow-x: none ;
}
.home-char {
  margin-top: 24px;
  width: 100%;
}
.char-right {
  flex: 1;
}
.char-left {
  flex: 1;
}
.title-order-home{
  margin: 12px 0;
}
.apx-legend-position-right{
  margin-top: 12px;
}
</style>
