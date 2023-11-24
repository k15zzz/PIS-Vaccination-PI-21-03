<script setup>
import Block from "../components/ui/Block.vue";
import {onBeforeMount, reactive} from "vue";
import InputText from "../components/ui/InputText.vue";
import {OrganizationController} from "../controller/OrganizationController.js";
import InputCheckbox from "../components/ui/InputCheckbox.vue";
import Multiselect from "vue-multiselect";
import AppButton from "../components/ui/AppButton.vue";
import {useRoute} from "vue-router";

const route = useRoute();

const controller = new OrganizationController(route.meta.mode, route.params.id);
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="organization__page">
    <router-link :to="controller.backLink"> Вернуться назад </router-link>
    <h3>Форма организации</h3>
    <input-text
        label="Наименование"
        v-model="controller.value.full_name"
        :disabled="controller.disableStatus()"
    />
    <input-text
        label="ИНН"
        v-model="controller.value.inn"
        :disabled="controller.disableStatus()"
    />
    <input-text
        label="КПП"
        v-model="controller.value.kpp"
        :disabled="controller.disableStatus()"
    />
    <input-text
        label="Адрес"
        v-model="controller.value.address"
        :disabled="controller.disableStatus()"
    />
    <input-text
        label="Тип организации"
        v-model="controller.value.type"
        :disabled="controller.disableStatus()"
    />
    <div>
      <label>ИП</label>
      <input-checkbox
          name="ИП"
          title="ИП?"
          v-model="controller.value.legal_entity"
          :disabled="controller.disableStatus()"
      />
    </div>
    <div>
      <label>Город</label>
      <multiselect
          v-if="controller.townList.length > 0"
          v-model="controller.value.town"
          :options="controller.townList"
          :multiple="false"
          :close-on-select="true"
          placeholder="Выберите тип"
          :preselect-first="true"
          label="name"
          :disabled="controller.disableStatus()"
      >
        <template slot="selection" slot-scope="{ values, search, isOpen }">
                            <span class="multiselect__single" v-if="values.length" v-show="!isOpen">
                                {{ values.length }} options selected
                            </span>
        </template>
      </multiselect>
    </div>
    <app-button 
        v-if="!controller.disableStatus()"
        @click="controller.sendData()" 
        class="organization-page__button--green"
    >
      Отправить
    </app-button>
  </block>
</template>

<style scoped lang="less">
.organization__page {
  display: grid;
  gap: 15px;
  .organization-page__button--green {
    width: 100%;
    background: var(--color-green);
  }
}
</style>