<script setup>
import Block from "../components/ui/Block.vue";
import {onBeforeMount} from "vue";
import InputText from "../components/ui/InputText.vue";
import {AnimalController} from "../controller/AnimalController.js";
import Multiselect from "vue-multiselect";
import Datepicker from "../components/ui/datepicker/Datepicker.vue";
import AppButton from "../components/ui/AppButton.vue";
import AppTextarea from "../components/ui/AppTextarea.vue";
import CheckBox from "../components/ui/CheckBox.vue";
import InputCheckbox from "../components/ui/InputCheckbox.vue";
import {useRoute} from "vue-router";

const route = useRoute()

const controller = new AnimalController(route.meta.mode, route.params.id);
onBeforeMount(async () => {
  await controller.load();
});
</script>

<template>
  <block class="registry">
    <router-link :to="controller.backLink"> Вернуться назад </router-link>
    <h3>Форма животного</h3>
    <input-text
        label="Регистрационный номер"
        type="number"
        v-model="controller.value.regNum"
        :disabled="controller.disableStatus()"
    />
    <div>
      <label>Пол</label>
      <input-checkbox 
          name="Пол" 
          title="М/Ж" 
          v-model="controller.value.sex"
          :disabled="controller.disableStatus()"
      />
    </div>
    <div>
      <label>Категория</label>
      <multiselect
          v-if="controller.categoryList.length > 0"
          v-model="controller.value.category"
          :options="controller.categoryList"
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
    <div>
      <label>Дата рождение</label>
      <input
          type="datetime-local"
          v-model="controller.value.yearBirth"
          :disabled="controller.disableStatus()"
      />
    </div>
    <input-text
        label="Номер электронного чипа"
        :disabled="controller.disableStatus()"
        v-model="controller.value.electronicChipNumber"
    />
    <input-text
        label="Кличка"
        :disabled="controller.disableStatus()"
        v-model="controller.value.name"
    />
    <app-textarea
        label="Особые приметы"
        :disabled="controller.disableStatus()"
        v-model="controller.value.specialMarks"
    />
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