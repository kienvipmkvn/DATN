const constants = {
  /**
   * List item sidebar
   */
  SidebarMenu: [
    {
      text: "Trang chủ",
      classIcon: "icon-home",
      path : "/",
      name:"Home"
    },
    {
      text: "Quản lý sản phẩm",
      classIcon: "icon-product",
      path : "/products",
      name:"Product"
    },
    {
      text: "Quản lý màu sắc",
      classIcon: "icon-overview",
      path : "/colors",
      name:"Color"
    },
    {
      text: "Quản lý loại sản phẩm",
      classIcon: "icon-cash",
      path : "/types",
      name:"Type"
    },
    {
      text: "Quản lý kích cỡ",
      classIcon: "icon-size",
      path : "/sizes",
      name:"Size"
    },
    {
      text: "Quản lý thương hiệu",
      classIcon: "icon-cash",
      path : "/brands",
      name:"Brand"
    },
    {
      text: "Quản lý tài khoản khách hàng",
      classIcon: "icon-customer",
      path : "/customers",
      name:"Customer"
    },
    {
      text: "Quản lý nhà cung cấp",
      classIcon: "icon-supplier",
      path : "/suppliers",
      name:"Supplier"
    },
    {
      text: "Quản lý phương thức giao hàng",
      classIcon: "icon-supplier",
      path : "/shipments",
      name:"Shipment"
    },
    {
      text: "Quản lý tài khoản quản trị",
      classIcon: "icon-admin",
      path : "/admins",
      name:"Admin"
    },
    {
      text: "Thông tin nhập hàng",
      classIcon: "icon-supply",
      path : "/supplys",
      name:"Supply"
    },
    {
      text: "Quản lý đơn hàng",
      classIcon: "icon-order",
      path : "/orders",
      name:"Order"
    },
  ],
  /**
   * List item pageSize
   */
  listNavigateNumber: [
    {
      id: 10,
      value: "10 bản ghi trên 1 trang",
    },
    {
      id: 20,
      value: "20 bản ghi trên 1 trang",
    },
    {
      id: 30,
      value: "30 bản ghi trên 1 trang",
    },
    {
      id: 50,
      value: "50 bản ghi trên 1 trang",
    },
    {
      id: 100,
      value: "100 bản ghi trên 1 trang",
    },
  ],
  /**
   * List item pageSize
   */
  listStatusFilterImport: [
    {
      id: 3,
      value: "Tất cả",
    },
    {
      id: 1,
      value: "Không hợp lệ",
    },
    {
      id: 2,
      value: "Hợp lệ",
    }
  ],
  /**
   * Regex
   */
  regexConstants: {
		ItemCode: /^NV-[0-9]{1,17}$/,
		Email: /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/,
		PhoneNumber: /((09|03|07|08|05)+([0-9]{8})\b)/,
		PhoneNumberFixed: /((09|03|07|08|05)+([0-9]{8})\b)/,
	},
};

export default constants;