export default {
  created() {
      this.$state.form  =  this._data.formName;
      this.$state.titleForm =  this._data.titleForm;
      this.$state.isSaveForm =  false;
      this.$state.nameTable=  this._data.tableName;
      this.$state.level = this._data?.level;
      this.$state.parentName = this._data?.parentName;
      this.$state.parentPath = this._data?.parentPath;
      this.$state.mode = this._data?.mode;
      this.$state.lock = this._data?.lock;
      this.$state.delete = this._data?.delete;
  },
  data() {
      return {};
    },
    methods: {},
    watch:{}
};
