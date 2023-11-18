<template>
  <div class="cbb-muti">
    <v-combobox
    v-model="selectedItems"
    :items="items"
    item-value="value"
    item-text="text"
    label="Select items"
    multiple
    hide-selected
  >
    <template v-slot:item="{ item, on, attrs }">
      <v-list-item v-on="on" v-bind="attrs">
        <v-list-item-action>
          <v-checkbox v-model="item.selected" />
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title>
            {{ item.text }}
          </v-list-item-title>
          <v-list-item-subtitle>
            {{ item.description }}
          </v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </template>
  </v-combobox>
  </div>
  <div>{{ select }}</div>
</template>
<script>
import baseApi from "@/api/baseApi";
import {  VCombobox, VListItemAction } from "vuetify/lib/components";
import { VListItem } from 'vuetify/lib/components';
import { VListItemTitle } from 'vuetify/lib/components';
import { VListItemSubtitle } from 'vuetify/lib/components';
import { VCheckbox } from 'vuetify/lib/components';
export default {
  components: {
    VCombobox,
    VListItemAction,
    VListItem,
    VListItemTitle,
    VListItemSubtitle,
    VCheckbox
  },
  props: {
    modelValue: [Array],
    isAPI: Boolean,
    table: String,
    dataModel: [Array, Object],
  },
  created: async function () {
    if (this.isAPI) {
      const res = await new baseApi(this.table).getFilterDynamic();
      this.data = res.Data;
    } else {
      this.data = [
        {
          name: "123213",
          id: 1,
        },
        {
          name: "2222",
          id: 2,
        },
        {
          name: "333",
          id: 3,
        },
      ];
    }
  },
  data() {
    return {
      data: [],
      selectedItems: [],
      items: [
        { value: 1, text: 'Item 1', description: 'Description of item 1' },
        { value: 2, text: 'Item 2', description: 'Description of item 2' },
        { value: 3, text: 'Item 3', description: 'Description of item 3' },
      ],

    };
  },
};
</script>
<style scoped>
select[multiple] {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  background: transparent;
  padding: 0;
  border: none;
}

/* Thêm đường viền xung quanh combo select */
select[multiple]:focus {
  outline: none;
  border: 1px solid #ccc;
}

/* Thêm kiểu tùy chỉnh cho phần tử option được chọn */
select[multiple] option:checked {
  background-color: #ddd;
}

/* Thêm kiểu tùy chỉnh cho nút xóa */
#clear-button {
  margin-left: 10px;
  padding: 5px 10px;
  border: 1px solid #ccc;
  border-radius: 3px;
  background-color: #fff;
  cursor: pointer;
}

#clear-button:hover {
  background-color: #ccc;
}
</style>
