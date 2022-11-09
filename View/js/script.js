var url = 'http://localhost:3000/'


function cadastrar() {
    //validacao de alguns dos inputs

    if (!validaNome('nome-completo')) {
        return
    }

    if (!validaData('data-nascimento')) {
        return
    }

    if (!validaNome('nome-completo')) {
        return
    }

    let body =
    {
        'Nome': document.getElementById('nome-completo').value,
        'Nascimento': document.getElementById('data-nascimento').value,
    }

    fetch(url + "Leitor",
        {
            'method': 'POST',
            'redirect': 'follow',
            'headers':
            {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            'body': JSON.stringify(body)
        })
        //checa se requisicao deu certo
        .then((response) => {
            if (response.ok) {
                return response.text()
            }
            else {
                return response.text().then((text) => {
                    throw new Error(text)
                })
            }
        })
        //trata resposta
        .then((output) => {
            console.log(output)
            alert('Cadastro efetuado! :D')
        })
        //trata erro
        .catch((error) => {
            console.log(error)
            alert('Não foi possível efetuar o cadastro! :(')
        })

    function validaNome(id) {
        let divNome = document.getElementById(id)
        if (divNome.value.trim().split(' ').length >= 2) {
            divNome.style.border = 0
            return true
        }
        else {
            divNome.style.border = 'solid 1px red'
            return false
        }
    }

    function validaData(id) {
        let divData = document.getElementById(id)
        if (divData.value.length > 0) {
            divData.style.border = 0
            return true
        }
        else {
            divData.style.border = 'solid 1px red'
            return false
        }
    }
}