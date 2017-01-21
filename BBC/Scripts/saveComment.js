$(document).ready(function() {
    $("#btn").click(function() {
        var obj = {
            scController: $("#scController").val(),
            scAction: $("#scAction").val(),
            FullName: $("#FullName").val().trim(),
            Description: $("#Description").val().trim(),
            Name: $("#Name").val().trim()
        };

        if (obj.FullName.length === 0 || obj.Description.length === 0) {
            alert("Nothing to save.");
            return;
        }

        $.ajax({
            url: window.location.href,
            type: "POST",
            context: this,
            data: obj,
            success: function(data) {
                if (data.succeed === true) {
                    alert(data.message);
                } else {

                    alert("Failed to save comment!");

                }
            },
            error: function(data) {
                console.log("error", data);
            }
        });
    });
});