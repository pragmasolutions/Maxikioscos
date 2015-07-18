var maxikioscoSpinner = function () {
    //// Start spin on any operation which reference this one. (the spin blocks the UI)
    var spinner = null,
        startSpin = function () {

            if ($("#loading").is(':visible')) {
                return;
            }
            
            $("#loading").fadeIn();

            var target = document.getElementById('loading');

            if (spinner == null) {
                var opts = {
                    lines: 12, // The number of lines to draw
                    length: 7, // The length of each line
                    width: 4, // The line thickness
                    radius: 10, // The radius of the inner circle
                    color: '#2A6496', // #rgb or #rrggbb
                    speed: 1, // Rounds per second
                    trail: 60, // Afterglow percentage
                    shadow: false, // Whether to render a shadow
                    hwaccel: false // Whether to use hardware acceleration
                };
                spinner = new Spinner(opts);
            }

            spinner.spin(target);
        },
        
        stopSpin = function() {
            $("#loading").fadeOut();
        };
        
    return {
        startSpin: startSpin,
        stopSpin: stopSpin
    };
}();