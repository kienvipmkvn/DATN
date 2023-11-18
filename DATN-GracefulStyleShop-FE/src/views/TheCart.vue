<template>
  <folder-routes />
  <div class="cart">
    <div class="content-cart-detail">
      <div class="mainCart-detail">
        <div class="heading-cart">
          <h1>Giỏ hàng của bạn</h1>
        </div>
      </div>
      <div class="list-pageform-cart" v-if="$state.cartNumber != 0">
        <form action="/cart" id="cartformpage" method="post">
          <div class="cart-row">
            <p class="title-number-cart">
              Bạn đang có
              <strong class="count-cart">{{ carts.length }} sản phẩm</strong>
              trong giỏ hàng
            </p>
            <div class="table-cart">
              <cart-item
                v-for="(cart, index) in carts"
                :item="cart"
                :key="index"
                @remove="removeItem"
                @refresh="getCart"
              />
            </div>
          </div>
        </form>
      </div>
      <div class="m__e-list-empty" v-if="$state.cartNumber == 0">
        <img
          src="@/assets/img/bg_report_nodata.76e50bd8.svg"
          alt="Không có dữ liệu"
        />
        <div>Không có sản phẩm trong giỏ hàng</div>
      </div>
    </div>
    <div class="order-summary-block">
      <h2 class="summary-title">Thông tin đơn hàng</h2>
      <div class="summary-total">
        <p style="font-weight: normal">
          Tổng giá trước KM:
          <span style="color: #252a2b; font-size: 20px; font-weight: normal">
            <del>{{ $state.formatPrice(total.totalDel) }}</del>
          </span>
        </p>
        <p style="font-weight: normal">
          Tổng tiền:
          <span total-final>{{ $state.formatPrice(total.totalPrice) }}</span>
        </p>
      </div>
      <div class="summary-action">
        <p>TokyoLife FreeShip toàn quốc với đơn hàng từ 500.000Đ!</p>
        <p>
          <strong>LƯU Ý</strong>
          : Đơn hàng có thể được giao làm nhiều lần do được vận chuyển từ nhiều
          kho
        </p>
        <div class="summary-alert alert alert-danger" style="display: none">
          Giỏ hàng của bạn hiện chưa đạt mức tối thiểu để thanh toán.
        </div>
        <div class="summary-button" @click="toCheckout">THANH TOÁN</div>
      </div>
      <div class="order-summary-block order-summary-notify">
        <div class="summary-warning alert-order">
          <p class="textmr">
            <strong
              >TokyoLife nhận ship đơn hàng trị giá từ 150K. Hy vọng quý khách
              hàng có những trải nghiệm tốt nhất khi mua sắm tại website
              TokyoLife. Xin cảm ơn!</strong
            >
          </p>
          <p>
            Hiện chúng tôi chỉ áp dụng thanh toán với đơn hàng có giá trị tối
            thiểu
            <strong>50.000₫ </strong>
            trở lên.
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import CartItem from "@/components/Cart/CartItem.vue";
import FolderRoutes from "@/components/FolderRoutes.vue";
import baseApi from "@/api/baseApi";
import cartApi from "@/api/cartApi";
export default {
  name: "TheCart",
  components: {
    FolderRoutes,
    CartItem,
  },
  created: async function () {
    await this.getCart();
  },
  data() {
    return {
      carts: [],
      total: {
        totalPrice: 0,
        totalDel: 0,
      },
    };
  },
  methods: {
    async removeItem(cartId) {
      await new baseApi("Cart").remove([cartId]);
      const cartNumber = await new cartApi("Cart").cartNumber();
      this.$state.cartNumber = cartNumber?.data == "0" ? 0 : cartNumber;
      this.carts = this.carts.filter((x) => x.CartId != cartId);
      this.total = {
            totalPrice: 0,
            totalDel: 0,
       }
      this.carts.forEach((element) => {
        this.total.totalPrice += element.TotalPrice;
        this.total.totalDel += element.TotalDel;
      });
    },
    async getCart() {
      try {
        if (this.$state.user) {
          const res = await new baseApi("Cart").getByFilter({});
          this.carts = res.Data;
          (this.total = {
            totalPrice: 0,
            totalDel: 0,
          }),
            this.carts.forEach((element) => {
              this.total.totalPrice += element.TotalPrice;
              this.total.totalDel += element.TotalDel;
            });
        }else{
          this.$router.push("/");
        }
      } catch (error) {
        console.log(error);
      }
    },
    toCheckout() {
      if (this.$state.cartNumber != 0) {
        this.$router.push("checkout");
      }
    },
  },
};
</script>
<style scoped>
.cart {
  display: flex;
  justify-content: space-between;
}
.content-cart-detail {
  background-color: var(--color-content);
  width: 66.66666667%;
}
.list-pageform-cart {
  padding: 15px 15px;
}
.heading-cart {
  border-bottom: 1px solid #e3e3e3;
}
.heading-cart h1 {
  font-size: 20px;
  margin: 0;
  border-bottom: 1px solid #e7e7e7;
  padding: 10px 15px;
}
.cart-row {
  width: 100%;
  display: inline-block;
}
.title-number-cart {
  font-weight: 400;
  font-size: 16px;
  margin: 0 0 15px;
}
.title-number-cart strong {
  font-weight: 700;
}
.table-cart {
  border: 1px solid #d1cece;
  border-radius: 4px;
  padding: 12px;
}

