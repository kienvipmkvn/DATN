import { createApp } from 'vue'
import App from './App.vue'
import router from './routes';
import clickOutside from './store/clickOutside';
import { createVuetify } from 'vuetify'
import 'vuetify/dist/vuetify.css'
import 'mdb-vue-ui-kit/css/mdb.min.css';
import store from './store';
import MLoadding from '@/components/loadding/MLoadding.vue'

const app = createApp(App);
const vuetify = createVuetify({})
app.directive('click-outside', clickOutside);
app.config.globalProperties.$state = store.state;
app.component("MLoadding",MLoadding);
app.use(router);
app.use(vuetify)
app.mount('#app')
