const registerUser = document.querySelector('.register-user');

const userNameValue = document.getElementById('username-value');
const emailValue = document.getElementById('emailid-value');
const passValue = document.getElementById('password-value');

const url = 'https://localhost:5001/Usuario/register';
const successMessage = document.getElementById("success-message")

//Create users
// METODO POST
registerUser.addEventListener('submit', (e) => {
    e.preventDefault();

    
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify({
            nombreUsuario:userNameValue.value,
            correo:emailValue.value,
            contraseña:passValue.value
        })
    })
    .then(function(response) {
	    if (!response.ok) {
            successMessage.innerHTML = `
            <div class="alert alert-warning" role="alert">
                Error en el registro!!
            </div>
        `;  
	    throw Error(response.statusText);
		}
		// Here is where you put what you want to do with the response.
        successMessage.innerHTML = `
            <div class="alert alert-success" role="alert">
                Te has registrado correctamente!!
            </div>
        `;
        alert('Te has registrado correctamente!!');


	})
	.catch(function(error) {
		console.log('Looks like there was a problem: \n', error);
	});

    

    
})