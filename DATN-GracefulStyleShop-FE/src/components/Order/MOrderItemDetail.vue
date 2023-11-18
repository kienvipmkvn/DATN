<template>
  <div class="order-item-detail" v-if="isShow">
    <div class="order-item-detail-header">
      <div class="header-prev" @click="$emit('close')">TRỞ LẠI</div>
      <div class="header-info">
        <span>{{ order.OrderCode }}</span> |
        {{ getTitleStatusOrder(order.Status) }}
      </div>
    </div>
    <div class="paid">{{ getStatusPaid(order.IsPaid) }}</div>
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
        <h6>{{ order.Receiver }}</h6>
        <div>{{ order.Phone }}</div>
        <div>
          {{ order.AddressDetail }}
        </div>
        <div v-if="order.Status == 6" :style="{fontWeight: 'bold'}">
          Lí do hủy : {{ order.CancelReason }}
        </div>
        <div v-if="order.Note" :style="{fontWeight: 'bold'}">
          Lưu ý : {{ order.Note }}
        </div>
      </div>
      <div class="info-product">
        <cart-item-checkout
          v-for="(orderDetail, index) in order.OrderDetails"
          :key="index"
          :item="orderDetail"
        />
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Tổng số lượng</span>
          </div>
          <div class="CxyZBG">
            <div>{{ order.TotalAmount }}</div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Tổng tiền hàng</span>
          </div>
          <div class="CxyZBG">
            <div>
              {{ $state.formatPrice(order.TotalPrice - order.PriceShip) }}
            </div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Phí vận chuyển</span>
          </div>
          <div class="CxyZBG">
            <div>{{ $state.formatPrice(order.PriceShip) }}</div>
          </div>
        </div>
        <div class="TokOv1">
          <div class="_8kMYJ3">
            <span>Thành tiền</span>
          </div>
          <div class="CxyZBG active">
            <div>{{ $state.formatPrice(order.TotalPrice) }}</div>
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
          <div>{{ order.ShipmentName }}</div>
        </div>
      </div>
      <div class="TokOv1">
        <div class="_8kMYJ3">
          <span>Phương thức thanh toán</span>
        </div>
        <div class="CxyZBG">
          <div>{{ getPaymentMethod(order.PaymentMethod) }}</div>
        </div>
      </div>
    </div>
    <div class="_8kMYJ3 btn-destroy" v-if="order.Status <= 2">
         <m-button typeBtn="delete" @click="isShowWarning = true">Hủy đơn hàng</m-button>
        </div>
  </div>
  <MPopUpWarn
    :isShow="isShowWarning"
    @close-pop-up="isShowWarning = false"
    width="450px"
  >
    <div class="warnning-close-order">
      <div class="div">Bạn có chắc chắn muốn hủy đơn hàng không?</div>
      <div class="close-order-note">
        <textarea v-model="cancelReason" name="" id="" rows="2"></textarea>
      </div>
    </div>
    <template #footer>
      <div class="warning__delete-btn">
        <div @click="isShowWarning = false">
          <MButton typeBtn="close">Không</MButton>
        </div>
        <div @click="destroyOrder">
          <MButton typeBtn="delete">Có</MButton>
        </div>
      </div>
    </template>
  </MPopUpWarn>
</template>
<script>
import baseApi from "@/api/baseApi";
import orderApi from "@/api/orderApi";
import CartItemCheckout from "../Cart/CartItemCheckout.vue";
import common from "@/common/common";
import enumD from "@/common/enum";
import MButton from "../button/MButton.vue";
import MPopUpWarn from '../pop-up/MPopUpWarn.vue';
import resources from '@/common/resource';
export default {
  components: {
    CartItemCheckout,
    MButton,
    MPopUpWarn
  },
  props: {
    isShow: Boolean,
    OrderId: String,
  },
  created: async function () {},
  mounted() {},
  data() {
    return {
      order: {},
      status: enumD.enumStatusOrder,
      isShowWarning : false,
      cancelReason :""
    };
  },
  methods: {
    getTitleStatusOrder(status) {
      return common.getTitleStatusOrder(status);
    },
    getPaymentMethod(paymentMethod) {
      switch (paymentMethod) {
        case enumD.paymentMethod.TTKLH:
          return "Thanh toán khi nhận hàng";
        case enumD.paymentMethod.ONLINE:
          return "Thanh toán trực tuyến";
        default:
          break;
      }
    },
    getStatusPaid(paid) {
      switch (paid) {
        case 0:
          return "Chưa thanh toán";
        case 1:
          return "Đã thanh toán";
        default:
          break;
      }
    },
    setActiveStep(step) {
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
        case 6:
          return this.order.Status > 4;
        default:
          break;
      }
    },
    setActiveHrProcess(step) {
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
          return false;
        case 6:
          return false;
        default:
          break;
      }
    },
    async destroyOrder(){
      try {
        this.isShowWarning = false;
        await new orderApi().updateStatus({Status : enumD.enumStatusOrder.DaHuy , OrderId : this.OrderId,CancelReason : this.cancelReason});
        window.scrollTo(0, 0);
        const res = await new baseApi("Order").getById(this.OrderId);
        this.order = res;
        if(res){
          this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.SUCCESS("Đã hủy đơn hàng ")
          );
        }
      } catch (error) {
        console.log(error);
      }
    }
  },
  watch: {
    OrderId: async function () {
      if (this.OrderId) {
        window.scrollTo(0, 0);
        const res = await new baseApi("Order").getById(this.OrderId);
        this.order = res;
      }
    },
  },
};
</script>
<style scoped>
.header-info span {
  font-size: 16px;
  font-weight: bold;
  color: black;
}
.header-info {
  font-size: 16px;
  font-weight: bold;
  color: #f93b3b;
}
.btn-close {
  display: flex;
  justify-content: flex-end;
}
._8kMYJ3.btn-destroy{
  background-color: white;
}
.close-order-note textarea{
  width: 100%;
  border: 1px solid #908f8f;
  outline: none;
  padding: 8px;
}
</style>
