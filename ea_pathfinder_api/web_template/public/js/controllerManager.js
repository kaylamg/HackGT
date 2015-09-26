/*
Copyright (C) 2015 Electronic Arts Inc.  All rights reserved.

This software is solely licensed pursuant to the Hackathon License Agreement,
Available at:  www.eapathfinders.com/license
All other use is strictly prohibited.
*/

$(document).ready(function () {

	console.log("Document Loaded");

	// INIT..
	conn = new Connection();
	conn.sendMessage({"type": "connect"});

	$("body").on('touchstart', function (e) {
		$("body").addClass('touched');
	});

	$("body").on('touchend', function (e) {
		$("body").removeClass('touched');
	});

	$("body").on('touchmove', function (e) {
		e.preventDefault();

		touchobj = e.originalEvent.changedTouches[0];
		var touchX = parseInt(touchobj.clientX) / screen.height; // height and width switched in landscape view for mobile!
		var touchY = parseInt(touchobj.clientY) / screen.width;

		//send message to unity
		var msg = {
			"type": "position",
			"x-coordinate": touchX,
			"y-coordinate": touchY
		};
		conn.sendMessage(msg, 0);
	});
});
