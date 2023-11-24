<script setup>
import {informerStores} from "../stores/informerStores.js";

const iStores = informerStores();
</script>

<template>
  <div v-if="iStores.get" class="informer__container" :class="iStores.type">
    {{ iStores.get }}
    <span @click="iStores.remove()" class="informer-con__close">
      <svg width="14" height="14" viewBox="0 0 14 14" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M13.717 1.69702L12.303 0.28302L6.99999 5.58602L1.69699 0.28302L0.28299 1.69702L5.58599 7.00002L0.28299 12.303L1.69699 13.717L6.99999 8.41402L12.303 13.717L13.717 12.303L8.41399 7.00002L13.717 1.69702Z" fill="white"/>
      </svg>
    </span>
  </div>
</template>

<style lang="less" scoped>
.informer__container {
  color: white;
  text-align: center;
  padding: 15px;
  .informer-con__close {
    padding-left: 20px;
    cursor: pointer;
  }
}
.--error {
  background: var(--color-danger);
}
.--info {
  background: var(--color-primary);
}
</style>