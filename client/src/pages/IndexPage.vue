<script setup>
import Block from "../components/ui/Block.vue";
import AppButton from "../components/ui/AppButton.vue";
import CheckBox from "../components/ui/CheckBox.vue";
import {ref} from "vue";
import BuildStatistic from "../components/BuildStatistic.vue";
import {PermissionService} from "../services/PermissionService.js";
</script>

<template>
  <block>
    <div class="page-index">
      <div class="pi__navigation">
        <h3 class="pi-navigation__title">
          Список реестров
        </h3>
        <div class="pi-navigation__items">
          <router-link
              v-if="PermissionService.can('read-animal')"
              to="/animal-registry" 
              class="pi-nav-items__item"
          >
            Реестр животных
          </router-link>
          <router-link
              v-if="PermissionService.can('read-contract')"
              to="/contact-registry" 
              class="pi-nav-items__item"
          >
            Реестр контактов
          </router-link>
          <router-link
              v-if="PermissionService.can('read-organization')"
              to="/organization-registry" 
              class="pi-nav-items__item"
          >
            Реестр организаций
          </router-link>
        </div>
      </div>
      <build-statistic v-if="PermissionService.can('create-statistic')"/>
    </div>
  </block>
</template>

<style scoped lang="less">
.page-index {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 50px;
  .pi__navigation {
    .pi-navigation__title {}
    .pi-navigation__items {
      display: grid;
      gap: 20px;
      .pi-nav-items__item {
        padding: 20px;
        border-radius: 10px;
        color: var(--color-gray);
        border: 1px solid var(--color-secondary-hover);
        text-align: center;
        font-size: 18px;
        &:hover {
          border: 1px solid var(--color-primary-hover);
        }
      }
    }
  }
}
</style>