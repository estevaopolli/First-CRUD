const $button = document.querySelector("#signup-button");
$button.addEventListener('click', signup);

async function signup(){

    const username = document.querySelector("#username").value;
    const email = document.querySelector("#email").value;
    const password = document.querySelector("#password").value;

    const response = await fetch('http://localhost:5134/usuarios', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username: username,
            email: email,
            password: password
        })
    });
    
    const responseMessage = await response.json();

    if(!response.ok){
        alert(responseMessage.message);
    }
    else{
        window.location.href = "./login.html"
    }
    
}
