const sideButtonElement = document.querySelectorAll(".side-button");

sideButtonElement.forEach(button => {
    button.addEventListener("click", function (event) {
        sideButtonElement.forEach(button => {
            button.classList.remove("list-group-item-dark");
        })
        button.classList.add("list-group-item-dark");
    });
});

