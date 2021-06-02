(function ($) {

	"use strict";

	$(".toggle-password").click(function () {
		$(this).toggleClass("bi-eye-slash-fill bi-eye-fill");
		var input = $($(this).attr("toggle"));
		if (input.attr("type") == "password") {
			input.attr("type", "text");
		} else {
			input.attr("type", "password");
		}
	});

})(jQuery);