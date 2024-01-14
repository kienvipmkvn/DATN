<template>
  <div class="product-all">
    <div class="filter-product">
      <div class="filter-search">
        <label for="">Tìm kiếm : </label>
        <MInput placeholder="Tim kiếm theo tên sản phẩm" />
      </div>
      <div class="filter-cbb">
        <div class="filter-cbb-item">
          <label for="">Thương hiệu : </label>
          <MCombobox v-model="brandId" propName="BrandName" propValue="BrandId" marginBottom="28px" :data="brands" />
        </div>
        <div class="filter-cbb-item">
          <label for="">Loại : </label>
          <MCombobox v-model="typeId" propName="TypeName" propValue="TypeId" marginBottom="28px" :data="types" />
        </div>
      </div>
    </div>
    <!-- <m-combobox-muti /> -->
    <div class="list-products">
      <product-card
        padding="0 16px"
        v-for="(product, index) in products"
        :item="product"
        :key="index"
      />
    </div>
    <div class="btn-add-product">
      <v-btn
        color="blue-grey"
        class="btn-view-products"
        @click="load()"
      >
        Xem thêm sản phẩm
      </v-btn>
    </div>
  </div>
</template>
<script>
import baseApi from "@/api/baseApi";
import ProductCard from "@/components/ProductCard.vue";
import { VBtn } from "vuetify/lib/components";
import MInput from "@/components/input/MInput.vue";
import MCombobox from "@/components/combobox/MCombobox.vue";
export default {
  components: {
    ProductCard,
    VBtn,
    MInput,
    MCombobox,
  },
  created: async function () {
    try {
      let res = await new baseApi("Product").getByFilterDetail({});
      this.products = res.Data;
      res = await new baseApi("Type").getByFilter({});
      this.types = res.Data;
      res = await new baseApi("Brand").getByFilter({});
      this.brands = res.Data;
    } catch (error) {
      console.log(error);
    }
  },
  data() {
    return {
      products: [],
      numberPage: 1,
      types: [],
      brands: [],
      typeId : "",
      brandId : ""
    };
  },
  methods: {
    async load() {
      try {
        this.numberPage = this.numberPage + 1;

        const res = await new baseApi("Product").getByFilterDetail({
          PageNumber: this.numberPage,
        });
        if (res.Data.length > 0) {
          this.products.push(...res.Data);
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
  watch:{
    typeId: async function(){
      let res = await new baseApi("Product").getByFilterDetail({
        TypeId : this.typeId,
        BrandId : this.brandId,
      });
      this.products = res.Data;
    },
    brandId: async function(){
      let res = await new baseApi("Product").getByFilterDetail({
        BrandId : this.brandId,
        TypeId : this.typeId,
      });
      this.products = res.Data;
    }

  }
};
</script>
<style scoped>
.product-all {
  margin-top: 70px !important;
  background-color: white;
}
.list-products {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  padding: 0 24px;
}
.btn-add-product {
  text-align: center;
  padding: 12px 0;
}
.filter-product {
  display: flex;
  justify-content: space-between;
  padding: 0 24px;
}
.filter-search {
  margin-top: 4px;
  flex-basis: 40%;
  display: flex;
  align-items: center;
}
.filter-search label{
  min-width: max-content;
  margin-right: 12px;
}
.filter-cbb{
  display: flex;
  flex-basis: 60%;
  justify-content: flex-end;
}
.filter-cbb-item{
  display: flex;
  align-items: center;
  width: max-content;
  padding-left: 32px;
}
.filter-cbb-item label{
  min-width: max-content;
  margin-right: 12px;
}
</style>
