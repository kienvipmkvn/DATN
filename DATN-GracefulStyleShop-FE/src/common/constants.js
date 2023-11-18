const constants = {
  /**
   * List item sidebar
   */
  SidebarMenu: [
    {
      text: "Tổng quan",
      classIcon: "icon-overview",
      path : "/app/employee"
    },

    {
      text: "Tiền mặt",
      classIcon: "icon-cash",
      path : "/app/about"
    },

    {
      text: "Tiền gửi",
      classIcon: "icon-deposits",
      path : "/app"
    },

    {
      text: "Mua hàng",
      classIcon: "icon-purchase",
      path : "/app"
    },

    {
      text: "Bán hàng",
      classIcon: "icon-sell",
      path : "/app"
    },

    {
      text: "Quản lý hóa đơn",
      classIcon: "icon-bill",
      path : "/app"
    },

    {
      text: "Kho",
      classIcon: "icon-contain",
      path : "/app"
    },

    {
      text: "Công cụ công dụng",
      classIcon: "icon-tools",
      path : "/app"
    },

    {
      text: "Tài sản cố định",
      classIcon: "icon-asset",
      path : "/app"
    },

    {
      text: "Thuế",
      classIcon: "icon-tax",
      path : "/app"
    },
    {
      text: "Giá thành",
      classIcon: "icon-price",
      path : "/app"
    },
    {
      text: "Tổng hợp",
      classIcon: "icon-total",
      path : "/app"
    },
    {
      text: "Ngân sách",
      classIcon: "icon-budget",
      path : "/app"
    },
    {
      text: "Báo cáo",
      classIcon: "icon-report",
      path : "/app"
    },
    {
      text: "Phân tích tài chính",
      classIcon: "icon-analysis",
      path : "/app"
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
		EmployeeCode: /^NV-[0-9]{1,17}$/,
		Email: /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/,
		Phone: /((09|03|07|08|05)+([0-9]{8})\b)/,
		PhoneNumberFixed: /((09|03|07|08|05)+([0-9]{8})\b)/,
	},
};

export default constants;