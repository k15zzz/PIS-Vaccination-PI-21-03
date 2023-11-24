import { createApp } from 'vue';
import App from './App.vue';
import {createPinia} from "pinia";
import router from "./router/index.js";
import Multiselect from 'vue-multiselect';

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.component('multiselect', Multiselect)

app.mount('#app')
