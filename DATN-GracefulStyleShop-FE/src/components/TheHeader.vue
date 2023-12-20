<template>
  <header class="header" v-if="$state.isHeaderAndFooterShow">
    <div class="logo">
      <a href="/"><img src="@/assets/img/logo.png" alt="" /></a>
    </div>
    <div class="menu">
      <li class="menu-item">
        <router-link class="link" to="/">
          Trang chủ
        </router-link>
      </li>
      <li class="menu-item">      
        <router-link class="link" to="/products">
          Sản phẩm
        </router-link>
      </li>
    </div>
    <div class="action">
      <div class="search" @click="$state.isSearch = true">
        <div class="icon icon-search"></div>
      </div>
      <div class="action_setting">
        <div
          class="hd-icon"
          @click="this.$state.isShowLogin = !this.$state.isShowLogin"
          ref="hdIcon"
          v-if="!$state.user"
        >
          <svg class="svg-ico-account" viewBox="0 0 1024 1024">
            <path
              class="path1"
              d="M486.4 563.2c-155.275 0-281.6-126.325-281.6-281.6s126.325-281.6 281.6-281.6 281.6 126.325 281.6 281.6-126.325 281.6-281.6 281.6zM486.4 51.2c-127.043 0-230.4 103.357-230.4 230.4s103.357 230.4 230.4 230.4c127.042 0 230.4-103.357 230.4-230.4s-103.358-230.4-230.4-230.4z"
            ></path>
            <path
              class="path2"
              d="M896 1024h-819.2c-42.347 0-76.8-34.451-76.8-76.8 0-3.485 0.712-86.285 62.72-168.96 36.094-48.126 85.514-86.36 146.883-113.634 74.957-33.314 168.085-50.206 276.797-50.206 108.71 0 201.838 16.893 276.797 50.206 61.37 27.275 110.789 65.507 146.883 113.634 62.008 82.675 62.72 165.475 62.72 168.96 0 42.349-34.451 76.8-76.8 76.8zM486.4 665.6c-178.52 0-310.267 48.789-381 141.093-53.011 69.174-54.195 139.904-54.2 140.61 0 14.013 11.485 25.498 25.6 25.498h819.2c14.115 0 25.6-11.485 25.6-25.6-0.006-0.603-1.189-71.333-54.198-140.507-70.734-92.304-202.483-141.093-381.002-141.093z"
            ></path>
          </svg>
        </div>
        <div class="account-user-login">
          <div
            class="account"
            ref="accountUser"
            @click="this.$state.isShowLogin = !this.$state.isShowLogin"
            v-if="!$state.user"
          >
            Tài khoản
          </div>
          <div
            class="account-user"
            v-if="$state.user"
            @click="isShowSettingUser = !isShowSettingUser"
            ref="accountUser"
          >
            {{ $state.user.FullName }}
            <div class="icon-drop"></div>
          </div>
          <div
            class="header-action_dropdown"
            v-if="isShowSettingUser"
            v-click-outside="clickOutSideInfoUser"
          >
            <div class="header-dropdown_content">
              <div class="site_account_panel_list">
                <div class="site_account_info">
                  <div class="site_account_header">
                    <p class="txt-title">Thông tin tài khoản</p>
                  </div>
                  <div class="site_account_inner">
                    <ul>
                      <li>
                        <router-link class="link" to="/account/profile">
                            Tài khoản của tôi
                          </router-link>
                      </li>
                      <li @click="goToOrder">
                        <a>Đơn hàng đã đặt</a>
                      </li>
                      <li><a @click="logout">Đăng xuất</a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <site-account
          v-model="this.$state.isShowLogin"
          @click-outside="clickOutSideSideAccount"
        />
      </div>
      <div class="cart-icon-view">
        <div
          class="action_cart"
          ref="cartView"
          @click="isShowCartView = !isShowCartView"
          @dblclick="$router.push('/cart')"
        >
          <div class="hd-icon">
            <svg
              class="svg-ico-cart"
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 -13 456.75885 456"
              width="456pt"
            >
              <path
                d="m150.355469 322.332031c-30.046875 0-54.402344 24.355469-54.402344 54.402344 0 30.042969 24.355469 54.398437 54.402344 54.398437 30.042969 0 54.398437-24.355468 54.398437-54.398437-.03125-30.03125-24.367187-54.371094-54.398437-54.402344zm0 88.800781c-19 0-34.402344-15.402343-34.402344-34.398437 0-19 15.402344-34.402344 34.402344-34.402344 18.996093 0 34.398437 15.402344 34.398437 34.402344 0 18.996094-15.402344 34.398437-34.398437 34.398437zm0 0"
              ></path>
              <path
                d="m446.855469 94.035156h-353.101563l-7.199218-40.300781c-4.4375-24.808594-23.882813-44.214844-48.699219-48.601563l-26.101563-4.597656c-5.441406-.96875-10.632812 2.660156-11.601562 8.097656-.964844 5.441407 2.660156 10.632813 8.101562 11.601563l26.199219 4.597656c16.53125 2.929688 29.472656 15.871094 32.402344 32.402344l35.398437 199.699219c4.179688 23.894531 24.941406 41.324218 49.199219 41.300781h210c22.0625.066406 41.546875-14.375 47.902344-35.5l47-155.800781c.871093-3.039063.320312-6.3125-1.5-8.898438-1.902344-2.503906-4.859375-3.980468-8-4zm-56.601563 162.796875c-3.773437 12.6875-15.464844 21.367188-28.699218 21.300781h-210c-14.566407.039063-27.035157-10.441406-29.5-24.800781l-24.699219-139.398437h336.097656zm0 0"
              ></path>
              <path
                d="m360.355469 322.332031c-30.046875 0-54.402344 24.355469-54.402344 54.402344 0 30.042969 24.355469 54.398437 54.402344 54.398437 30.042969 0 54.398437-24.355468 54.398437-54.398437-.03125-30.03125-24.367187-54.371094-54.398437-54.402344zm0 88.800781c-19 0-34.402344-15.402343-34.402344-34.398437 0-19 15.402344-34.402344 34.402344-34.402344 18.996093 0 34.398437 15.402344 34.398437 34.402344 0 18.996094-15.402344 34.398437-34.398437 34.398437zm0 0"
              ></path>
            </svg>
            <div class="number-pro" v-if="$state.user">
              {{ $state.cartNumber }}
            </div>
          </div>
          <div class="hd-card">Giỏ hàng</div>
        </div>
        <div
          class="cart-view"
          v-if="isShowCartView && $state.user"
          v-click-outside="clickOutSideCartView"
        >
          <h1>Giỏ hàng</h1>
          <div class="cart-view-list" v-if="$state.cartNumber != 0">
            <div
              class="cart-view-item"
              v-for="(item, index) in cartView"
              :key="index"
            >
              <cart-item-view :item="item" />
            </div>
          </div>
          <div class="cart-total-price" v-if="$state.cartNumber != 0">
            <div>TỔNG TIỀN:</div>
            <div>{{ $state.formatPrice(getTotal()) }}</div>
          </div>
          <div class="m__e-list-empty" v-if="$state.cartNumber == 0">
            <img
              src="@/assets/img/bg_report_nodata.76e50bd8.svg"
              alt="Không có dữ liệu"
            />
            <div>Không có sản phẩm trong giỏ hàng</div>
          </div>
          <m-button
            backgroundColor="#ff0000"
            width="100%"
            @click="rediricCart"
            v-if="$state.cartNumber != 0"
            >Xem giỏ hàng</m-button
          >
        </div>
      </div>
    </div>
  </header>
