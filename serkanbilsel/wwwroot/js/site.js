let toggle = document.querySelector('.toggle');
let menu = document.querySelector('.menu');
toggle.onclick = function () {
    menu.classList.toggle('active')
}


document.getElementById('openPopup').addEventListener('click', function () {
    // Pop-up penceresini aç
    openPopup();
});

function openPopup() {
    var popup = document.createElement('div');
    popup.className = 'popup';

    var closeBtn = document.createElement('span');
    closeBtn.className = 'close';
    closeBtn.innerHTML = '&times;';
    closeBtn.addEventListener('click', function () {
        document.body.removeChild(popup);
    });

    var popupContent = document.createElement('div');
    popupContent.className = 'popup-content';
    popupContent.innerHTML = '"/**/"';

    popupContent.appendChild(closeBtn);
    popup.appendChild(popupContent);

    document.body.appendChild(popup);
}

/* CODE MIRROR***************************************** */
