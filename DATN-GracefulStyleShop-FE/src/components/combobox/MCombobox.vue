<template>
  <div
    :style="{
      marginBottom: errorMsg ? '32px' : marginBottom ? marginBottom : '24px',
      width: width,
    }"
    class="m-input-component"
    :class="{ error: errorMsg }"
    v-click-outside="() => (isShowHideList = false)"
  >
    <label for="m-input" class="m-lable"
      >{{ textField
      }}<span>{{ required && textField ? " *" : "" }}</span></label
    >
    <div class="m-input-main m-input-main-cbb">
      <input
        :ref="name"
        type="text"
        :tabindex="tabIndex"
        :readonly="isReadonly"
        class="m-input"
        v-model="textSelected"
        @input="onSearchItem"
        autocomplete="off"
        @keydown="inputOnKeyDown"
        @focus="inputFocus"
        @blur="inputBlur"
      />
      <p class="m-input__error-msg">{{ errorMsg }}</p>
      <div
        class="m-combobox__btn"
        @click="onToggleList"
        @keydown="inputOnKeyDown"
      >
        <div
          class="m-combobox-icon"
          :class="icon"
          :style="{
            transform: isShowHideList ? 'rotate(180deg)' : 'rotate(0)',
          }"
        ></div>
      </div>
      <div
        class="m-combobox-list"
        :style="{ marginTop: '-' + locationSize + 'px' }"
        v-if="isShowHideList"
        ref="listItemCombobox"
      >
        <li
          class="m-combobox-item"
          v-for="(item, index) in dataSearch"
          :key="index"
          :value="item[propValue]"
          :class="{
            active: index === indexItemSelected,
          }"
          @mousedown="itemSelected(item, index)"
        >
          {{ item[propName] }}
        </li>
      </div>
    </div>
  </div>
