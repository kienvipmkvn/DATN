<template>
  <div class="page__number">
    <paginate
      :page-count="pageCount"
      :page-range="pageRange"
      :margin-pages="marginPages"
      :click-handler="eventHandlePaginate"
      :prev-text="prevText"
      :next-text="nextText"
      :container-class="containerClass"
      :page-class="pageClass"
      v-model="page"
    >
    </paginate>
  </div>
</template>
<script>
import Paginate from "vuejs-paginate-next";
export default {
  name: "MPaginate",
  emits:["change"],
  components: {
    Paginate,
  },
  props: {
    pageCount: {
      type: Number,
      default: 20,
    },
    pageRange: {
      type: Number,
      default: 3,
    },
    marginPages: {
      type: Number,
      default: 1,
    },
    prevText: {
      type: String,
      default: "Trước",
    },
    nextText: {
      type: String,
      default: "Sau",
    },
    containerClass: {
      type: String,
      default: "pagination",
    },
    pageClass: {
      type: String,
      default: "page-item",
    },
  },
  data() {
    return {
      page : 0
    }
  },
  methods: {
    /**
     * Xử lý khi chọn page
     */
    eventHandlePaginate(pageNumber) {
      this.$emit("change", pageNumber);
    },
  },
  watch:{
    /**
     * Kiểm tra sự thay đổi của pageSize
     */
    pageCount(){
      this.page = 1;
    }
  }
};
</script>
<style scoped>
@import url(./pagination.css);
</style>