.order-noted-block {
  margin: 20px 0 10px;
  background: rgba(0, 0, 0, 0.03);
  padding: 10px 12px 15px;
}
.note-label {
  display: block;
  margin: 0 0px 0 10px;
  font-weight: 600;
  font-size: 14px;
}
.order-noted-block textarea {
  padding: 10px 15px;
  width: 100% !important;
  height: 80px;
  min-height: 80px;
  max-width: 100%;
  resize: auto;
  border: 1px solid #000000;
  box-shadow: none;
}
.order-summary-block {
  background-color: var(--color-content);
  padding: 15px;
  width: 32%;
}
.summary-title {
  font-size: 20px;
  font-weight: bold;
  margin-top: 10px;
  margin-bottom: 15px;
}
.summary-total {
  font-size: 16px;
  padding-bottom: 10px;
  padding-top: 10px;
  font-weight: bold;
  border-top: 1px dotted #dfe0e1;
  border-bottom: 1px dotted #dfe0e1;
  margin-bottom: 10px;
}
.summary-total span {
  color: #252a2b;
  font-size: 20px;
  font-weight: normal;
}
.summary-total span {
  font-weight: bold;
  float: right;
  color: red;
  font-size: 24px;
}
.summary-action {
  padding-top: 5px;
  text-align: center;
}
.summary-action p {
  position: relative;
  font-size: 14px;
  margin-bottom: 4px;
  font-weight: 400;
  text-align: left;
  padding-left: 12px;
}
.summary-action p::before {
  content: "●";
  position: absolute;
  left: 0;
}
.summary-button {
  display: block;
  background: red;
  color: #fff;
  text-decoration: none;
  text-transform: uppercase;
  padding: 10px 5px;
  text-align: center;
  font-size: 15px;
  font-weight: bold;
  border-radius: 4px;
  margin-top: 12px;
  -webkit-transition: 0.1s ease-in-out;
  transition: 0.1s ease-in-out;
  cursor: pointer;
}
.order-summary-block.order-summary-notify {
  width: 100%;
  margin: 16px 0;
  padding: 0;
  font-size: 14px;
}
.summary-warning {
  padding: 12px 15px;
  border-radius: 4px;
  background-color: #d9edf7;
  border: 1px solid #bce8f1;
}
.textmr {
  margin-bottom: 5px;
}
</style>
