<template>
  <div v-if="isShow" class="m-pup-up-main">
    <div class="m-pop-up" :style="{ padding: padding, width: width }">
      <header class="m-pop-up__header">
        <div class="pop-up__title-default">{{titleName}}</div>
      </header>
      <main class="m-pop-up__main">
        <div class="warning__delete-content">
          <div class="warning__delete-icon" :class="iconTitleClass"></div>
          <div class="warning__delete-content-text">
            <slot />
          </div>
        </div>
      </main>
      <footer class="m-pop-up__footer">
        <slot name="footer"></slot>
      </footer>
      <div
        v-if="isIconClose"
        class="m-pop-up-close"
        :class="iconCloseClass"
        :data-tip-icon="dataTipIcon"
        @click="closePopUp"
      ></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MPopUpWarn",
  emits: ["close-pop-up"],
  data() {
    return {};
  },
  props: {
    isShow: Boolean,
    isIconClose: {
      type: Boolean,
      default: true,
    },
    padding: {
      type: String,
      default: "24px",
    },
    width: {
        type: String,
        default: "444px",
    },
    isHeader: Boolean,
    iconCloseClass: {
      type: String,
      default: "icon-close",
    },
    titleName: {
        type: String,
        default: "Thông báo",
    },
    iconTitleClass: {
        type: String,
        default: "icon-warn-big",
    },
    dataTipIcon: String,

  },
  methods: {
    /**
     * Đóng popup
     */
    closePopUp() {
      this.$emit("close-pop-up");
    },
  },
};
</script>
<style scoped>
@import url(./pop-up.css);
</style>
