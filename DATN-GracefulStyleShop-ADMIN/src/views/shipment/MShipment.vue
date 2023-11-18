<template>
    <div class="m-shipment">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import ShipmentConfig from "@/views/shipment/ShipmentConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MShipment",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new ShipmentConfig()
        }
    },
}
</script>
<style scoped>
</style>