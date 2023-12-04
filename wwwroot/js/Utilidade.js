// Recebe um elemento html pelo ID e atribui o foco da tela a ele
function focusById(elementId)
{
    var element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}


// Recebe um elemento pelo ID e ativa o evento de click dele
function pressButton(buttonId) {
    var element = document.getElementById(buttonId);
    if (element) {
        element.click();
    }
}

function testeNTS() {
    console.log("O js esta carregado.");
}