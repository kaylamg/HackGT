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

	audio = new Audio ("sound/sci-fi-electricity.mp3");

	$("#startButton").on('touchend', function (e) {
		console.log("sdf");
		// this.m_state = 1;

		// send msg to Unity
		// var msg = {
		// 	"type": "start"
		// };
		// conn.sendMessage(msg, 0);
	});

	$("#touchPad").on('touchstart', function (e) {
		$("#touchPad").addClass('touched');
		// audio = new Audio ("sound/electric-power-turn-on.mp3");
		// audio.play();
	});

	$("#touchPad").on('touchend', function (e) {
		$("#touchPad").removeClass('touched');
		audio = new Audio ("sound/laser-gun-cannon.mp3"); // buffer on load as soon as controller
		audio.play();
		alert("END");
	});

	$("#touchPad").on('touchmove', function (e) {
		e.preventDefault();
		audio = new Audio ("sound/woosh.wav");
		audio.play();

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
