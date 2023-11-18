import { createApp } from 'vue'
import App from './App.vue'
import MToastList from './components/toast-list/MToastList.vue'
import clickOutside from './store/clickOutside';
import router from './router';
import store from './store';
import VueApexCharts from "vue3-apexcharts";
const app = createApp(App);
app.directive('click-outside', clickOutside);
app.use(router);

app.config.globalProperties.$state = store.state;
app.component("MToastList",MToastList);
app.use(VueApexCharts)
// eslint-disable-next-line vue/multi-word-component-names
app.component("apexchart",VueApexCharts);
app.mount('#app')
