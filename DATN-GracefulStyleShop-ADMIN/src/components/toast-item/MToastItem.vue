<template>
  <div class="m-toast-msg-item">
    <div class="m-toast-content">
      <div class="m-toast-icon" :class="classIcon"></div>
      <div class="m-toast-content-text" >
        <span :style="{ color: colorMsg }" >{{ messageType }}</span> {{ messageContent }}
      </div>
    </div>
    <div class="m-toast-btn">
        <!-- <span>Hoàn tác</span> -->
        <div class="m-toast-icon icon-close" @click="closeItem()"></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MToastItem",
  emits:["close"],
  props: {
    classIcon: {
      type: String,
      default: "",
    },
    messageType: {
      type: String,
      default: "",
    },
    messageContent: {
      type: String,
      default: "",
    },
    colorMsg: {
      type: String,
      default: "icon-success-small",
    },
    show : {
      type : Boolean,
      default :false
    }
  },
  methods: {
    /**
     * Hủy toast mesage
     */
    closeItem(){
      this.$emit("close");
    }
  }
};
</script>
<style scoped>
@import url(./toast-item.css);
</style>
