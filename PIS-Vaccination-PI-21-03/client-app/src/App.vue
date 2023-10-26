<script setup>
import { RouterLink, RouterView } from 'vue-router';
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";
import DefaultLayouts from "./layouts/DefaultLayouts.vue";
import {PermissionService} from "./services/PermissionService.js";
</script>

<template>
  <app-header v-if="PermissionService.isAuth()"/>
  <default-layouts>
    <RouterView></RouterView>
  </default-layouts>
  <app-footer v-if="PermissionService.isAuth()"/>
</template>

<style>
@import url("./assets/main.less");
</style>
