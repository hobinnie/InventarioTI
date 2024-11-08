// Seleccionamos el botón de alternar modo oscuro
const darkModeToggle = document.getElementById('darkModeToggle');

// Verificamos si el usuario ya tiene preferencia por el modo oscuro
const userPrefersDark = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;

// Al cargar la página, aplicamos el modo oscuro si es necesario
if (localStorage.getItem('darkMode') === 'enabled' || userPrefersDark) {
    document.body.classList.add('dark-mode');
}

// Evento al hacer clic en el botón de alternar
darkModeToggle.addEventListener('click', () => {
    document.body.classList.toggle('dark-mode');

    // Guardamos la preferencia del usuario en localStorage
    if (document.body.classList.contains('dark-mode')) {
        localStorage.setItem('darkMode', 'enabled');
    } else {
        localStorage.setItem('darkMode', null);
    }
});
