<template>
  <div v-if="isShow" class="m-pup-up-main">
    <div class="m-pop-up" :style="{ padding: padding, minWidth: minWidth }">
      <header class="m-pop-up__header">
        <slot name="header"></slot>
      </header>
      <main class="m-pop-up__main">
        <slot />
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
  name: "MPopUp",
  emits:["close-pop-up"],
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
    minWidth: String,
    isHeader: Boolean,
    iconCloseClass:{
      type : String,
      default : 'icon-close'
    },
    dataTipIcon: String
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
