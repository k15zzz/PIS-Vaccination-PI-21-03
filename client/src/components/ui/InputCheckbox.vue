<template>
    <section
        :class="{
      'm-toggle--is-dark':     darkTheme,
      'm-toggle--is-disabled': disabled,
    }"
        class="m-toggle"
    >
        <input
            :id="id"
            v-model="toggled"
            :disabled="disabled"
            :name="name"
            class="m-toggle__input"
            type="checkbox"
        />
        <span
            :aria-checked="toggled"
            :aria-disabled="disabled"
            :aria-labelledby="`${id}-label`"
            :aria-readonly="disabled"
            class="m-toggle__content"
            :class="{'m-toggle__content--active': toggled}"
            role="checkbox"
            @click="changeToggled"
        />
        <label
            :id="`${id}-label`"
            :for="id"
            class="m-toggle__label"
        >
            {{ title }}
        </label>
    </section>
</template>

<script>
export default {
    name: 'InputCheckbox',

    props: {
        activeColor: {type: String, default: '#FF4500'},
        darkTheme: {type: Boolean, default: false},
        disabled: {type: Boolean, default: false},
        fontSize: {type: String, default: '16px'},
        fontWeight: {type: String, default: 'normal'},
        name: {type: String, required: true},
        title: {type: String, required: true},
        modelValue: {type: Boolean, default: false},
    },

    data() {
        return {
            toggleState: true,
        }
    },

    methods: {
        changeToggled() {
            this.toggled = !this.toggled;
        }
    },

    computed: {
        toggled: {
            get() {
                return this.modelValue;
            },
            set(value) {
                if (this.disabled) return;
                this.$emit("update:modelValue", value);
            }
        },
        id() {
            return this.name.replace(/ /g, '').toLowerCase();
        },
    }
};
</script>

<style lang="scss" scoped>
.m-toggle {
    $self: &;
    $toggle-spacing: 2px;
    align-items: center;
    display: flex;
    margin: 0 -5px;

    > * {
        cursor: pointer;
        margin: 0 5px;
    }

    &__label {
        user-select: none;
        font-weight: v-bind(fontWeight);
        font-size: v-bind(fontSize);

        #{$self}--is-disabled & {
            cursor: not-allowed;
        }

        #{$self}--is-dark & {
            color: white;
        }
    }

    &__input {
        display: none;

        &:checked {
            & + #{$self}__content {
                &:after {
                    left: calc(50% + #{$toggle-spacing});
                }
            }
        }
    }

    &__content {
        background: #F0F0F0;
        border-radius: 5px;
        box-sizing: border-box;
        height: 2em;
        outline: 0;
        overflow: hidden;
        padding: $toggle-spacing;
        transition: background-color .4s ease;
        width: 4em;
        will-change: background-color;

        &--active {
            background-color: var(--color-primary);
        }

        &:after {
            background: white;
            border-radius: 5px;
            box-shadow: 0 0 5px 0 rgba(0, 0, 0, .05);
            content: '';
            display: block;
            height: 100%;
            left: 0;
            position: relative;
            transition: left .2s ease;
            width: calc(50% - #{$toggle-spacing});
            will-change: left;
        }

        #{$self}--is-disabled & {
            cursor: not-allowed;
            opacity: 50%;
        }

        #{$self}--is-dark & {
            background: var(--color-primary);
        }
    }
}
</style>
