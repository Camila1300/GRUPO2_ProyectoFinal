const loginUser = document.querySelector('.login-user')

const emailValue = document.getElementById('username-value');
const passValue = document.getElementById('password-value');

const url = 'http://localhost:5000/Usuario/Login';
const successMessage = document.getElementById("success-message")

//Create users
// METODO POST
loginUser.addEventListener('submit', (e) => {
    e.preventDefault();

    
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify({
            correo:emailValue.value,
            contraseña:passValue.value
        })
    })
    .then(function(response) {
	    if (!response.ok) {
	    throw Error(response.statusText);
		}
		// Here is where you put what you want to do with the response.
        sessionStorage.userName = emailValue.value;
        window.location.href = "http://127.0.0.1:5500/html/userSession.html";
        alert("Te has logueado correctamente");
	})
	.catch(function(error) {
		console.log('Looks like there was a problem: \n', error);
        alert("Datos Incorrectos");
	});
})