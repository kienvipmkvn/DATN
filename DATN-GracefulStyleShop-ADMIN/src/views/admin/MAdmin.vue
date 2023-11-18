<template>
    <div class="m-admin">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import AdminConfig from "@/views/admin/AdminConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MAdmin",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new AdminConfig()
        }
    },
}
</script>
<style scoped>
</style>