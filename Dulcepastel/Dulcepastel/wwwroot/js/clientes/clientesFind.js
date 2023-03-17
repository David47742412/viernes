const labelFind = document.getElementById('lblFind');
const listFind = document.getElementById("listFind");

//para realizar acciones curd
const btnAccion = document.getElementById("btnAccion")
const listAcciones = document.getElementById("listAccion");

listFind.addEventListener('change', () => {
    if (listFind.options[listFind.selectedIndex].text === 'dirección' || listFind.options[listFind.selectedIndex].text === 'fecha de Nacimiento') {
        labelFind.textContent = `Ingrese la ${listFind.options[listFind.selectedIndex].text}`;
    } else {
        labelFind.textContent = `Ingrese el ${listFind.options[listFind.selectedIndex].text}`;
    }
});

listAcciones.addEventListener('change', () => {
    if (listAcciones.selectedIndex === 0) {
        btnAccion.style.backgroundColor = "#50d07f";
        btnAccion.textContent = "Registrar";
    } else if (listAcciones.selectedIndex === 1) {
        btnAccion.style.backgroundColor = "blue";
        btnAccion.textContent = "Consultar";
    }
    else if (listAcciones.selectedIndex === 2) {
        btnAccion.style.backgroundColor = "#006400";
        btnAccion.textContent = "Modificar";
    } else {
        btnAccion.style.backgroundColor = "red";
        btnAccion.textContent = "Eliminar";
    }
})

