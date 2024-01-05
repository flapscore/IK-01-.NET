var builder = WebApplication.CreateBuilder(args);

// Настройка логирования
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();

// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://example.com") // Замените example.com на актуальный домен
                           .AllowAnyHeader()
                           .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();// AddSwaggerGen() добавляет промежуточное ПО, которое генерирует спецификацию OpenAPI для вашего API

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();// UseSwagger() добавляет промежуточное ПО, которое включает веб-интерфейс Swagger UI, который предоставляет документацию для конечных точек API
    app.UseSwaggerUI();// UseSwaggerUI() добавляет промежуточное ПО, которое включает веб-интерфейс Swagger UI, который предоставляет документацию для конечных точек API
}

app.UseHttpsRedirection();// UseHttpsRedirection() добавляет промежуточное ПО, которое перенаправляет HTTP-запросы на HTTPS

// Применение настроек CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization(); // UseAuthorization() добавляет промежуточное ПО, которое проверяет, авторизован ли пользователь, прежде чем выполнять действие

app.MapControllers();// MapControllers() добавляет маршруты к методам действий в контроллерах

app.Run();// Run() запускает приложение


/*
 * В этом коде:

Есть логирование в консоль, что может быть полезно для отладки.
Есть настройки CORS, позволяющие веб-приложениям с определенного домена обращаться к вашему API.
 В примере они разрешают доступ всем методам с определенного домена.
*/