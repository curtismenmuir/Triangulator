var uri;
var input = document.getElementById('inputBox');

input.addEventListener("keyup", function (event) {
    event.preventDefault();
    if (event.keyCode === 13) {
        document.getElementById("submitBtn").click();
    }
});

function getTriangle() {
    if (input.value.length < 4) {
        uri = 'api/triangulator/GetCoordinates/';
    }
    else {
        uri = 'api/triangulator/GetTriangleName/';
    }
    $.getJSON(uri + input.value)
        .done(function (triangle) {
            $('#triangleName').text('Triangle Name: ' + triangle.triangleName);
            $('#triangleCoordinates').text('Coordinates: ' + triangle.coordinates);
            input.classList.remove("is-invalid");
            clearGrid();
            drawTriangle(triangle.coordinates);
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#triangleName').text('Invalid Entry');
            $('#triangleCoordinates').text('');
            var formGroup = document.getElementById('formGroup');
            input.classList.add("is-invalid");
            clearGrid();
        });
}

function drawTriangle(coordinates) {
    var triangleCanvas = document.getElementById('triangleCanvas');
    if (triangleCanvas.getContext) {
        coordinates = coordinates.replace(/[()]/g, '');
        coordinates = coordinates.split(',');
        var context = triangleCanvas.getContext('2d');
        context.beginPath();
        context.moveTo(coordinates[0] * 3, coordinates[1] * 3); // Multply all coordinates by 3 to fit canvas (180,180)
        context.lineTo(coordinates[2] * 3, coordinates[3] * 3); // Multply all coordinates by 3 to fit canvas (180,180)
        context.lineTo(coordinates[4] * 3, coordinates[5] * 3); // Multply all coordinates by 3 to fit canvas (180,180)
        context.fillStyle = "rgba(97, 97, 97, 1)";
        context.fill();
    }
}

function clearGrid() {
    var triangleCanvas = document.getElementById('triangleCanvas');
    if (triangleCanvas.getContext) {
        var context = triangleCanvas.getContext('2d');
        context.clearRect(0, 0, triangleCanvas.width, triangleCanvas.height);
    }
}