/**
 * Xử lý click outside
 */
export default {
  mounted(el, binding) {
    const handler = (event) => {
      if (!el.contains(event.target) && el !== event.target) {
        binding.value(event);
      }
    };

    document.addEventListener("mousedown", handler);

    el._clickOutsideHandler = handler;
  },

  beforeUnmount(el) {
    document.removeEventListener("mousedown", el._clickOutsideHandler);
  },
};
