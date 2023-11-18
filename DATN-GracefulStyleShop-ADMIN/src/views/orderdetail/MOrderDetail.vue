<template>
  <div class="order-item-detail">
    <div class="order-item-detail-header">
      <div class="header-prev" @click="$router.push('/orders')">TRỞ LẠI </div>
      <div class="header-info"><span>{{order.OrderCode}}</span> | {{getTitleStatusOrder(order.Status)}}</div>
    </div>
    <div class="paid">{{getStatusPaid(order.IsPaid)}}</div> 
    <ul class="progressbar">
      <div class="step">
        <div class="step-icon" :class="{ active: setActiveStep(1) }">
          <div><i class="fa-solid fa-paper-plane"></i></div>
        </div>
        <div class="step-title">Chờ xác nhận</div>
        <div class="hr-step" :class="{ active: setActiveHrProcess(1) }"></div>
      </div>
      <div class="step">
        <div class="step-icon" :class="{ active: setActiveStep(2) }">
          <div><i class="fa-solid fa-square-check"></i></div>
        </div>
        <div class="step-title">Đã xác nhận</div>
        <div class="hr-step" :class="{ active: setActiveHrProcess(2) }"></div>
      </div>
      <div class="step">
        <div class="step-icon" :class="{ active: setActiveStep(3) }">
          <div><i class="fa-solid fa-truck-fast"></i></div>
        </div>
        <div class="step-title">Đang giao</div>
        <div class="hr-step" :class="{ active: setActiveHrProcess(3) }"></div>
      </div>
      <div class="step">
        <div class="step-icon" :class="{ active: setActiveStep(4) }">
          <div><i class="fa-solid fa-download"></i></div>
        </div>
        <div class="step-title">Đã nhận hàng</div>
        <div class="hr-step" :class="{ active: setActiveHrProcess(4) }"></div>
      </div>
      <div class="step" v-if="order.Status == status.DaHuy">
        <div class="step-icon" :class="{ active: setActiveStep(5) }">
          <div><i class="fa-solid fa-rectangle-xmark"></i></div>
        </div>
        <div class="step-title">Đã hủy</div>
      </div>
      <div class="step" v-if="order.Status != 6">
        <div class="step-icon" :class="{ active: setActiveStep(6) }">
          <div><i class="fa-solid fa-thumbs-up"></i></div>
        </div>
        <div class="step-title">Hoàn thành</div>
      </div>
    </ul>
    <div class="DM1xQK"></div>
    <div class="order-item-detail-info">
      <div class="info-address">
        <h5>Địa Chỉ Nhận Hàng</h5>
        <h6>{{order.Receiver}}</h6>
        <div>{{order.Phone}}</div>
        <div>
          {{order.AddressDetail}}
        </div>
        <div v-if="order.Status == 6" :style="{fontWeight: 'bold'}">
          Lí do hủy : {{ order.CancelReason }}
        </div>
        <div v-if="order.Note" :style="{fontWeight: 'bold'}">
          Lưu ý : {{ order.Note }}
        </div>
      </div>
      <div class="info-product">
        <cart-item-checkout v-for="orderDetail,index in order.OrderDetails" :key="index" :item="orderDetail" />
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Tổng số lượng</span>
          </div>
          <div class="CxyZBG">
            <div>{{order.TotalAmount}}</div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Tổng tiền hàng</span>
          </div>
          <div class="CxyZBG">
            <div>{{$state.formatPrice(order.TotalPrice - order.PriceShip)}}</div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Phí vận chuyển</span>
          </div>
          <div class="CxyZBG">
            <div>{{$state.formatPrice(order.PriceShip)}}</div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3 ">
            <span>Thành tiền</span>
          </div>
          <div class="CxyZBG active">
            <div>{{$state.formatPrice(order.TotalPrice)}}</div>
          </div>
        </div>
        
      </div>
    </div>
    <div class="order-method">
      <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Phương thức giao hàng</span>
          </div>
          <div class="CxyZBG">
            <div>{{order.ShipmentName}}</div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Phương thức thanh toán</span>
          </div>
          <div class="CxyZBG">
            <div>{{getPaymentMethod(order.PaymentMethod)}}</div>
          </div>
        </div>
    </div>
  </div>
