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

	//Process incoming game messages
	// $(document).on("game_message", function (e, message) {
	// 	console.log("Received Message: " + JSON.stringify(message));
	// 	var payload = message.payload;
	// 	switch (payload.type) {
	// 		//your code here
	// 	}
	// });

	$("body").on('touchmove', function (e) {
		e.preventDefault();
		console.log("entered touchmove")

		//send message to unity
		// var msg = {
		// 	"type": "position",
		// 	"x-coordinate": x,
		// 	"y-coordinate": y
		// };
		// conn.sendMessage(msg, 0);
	});
});

