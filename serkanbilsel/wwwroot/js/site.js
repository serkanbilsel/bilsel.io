let avatar = document.querySelector('.avatar');
let menu = document.querySelector('.menu');
avatar.onclick = function () {
    menu.classList.avatar('active')
}



document.getElementById('openPopupButton').addEventListener('click', function () {
    var popupContainer = document.getElementById('popupContainer');
    popupContainer.style.display = 'block';

    var closePopup = document.getElementById('closePopup');
    closePopup.addEventListener('click', function () {
        popupContainer.style.display = 'none';
    });
});


