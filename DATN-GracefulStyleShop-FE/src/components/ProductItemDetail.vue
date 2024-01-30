<template>
  <div class="product-item">
    <div class="item-imgs">
      <div>
        <div class="imgs-left">
          <Carousel
            id="gallery"
            :items-to-show="1"
            :wrap-around="false"
            v-model="currentSlide"
            class="carousel-image-item"
          >
            <Slide v-for="(slide, index) in item.Images" :key="index">
              <img :src="slide.ImageLink" alt="" />
            </Slide>
            <template #addons>
              <Pagination />
              <Navigation />
            </template>
          </Carousel>
        </div>
        <div class="m-t-8"></div>
        <Carousel
          id="thumbnails"
          :items-to-show="5"
          v-model="currentSlide"
          ref="carousel"
          snapAlign="left"
          class="carousel-list-item-detail"
          :setting="settingsSlide"
        >
          <Slide v-for="(slide, index) in item.Images" :key="index">
            <img :src="slide.ImageLink" alt="" @click="slideTo(index)" />
          </Slide>
        </Carousel>
      </div>
    </div>
    <div class="item-content">
      <div class="product-title">
        {{ item.ProductName }}
      </div>
      <div class="product-brand">
        Thương hiệu: <span>{{ item.BrandName }}</span>
      </div>
      <div class="product-price">
        <div class="product-price-old">
          {{ $state.formatPrice(item.PriceSale) }}
        </div>
        <div class="product-price-new">
          {{ $state.formatPrice(item.PriceDel) }}
        </div>
      </div>
      <div class="product-color">
        <div class="product-color-title">
          Màu sắc: <br /><strong >
            {{ colorActive.ColorName }}
          </strong>
        </div>
        <div class="product-color-list">
          <div
            class="product-color-item"
            @click="activeColor(color)"
            :class="{ active: colorActive.ColorId == color.ColorId }"
            v-for="(color, index) in Colors"
            :key="index"
            :style="{ backgroundColor: color.ColorCode }"
          ></div>
        </div>
      </div>
      <div class="product-size">
        <div class="product-size-title">Kích thước:</div>
        <div class="product-size-list">
          <div
            class="product-size-item"
            @click="activeSize(size)"
            :class="{
              disable: !listSizeByColor.includes(size.SizeId),
              active: sizeActive.SizeId == size.SizeId,
            }"
            v-for="(size, index) in Sizes"
            :key="index"
          >
            {{ size.SizeCode }}
          </div>
        </div>
      </div>
      <div class="p-quantity-detail">Số lượng : {{ sizeActive.ProductVariantQuantity }}</div>
      <hr />
      <div class="view-size-guide m-b-8">
        <a href="">Hướng dẫn chọn size</a>
      </div>
      <div class="select-quantity">
        <button @click="quantityNumber(-1)">-</button>
        <input
          type="number"
          @input="changeQuantity"
          @keydown="handleKeyDown"
          :min="1"
          :max="1000"
          v-model="quantity"
        />
        <button @click="quantityNumber(1)">+</button>
      </div>
      <div class="addcart-area">
        <button @click="addToCart">
          <span>Thêm vào giỏ</span>
        </button>
        <button class="btnred">
          <span @click="toCart()">Mua ngay</span>
        </button>
      </div>
      <div class="product-policy-detail">
        <div class="item-policy-detail">
          Bảo hành 1 đổi 1 trong vòng 7 ngày (*) áp dụng có điều kiện
        </div>
        <div class="item-policy-detail">
          Miễn phí vận chuyển cho đơn hàng từ 500,000 đồng
        </div>
      </div>
      <div class="product-description product-description--accordion">
        <div class="panel-group">
          <div class="panel-title">
            <div class="panel-title-name">THông tin sản phẩm</div>
            <div
              class="panel-icon"
              @click="InformationSummary = !InformationSummary"
            >
              <i class="fa fa-plus"></i>
            </div>
          </div>
          <div v-html="item.Description" v-if="!InformationSummary"></div>
          <hr />
        </div>
        <div class="panel-group">
          <div class="panel-title noclick">
            <div class="panel-title-name">Dịch vụ giao hàng</div>
            <div class="panel-icon" @click="serviceSummary = !serviceSummary">
              <i class="fa fa-plus"></i>
            </div>
          </div>
          <hr />
          <div class="description-content" v-if="!serviceSummary">
            <div class="product-deliverly">
              <ul class="infoList-deliverly">
                <li>
                  <span>
                    <img
                      src="https://file.hstatic.net/1000397797/file/delivery-ico1_f26631929e1b41dab022d9960006297c.svg"
                      alt=""
                    />
                  </span>
                  Cam kết 100% chính hãng từ TokyoLife
                </li>
                <li>
                  <span>
                    <img
                      src="https://file.hstatic.net/1000397797/file/delivery-ico2_5ea2de2f279b4dbfa10fcb9b9c448b4d.svg"
                      alt=""
                    />
                  </span>
                  Giao hàng dự kiến từ 1-3 ngày làm việc. (
                  <strong>LƯU Ý</strong>
                  : Đơn hàng có thể được giao làm nhiều lần do được vận chuyển
                  từ nhiều kho)
                </li>
                <li>
                  <span>
                    <img
                      src="https://file.hstatic.net/1000397797/file/delivery-ico3_dd589d9c49584441a9ef0c2f9300649f.svg"
                      alt=""
                    />
                  </span>
                  Hỗ trợ 24/7 qua Fanpage, Zalo Email & Hotline
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Carousel, Slide, Pagination, Navigation } from "vue3-carousel";
import baseApi from "@/api/baseApi";
import cartApi from "@/api/cartApi";
import resources from "@/common/resource";
export default {
  name: "ProductItemDetail",
  components: {
    Carousel,
    Slide,
    Navigation,
    Pagination,
  },
  props: {
    item: Object,
  },
  created() {},
  data() {
    return {
      currentSlide: 0,
      InformationSummary: true,
      serviceSummary: true,
      Sizes: [],
      Colors: [],
      quantity: 1,
      colorActive: {},
      listSizeByColor: [],
      sizeActive: {},
      settingsSlide: {
        itemsToShow: 5,
        snapAlign: "start",
        touchDrag: false,
        pauseAutoplayOnHover: true,
      },
    };
  },
  methods: {
    slideTo(val) {
      this.currentSlide = val;
    },
    quantityNumber(qty) {
      var number = this.quantity + qty;
      if(number > this.sizeActive.ProductVariantQuantity){
        this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.ERROR("Số lượng vượt quá số lượng có.")
          );
          return;
      }
      if (number > 0) {
        this.quantity = number;
      }
    },
    changeQuantity() {
       if(this.quantity > this.sizeActive.ProductVariantQuantity){
        this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.ERROR("Số lượng vượt quá số lượng có.")
          );
          this.quantity = 1;
          return;
      }
      if (this.quantity < 1 || this.quantity > 100000) {
        this.quantity = 1;
      }
    },
    handleKeyDown(event) {
      if (event.key === "e") {
        event.preventDefault();
      }
    },
    activeColor(color) {
      this.colorActive = color;
      this.listSizeByColor =
        this.colorActive.Sizes.length > 0
          ? this.colorActive.Sizes.map((x) => x.SizeId)
          : [];
      this.sizeActive = color.Sizes[0] ? color.Sizes[0] : null;
    },
    activeSize(size) {
      if(!this.listSizeByColor.includes(size.SizeId)){
        return;
      }
      this.sizeActive = this.colorActive.Sizes.find(x => x.SizeId == size.SizeId);
    },
    async addToCart() {
      try {
        if (!this.$state.user) {
          this.$state.isShowLogin = true;
        } else {
          var ProductVariant = this.colorActive.Sizes.find(
            (x) => x.SizeId == this.sizeActive.SizeId
          );
          var cart = {
            ProductVariantId: ProductVariant.ProductVariantId,
            Quantity: this.quantity,
            CustomerId: this.$state.user.CustomerId,
          };
          await new baseApi("Cart").create(cart);
          if (this.$state.user) {
            const cartNumber = await new cartApi("Cart").cartNumber();
            this.$state.cartNumber = cartNumber?.data == 0 ? 0 : cartNumber;
          }
          this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.SUCCESS("Thêm sản phẩm vào giỏ")
          );
        }
      } catch (error) {
        console.log(error);
        this.$state.toastMessage.unshift(
          resources.vi.TOAST_MESSAGE.ERROR("Có lỗi vui lòng thử lại!")
        );
      }
    },
    async toCart() {
      this.$router.push("/checkout");
    },
  },
  watch: {
    item: function () {
      this.Colors = this.item.Colors;
      this.colorActive = this.Colors.length > 0 ? this.Colors[0] : {};
      this.listSizeByColor =
        this.colorActive.Sizes.length > 0
          ? this.colorActive.Sizes.map((x) => x.SizeId)
          : [];
      this.sizeActive =
        this.colorActive.Sizes.length > 0 ? this.colorActive.Sizes[0] : null;
      this.Sizes = this.item.Sizes;
    },
  },
};
</script>
<style>
.product-item {
  width: 100%;
  display: flex;
}
.item-imgs {
  width: 50%;
}
.item-content {
  width: 50%;
  background-color: var(--color-content);
}
.slide {
  display: flex;
  flex-direction: column;
}
.carousel.carousel-image-item > .carousel__viewport {
  height: 600px !important;
}
.carousel.carousel-image-item ol {
  height: 100% !important;
}
.carousel-list-item-detail .carousel__slide {
  height: 100px !important;
  margin: 0 8px;
  border-radius: 1px solid #cac8c8;
}

