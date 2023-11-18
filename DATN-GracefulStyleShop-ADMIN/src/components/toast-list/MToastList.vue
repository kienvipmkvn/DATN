<template>
  <div class="m-toast-list">
    <MToastItem
      v-for="(toast, index) in $state.toastMessage"
      :key="index"
      :messageType="toast.messageType"
      :messageContent="toast.messageContent"
      :colorMsg="toast.colorMsg"
      :classIcon="toast.classIcon"
      @close="closeItem(index)"
    />
  </div>
</template>
<script>
import MToastItem from "../toast-item/MToastItem.vue";
export default {
  name: "MToastList",
  components: {
    MToastItem,
  },
  props:{
    notificationToast : null
  },
  created(){
    this.listToast = this.$state.toastMessage;
  },
  data() {
    return {
      listToast: [],
      listToastItem: [],
    };
  
  },
  methods: {
    /**
     * Close toast message
     */
    closeItem(index){
      this.$state.toastMessage.splice(index, 1);
    }
  },
  watch :{
    /**
     * Bắt sự kiện khi thêm toast message
     */
    '$state.toastMessage'(){
      this.listToast = this.$state.toastMessage;
    },
  }
};
</script>
<style scoped>
@import url(./toast-list.css);
</style>
