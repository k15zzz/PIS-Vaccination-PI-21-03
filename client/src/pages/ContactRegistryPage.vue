<script setup>
import Block from "../components/ui/Block.vue";
import ModelRegistry from "../components/ModelRegistry.vue";
import {onBeforeMount, reactive} from "vue";
import {ContractRepository} from "../repositorys/ContractRepository.js";
import {ContractModel} from "../models/ContractModel.js";

let models = reactive([])
onBeforeMount(async () => {
  Object.assign(models, await ContractRepository.list());
});
</script>

<template>
  <block class="registry">
    <model-registry 
        :models="models"
        :model="ContractModel"
    />
  </block>
</template>

<style scoped lang="less"></style>