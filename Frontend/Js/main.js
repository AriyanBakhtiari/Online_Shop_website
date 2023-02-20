toPersianNumbers();
function toPersianNumbers() {
    let elements = document.getElementsByClassName("persian-num");
    for (let i = 0; i < elements.length; i++) {
        const element = elements[i];
        element.innerText = toFarsiNumber(element.innerText);
    }

    function toFarsiNumber(n) {

        const farsiDigits = ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'];
        let num = "";
        for (let i = 0; i < n.length; i++) {
            if (n[i] == "0") {
                num += farsiDigits[0];
            }
            else if (n[i] == "1") {
                num += farsiDigits[1];
            }
            else if (n[i] == "2") {
                num += farsiDigits[2];
            }
            else if (n[i] == "3") {
                num += farsiDigits[3];
            }
            else if (n[i] == "4") {
                num += farsiDigits[4];
            }
            else if (n[i] == "5") {
                num += farsiDigits[5];
            }
            else if (n[i] == "6") {
                num += farsiDigits[6];
            }
            else if (n[i] == "7") {
                num += farsiDigits[7];
            }
            else if (n[i] == "8") {
                num += farsiDigits[8];
            }
            else if (n[i] == "9") {
                num += farsiDigits[9];
            }
            else {
                num += n[i]
            }
        }
        return num;
    }
}

$(function () {
    var includes = $('[data-include]')
    $.each(includes, function () {
        var file = 'PartialViews/' + $(this).data('include') + '.html'
        $(this).load(file)
    })
})