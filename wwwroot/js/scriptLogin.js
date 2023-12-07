document.addEventListener('DOMContentLoaded', function () {
    console.log('O DOM foi totalmente carregado!');

    wrapper = document.querySelector('.wrapper');
    loginLink = document.querySelector('.login-link');
    registerLink = document.querySelector('.register-link');
    btnPopup = document.querySelector('.btnLogin-popup');
    iconClose = document.querySelector('.icon-close');

    console.log(wrapper);
    console.log(registerLink);



    registerLink.addEventListener('click', (e) => {
        console.log("algo errado não está certo...");
        e.preventDefault();
        wrapper.classList.add('active');
    });

    loginLink.addEventListener('click', (e) => {
        console.log("hm...");
        e.preventDefault();
        wrapper.classList.remove('active');
    });

    btnPopup.addEventListener('click', () => {
        wrapper.classList.add('active-popup');
    });

    iconClose.addEventListener('click', () => {
        wrapper.classList.remove('active-popup');
    });
});


function testeNTS() {
    wrapper = document.querySelector('.wrapper');
    registerLink = document.querySelector('.register-link');
    registerLink.addEventListener('click', (e) => {
        wrapper.classList.add('active');
        console.log("algo errado não está certo...");
    });
}