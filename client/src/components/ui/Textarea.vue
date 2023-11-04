<template>
    <div class="form-group">
        <label>{{ label }}</label>
        <textarea
            @input="updateInput"
            :disabled="disabled"
            v-bind="$attrs"
            :value="modelValue"
            rows="6"
        />
        <div class="validation-error" v-for="error in errors">
            {{ error }}
        </div>
    </div>
</template>

<script setup>
defineOptions({
    inheritAttrs: false
});

defineProps({
    label: String,
    modelValue: [String, Number],
    errors: {
        type: Object,
        default: null
    },
    disabled: {
        default: false,
        type: Boolean
    }
});

const emit = defineEmits(['update:modelValue']);

const updateInput = (e) => {
    emit('update:modelValue', e.target.value);
}
</script>

<style lang="less" scoped>
.form-group {
    display: flex;
    flex-direction: column;
    gap: 5px;
    label {
        color: #000000;
        font-size: 17px;
    }
    .validation-error {
        color: var(--color-danger);
    }
    textarea {
        padding: 10px;
        font-size: 17px;
        border-radius: 4px;
        color: #000000;
        border: none;
        background: #FFFFFF;
        box-shadow: 0 0 4px 0 rgba(0, 0, 0, 0.2);
        &:focus-visible {
            outline: 2px solid var(--color-primary);
        }
        &:disabled {
            color: var(--color-secondary);
            background: var(--color-lighter-gray);
            box-shadow: none;
        }
    }
}
</style>
