<script setup>
import AppButton from "../components/ui/AppButton.vue";
import {PermissionService} from "../services/PermissionService.js";
import {useRouter} from "vue-router";
const router = useRouter();

defineProps({
  models: Array,
  model: Function,
  title: String,
  routerCreate: String,
});
</script>

<template>
  <div class="registry">
    <h1>
      {{ title }}
    </h1>
    <div class="reg__header">
      <div class="reg-head__filter">
        Фильтр
      </div>
      <router-link
          :to="{ name: routerCreate }"
          class="reg-head__add"
      >
        Добавить
      </router-link>
    </div>
    <div class="reg__table">
      <div class="reg-table__row">
        <div class="reg-table-row__info">
          <div class="reg-table__row_">
            <div class="reg-table-row__columns">
              <div v-for="column in model.getParams()" class="reg-t-row__column">
                <span>{{model.getTitle(column)}}</span>
              </div>
            </div>
          </div>
          <div v-for="value in models" class="reg-table__row_">
            <div class="reg-table-row__columns">
              <div v-for="column in model.getParams()" class="reg-t-row__column">
                <span>{{value.getValue(column)}}</span>
              </div>
            </div>
          </div>
        </div>
        <div class="reg-table-row__actions">
          <div class="reg-table-row__action"></div>
          <div v-for="value in models" class="reg-table-row__action">
            <app-button
                class="__read"
                v-if="PermissionService.can(model.getPermission('read'))"
                @click="router.push({name: model.getRouterAction('read'), params:{ id: value.id }})"
            >
              Посмотреть
            </app-button>
            <app-button
                class="__update"
                v-if="PermissionService.can(model.getPermission('update'))"
                @click="router.push({name: model.getRouterAction('update'), params:{ id: value.id }})"
            >
              Редактировать
            </app-button>
            <app-button
                class="__del"
                v-if="PermissionService.can(model.getPermission('delete'))"
                @click="router.push({name: model.getRouterAction('delete'), params:{ id: value.id }})"
            >
              Удалить
            </app-button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="less">
.registry {
  .reg__header {
    display: grid;
    grid-template-columns: 1fr 100px;
    .reg-head__add {
      background: var(--color-green);
      color: white;
      padding: 10px;
      border-radius: 10px;
      display: grid;
      justify-items: center;
      align-items: center;
    }
  }
  .reg__table {
    display: grid;
    .reg-table__row {
      display: grid;
      grid-template-columns: 1fr 150px;
      .reg-table-row__info {
        overflow-y: auto;
        display: grid;
        gap: 25px;
        .reg-table-row__columns {
          display: grid;
          grid-auto-flow: column;
          gap: 20px;
          .reg-t-row__column {
            width: 100px;
            height: 150px;
          }
        }
      }
      .reg-table-row__actions {
        display: grid;
        gap: 25px;
        .reg-table-row__action {
          display: grid;
          gap: 10px;
          height: 150px;
          button {
            width: 100%;
          }
          .__del {
            background: var(--color-danger);
          }
          .__read {
            background: var(--color-primary);
          }
          .__update {
            background: var(--color-primary);
          }
        }
      }
    }
  }
}
</style>