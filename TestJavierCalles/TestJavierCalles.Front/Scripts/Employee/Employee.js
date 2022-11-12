
//Valitation for phone format
document.getElementById('txtPhone').addEventListener('input', function (e) {
    var x = e.target.value.replace(/\D/g, '').match(/(\d{0,3})(\d{0,3})(\d{0,4})/);
    e.target.value = !x[2] ? x[1] : '(' + x[1] + ') ' + x[2] + (x[3] ? '-' + x[3] : '');
});

//Valitation for phone format
document.getElementById('txtPhoneUpdate').addEventListener('input', function (e) {
    var x = e.target.value.replace(/\D/g, '').match(/(\d{0,3})(\d{0,3})(\d{0,4})/);
    e.target.value = !x[2] ? x[1] : '(' + x[1] + ') ' + x[2] + (x[3] ? '-' + x[3] : '');
});

//Valitation for phone format
document.getElementById('txtSearchphone').addEventListener('input', function (e) {
    var x = e.target.value.replace(/\D/g, '').match(/(\d{0,3})(\d{0,3})(\d{0,4})/);
    e.target.value = !x[2] ? x[1] : '(' + x[1] + ') ' + x[2] + (x[3] ? '-' + x[3] : '');
});


function Add() {

    let lastName = $("#txtLastName").val();
    let firstName = $("#txtFirstName").val();
    let phone = $("#txtPhone").val();
    let zip = $("#txtZip").val();

    if (lastName != "" && firstName != "" && phone != "" && zip != "") {
        if (zip.length == 5) {
            if (phone.length == 14) {
                $.get(UrlAdd,
                    {
                        lastName: lastName,
                        firstName: firstName,
                        phone: phone,
                        zip: zip
                    })
                    .done(function (data) {
                        $("#txtLastName").val('');
                        $("#txtFirstName").val('');
                        $("#txtPhone").val('');
                        $("#txtZip").val('');
                        location.replace(window.location.origin);

                    }).fail(function () {
                        alert("Error");
                    });
            }
            else {
                alert("Phone formatted has be (555) 555-5555");
            }
        } else {
            alert("Zip has to be 5 numbers");
        }
    } else {
        alert("All inputs are required");
    }

}

function Update() {
    let lastName = $("#txtLastNameUpdate").val();
    let firstName = $("#txtFirstNameUpdate").val();
    let phone = $("#txtPhoneUpdate").val();
    let zip = $("#txtZipUpdate").val();
    let employeeId = $("#txtEmployeeIdUpdate").val();

    if (lastName != "" && firstName != "" && phone != "" && zip != "") {
        if (zip.length == 5) {
            if (phone.length == 14) {
                $.post(UrlUpdate,
                    {
                        lastName: lastName,
                        firstName: firstName,
                        phone: phone,
                        zip: zip,
                        employeeId: employeeId
                    })
                    .done(function (data) {

                        location.replace(window.location.origin);

                    }).fail(function () {
                        alert("Error");
                    });
            }
            else {
                alert("Phone formatted has be (555) 555-5555");
            }
        } else {
            alert("Zip has to be 5 numbers");
        }
    } else {
        alert("All inputs are required");
    }

}


function Delete(employeeId) {

    $.post(UrlDelete,
        {
            IdEmployee: employeeId
        })
        .done(function (data) {

            location.replace(window.location.origin);

        }).fail(function () {
            alert("Error with tried update employee");
        });


}

//Funtion for show model for update an employee
function showModal(employeeId, lastName, firstName, phone, zip) {


    $("#txtLastNameUpdate").val(lastName);
    $("#txtFirstNameUpdate").val(firstName);
    $("#txtPhoneUpdate").val(phone);
    $("#txtZipUpdate").val(zip);
    $("#txtEmployeeIdUpdate").val(employeeId);


    $('#modalUpdateEmployee').modal('show');

}




