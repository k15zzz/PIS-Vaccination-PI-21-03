<script setup>
import Block from "../components/ui/Block.vue";
import {onBeforeMount} from "vue";
import InputText from "../components/ui/InputText.vue";
import Multiselect from "vue-multiselect";
import AppButton from "../components/ui/AppButton.vue";
import AppTextarea from "../components/ui/AppTextarea.vue";
import InputCheckbox from "../components/ui/InputCheckbox.vue";
import {useRoute} from "vue-router";
import {VaccinationController} from "../controller/VaccinationController.js";

const route = useRoute()

const controller = new VaccinationController(route.meta.mode, route.params.id);
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="registry">
    <router-link :to="controller.backLink"> Вернуться назад </router-link>
    <h3>Форма вакцинации</h3>
    <input-text
        label="Тип вакцины"
        v-model="controller.value.type"
        :disabled="controller.disableStatus()"
    />
    <div>
      <label>Дата вакцинации</label>
      <input
          type="datetime-local"
          v-model="controller.value.date"
          :disabled="controller.disableStatus()"
      />
    </div>
    <input-text
        label="Номер серии"
        v-model="controller.value.numOfSeries"
        :disabled="controller.disableStatus()"
    />
    <div>
      <label>Действительность вакцины</label>
      <input
          type="datetime-local"
          v-model="controller.value.dateOfExpire"
          :disabled="controller.disableStatus()"
      />
    </div>
    <input-text
        label="Должность ветеринарного специалиста"
        v-model="controller.value.positionOfDoc"
        :disabled="controller.disableStatus()"
    />
    <div>
      <label>Организация</label>
      <multiselect
          v-if="controller.organizationList.length > 0"
          v-model="controller.value.org"
          :options="controller.organizationList"
          :multiple="false"
          :close-on-select="true"
          placeholder="Выберите тип"
          :preselect-first="true"
          label="fullName"
          :disabled="controller.disableStatus()"

      >
        <template slot="selection" slot-scope="{ values, search, isOpen }">
                            <span class="multiselect__single" v-if="values.length" v-show="!isOpen">
                                {{ values.length }} options selected
                            </span>
        </template>
      </multiselect>
    </div>
    <div>
      <label>Контракт</label>
      <multiselect
          v-if="controller.contractList.length > 0"
          v-model="controller.value.contract"
          :options="controller.contractList"
          :multiple="false"
          :close-on-select="true"
          placeholder="Выберите тип"
          :preselect-first="true"
          label="number"
          :disabled="controller.disableStatus()"

      >
        <template slot="selection" slot-scope="{ values, search, isOpen }">
                            <span class="multiselect__single" v-if="values.length" v-show="!isOpen">
                                {{ values.length }} options selected
                            </span>
        </template>
      </multiselect>
    </div>
    <div>
      <label>Животное</label>
      <multiselect
          v-if="controller.animalList.length > 0"
          v-model="controller.value.animal"
          :options="controller.animalList"
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
        @click="controller.sendData()"
        v-if="!controller.disableStatus()"
        class="registry__button--green"
    >
      Отправить
    </app-button>
  </block>
</template>

<style lang="less">
.registry {
  display: grid;
  gap: 15px;

  .registry__group-fields {
    display: grid;
    grid-template-columns: 1fr 1fr;
  }
  .registry__button--green {
    background: var(--color-green);
  }
}
</style>