</template>

<script>
import MButton from "./button/MButton.vue";
import CartItemView from "./Cart/CartItemView.vue";
import SiteAccount from "./SiteAccount.vue";
import authApi from "@/api/authApi";
import baseApi from "@/api/baseApi";
export default {
  name: "TheFooter",
  components: {
    SiteAccount,
    CartItemView,
    MButton,
  },
  data() {
    return {
      isShowSettingUser: false,
      isShowCartView: false,
      cartView: [],
    };
  },
  methods: {
    rediricCart() {
      this.isShowCartView = false;
      this.$router.push("/cart");
    },
    goToOrder() {
      this.isShowSettingUser = false;
      this.$state.tabProfile = 3;
      this.$router.push("/account/profile").then(() => {
        window.scrollTo(0, 0);
      });
    },
    async logout() {
      try {
        var res = await new authApi().signout(localStorage.getItem("token"));
        if (res) {
          localStorage.removeItem("user");
          localStorage.removeItem("token");
          this.isShowSettingUser = false;
          window.location.reload();
          window.location.assign('/');
        }
      } catch (error) {
        console.log(error);
      }
    },
    clickOutSideSideAccount(e) {
      if (
        !this.$refs.accountUser.contains(e.target) &&
        !this.$refs.hdIcon.contains(e.target)
      ) {
        this.$state.isShowLogin = false;
      }
    },
    clickOutSideInfoUser(e) {
      if (!this.$refs.accountUser.contains(e.target)) {
        this.isShowSettingUser = false;
      }
    },
    clickOutSideCartView(e) {
      if (!this.$refs.cartView.contains(e.target)) {
        this.isShowCartView = false;
      }
    },
    getTotal() {
      var total = 0;
      (this.cartView ? this.cartView : []).forEach((x) => {
        total += x.TotalPrice;
      });
      return total;
    },
  },
  watch: {
    isShowCartView: async function () {
      if (this.isShowCartView && this.$state.user) {
        const res = await new baseApi("Cart").getByFilter({});
        this.cartView = res.Data;
      }
    },
  },
};
</script>

<style>
.m__e-list-empty {
  text-align: center;
  display: block;
}
.m__e-list-empty img {
  width: 100px;
}
.menu li a {
  color: unset;
}
</style>
