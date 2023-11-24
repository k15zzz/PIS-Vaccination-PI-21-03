<script setup>
import Block from "../components/ui/Block.vue";
import ModelRegistry from "../components/ModelRegistry.vue";
import {onBeforeMount, reactive} from "vue";
import {AnimalRepository} from "../repositorys/AnimalRepository.js";
import {AnimalModel} from "../models/AnimalModel.js";

let models = reactive([])

onBeforeMount(async () => {
  Object.assign(models, await AnimalRepository.list());
});
</script>

<template> 
  <block class="registry">
    <model-registry 
        :models="models"
        :model="AnimalModel"
        router-create="animalCreate"
        title="Реестр животных"
    />
  </block>
</template>

<style scoped lang="less"></style>