window.onload = function () {
    var ageElement = document.getElementById('age');
    var birthdate = new Date(ageElement.dataset.birthdate);
    var today = new Date();
    var age = today.getFullYear() - birthdate.getFullYear();
    var m = today.getMonth() - birthdate.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < birthdate.getDate())) {
        age--;
    }

    ageElement.innerHTML = age;
}