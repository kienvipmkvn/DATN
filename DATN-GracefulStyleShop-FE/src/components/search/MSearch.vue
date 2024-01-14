<template>
  <div class="m-search" v-if="$state.isSearch">
    <div class="m-search-body">
      <div class="logo">
        <a href="/"><img src="@/assets/img/logo.png" alt="" /></a>
      </div>
      <div class="m-search-input">
        <m-input
          placeholder="Tìm kiếm theo tên sản phẩm"
          @change-input="searchData"
        />
        <h6 v-if="products.length == 0">Gợi ý sản phẩm</h6>
        <div class="list-product-saerch">
          <m-search-item
            v-for="(product, index) in products"
            :key="index"
            :item="product"
          />
        </div>
        <h6
          class="total-product"
          v-if="products.length != 0"
          @click="goToProductsAll"
        >
          Xem thêm {{ totalProduct }} sản phẩm
        </h6>
      </div>
      <div class="logo">
        <a style="opacity: 0" href="/"
          ><img src="@/assets/img/logo.png" alt=""
        /></a>
      </div>
      <div
        @click="$state.isSearch = false"
        class="close-search icon-close-big"
      ></div>
    </div>
  </div>
</template>
<script>
import baseApi from "@/api/baseApi";
import MInput from "../input/MInput.vue";
import MSearchItem from "./MSearchItem.vue";
export default {
  components: {
    MInput,
    MSearchItem,
  },
  data() {
    return {
      textSearch: "",
      products: [],
      totalProduct: 0,
    };
  },
  methods: {
    async searchData(event) {
      try {
        if (this.timeout) clearTimeout(this.timeout);
        // Xét thời gian tìm kiếm 0,5s
        this.timeout = setTimeout(async () => {
          this.textSearch = event.target.value || "";
          await this.getData();
        }, 500); // delay
      } catch (error) {
        console.log("Lỗi search data : ", error);
      }
    },
    async getData() {
      if (this.textSearch) {
        const res = await new baseApi("Product").getByFilterDetail({
          TextSearch: this.textSearch,
          PageNumber: 1,
          PageSize: 5,
        });
        this.products = res.Data;
        this.totalProduct = res.Total;
      } else {
        this.products = [];
      }
    },
    goToProductsAll() {
      this.$state.isSearch = false;
      this.$router.push("/products");
    },
  },
};
</script>
<style scoped>
.m-search {
  background: rgba(106, 105, 105, 0.323);
  width: 100%;
  position: fixed;
  top: 0;
  left: 0;
  height: 100vh;
  z-index: 10;
}
.m-search-body {
  background-color: white;
  width: calc(100% - var(--padding-beside) * 2);
  margin: 0 auto;
  padding: 0 32px 32px 32px;
  border-radius: 0 0 8px 8px;
  display: flex;
  justify-content: space-between;
  position: relative;
}
.m-search-input {
  width: 100%;
  flex-basis: 60%;
}
.m-search-input > h6 {
  text-align: center;
}
.list-product-saerch {
  max-height: 500px;
  overflow-y: auto;
}
.logo {
  flex-basis: 20%;
}
.logo img {
  width: 100%;
  -o-object-fit: cover;
  object-fit: cover;
  height: auto;
  margin-top: 14px;
  right: 16px;
  position: relative;
}
.close-search {
  position: absolute;
  right: 20px;
  top: 31px;
  padding: 4px;
}
.total-product {
  text-align: center;
  cursor: pointer;
}
</style>
