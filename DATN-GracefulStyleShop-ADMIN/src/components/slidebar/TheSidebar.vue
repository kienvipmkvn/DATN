<template>
  <div class="sidebar-menu" :class="toggleSidebar ? '' : 'm-menu-collapse'">
    <div class="sidebar__header">
      <div
        class="sidebar__header-icon__dots"
        @click="toggleSidebarChange"
        :class="toggleSidebar ? 'icon-dots' : 'icon-bar-white'"
      ></div>
      <div class="sidebar__header-brand__logo">
        <img
          src="@/assets/img/logo.png"
          alt="logo"
        />
      </div>
    </div>
    <div class="m-menu">
      <div class="m-menu__list">
        <router-link
          :to="`${item.path}`"
          v-for="(item, index) in listMenuItem"
          :key="index"
          class="m-menu__list-item-link"
        >
          <li
            class="m-menu__list-item"
            :class="$state.nameTable == item.name ? 'active' : ''"
            :key="index"
            @click="activeItem(index)"
            :style="{display :  (item.name != 'Admin'|| $state.user?.IsBoss) ? '' : 'none'}"
          >
            <div class="m-menu__list-item-icon" :class="item.classIcon"></div>
            <div class="m-menu__list-item-title menu-item-text">
              {{ item.text }}
            </div>
          </li>
        </router-link>
      </div>
    </div>
  </div>
</template>
<script>
import constants from "../../assets/js/constants";
export default {
  name: "TheSidebar",
  data() {
    return {
      isActive: null,
      listMenuItem: constants.SidebarMenu,
      itemActive: 0,
      toggleSidebar: true,
    };
  },
  methods: {
    /**
     * Xử lý active item sidebar
     
     */
    activeItem(index) {
      this.itemActive = index;
    },
    /**
     * Xử lý mở rộng side bar
     
     */
    toggleSidebarChange() {
      if (!this.toggleSidebar) {
        this.$state.toggleSidebar = true;
        this.toggleSidebar = true;
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
@import url(./sidebar.css);
</style>
