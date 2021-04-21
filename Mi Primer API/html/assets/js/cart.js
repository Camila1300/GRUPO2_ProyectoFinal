const usersList = document.querySelector('.users-list');
const usersDetail = document.querySelector('.user-detail');
const editUser = document.querySelector('.edit-user');

let output = '';
let userNameSession = sessionStorage.userName;
const url = 'https://localhost:5001/Usuario/' + userNameSession;
const urlProducts = 'https://localhost:5001/Producto';
const urlCarrito = 'https://localhost:5001/Carrito';

const userNameValue = document.getElementById('username-value');
const firstNameValue = document.getElementById('firstname-value');
const lastNameValue = document.getElementById('lastname-value');
const emailValue = document.getElementById('emailid-value');
const passValue = document.getElementById('password-value');
const phoneValue = document.getElementById('phone-value');
let idValue = '';

//Se crean esta variables donde se almacena los cambios del form edit
let userContent = '';
let firstNameContent = '';
let lastNameContent = '';
let emailContent = '';
let passwordNameContent = '';
let phoneNameContent = '';

var menTshirtWhite = "https://cdn.shopify.com/s/files/1/0402/4117/products/WHITE_F_7cb99670-47bb-4088-8142-fe55fec2c5c9.jpg";

document.getElementById("editUser").style.display = "none";
const successMessage = document.getElementById("success-message");

if (typeof(Storage) !== 'undefined') {
    console.log(`Si es compatible, Mi nombres es ${userNameSession}`);
  } else {
    console.log("No es compatible");
  }

//Get Productos
const renderUsers = (products) => {
    products.forEach(product => {
        output += `
        <div class="card mt-4 col-md-6 bg-light producto">
        <img src="https://st2.depositphotos.com/4845131/7223/v/600/depositphotos_72231685-stock-illustration-icon-hangers.jpg" class="card-img-top" alt="...">
            <div class="card-body" id="idProducto" data-id=${product.idProducto}>
                <h5 class="card-title" data-id=${product.nombre}>${product.nombre}</h5>
                <p class="card-text precio">${product.precioCompra}</p>
                <p class="card-text id">${product.idProducto}</p>
                <label class="form-label">Cantidad</label>
                <input class="form-control cantidadCarrito">
                <a href="#" class="card-link" id="agregarCarrito">Añadir al Carrito</a>
            </div>
        </div>
        `;
        });
        usersList.innerHTML = output;
}

fetch(urlProducts)
        .then(response => response.json())
        .then(data => renderUsers(data))

let compras = [];
    // object to add
let compra = {};

    
    usersList.addEventListener('click', (e) => {
    e.preventDefault();
    let delButtonIsPressed = e.target.id == 'delete-user';
    let editButtonIsPrecced = e.target.id == 'edit-user';
    let addButtonIsPrecced = e.target.id == 'agregarCarrito';

    //Este id no se cambia
    idValue = e.target.parentElement.dataset.id;
    
    if(addButtonIsPrecced){
        const parent = e.target.parentElement;
        compra = {
            precioCompra: parent.querySelector('.precio').textContent,
            idProducto: parent.querySelector('.idProducto'),
            cantidad: parent.querySelector('.cantidadCarrito').value,
            total: parent.querySelector('.cantidadCarrito').value * parent.querySelector('.precio').textContent
            }
        compras.unshift(compra);
        console.log(compras);
        console.log(compra);
    }

   /**  let sum = 0;
    compras.forEach(function(item) {
        sum += item.total;
        console.log(item.precio, item.id, sum);
    }); **/

    let sum_total = '';
    sum_total = sum;

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
        firstNameContent = parent.querySelector('.card-text').textContent;
        lastNameContent = parent.querySelector('.lastname').textContent;
        emailContent = parent.querySelector('.email').textContent;
        passwordNameContent = parent.querySelector('.password').textContent;
        phoneNameContent = parent.querySelector('.phonenumber').textContent;

        //Aqui se llenan los campos del form con la tarjeta de detalles
        userNameValue.value = userContent;
        firstNameValue.value = firstNameContent;
        lastNameValue.value = lastNameContent;
        emailValue.value = emailContent;
        passValue.value = passwordNameContent;
        phoneValue.value = phoneNameContent;
        idValue = e.target.parentElement.dataset.id;

        console.log(userContent, firstNameContent, lastNameContent, emailContent,passwordNameContent,phoneNameContent,idValue);
    }  
});

comprarCarrito.addEventListener('submit', (e) => {
    e.preventDefault();

    compras.forEach(compra => {
        fetch(urlCarrito, {
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                precioProducto:compra.precio,
                total:compra.total,
                usuarioCompra: userNameSession,
                idProducto:compra.idproducto,
                idCompra:compra.idcarrito
            })
        }) 
    });
    successMessage.innerHTML = `
              <div class="alert alert-success" role="alert">
                  Se ha compro correctamente!!
              </div>
          `;


    
})


  editUser.addEventListener('submit', (e) => {
      e.preventDefault();
      console.log(idValue);
      fetch(`${urlId}/${idValue}`, {
          method: 'PUT',
          headers: {
              'Content-Type' : 'application/json'
          },
          body: JSON.stringify({
              id:idValue.value,
              userName:userNameValue.value,
              firstName:firstNameValue.value,
              lastName:lastNameValue.value,
              emailId:emailValue.value,
              password:passValue.value,
              confirmPassword:passValue.value,
              phoneNumber: phoneValue.value,
              userRole:"User"
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
  