</template>
<script>
import baseApi from '@/api/baseApi';
import common from '@/assets/js/common';
import enumD from '@/assets/js/enum';
import CartItemCheckout from './CartItemCheckout.vue';
export default {
  components: {
    CartItemCheckout,
  },
  props:{
  },
  created: async function(){
    this.OrderId = this.$route.params.id;
    window.scrollTo(0, 0);
    const res = await new baseApi("Order").getById(this.OrderId);
    this.order = res;
  },
  mounted(){
  },
  data() {
    return {
      order : {
      },
      status : enumD.enumStatusOrder,
      OrderId : "",
    };
  },
  methods:{
    getTitleStatusOrder(status){
      return common.getTitleStatusOrder(status);
    },
    getPaymentMethod(paymentMethod){
      switch (paymentMethod) {
        case enumD.paymentMethod.TTKLH:
          return 'Thanh toán khi nhận hàng';
        case enumD.paymentMethod.ONLINE:
          return 'Thanh toán trực tuyến';
        default:
          break;
      }
    },
    getStatusPaid(paid){
      switch (paid) {
        case 0:
          return 'Chưa thanh toán';
        case 1:
          return 'Đã thanh toán';
        default:
          break;
      }
    },
    setActiveStep(step){
      switch (step) {
        case 1:
          return this.order.Status > 0;
        case 2:
          return this.order.Status > 1;
        case 3:
          return this.order.Status > 2;
        case 4:
          return this.order.Status > 3;
        case 5:
          return this.order.Status > 4;
        case 6 :
        return this.order.Status > 4;
        default:
          break;
      }
    },
    setActiveHrProcess(step){
      switch (step) {
        case 1:
          return this.order.Status > 1;
        case 2:
          return this.order.Status > 2;
        case 3:
          return this.order.Status > 3;
        case 4:
          return this.order.Status > 4;
        case 5:
          return this.order.Status > 5;
        case 6 :
        return this.order.Status > 5;
        default:
          break;
      }
    }
  },
  watch:{
    // OrderId  :async  function () {
    //   if(this.OrderId){
        
    //   }
    // }
  }
};
</script>
<style scoped>
.header-prev{
    cursor: pointer;
}
.header-info span{
  font-size: 16px;
  font-weight: bold;
}
.order-item-detail-header{
    display: flex;
    justify-content: space-between;
    padding: 12px 24px;
    background-color: white;
    border-radius: 0 0 8px 8px;
}
.order-item-detail{
    position: relative;
    max-height: calc(100vh - 50px - 40px);
    overflow-y: auto;
}
.progressbar{
    display: flex;
    justify-content: space-between;
    background-color: white;
    border-radius: 8px ;
    padding: 16px 0;
}
.paid{
    position: absolute;
    width: max-content;
    padding: 2px 4px;
    z-index: 9;
    top: 191px;
    border: 2px solid #2dc258;
    left: 83%;
    transform: rotate(-8deg);
}
.step{
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    position: relative;
    z-index: 1;
}
.hr-step{
    background-color: #b0b3b1;
    width: 100%;
    height: 4px;
    position: absolute;
    top: 24px;
    left: 50%;
    z-index: -1;
}
.hr-step.active{
    background-color: #2dc258;
}
.step-icon{
    width: 50px;
    height: 50px;
    border-radius: 50%;
    border: 3px solid #b0b3b1;
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
    background-color: white;
}
.step-icon.active{
    border: 3px solid #2dc258;
}
.step-title{
    font-size: 14px;
    font-weight: 500;
    margin-top: 2px;
}
.step-icon div{
    font-size: 20px;
    color: #393b3a;
    background-color: white;
    z-index: 1;
}
.step-icon.active div{
    color: #2dc258;
}
.DM1xQK{
    height: 0.1875rem;
    width: 100%;
    background-repeat: repeat-x;
    background-position-x: -1.875rem;
    background-size: 7.25rem 0.1875rem;
    background-image: repeating-linear-gradient(45deg,#6fa6d6,#6fa6d6 33px,transparent 0,transparent 41px,#f18d9b 0,#f18d9b 74px,transparent 0,transparent 82px);
}
.order-item-detail-info{
    display: flex;
    background-color: white;
    padding-top: 24px;
}
.order-method{
    background-color: white;
    padding: 8px 24px;
}.info-address{
    flex-basis: 30%;
    padding: 0 24px;
    border-right: 1px solid #ccc9c9;
}
.info-address h5{
    text-transform: capitalize;
    color: rgba(0,0,0,.8);
    font-size: 20px;
    line-height: 24px;
}
.info-address h6{
  margin-top: 8px;
    max-width: 100%;
    overflow: hidden;
    font-size: 14px;
    text-overflow: ellipsis;
    color: rgba(0,0,0,.8);
}
.info-address div{
    color: rgba(0,0,0,.54);
    font-size: 12px;
    white-space: pre-line;
    padding: 4px 0;
}
.info-product{
    flex-basis: 70%;
    padding:8px 24px;
    font-size: 13px;
}
.CxyZBG.active{
    color: #ee4d2d;
    font-size: 24px;
}
.TokOv1{
    padding: 0 24px;
    display: flex;
    justify-content: flex-end;
    align-items: center;
    text-align: right;
    border-bottom: 1px dotted rgba(0, 0, 0, 0.132);
    border-top: 1px dotted rgba(0, 0, 0, 0.132);
}
._8kMYJ3{
    padding: 13px 10px;
    color: rgba(0,0,0,.54);
    font-size: 14px;
}
._8kMYJ3 > span{
    display: inline-block;
    vertical-align: middle;
}
.CxyZBG{
    padding: 13px 0 13px 10px;
    width: 200px;
    border-left: 1px dotted rgba(0,0,0,.09);
    justify-content: flex-end;
    word-wrap: break-word;
    color: rgba(0,0,0,.8);
}
.CxyZBG > div{
    display: block;
}
.profile-tab-item-2.active,
.profile-tab-item-1.active{
    color: red;
}
</style>
