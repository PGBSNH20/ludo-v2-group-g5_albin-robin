var hubConnection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();
var playerName = "";
var playerImage = "";
var hash = "#";
hubConnection.start();
$("#btnRegister").click(function () { //// Fires on button click
    playerName = $('#name').val(); //// Sets the player name with the input name.
        playerImage = $('#previewImage').attr('src'); //// Sets the player image variable with specified image
    var data = playerName.concat(hash, playerImage); //// The registration data to be sent to server.
    hubConnection.invoke('RegisterPlayer', data); //// Invoke the "RegisterPlayer" method on gameHub.
});
$("#image").change(function () { //// Fires when image is changed.
    readURL(this); //// HTML 5 way to read the image as data url.
});
function readURL(input) {
    if (input.files && input.files[0]) { //// Go in only if image is specified.
            var reader = new FileReader();
        reader.onload = imageIsLoaded;
        reader.readAsDataURL(input.files[0]);
    }
}
function imageIsLoaded(e) {
    if (e.target.result) {
        $('#previewImage').attr('src', e.target.result); ////Sets the image source for preview.
        $("#divPreviewImage").show();
            }
}