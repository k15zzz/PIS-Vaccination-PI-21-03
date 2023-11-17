<script setup>
import AppButton from "../components/ui/AppButton.vue";
import {PermissionService} from "../services/PermissionService.js";

defineProps({
  models: Array,
  model: Function,
});
</script>

<template>
  <div class="registry">
    <h1>
      Реестр животных
    </h1>
    <div class="reg__header">
      <div class="reg-head__filter">
        Фильтр
      </div>
      <app-button 
          class="reg-head__add"
      >
        Добавить
      </app-button>
    </div>
    <div class="reg__table">
      <div class="reg-table__row">
        <div class="reg-table-row__columns">
          <div v-for="column in model.getParams()" class="reg-t-row__column">
            <span>{{model.getTitle(column)}}</span>
          </div>
        </div>
        <div class="reg-table-row__actions"></div>
      </div>
      <div v-for="value in models" class="reg-table__row">
        <div class="reg-table-row__columns">
          <div v-for="column in model.getParams()" class="reg-t-row__column">
            <span>{{value.getValue(column)}}</span>
          </div>
        </div>
        <div class="reg-table-row__actions">
          <app-button
              class="__read"
              v-if="PermissionService.can(model.getPermission('read'))"
          >
            Посмотреть
          </app-button>
          <app-button
              class="__update"
              v-if="PermissionService.can(model.getPermission('update'))"
          >
            Редактировать
          </app-button>
          <app-button
              class="__del"
              v-if="PermissionService.can(model.getPermission('delete'))"
          >
            Удалить
          </app-button>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="less">
.registry {
  .reg__header {
    display: grid;
    grid-template-columns: 1fr 75px;
    .reg-head__add {
      background: var(--color-green);
    }
  }
  .reg__table {
    overflow-y: auto;
    display: grid;
    gap: 15px;
    .reg-table__row {
      display: grid;
      grid-template-columns: 1fr 75px;
      .reg-table-row__columns {
        display: grid;
        grid-auto-flow: column;
        gap: 20px;
        .reg-t-row__column {
          width: 100px;
        }
      }
      .reg-table-row__actions {
        display: grid;
        gap: 10px;
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
</style>