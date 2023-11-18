<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import ProductConfig from "@/views/product/ProductConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MProduct",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new ProductConfig()
        }
    },
}
</script>
<style scoped>
</style>