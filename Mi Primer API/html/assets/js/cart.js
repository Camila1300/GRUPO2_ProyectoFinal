const usersList = document.querySelector('.users-list');
const url = 'https://localhost:5001/Producto';

let idValue = '';

const successMessage = document.getElementById("success-message");

let output = '';

const renderUsers = (users) => {
    users.forEach(user => {
        output += `
        <div class="card mt-4 col-md-6 bg-light producto">
        <img src="https://st2.depositphotos.com/4845131/7223/v/600/depositphotos_72231685-stock-illustration-icon-hangers.jpg" class="card-img-top" alt="...">
            <div class="card-body" data-id=${user.idProducto}>
                <h5 class="card-title" data-id=${user.nombre}>${user.nombre}</h5>
                <p class="card-text precio">${user.precioCompra}</p>
                <label class="form-label">Cantidad</label>
                <input class="form-control cantidadCarrito" id="cantidadCarrito">
                <a href="#" class="card-link" id="add-carrito">Añadir al Carrito</a>
            </div>
        </div>
        `;
        });
        usersList.innerHTML = output;
}

    
    let precioContent = '';
    let cantidadValue = '';
    

    //Get users
    fetch(url)
        .then(response => response.json())
        .then(data => renderUsers(data))
        

    usersList.addEventListener('click', (e) => {
        e.preventDefault();
        let addButtonIsPrecced = e.target.id == 'add-carrito';

        let id = e.target.parentElement.dataset.id;

        if(addButtonIsPrecced)
        {
            const parent = e.target.parentElement;
            precioContent = parent.querySelector('.precio').textContent;
            cantidadValue = parent.querySelector('.cantidadCarrito').value;
            console.log(id, precioContent, cantidadValue);
        }
});