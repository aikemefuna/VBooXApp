$(function () {
    var baseUrl = $('#BaseUrl').val();
    var siteLocation = $('#siteLocation').val();
  

    $('#FreeTrailBtn_Submit').click(function () {
        var email = document.getElementById("email").value;
        var phone = document.getElementById("phone").value;
        let isValid = true;
        if (email === "" || email == null) {
            $('#email').css('border-color', 'Red');
            ($('#email').focus());
            isValid = false;
        }
        if (phone === "" || phone == null) {
            $('#phone').css('border-color', 'Red');
            ($('#phone').focus());
            isValid = false;
        }
        if (isValid != true) {
            return false;
        }
        else {
            $("#FreeTrailBtn_Submit").hide();
            $("#signup_loader_btn").show();
            CreateMyFreeAccount(email);
        }
       
    });
  

   
    function CreateMyFreeAccount() {
        var createClientAccountRequest = {
            email: $("#email").val(),
            phoneNo: $("#phone").val(),
            webUrl: siteLocation
        };

        var applicationUrl = baseUrl + 'v1.0/Client';
        $.ajax({
            url: applicationUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(createClientAccountRequest),
            success: function (data) {
                if (data.succeeded == true) {
                    document.getElementById("signUpForm").reset();
                    $("#signup_loader_btn").hide();
                    $("#FreeTrailBtn_Submit").show();
                    swal("Account Created!", "Please follow the instructions in your email", "success");
                }
                else {
                    $("#signup_loader_btn").hide();
                    $("#FreeTrailBtn_Submit").show();
                    swal("Aye! Not Successful", data.message, "warning");
                }


            },
            error: function (xhr) {
                $("#signup_loader_btn").hide();
                $("#FreeTrailBtn_Submit").show();
                swal("Aye! Not Successful", "Error occured when processing your request", "warning");
            }
        });

    }


});
//$(document).on({
//    ajaxStart: function () {
//        $('#cover-spin').show(0);
//    },
//    ajaxStop: function () {
//        $('#cover-spin').hide();
//    }
//});
