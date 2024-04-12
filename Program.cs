var AllPics = new List<string>();

if (!File.Exists("pics.txt"))
    File.WriteAllText("pics.txt", "");
else
    AllPics = File.ReadAllLines("pics.txt").ToList();

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();



//make a randomizer from 0 to AllPics.Count
app.MapGet("/",  (HttpContext context ) =>
{
    var random = new Random();
    var index = random.Next(0, AllPics.Count);

  context.Response.ContentType = "text/html";
    return  context.Response.WriteAsync($"<img src='{AllPics[index]}' />");

});

app.Run();
