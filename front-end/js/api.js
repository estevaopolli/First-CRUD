export async function signup(usuario){
    const response = await fetch('http://localhost:5134/usuarios', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(usuario)
    });
    
    return response;
}
