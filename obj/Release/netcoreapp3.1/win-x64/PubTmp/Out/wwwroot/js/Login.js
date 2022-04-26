


//function showPassword() {
//    console.log('mousedown');
//    $("#togglePassword").attr('type', 'text');
//    console.log($("#togglePassword").attr('type'));
//}
//function hidePassword() {
//    console.log('mouseup');
//    $("#togglePassword").attr('type', 'password');
//    console.log($("#togglePassword").attr('type'));
//}


var eye = document.getElementById("eye");
eye.addEventListener("mousedown", function (eventData) {
    if (eventData.button === 0) {
        passwordVisibility(true);
    }
}, false);
eye.addEventListener("mouseup", function (eventData) {
    if (eventData.button === 0) {
        passwordVisibility(false);
    }
}, false);

function passwordVisibility(toggle) {
    var x = document.getElementById("myPassword");
    if (toggle === true) {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
