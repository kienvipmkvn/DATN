<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import ProductVariantConfig from "@/views/productvariant/ProductVariantConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MProductVariant",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new ProductVariantConfig()
        }
    },
}
</script>
<style scoped>
</style>