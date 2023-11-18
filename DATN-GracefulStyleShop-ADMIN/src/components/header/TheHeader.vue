<template>
  <div class="m__header">
    <div class="m__header-left">
      <div
        class="m__header-bar"
        :class="toggleSidebar ? 'icon-bar' : ''"
        @click="toggleSidebarChange"
      ></div>
      <div class="m__header-name">
        <div class="m__header-name__content"></div>
        <!-- <div class="m__header-name__icon icon-drop"></div> -->
      </div>
    </div>
    <div class="m__header-right">
      <div
        class="m__header-notification icon-notification"
        data-tip="Tính năng chưa phát triển"
      ></div>
      <div class="m__header-setting">
        <div class="setting__avt" data-tip="Tính năng chưa phát triển">
          <img src="../../assets/img/default-avatar.jpg" alt="avt" />
        </div>
        <div class="setting__profile">
          <div class="setting__info" @click="isShowSettingUser = !isShowSettingUser" >
            <div class="setting__info-name" ref="accountUser">{{ $state.user?.FullName }}</div>
            <div class="setting__info-icon icon-drop" ref="accountUser"></div>
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
                          <a href="/account/profile">Tài khoản của tôi</a>
                        </li>
                        <li><a @click="logout">Đăng xuất</a></li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import authApi from "@/api/authApi";
export default {
  name: "TheHeader",
  emits: ["toggle-sidebar"],
  data() {
    return {
      toggleSidebar: true,
      isShowSettingUser: false,
    };
  },
  methods: {
    /**
     * Xử lý thu gọn sidebar
     */
    toggleSidebarChange() {
      this.toggleSidebar = false;
      this.$state.toggleSidebar = false;
    },
    async logout() {
      try {
        var res = await new authApi().signout(localStorage.getItem("token_admin"));
        if (res) {
          localStorage.removeItem("user_admin");
          localStorage.removeItem("token_admin");
          this.isShowSettingUser = false;
          this.$router.push("/auth/signin");
        }
      } catch (error) {
        console.log(error);
      }
    },
    clickOutSideInfoUser(e) {
      if (!this.$refs.accountUser.contains(e.target)) {
        this.isShowSettingUser = false;
      }
    },
  },
  /**
   * Theo dõi sự thay đổi đóng mở của sidebar
   
   */
  watch: {
    "$state.toggleSidebar": function () {
      this.toggleSidebar = this.$state.toggleSidebar;
    },
  },
};
</script>
<style scoped>
@import url(./header.css);
</style>
