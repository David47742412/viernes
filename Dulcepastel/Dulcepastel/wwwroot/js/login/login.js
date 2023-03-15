const email = document.getElementById("txtEmail");
const password = document.getElementById("txtPassword");
const ingresar = document.getElementById("btnIngresar");

email.addEventListener("input", () => {
    ingresar.disabled = email.value === "";
    console.log(email.value)
});

console.log("ejecutnaod")