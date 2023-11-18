<template>
  <div class="product-detail">
    <div class="folder">
      <FolderRoutes :folderRoutes="folderRoutes" />
    </div>
    <product-item-detail :item="product" />
  </div>
  <div class="product-related">
    <div class="list-product">
      <div class="list-product-title">Sản phẩm liên quan</div>
      <Carousel
        :settings="config.settingsProduct"
        :breakpoints="config.breakpointsProducts"
      >
        <Slide v-for="item,index in config.productRelated" :key="index">
          <product-card @detail="refreshDetail" :item="item" />
        </Slide>
      </Carousel>
    </div>
  </div>
</template>

<script>
import "vue3-carousel/dist/carousel.css";
import { Carousel, Slide } from "vue3-carousel";
import ProductItemDetail from "@/components/ProductItemDetail.vue";
import FolderRoutes from '@/components/FolderRoutes.vue';
import baseApi from '@/api/baseApi';
import config from "@/config";
import ProductCard from '@/components/ProductCard.vue';
export default {
  name: "ProductDetail",
  components: {
    ProductItemDetail,
    FolderRoutes,
    Carousel,
    Slide,
    ProductCard
  },
  created: async function (){
    const id = this.$route.params.id;
    if(id){
      this.product = await new baseApi("Product").getByIdDetail(id);
      const res = await new baseApi("Product").getByFilterDetail({
        TypeId : this.product.TypeId,
        BrandId : this.product.BrandId
      });
      this.config.productRelated = res.Data.filter(x => x.ProductId != this.product.ProductId);
      this.folderRoutes[1].title = this.product ? this.product.ProductName : "";
    }else{
      this.$router.push("/");
    }
  },
  data() {
    return {
      product:{},
      productRelated : [],
      folderRoutes :[
        {
          url: "/",
          title: "Trang chủ / ",
        },
        {
          url: "",
          title: "",
        },
      ],
      config : new config()
    }
  },
  methods:{
    refreshDetail(id){
      // eslint-disable-next-line no-debugger
      debugger
      window.location.replace("/products/"+id);
    }
  }
};
</script>
<style>
.product-detail{
  margin-bottom: 24px;
}
</style>