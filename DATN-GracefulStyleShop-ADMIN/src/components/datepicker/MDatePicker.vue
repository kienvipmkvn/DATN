<template>
  <label class="dp__lable"
    >{{ textField }} <span v-if="isRequired">*</span></label
  >
  <Datepicker
    :enable-time-picker="false"
    v-model="date"
    @update:modelValue="changeDateValue"
    :config="options"
    :ref="name+'date'"
    locale="vi"
    auto-apply
    show-now-button
    :format="formatDate"
    :disabled-dates="disabledDate"
    :day-names="['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN']"
  >
    <template #dp-input="{ value }">
      <div class="date-picker__wrapper">
        <input
          class="m-input"
          type="text"
          placeholder="DD/MM/YYYY"
          :name="name"
          :value="value"
          autocomplete="off"
          :ref="name"
          :tabindex="tabIndex"
        />
        <p class="date-picker__icon">
          <i></i>
        </p>
      </div>
    </template>

    <template #now-button="{ selectCurrentDate }">
      <div class="dp__active_date-now" @click="selectCurrentDate()">
        Hôm nay
      </div>
    </template>
  </Datepicker>
  <p class="m-input__error-msg">{{ errorMsg }}</p>
</template>
<script>
import Datepicker from "@vuepic/vue-datepicker";
import common from "@/assets/js/common";
export default {
  name: "MDatePicker",
  emits: ["change", "message-error-input"],
  components: {
    Datepicker,
  },
  data() {
    return {
      date: this.modelValue,
      options: {
        format: "DD/MM/YYYY",
        useCurrent: false,
      },
    };
  },
  props: {
    modelValue: {
      type: Date,
    },
    isRequired: {
      type: Boolean,
    },
    textField: {
      type: String,
    },
    name: {
      type: String,
    },
    errorMsg: {
      type: String,
    },
    rules: {
      type: Array,
      default: new Array(0),
    },
    tabIndex: Number,
  },
  methods: {
    /**
     * Truyền sự kiện date thay đổi
     */
    changeDateValue(date) {
      this.$emit("update:modelValue", date);
    },
    /**
     * Check vaidate theo rules truyen vao
     */
    checkValidate() {
      if (this.rules.length != 0) {
        var msgErrorInput = common.inputValidation(
          this.rules,
          this.name,
          this.modelValue
        );
        this.$emit("message-error-input", this.name, msgErrorInput);
      }
    },
    /**
     * Kiểm tra date hợp lệ
     */
    isDateValid(event){
      var value = event.target.value;
      const dateRegex =/^([1-9]|[0-2][0-9]|3[0-1])\/([1-9]|0[1-9]|1[0-2])\/[1-2][0-9][0-9][0-9]$/;
      return dateRegex.exec(value);
    },
    /**
     * Xử lý nhập tay khi change
     */
    onInput(event){
      if (this.isDateValid(event)) {
        const newDate = new Date(event.target.value.split("/").reverse().join("-"));
        this.changeDateValue(newDate);
      }
    },
    /**
     * Xử lý nhập tay khi blur
     */
    blurInput(event) {
      this.$refs[this.name+'date'].closeMenu();
      if (this.isDateValid(event)) {
        const newDate = new Date(event.target.value.split("/").reverse().join("-"));
        this.changeDateValue(newDate);
      } else {
        this.changeDateValue(undefined);
        this.$refs[this.name].value = "";
      }
    },
    /**
     * Xử lý không cho phép nhập quá ngày hiện tại
     */
    disabledDate(time) {
      return time.getTime() > Date.now();
    },
  },
  watch: {
    modelValue : function(){
      this.date = this.modelValue;
    }
  },
  computed: {
    /**
     * Format date
     */
    formatDate() {
      return common.formatDate(this.modelValue);
    },
  },
};
</script>
<style scoped>
@import url(./date-picker.css);
</style>
