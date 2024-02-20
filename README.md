# signup

Sito realizzato con ASP.NET MVC

CONSEGNA:
Modificare [il progetto precedente](https://github.com/alicefgl/FORM-dotnetMVC) in questo modo:

 - Il sito deve esporre nella barra di navigazione le pagine: Home, Privacy, SignUp, Purchase, Cart
 - La pagina di SignUp deve contenere un form di registrazione
 - Una volta compilato il form di SignUp l'utente deve essere rimandato ad una pagina di Riepilogo dei dati inseriti (raggiungibile solo tramite metodo HTTP-POST).
 - La pagina di Purchase deve esporre un form in cui l'utente possa inserire: nome del prodotto da acquistare, quantità di interesse.
 - Una volta compilato il form di Purchase l'utente deve essere rimandato alla pagina Cart, in cui comparirà l'elenco dei prodotti inseriti

PROCEDIMENTO:
Sulla base degli esercizi precedenti, ho aggiunto un nuovo form contenente i prodotti (che comporranno poi la classe Prodotti),
Il model utilizzato è una lista di classe Prodotto, che contiene il nome del prodotto e la quantità desiderata come suoi attributi.
La pagina Purchase, è un form all'interno del quale si possono inserire il nome e la quantità del prodotto desiderato tramite due caselle di testo, tramite le quali si popola il model (passato dall'Home Controller come lista di Prodotti).
Alla fine della pagina è posto un tasto submit, tramite il quale si passa alla View "Cart".
Di seguito la pagina Purchase:

```
@model Prodotto;
@{
    ViewData["Title"] = "Purchase";
}

<div class="text-center">
    <h1 class="display-4">Purchase</h1>

    <form class="m-2" method="post" asp-action="Cart">
        <div class="form_group">
            <label asp-for="_NomeP">Nome del prodotto:</label>
            <input asp-for="_NomeP" class="form-control">
        </div>

        <div class="form_group">
            <label asp-for="quantita">Quantità desiderata:</label>
            <input asp-for="quantita" class="form-control">
        </div>

        <button type="submit" class="btn btn-primary w-25 mb-2">Aggiungi al carrello</button>
    </form>
    
</div>
```

Per stampare il riepilogo dell'ordine, ho creato una nuova View "Cart", contentente un ulteriore form che stampi a video il contenuto del model.
La View "Cart" viene mostrata tramite una procedura di HTTP Post, infatti essa è raggiungibile solamente tramite la pagina di acquisto dei prodotti, e non tramite l'URL del sito (come invece sarebbe stato se si fosse trattato di una procedura di HTTP GET).
All'interno dell'Home Controller, quando si richiama la View contenente i prodotti nel carrello, si passa alla funzione un Prodotto "pr", il quale viene aggiunto alla lista e permette di effettuare la Post.
```
    [HttpGet]
    public IActionResult Purchase()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cart(Prodotto pr)
    {
        Prodotti.Add(pr);
        return View(Prodotti);
    }
```
La View "Purchase", invece, è raggiungibile tramite la navbar del sito collegandola ad un nav-item, in questo modo:
```
     <li class="nav-item">
                <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Purchase">Purchase</a>
     </li>
```
_____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
UPDATE CONSEGNA:
Modificare il progetto Signup&Purchase precedente in modo che utilizzi le variabili di sessione per fare login.

PROCEDIMENTO:
All'interno di Program.cs si abilita il servizio per gestire le sessioni, specificando le opzioni relative ai cookies ed alla durata della sessione stessa:
```
// Add services to the container.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();
```
Applicare le modalità prima definite per l'applicazione in uso:
```
app.UseSession();
```
All'interno dell'HomeController, si salvano le variabili di sessione tramite il comando SetString:
```
public IActionResult Index()
{
    HttpContext.Session.SetString("NomeUtente", "Alice Foglietta");
    return View();
}
```
_____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
UPDATE CONSEGNA:
- Modificare il progetto SignupSession precedente in modo che utilizzi un tema Bootstrap preso da qui: https://bootswatch.com/
- Se volete integrare boostrap nella sua vesione cdn, potete prtelevare il link da qui: https://getbootstrap.com/
- Qui trovate alcune istruzioni... https://www.youtube.com/watch?v=bUgFQeUaze0&ab_channel=DigitalTechJoint

PROCEDIMENTO:
Dopo aver installato il tema (Darkly -> https://bootswatch.com/darkly/) ho salvato il file bootstrap.css all'interno della cartella wwwroot, rinominandolo come site.css (in modo che venisse riconosciuto dal programma).
Ho poi integrato bootstrap con la sua versione CDN copiando il link fornito dalla consegna all'interno di _Layout.cshtml, in questo modo:
```
    <link rel="stylesheet" href="~/css/site.css/"/>
```
```
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
```
Per ultima cosa ho modificato la navbar copiando il codice css fornito da bootswatch e moficandolo inserendo le varie pagine create in precedenza (SignUp, Purchase ecc...), e aggiungendo un menu a tendina che mostrasse la possibilità di accedere alle pagine (questo verrà migliorato in futuro con l'aggiunta di altre pagine o la riorganizzazione di quelle già esistenti).
```
            <div class="dropdown-menu">
                <a class="dropdown-item" asp-area="" asp-controller="Home" asp-action="Home">Home</a>
                <a class="dropdown-item" asp-area="" asp-controller="Home" asp-action="Purchase">Purchase</a>
                <a class="dropdown-item" asp-area="" asp-controller="Home" asp-action="Cart">Cart</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" asp-area="" asp-controller="Home" asp-action="SignUp">Sign Up</a>
            </div>
```
Ho inserito la pagina di SignUp in seguito ad un separatore in moda dividere le pagine legate ai "servizi" del sito da quelle legate all'utente (implementabile aggiungendo la pagina Cart in questa sezione).
