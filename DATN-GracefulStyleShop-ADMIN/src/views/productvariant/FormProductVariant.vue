<template>
  <div class="form-submit">
    <div class="m__e-form">
      <div class="form__row" style="width: 100%">
        <div class="form__row f-bw" style="width: 48%">
          <MCombobox
            :data="listColor"
            v-model="formData.ColorId"
            ref="ColorId"
            propName="ColorName"
            propValue="ColorId"
            propCode="ColorCode"
            :rules="[rules.NOT_EMPTY]"
            name="ColorId"
            textField="Màu"
            :tabIndex="1"
            :required="true"
            :errorMsg="errorMsgObjectInput?.ColorId"
            @message-error-input="handleBindMessageInput"
          />
        </div>
        <div class="form__col" style="width: 48%">
          <MCombobox
            :data="listSize"
            v-model="formData.SizeId"
            ref="SizeId"
            propName="SizeCode"
            propValue="SizeId"
            propCode="SizeNumber"
            :rules="[rules.NOT_EMPTY]"
            name="SizeId"
            textField="Kích cỡ"
            :tabIndex="2"
            :required="true"
            :errorMsg="errorMsgObjectInput?.SizeId"
            @message-error-input="handleBindMessageInput"
          />
        </div>
      </div>
      <div style="height: 24px"></div>
      <div class="form__row" style="width: 100%">
        <div class="form__row f-bw" style="width: 100%">
          <MCombobox
            :data="listSupplier"
            v-model="formData.SupplierId"
            ref="SupplierId"
            propName="SupplierName"
            propValue="SupplierId"
            propCode="SupplierCode"
            :rules="[rules.NOT_EMPTY]"
            name="SupplierId"
            textField="Nhà cung cấp"
            :tabIndex="3"
            :required="true"
            :errorMsg="errorMsgObjectInput?.ColorId"
            @message-error-input="handleBindMessageInput"
          />
        </div>
      </div>
      <div style="height: 24px"></div>
      <div class="form__row" style="width: 100%">
        <MInput
          textField="Số lượng"
          v-model="formData.Quantity"
          :required="true"
          ref="Quantity"
          name="Quantity"
          :tabIndex="4"
          :errorMsg="errorMsgObject?.Quantity"
          :rules="[rules.NOT_EMPTY]"
          @message-error-input="handleBindMessageInput"
        />
      </div>
      <div class="form__row" style="width: 100%">
        <MInput
          textField="Giá nhập"
          v-model="formData.PriceSupply"
          :required="true"
          ref="PriceSupply"
          name="PriceSupply"
          :tabIndex="5"
          :errorMsg="errorMsgObject?.PriceSupply"
          :rules="[rules.NOT_EMPTY]"
          @message-error-input="handleBindMessageInput"
        />
      </div>
    </div>
  </div>
</template>

<script>
import MInput from "@/components/input/MInput.vue";
import resources from "@/assets/js/resource";
import mixinForm from "@/mixins/mixinForm.js";
import MCombobox from "@/components/combobox/MCombobox.vue";
import baseApi from "@/api/baseApi";
export default {
  name: "FormColor",
  emits: ["update:modelValue"],
  components: {
    MInput,
    MCombobox,
  },
  mixins: [mixinForm],
  created: async function () {
    this.listColor = await this.getDataCombobox("Color");
    this.listSize = await this.getDataCombobox("Size");
    this.listSupplier = await this.getDataCombobox("Supplier");
    this.formData.ProductId = this.$route.params.id;
  },
  props: {
    modelValue: Object,
  },
  data() {
    return {
      isShow: true,
      rules: resources.FORM_RULES, // Rules validate
      formData: {},
      errorMsgObject: {},
      listColor: [],
      listSize: [],
      listSupplier: [],
      api: baseApi,
    };
  },
  methods: {
    async getDataCombobox(tableName) {
      this.api = new baseApi(tableName);
      let res = await this.api.getByFilter({ pageSize: 100, numberPage: 1 });
      return res.Data;
    },
  },
};
</script>
<style scoped>
.m-pop-up {
  min-width: 1500px !important;
}
</style>
