<script setup>
import Block from "../components/ui/Block.vue";
import ModelRegistry from "../components/ModelLogRegistry.vue";
import {onBeforeMount, reactive} from "vue";
import {LogRepository} from "../repositorys/LogRepository.js";
import {LogModel} from "../models/LogModel.js";


let models = reactive([])
onBeforeMount(async () => {
  Object.assign(models, await LogRepository.list());
});
</script>

<template>
  <block class="registry">
    <model-registry
        :models="models"
        :model="LogModel"
        router-create="exportCreate"
        title="Реестр логов"
    />
  </block>
</template>

<style scoped lang="less">

</style>