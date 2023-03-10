using Microsoft.AspNetCore.Mvc;
// as duas primeiras linhas criam o nosso host que é o cara que vai ficar escutando tudo que está sendo pedido
//escutando as requisições

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "AOBA!!!!!"); //o primeiro end point, nossa primeira rota, vamos criar outro endpoint para teste
app.MapGet("/user", () => "Jucelino");


//-------------------------------------------------------------------
//podemos também criar um objeto que o proprio c# ira transforma-lo em um json
//temos aqui e a cima uma expressão lambida que é uma função roda apenas em uma 
//linha que leva alguns parametros para ser lambda
app.MapPost("/", () => new {Name =  "teste json", Age = 20});
//-------------------------------------------------------------------


//podemos também alterar e adicionar informações, como no exemplo abaixo

    //1- app.MapGet("/AddHeader", (HttpResponse response) => response.Headers.Add("Teste", "testeteste"));

//podemosm também adicionar uma informação para ser retornada no meu body

app.MapGet("/AddHeader", (HttpResponse response) => { // aqui temos uma função lambda, qe é uma expressão que 
                                                            //retorna uma função usando os operadores logicos =>
    response.Headers.Add("Teste", "testeteste");

    return new {Name = "teste json", Age = 20};
    
});
//------------------------------------------------------------------------
//agora criamos o nosso end point junto com a função lambda, como ja foi feito anteriormente -2-

app.MapPost("/cadastrarproduct", (Product product) => { //nosso endpoint aqui leva como metodo o POST pois de acordo com a logica do crud esse endpoint 
                                                        //acessa o metodo post para salvar informações em um banco de dados.  //  O " - " É PRA CONCATENAR O CODIGO COM O NOME DO PRODUTO
    return product.Code + " - " + product.Name;
});

// ALERTA !!!! PARA VOCE CADASTAR O PRODUTO COMO TESTE VC DEVE IR NO SEU PROGRAMA DE CLIENT NO CASO O POSTMAN
//PROCURAR PELO ENDEREÇO DA REQUISIÇÃO COLOCAR NO BODY - RAW E ESCREVER MANUALMENTE O NOSSO CADASTRO "{ "Code": "1", "Name": "HD SSD"}"
//PASSAMOS INFORMAÇÃO ATRAVÉS DO CORPO
//--------------------------------------------------------------------------------

//também podemos passar informações atraves da url, lembrando sempre de que informações mais sigilosas geralmente nao usam esse metodo
//de envio, EXS

//api.app.com/users?datastart={date}&datastart={date}&dateend={date} - aqui estamos extraindo um relatorio de informações
//pela url mas podemos fazer o mesmo pela rota como abaixo !
 app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
 });
//-------------------------------------------------------------------------------------------------


//api.app.com/user/{code} //atraves da rota é como se ele pertencesse ao endpoint


 app.MapGet("/getproduct/{code}", (string code) => {
    return code; //retornando pela rota
 });
//------------------------------------------------------------------------
app.Run();
 // criamos um builder do tipo web e no final o rodamos



 //AGORA VAMOS CRIAR UM OBJETO PARA PASSAR SEUS PARAMETROS DENTRO DE UMA REQUISIÇÃO POST -1-
 public class Product { // temos a nossa classe do tipo "Produto"  e os atributos da nossa classe são strings o codigo do produto 
                        //e o nome do produto, e esses atributos estão atrelados aos metodos get e set ou seja eles podem variar 

    public string Code { get; set; } // podemos escrever prop e dar um tab para escrever o codigo defaut
                                        // podemos alterar o valor do metodo

    public string Name { get; set; } // esses ssão os metodos que retornarão valores 

 }

 //-----------------------------------------------------------------------------------------