/* item-content */
.item-content {
  padding: 10px 24px;
}
.product-title {
  font-size: 24px;
  margin: 20px 0 8px;
  color: #000000;
  margin: 0 0 13px 0;
  font-weight: 700;
  line-height: 1.2;
}
.product-brand span {
  font-weight: 500;
  color: #000000;
}
.product-price {
  display: flex;
  margin-top: 8px;
}
.product-price-old {
  font-size: 18px;
  color: #878c8f;
  margin-right: 10px;
  text-decoration: line-through;
}
.product-price-new {
  font-size: 25px;
  font-weight: 600;
  color: red;
}
.product-color {
  display: flex;
  align-items: center;
  margin-top: 16px;
}
.product-color-title {
  width: 28%;
  color: #252a2b;
  line-height: 1.45;
  font-size: 14px;
  display: block;
}
.product-color-title strong {
  font-size: 85%;
  display: block;
  color: #4ea8cd;
  line-height: 1.1;
  padding-bottom: 3px;
}
.product-color-list {
  display: flex;
}
.product-color-item {
  width: 34px;
  height: 34px;
  border-radius: 50%;
  cursor: pointer;
  border: 1px solid #878c8f;
  background-color: red;
  margin-right: 16px;
}
.p-quantity-detail{
  font-size: 12px;
  font-weight: 500;
}
.product-color-item.active {
  outline: 2px solid blue;
}
.product-size {
  display: flex;
  align-items: center;
  margin-top: 16px;
}
.product-size-title {
  width: 28%;
}
.product-size-list {
  display: flex;
  width: 72%;
}
.view-size-guide a {
  text-decoration: underline;
  margin-bottom: 15px;
  font-weight: bold;
  color: black;
}
.product-size-item {
  position: relative;
  display: block;
  margin: 0;
  padding: 0;
  min-width: 25px;
  height: 25px;
  line-height: 25px;
  background: #fff;
  border: 1px solid #bdbfbe;
  font-size: 10px;
  color: #515b5c;
  font-weight: bold;
  text-align: center;
  cursor: pointer;
  margin-right: 12px;
}
.product-size-item.active {
  background-color: var(--input-primary);
  color: white;
}
.product-size-item.disable::before {
  position: absolute;
  content: "";
  width: 1px;
  height: 100%;
  left: 50%;
  transform: translateX(-50%);
  transform: rotate(45deg);
  background-color: #515b5c;
}
.product-size-item.disable::after {
  position: absolute;
  content: "";
  width: 100%;
  height: 1px;
  top: 50%;
  left: 0;
  transform: translateY(-50%);
  transform: rotate(45deg);
  background-color: #515b5c;
}
.select-quantity {
  display: flex;
}
.select-quantity button {
  background: #f3f4f4;
  border: solid 1px #f3f4f4;
  cursor: pointer;
  font-weight: 600;
  font-size: 16px;
  outline: none;
  height: 45px;
  line-height: 45px;
  width: 45px;
  text-align: center;
  border-radius: 0;
  outline: none;
  appearance: none;
}
.select-quantity input {
  background: #fff;
  font-weight: 600;
  height: 45px;
  line-height: 45px;
  width: 60px;
  padding: 0;
  text-align: center;
  border: 1px solid #f3f4f4;
  border-left: none;
  border-right: none;
  border-radius: 1px;
  float: left;
  -webkit-appearance: none;
  -moz-appearance: none;
  -o-appearance: none;
  appearance: none;
}
.addcart-area {
  width: 100%;
  margin-top: 15px;
}
.addcart-area button {
  width: 49%;
  height: 45px;
  line-height: 45px;
  padding: 0 15px;
  outline: none;
  font-weight: 600;
  font-size: 15px;
}
.addcart-area button {
  position: relative;
  display: inline-block;
  z-index: 1;
  overflow: hidden;
  padding: 12px 28px;
  line-height: normal;
  color: #fff;
  background-color: #000000;
  border: 1px solid #252a2b;
  font-size: 13px;
  font-weight: 500;
  text-align: center;
  letter-spacing: 1px;
  outline: none;
  border-radius: 2px;
  text-transform: uppercase;
  -webkit-transition: color 0.45s cubic-bezier(0.785, 0.135, 0.15, 0.86),
    border 0.45s cubic-bezier(0.785, 0.135, 0.15, 0.86);
  transition: color 0.45s cubic-bezier(0.785, 0.135, 0.15, 0.86),
    border 0.45s cubic-bezier(0.785, 0.135, 0.15, 0.86);
}

