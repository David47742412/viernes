const email = document.getElementById("txtEmail");
const password = document.getElementById("txtPassword");
const ingresar = document.getElementById("btnIngresar");

ingresar.disabled = true;

email.addEventListener("input", () => {
    ingresar.disabled = email.value === '';
});