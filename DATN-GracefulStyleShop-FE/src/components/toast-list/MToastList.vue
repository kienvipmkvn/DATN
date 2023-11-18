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
  },
  data() {
    return {
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
  }
};
</script>
<style scoped>
@import url(./toast-list.css);
</style>
