const forma = document.querySelector("#formular");
forma.addEventListener("submit", function (ev)
{
    let polje;

    polje = document.querySelector("#ime");
    const imeiprezime = polje.value;
    if (imeiprezime === "") {
        Greska("Unesi ime i prezime", ev, polje);
        return false;
    }
    const imePrezime = polje.value.split(' ');
    if (imePrezime.length === 1) {
        Greska("Unesi prezime", ev, polje);
        return false;
    }
    const ime = imePrezime[0];
    const prezime = imePrezime[1];
    //ImePrezime
    if (containsNumbers(ime)) {
        Greska("Ime ne sme imati specijalne znakove i brojeve", ev, polje);

        return false;
    }
    if (containsNumbers(prezime)) {
        Greska("Prezime ne sme imati specijalne znakove i brojeve", ev, polje);
        return false;
    }

    //Adresa
    polje = document.querySelector("#adresa");
    const adresa = polje.value;

    if (adresa === "") {
        Greska("Unesi ulicu", ev, polje);
        return false;
    }

    const adresa1 = adresa.split(',');
    const ulica = adresa[0];
    const brojKuce = adresa1[1];

    if (adresa1.length === 1) {
        Greska("Unesi broj kuce", ev, polje);
        return false;
    }
    if (containsNumbers(ulica)) {

        Greska("Ulica ne sme imati broj", ev, polje);
        return false;
    }
    if (!containsOnlyNumbers(brojKuce)) {
        Greska("Broj kuce mora biti broj", ev, polje);
        return false;
    }

    //Broj telefona
    polje = document.querySelector("#telefon");
    const telefon = polje.value;

    if (telefon === "") {
        Greska("Unesi telefon", ev, polje);
        return false;
    }
    if (!containsOnlyNumbers(telefon)) {
        Greska("Telefon ne sme imati slova ili specijalne znakove", ev, polje);
        return false;
    }
    if (telefon.length != 10) {
        Greska("Telefon mora imati deset cifara", ev, polje);
        return false;
    }
});