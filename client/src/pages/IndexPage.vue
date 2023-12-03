<script setup>
import Block from "../components/ui/Block.vue";
import {PermissionService} from "../services/PermissionService.js";
</script>

<template>
  <block>
    <div class="page-index">
      <div class="pi__navigation">
        <h3 class="pi-navigation__title">
          Вакцинирование животных
        </h3>
        <div class="pi-navigation__items">
          <router-link
              v-if="PermissionService.can('create-statistic')"
              to="/report"
              class="pi-nav-items__item"
          >
            Создать отчет
          </router-link>
          <!-- // TODO: парава на вакцинацию -->
          <router-link
              v-if="PermissionService.can('read-animal')"
              to="/vaccination-registry"
              class="pi-nav-items__item"
          >
            Реестр вакцинаций
          </router-link>
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
          <router-link
              v-if="PermissionService.can('read-log')"
              v-if="PermissionService.can()"
              to="/logs-registry"
              class="pi-nav-items__item"
          >
            Реестр логов
           
          </router-link>
        </div>
      </div>
    </div>
  </block>
</template>

<style scoped lang="less">
.page-index {
  display: grid;
  grid-template-columns: 1fr;
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