export async function signup(newUser){
    const response = await fetch('http://localhost:5134/signup', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });
    
    return response;
}

export async function login(user){
    const response = await fetch('http://localhost:5134/login', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
    const responseMessage = await response.json();
    return responseMessage;
}
