<script setup>
import { RouterLink, RouterView } from 'vue-router';
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";
import DefaultLayouts from "./layouts/DefaultLayouts.vue";
import {PermissionService} from "./services/PermissionService.js";
import AppInformer from "./components/AppInformer.vue";
import {onBeforeMount, reactive} from "vue";

let value = reactive({status: false});

onBeforeMount(async () => {
  value.status = await PermissionService.isAuth();
});
</script>

<template>
  <app-header v-if="value.status"/>
  <app-informer/>
  <default-layouts>
    <RouterView></RouterView>
  </default-layouts>
  <app-footer v-if="value.status"/>
</template>

<style>
@import url("./assets/main.less");
</style>
