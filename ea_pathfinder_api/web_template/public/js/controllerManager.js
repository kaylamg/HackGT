/*
Copyright (C) 2015 Electronic Arts Inc.  All rights reserved.

This software is solely licensed pursuant to the Hackathon License Agreement,
Available at:  www.eapathfinders.com/license
All other use is strictly prohibited.
*/

$(document).ready(function () {

	console.log ("Document Loaded");

	// INIT..
	conn = new Connection();
	conn.sendMessage({"type": "connect"});

	// SOUNDS
	startAudio = new Audio ("sound/electric-power-turn-on.mp3");
	touchEndAudio = new Audio ("sound/peeeooop.wav");

	// START SCREEN
	var gameInProgress = 0;
	$("body").addClass('start');

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

	$("body").on('touchstart', function (e) {
		$("body").addClass('touched');
		touchEndAudio.play();
	});

	$("body").on('touchend', function (e) {
		e.preventDefault();
		if (!gameInProgress) {
			startAudio.play();
			touchEndAudio.play();
			// send msg to unity
			var msg = { "type": "start" };
			conn.sendMessage(msg, 0);

			// GAME BEGINS, display game screen
			gameInProgress = 1;
			$("body").removeClass('start');
		}
		touchEndAudio.play();
		$("body").removeClass('touched');
	});

	$("body").on('mousedown', function (e) {
		e.preventDefault();
		if (!gameInProgress) {
			startAudio.play();
			touchEndAudio.play();
			// send msg to unity
			var msg = { "type": "start" };
			conn.sendMessage(msg, 0);

			// GAME BEGINS, display game screen
			gameInProgress = 1;
			$("body").removeClass('start');
		}
		touchEndAudio.play();
		$("body").removeClass('touched');
	});

});
