<script setup>
import {AuthorizeController} from "../controller/AuthorizeController.js";
import {PermissionService} from "../services/PermissionService.js";
</script>

<template>
  <header>
    <router-link to="/">
      <img src="./../assets/logos/main-logo.svg" alt="" width="30" height="30">
    </router-link>
    <div>
      <router-link
          v-if="PermissionService.can('read-animal')"
          to="/animal-registry"
          class="pi-nav-items__item"
      >
        Реестр животных
      </router-link>
    </div>
    <div>
      <router-link
          v-if="PermissionService.can('read-contract')"
          to="/contact-registry"
          class="pi-nav-items__item"
      >
        Реестр контактов
      </router-link>
    </div>
    <div>
      <router-link
          v-if="PermissionService.can('read-organization')"
          to="/organization-registry"
          class="pi-nav-items__item"
      >
        Реестр организаций
      </router-link>
    </div>
    <div>
      <a @click="AuthorizeController.out()" href="#">Выйти</a>
    </div>
  </header>
</template>

<style lang="less" scoped>
header {
  padding: 20px;
  border-radius: 8px;
  background: var(--bg-default);
  box-shadow: 0 0 30px 0 rgba(0, 0, 0, 0.10);
  backdrop-filter: blur(5px);
  display: flex;
  flex-direction: row;
  gap: 30px;
  justify-content: center;
  align-items: center;
  div {
    a {
      &:hover {
        color: var(--color-primary);
      }
    }
  }
}
</style>