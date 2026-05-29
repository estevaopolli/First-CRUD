import { login } from "./api.js";

const $loginButton = document.querySelector("#login-button");
$loginButton.addEventListener('click', ValidateLogin);

async function ValidateLogin() {
    const $email = document.querySelector("#email").value;
    const $password = document.querySelector("#password").value;

    const user = {
        Email: $email,
        Password: $password
    };

    await login(user);
    console.log("debug");
}