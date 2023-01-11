
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


//------------------------------------------------------------------------
app.Run();
 // criamos um builder do tipo web e no final o rodamos



 //AGORA VAMOS CRIAR UM OBJETO PARA PASSAR SEUS PARAMETROS DENTRO DE UMA REQUISIÇÃO POST
 public class Product {

    public string Code { get; set; } // podemos escrever prop e dar um tab para escrever o codigo defaut
                                        // podemos alterar o valor do metodo

    public string Name { get; set; } // esses ssão os metodos que retornarão valores 

 }