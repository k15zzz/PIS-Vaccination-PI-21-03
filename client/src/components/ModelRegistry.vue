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
            <svg
                v-if="PermissionService.can(model.getPermission('read'))"
                @click="router.push({name: model.getRouterAction('read'), params:{ id: value.id }})"
                width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" clip-rule="evenodd" d="M1.78395 10C1.87503 10.1574 1.99577 10.358 2.14535 10.5896C2.52953 11.1844 3.09847 11.9755 3.83711 12.7634C5.3296 14.3554 7.41626 15.8333 10 15.8333C12.5837 15.8333 14.6704 14.3554 16.1629 12.7634C16.9015 11.9755 17.4705 11.1844 17.8547 10.5896C18.0042 10.358 18.125 10.1574 18.216 10C18.125 9.84261 18.0042 9.64204 17.8547 9.41044C17.4705 8.81557 16.9015 8.0245 16.1629 7.23662C14.6704 5.64463 12.5837 4.16667 10 4.16667C7.41626 4.16667 5.3296 5.64463 3.83711 7.23662C3.09847 8.0245 2.52953 8.81557 2.14535 9.41044C1.99577 9.64204 1.87503 9.84261 1.78395 10ZM19.1667 10C19.912 9.62732 19.9119 9.62704 19.9117 9.62673L19.9104 9.62406L19.9075 9.61837L19.8981 9.59985C19.8901 9.58439 19.8789 9.56276 19.8644 9.53537C19.8354 9.48058 19.7933 9.40269 19.7384 9.30499C19.6285 9.1097 19.4668 8.8346 19.2547 8.50623C18.8316 7.85109 18.2026 6.9755 17.3788 6.09672C15.7463 4.35537 13.2496 2.5 10 2.5C6.75041 2.5 4.25373 4.35537 2.62122 6.09672C1.79736 6.9755 1.16839 7.85109 0.74528 8.50623C0.533208 8.8346 0.371493 9.1097 0.261643 9.30499C0.206686 9.40269 0.164617 9.48058 0.135628 9.53537C0.121131 9.56276 0.109896 9.58439 0.101948 9.59985L0.0924917 9.61837L0.0896158 9.62406L0.0886417 9.626C0.0884886 9.6263 0.0879773 9.62732 0.833333 10L0.0879773 9.62732C-0.0293258 9.86193 -0.0293258 10.1381 0.0879773 10.3727L0.833333 10C0.0879773 10.3727 0.0878242 10.3724 0.0879773 10.3727L0.0896158 10.3759L0.0924917 10.3816L0.101948 10.4001C0.109896 10.4156 0.121131 10.4372 0.135628 10.4646C0.164617 10.5194 0.206686 10.5973 0.261643 10.695C0.371493 10.8903 0.533208 11.1654 0.74528 11.4938C1.16839 12.1489 1.79736 13.0245 2.62122 13.9033C4.25373 15.6446 6.75041 17.5 10 17.5C13.2496 17.5 15.7463 15.6446 17.3788 13.9033C18.2026 13.0245 18.8316 12.1489 19.2547 11.4938C19.4668 11.1654 19.6285 10.8903 19.7384 10.695C19.7933 10.5973 19.8354 10.5194 19.8644 10.4646C19.8789 10.4372 19.8901 10.4156 19.8981 10.4001L19.9075 10.3816L19.9104 10.3759L19.9114 10.374C19.9115 10.3737 19.912 10.3727 19.1667 10ZM19.1667 10L19.912 10.3727C20.0293 10.1381 20.029 9.86134 19.9117 9.62673L19.1667 10Z" fill="#52616B"/>
              <path fill-rule="evenodd" clip-rule="evenodd" d="M9.99984 8.33341C9.07936 8.33341 8.33317 9.07961 8.33317 10.0001C8.33317 10.9206 9.07936 11.6667 9.99984 11.6667C10.9203 11.6667 11.6665 10.9206 11.6665 10.0001C11.6665 9.07961 10.9203 8.33341 9.99984 8.33341ZM6.6665 10.0001C6.6665 8.15913 8.15889 6.66675 9.99984 6.66675C11.8408 6.66675 13.3332 8.15913 13.3332 10.0001C13.3332 11.841 11.8408 13.3334 9.99984 13.3334C8.15889 13.3334 6.6665 11.841 6.6665 10.0001Z" fill="#52616B"/>
            </svg>
            <svg
                v-if="PermissionService.can(model.getPermission('update'))"
                @click="router.push({name: model.getRouterAction('update'), params:{ id: value.id }})"
                width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" clip-rule="evenodd" d="M3.3335 4.16667C3.11248 4.16667 2.90052 4.25446 2.74424 4.41074C2.58796 4.56702 2.50016 4.77899 2.50016 5V16.6667C2.50016 16.8877 2.58796 17.0996 2.74424 17.2559C2.90052 17.4122 3.11248 17.5 3.3335 17.5H15.0002C15.2212 17.5 15.4331 17.4122 15.5894 17.2559C15.7457 17.0996 15.8335 16.8877 15.8335 16.6667V12.2167C15.8335 11.7564 16.2066 11.3833 16.6668 11.3833C17.1271 11.3833 17.5002 11.7564 17.5002 12.2167V16.6667C17.5002 17.3297 17.2368 17.9656 16.7679 18.4344C16.2991 18.9033 15.6632 19.1667 15.0002 19.1667H3.3335C2.67045 19.1667 2.03457 18.9033 1.56573 18.4344C1.09689 17.9656 0.833496 17.3297 0.833496 16.6667V5C0.833496 4.33696 1.09689 3.70107 1.56573 3.23223C2.03457 2.76339 2.67045 2.5 3.3335 2.5H7.7835C8.24373 2.5 8.61683 2.8731 8.61683 3.33333C8.61683 3.79357 8.24373 4.16667 7.7835 4.16667H3.3335Z" fill="#52616B"/>
              <path fill-rule="evenodd" clip-rule="evenodd" d="M14.4109 1.07733C14.7363 0.751893 15.264 0.751893 15.5894 1.07733L18.9228 4.41066C19.2482 4.7361 19.2482 5.26374 18.9228 5.58917L10.5894 13.9225C10.4331 14.0788 10.2212 14.1666 10.0002 14.1666H6.66683C6.20659 14.1666 5.8335 13.7935 5.8335 13.3333V9.99992C5.8335 9.7789 5.92129 9.56694 6.07757 9.41066L14.4109 1.07733ZM7.50016 10.3451V12.4999H9.65498L17.155 4.99992L15.0002 2.8451L7.50016 10.3451Z" fill="#52616B"/>
            </svg>
            <svg
                v-if="PermissionService.can(model.getPermission('delete'))"
                @click="router.push({name: model.getRouterAction('delete'), params:{ id: value.id }})"
                width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" clip-rule="evenodd" d="M5.68887 1.69576C5.83754 0.803717 6.60934 0.149902 7.5137 0.149902H12.4861C13.3905 0.149902 14.1623 0.803716 14.3109 1.69576L14.72 4.1499H17.9999C18.4693 4.1499 18.8499 4.53046 18.8499 4.9999C18.8499 5.46934 18.4693 5.8499 17.9999 5.8499H16.7914L15.9141 18.1317C15.8449 19.0998 15.0394 19.8499 14.0688 19.8499H5.93102C4.96044 19.8499 4.15487 19.0998 4.08572 18.1317L3.20845 5.8499H1.9999C1.53046 5.8499 1.1499 5.46934 1.1499 4.9999C1.1499 4.53046 1.53046 4.1499 1.9999 4.1499H5.27984L5.68887 1.69576ZM7.00329 4.1499H12.9965L12.6341 1.97524C12.622 1.90292 12.5594 1.8499 12.4861 1.8499H7.5137C7.44037 1.8499 7.37779 1.90291 7.36574 1.97524L7.00329 4.1499ZM4.91278 5.8499L5.7814 18.0106C5.78701 18.0891 5.85233 18.1499 5.93102 18.1499H14.0688C14.1475 18.1499 14.2128 18.0891 14.2184 18.0106L15.087 5.8499H4.91278ZM7.9999 7.1499C8.46934 7.1499 8.8499 7.53046 8.8499 7.9999V14.9999C8.8499 15.4693 8.46934 15.8499 7.9999 15.8499C7.53046 15.8499 7.1499 15.4693 7.1499 14.9999V7.9999C7.1499 7.53046 7.53046 7.1499 7.9999 7.1499ZM11.9999 7.1499C12.4693 7.1499 12.8499 7.53046 12.8499 7.9999V14.9999C12.8499 15.4693 12.4693 15.8499 11.9999 15.8499C11.5305 15.8499 11.1499 15.4693 11.1499 14.9999V7.9999C11.1499 7.53046 11.5305 7.1499 11.9999 7.1499Z" fill="#52616B"/>
            </svg>
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
          }
        }
      }
      .reg-table-row__actions {
        display: grid;
        gap: 25px;
        .reg-table-row__action {
          display: grid;
          grid-template-columns: 1fr 1fr 1fr;
          gap: 10px;
          justify-items: center;
          svg {
            cursor: pointer;
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