
function focusById(elementId)
{
    var element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}

function pressButton(buttonId) {
    var element = document.getElementById(buttonId);
    if (element) {
        element.click();
    }
}