$(function () {


    $("#battery-group").hide();
    $("#column-group").hide();
    $("#elevator-group").hide();

    //console.log("i am working")
    

    //console.log("customer is changing")
    var id_value_string = $("#customer").val();
    if (id_value_string == "") {
        $("select#building option").remove();
        var row = "<option value=\"" + "" + "\">" + "Building" + "</option>";
        $(row).appendTo("select#building");
    } else {
        // Send the request and update course dropdown
        //console.log("before ajax " + id_value_string)

        $.ajax({
            dataType: "json",
            method: 'GET',
            cache: false,
            url: 'https://rocket-elevators-rest-apii.herokuapp.com/buildings/from-customer/' + id_value_string,
            timeout: 5000,
            error: function (XMLHttpRequest, errorTextStatus, error) {
                alert("Failed to submit : " + errorTextStatus + " ;" + error);
            },
            success: function (data) {
                // Clear all options from course select
                $("select#building option").remove();
                //put in a empty default line
                var row = "<option value=\"" + "" + "\">" + "Building" + "</option>";
                $(row).appendTo("select#building");
                // Fill course select
                $.each(data, function (i, j) {
                    row = "<option value=\"" + j.id + "\">" + j.id + "</option>";
                    //console.log(row)
                    $(row).appendTo("select#building");
                    
                });
            }
        });
    }
    

    $("select#building").change(function () {
        $("#column-group").hide();
        $("#elevator-group").hide();
        //console.log("building is changing")
        var id_value_string = $(this).val();
        if (id_value_string == "") {
            $("select#battery option").remove();
            var row = "<option value=\"" + "" + "\">" + "Battery" + "</option>";
            $(row).appendTo("select#battery");
        } else {
            // Send the request and update course dropdown
            //console.log("before ajax " + id_value_string)

            $.ajax({
                dataType: "json",
                method: 'GET',
                cache: false,
                url: 'https://rocket-elevators-rest-apii.herokuapp.com/batteries/from-building/' + id_value_string,
                timeout: 5000,
                error: function (XMLHttpRequest, errorTextStatus, error) {
                    alert("Failed to submit : " + errorTextStatus + " ;" + error);
                },
                success: function (data) {
                    // Clear all options from course select
                    $("select#battery option").remove();
                    //put in a empty default line
                    var row = "<option value=\"" + "" + "\">" + "Battery" + "</option>";
                    $(row).appendTo("select#battery");
                    // Fill course select
                    $.each(data, function (i, j) {
                        row = "<option value=\"" + j.id + "\">" + j.id + "</option>";
                        //console.log(row)
                        $(row).appendTo("select#battery");
                        $("#battery-group").show();
                    });
                }
            });
        }
    });

    $("select#battery").change(function () {
        $("#elevator-group").hide();
        //console.log("battery is changing")
        var id_value_string = $(this).val();
        if (id_value_string == "") {
            $("select#column option").remove();
            var row = "<option value=\"" + "" + "\">" + "Column" + "</option>";
            $(row).appendTo("select#column");
        } else {
            // Send the request and update course dropdown
            //console.log("before ajax " + id_value_string)

            $.ajax({
                dataType: "json",
                method: 'GET',
                cache: false,
                url: 'https://rocket-elevators-rest-apii.herokuapp.com/columns/from-battery/' + id_value_string,
                timeout: 5000,
                error: function (XMLHttpRequest, errorTextStatus, error) {
                    alert("Failed to submit : " + errorTextStatus + " ;" + error);
                },
                success: function (data) {
                    // Clear all options from course select
                    $("select#column option").remove();
                    //put in a empty default line
                    var row = "<option value=\"" + "" + "\">" + "Column" + "</option>";
                    $(row).appendTo("select#column");
                    // Fill course select
                    $.each(data, function (i, j) {
                        row = "<option value=\"" + j.id + "\">" + j.id + "</option>";
                        //console.log(row)
                        $(row).appendTo("select#column");
                        $("#column-group").show();
                    });
                }
            });
        }
    });
    if ($("select#column").val() == "") {
        $("select#elevator option").remove();
        var row = "<option value=\"" + "" + "\">" + "Elevator" + "</option>";
        $(row).appendTo("select#elevator");
    }
    $("select#column").change(function () {
        var id_value_string = $(this).val();
        if (id_value_string == "") {
            $("select#elevator option").remove();
            $("select#elevator").val("");
            $("select#elevator").hide();
            var row = "<option value=\"" + "" + "\">" + "Elevator" + "</option>";
            $(row).appendTo("select#elevator");
        } else {
            // Send the request and update course dropdown
            $.ajax({
                dataType: "json",
                cache: false,
                url: 'https://rocket-elevators-rest-apii.herokuapp.com/elevators/from-column/' + id_value_string,
                timeout: 5000,
                error: function (XMLHttpRequest, errorTextStatus, error) {
                    alert("Failed to submit : " + errorTextStatus + " ;" + error);
                },
                success: function (data) {
                    // Clear all options from course select
                    $("select#elevator option").remove();
                    //put in a empty default line
                    var row = "<option value=\"" + "" + "\">" + "Elevator" + "</option>";
                    $(row).appendTo("select#elevator");
                    // Fill course select
                    $.each(data, function (i, j) {
                        row = "<option value=\"" + j.id + "\">" + j.id + "</option>";
                        $(row).appendTo("select#elevator");
                        $("#elevator-group").show();
                    });
                }
            });
        }
    });

    $("#intervention").submit(function (e) {
        e.preventDefault();
        var customerId = $("#customer").val();
        var buildingId = $("select#building").val();
        var batterieId = $("select#battery").val();
        if ($("select#column").val() == "") {
            var columnId = null;
        } else {
            var columnId = $("select#column").val();
        };
        if ($("select#elevator").val() == "")
        {
            var elevatorId = null;
        }else{
        var elevatorId = $("select#elevator").val();
        };
        var report = $("#description").val();

        var interventionData = {
            "customers_id": customerId,
            "building_id": buildingId,
            "batteries_id": batterieId,
            "columns_id": columnId,
            "elevators_id": elevatorId,
            "Report": report
        };
        //console.log(interventionData);
        //console.log("+++++++++");
        //console.log(JSON.stringify(interventionData));
        //console.log("+++++++++");
        //console.log("befor ajax");
        $.ajax({
            type: 'POST',
            data: JSON.stringify(interventionData), 
            contentType: "application/json",
            url: 'https://rocket-elevators-rest-apii.herokuapp.com/interventions',
            success: function (data) {
                alert("Your Interventions Has Been Saved");
            }
        });
        window.location.href = "/home";
    });

});