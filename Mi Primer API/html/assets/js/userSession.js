const usersDetail = document.querySelector('.user-detail');
const editUser = document.querySelector('.edit-user');

let output = '';
let userNameSession = sessionStorage.userName;
const url = 'https://localhost:5001/Usuario/'+ userNameSession;
const urlId = 'https://localhost:5001/Usuario';

const userNameValue = document.getElementById('username-value');
const emailValue = document.getElementById('emailid-value');
const passValue = document.getElementById('password-value');
let idValue = '';

let userContent = '';
let emailContent = '';
let passwordNameContent = '';


document.getElementById("editUser").style.display = "none";
const successMessage = document.getElementById("success-message");

if (typeof(Storage) !== 'undefined') {
    console.log(`Si es compatible, Mi nombres es ${userNameSession}`);
  } else {
    console.log("No es compatible");
  }


//Get users
//fetch(`${url}/${username}`)
fetch(url)
    .then(response => response.json())
    .then(data => {
        console.log(data);
        output = 
        `
        <div class="card mt-4 col-md-6 bg-light">
            <div class="card-body" data-id=${data.correo}>
                <h3>Información del Usuario</h3>
                <h5 class="card-title">${data.nombreUsuario}</h5>
                <p class="card-text email">${data.correo}</p>
                <p class="card-text password d-none">${data.contraseña}</p>
                <a href="#" class="card-link" id="delete-user">Delete</a>
                <a href="#" class="card-link" id="edit-user">Editar</a>
            </div>
        </div>
        `
        if (data.correo == null) {
          usersDetail.innerHTML = `<h3>Usuario no existe</h3>`
        }
        else{
          usersDetail.innerHTML = output;
        }
    })
    
  usersDetail.addEventListener('click', (e) => {
    e.preventDefault();
    let delButtonIsPressed = e.target.id == 'delete-user';
    let editButtonIsPrecced = e.target.id == 'edit-user';

    idValue = e.target.parentElement.dataset.id;
    let usernameId = e.target.parentElement.querySelector('.card-title').textContent;
    console.log(usernameId);

    //Delete user
    if (delButtonIsPressed) {
        fetch(`${urlId}/${idValue}`, {
            method: 'DELETE',
        })
        .then(res => res.json())
        .then(() => location.reload())
    }

    if(editButtonIsPrecced){
        document.getElementById("editUser").style.display = "block";
        const parent = e.target.parentElement;
        userContent = parent.querySelector('.card-title').textContent;
        emailContent = parent.querySelector('.email').textContent;
        passwordNameContent = parent.querySelector('.password').textContent;

        userNameValue.value = userContent;
        emailValue.value = emailContent;
        passValue.value = passwordNameContent;
        idValue = e.target.parentElement.dataset.id;

        console.log(userContent, emailContent,passwordNameContent,idValue);
    }  
});


  editUser.addEventListener('submit', (e) => {
      e.preventDefault();
      console.log(idValue);
      fetch(`${urlId}/${idValue}`, {
          method: 'PUT',
          headers: {
              'Content-Type' : 'application/json'
          },
          body: JSON.stringify({
              nombreUsuario:userNameValue.value,
              correo:emailValue.value,
              contraseña:passValue.value,
          })
      })
      .then(function(response) {
          if (!response.ok) {
              successMessage.innerHTML = `
              <div class="alert alert-warning" role="alert">
                  Error en actualizar!!
              </div>
          `;  
          throw Error(response.statusText);
          }
          // Here is where you put what you want to do with the response.
          location.reload();
          successMessage.innerHTML = `
              <div class="alert alert-success" role="alert">
                  Se ha actualizado correctamente!!
              </div>
          `;
      })
      .catch(function(error) {
          console.log('Looks like there was a problem: \n', error);
      });
  });
  
