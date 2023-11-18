<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import TypeConfig from "@/views/type/TypeConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MType",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new TypeConfig()
        }
    },
}
</script>
<style scoped>
</style>