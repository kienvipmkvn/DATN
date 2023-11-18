<template>
    <div class="m-supplier">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import SupplierConfig from "@/views/supplier/SupplierConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MSupplier",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new SupplierConfig()
        }
    },
}
</script>
<style scoped>
</style>