.addcart-area button.btnred {
  background-color: #ff0000;
  border-color: #ff0000;
  float: right;
}

.product-policy-detail {
  background: #f7f7f7;
  display: flex;
  justify-content: space-between;
  padding: 10px 0 0 0 !important;
  margin: 0 !important;
  margin: 8px;
}
.item-policy-detail {
  background: rgba(236, 235, 232, 0.65);
  padding: 15px;
  width: 49%;
  text-align: center;
  font-weight: bold;
  display: -ms-flexbox;
  display: flex;
  -ms-flex-align: center;
  align-items: center;
  -ms-flex-pack: center;
  justify-content: center;
  font-size: 13px;
}

.panel-group {
  margin-top: 16px;
}
.panel-title {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.panel-title-name {
  color: #000000;
  font-weight: 700;
  line-height: 1.2;
  text-transform: uppercase;
  font-size: 15px;
  font-weight: 500;
  margin: 0;
  cursor: pointer;
  font-weight: bold;
}
.panel-icon i {
  font-weight: 900;
  cursor: pointer;
}

.description-content {
  display: block;
}
.infoList-deliverly {
  padding: 0;
  margin: 0;
  list-style-type: none;
}
.infoList-deliverly li {
  padding-left: 45px;
  padding-top: 4px;
  position: relative;
  margin-bottom: 20px;
}
.infoList-deliverly li span {
  position: absolute;
  left: 0;
  top: 50%;
  transform: translateY(-50%);
  width: 30px;
  display: inline-block;
  vertical-align: middle;
}
</style>