</template>
<script>
import enumD from "@/common/enum";
import common from "@/common/common";
import resources from "@/common/resource";
export default {
  name: "MCombobox",
  emits: ["update:modelValue", "message-error-input"],
  props: {
    data: Array,
    propValue: String,
    propName: String,
    modelValue: [String, Number],
    textField: String,
    propCode : String,
    name: String,
    required: Boolean,
    isReadonly: Boolean,
    errorMsg: {
      type: String,
      default: "",
    },
    width: String,
    height: String,
    marginBottom: {
      type: String,
      default: "0",
    },
    locationList: {
      type: Number,
      default: 0,
    },
    rules: {
      type: Array,
      default: new Array(0),
    },
    tabIndex: Number,
    icon: {
      type: String,
      default: "icon-drop",
    },
  },
  data() {
    return {
      isShowHideList: false, // Ẩn hiện list cbb
      textSelected: null, // Text hiển thị input
      dataSearch: [], // Data tìm kiếm
      indexItemSelected: null, // Vị trí được chọn
      // indexItemSelected: null, // Vị trí nhấn phím
      textItemSelected: null, // Text được chọn
      locationSize: 0, // Text được chọn
    };
  },
  created() {
    // Hiển thị mặc định
    this.setItemSelected();
    // Xử lý nếu list hiện ở trên
    if (this.locationList == enumD.LoCATION_LIST_CBB.UP) {
      this.locationSize = 33.6 * this.data.length + 37;
    }
  },
  methods: {
    /**
     * Hàm ẩn hiện list combobox
     */
    onToggleList() {
      this.isShowHideList = !this.isShowHideList;
      if (!this.isShowHideList) this.textSelected = this.textItemSelected;
      this.dataSearch = this.data;
      if (this.textSelected) {
        this.indexItemSelected = this.dataSearch.findIndex(
          (x) =>
            x[this.propName].toLowerCase() == this.textSelected.toLowerCase()
        );
      }
    },
    /**
     * Hàm chọn item hiển thị lên input
     */
    itemSelected(item, index) {
      this.textSelected = item[this.propName];
      this.textItemSelected = item[this.propName];
      this.isShowHideList = false;
      this.$emit("update:modelValue", item[this.propValue]);
      this.$emit("itemSelected",item);
      this.indexItemSelected = index;
    },
    /**
     * Hàm set item được chọn khi truyền vào
     */
    setItemSelected() {
      var item = this.data.find((x) => x[this.propValue] == this.modelValue);
      if (item) {
        this.textSelected = item[this.propName];
        this.textItemSelected = item[this.propName];
      }
    },
    /**
     * Hàm tìm kiếm tiem
     */
    onSearchItem() {
      this.dataSearch = this.data.filter((x) =>
        x[this.propName].toLowerCase().includes(this.textSelected.toLowerCase())
      );
      this.indexItemSelected = this.dataSearch.findIndex((x) =>
        x[this.propName].toLowerCase().includes(this.textItemSelected)
      );
      this.isShowHideList = true;
    },
    /**
     * Bắt sự kiện focus
     */
    inputFocus(){
      this.dataSearch = this.data;
      this.isShowHideList = true;
    },
    /**
     * Bắt sự kiện blur
     */
    inputBlur(){
      this.isShowHideList = false;
    },
    /**
     * Hàm xử lý bàn phím
     */
    inputOnKeyDown(event) {
      switch (event.keyCode) {
        // Nhấn phím enter
        case enumD.KEY_CODE.ENTER:
          // check xem hover vào item nào chưa nếu rồi thì lưu item
          if (this.indexItemSelected !== null) {
            var me = this;
            this.dataSearch = this.data;
            var item = this.dataSearch[me.indexItemSelected];
            // this.indexItemSelected = this.dataSearch.findIndex(
            //   (x) => x[this.propValue] == item[me.propValue]
            // );
            this.itemSelected(item, this.indexItemSelected);
            me.isShowHideList = false;
          }
          break;
        // Phím mũi tên lên
        case enumD.KEY_CODE.KEY_UP:
          // Hiển list nếu ẩn
          if (!this.isShowHideList) this.isShowHideList = true;
          else {
            // Nếu chưa hover thì hover vào phần tử cuối
            if (this.indexItemSelected === null) {
              this.indexItemSelected = this.dataSearch.length - 1; // nếu chưa tồn tại thì gán vào hover cuối
            } else if (this.indexItemSelected > 0) {
              // nếu đã tồn tại thì giảm đi 1
              this.indexItemSelected--;
            } else {
              this.indexItemSelected = this.dataSearch.length - 1; // Nếu hover đầu rồi thì xuống cuối
            }
          }
          break;
        case enumD.KEY_CODE.KEY_DOWN:
          // Phím mũi tên xuống
          if (!this.isShowHideList) this.isShowHideList = true;
          else {
            // Nếu chưa hover thì hover vào phần tử cuối
            if (this.indexItemSelected === null) {
              this.indexItemSelected = 0; // nếu chưa tồn tại thì gán vào hover đầu
            } else if (this.indexItemSelected < this.dataSearch.length - 1) {
              this.indexItemSelected++; // nếu đã tồn tại thì tăng lên 1
            } else {
              this.indexItemSelected = 0; // Nếu hover cuối rồi thì xuống 0
            }
          }
          break;
        default:
          break;
      }
    },
    /**
     * Check vaidate theo rules truyen vao
     */
    checkValidate() {
      if (this.rules.length != 0) {
        var msgErrorInput;
        if (
          this.textSelected &&
          this.data.find((x) => x[this.propName] == this.textSelected) == null
        ) {
          // Lấy tên chuẩn tiếng việt của đối tượng
          const name = resources.vi.FORM_FIELD[this.name];
          msgErrorInput = resources.vi.FORM_MESSAGE.ERROR.NOT_EXIST(name);
        } else {
          msgErrorInput = common.inputValidation(
            this.rules,
            this.name,
            this.modelValue
          );
        }

        this.$emit("message-error-input", this.name, msgErrorInput);
      }
    },
    /**
     * Hàm focus input
     */
    onFocus() {
      this.$refs[this.name].focus();
    },
  },
  watch: {
    /**
     * Phát hiện sự thay đổi của phòng ban
     */
    modelValue() {
      if (this.modelValue) {
        this.setItemSelected();
        this.dataSearch = this.data;
      } else {
        this.textSelected = "";
      }
    },
    data(){
      this.setItemSelected();
    },
    /**
     * Validate nếu text không tồn tại thì k hợp lệ
     */
    textSelected() {
      if (!this.textSelected) {
        this.$emit("update:modelValue", undefined);
      }
    },
  },
};
</script>

<style scoped>
@import url(./combobox.css);
.m-combobox-item-code{
  flex-basis: 30%;
  height: 100%;
  border-right: 1px solid #5e5b5b;
}
.m-combobox-item-name{
  flex-basis: 69%;
  height: 100%;
  padding-left: 8px;
}
</style>
