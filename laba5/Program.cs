var builder = WebApplication.CreateBuilder(args);

// ��������� �����������
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();

// ��������� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://example.com") // �������� example.com �� ���������� �����
                           .AllowAnyHeader()
                           .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();// AddSwaggerGen() ��������� ������������� ��, ������� ���������� ������������ OpenAPI ��� ������ API

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();// UseSwagger() ��������� ������������� ��, ������� �������� ���-��������� Swagger UI, ������� ������������� ������������ ��� �������� ����� API
    app.UseSwaggerUI();// UseSwaggerUI() ��������� ������������� ��, ������� �������� ���-��������� Swagger UI, ������� ������������� ������������ ��� �������� ����� API
}

app.UseHttpsRedirection();// UseHttpsRedirection() ��������� ������������� ��, ������� �������������� HTTP-������� �� HTTPS

// ���������� �������� CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization(); // UseAuthorization() ��������� ������������� ��, ������� ���������, ����������� �� ������������, ������ ��� ��������� ��������

app.MapControllers();// MapControllers() ��������� �������� � ������� �������� � ������������

app.Run();// Run() ��������� ����������


/*
 * � ���� ����:

���� ����������� � �������, ��� ����� ���� ������� ��� �������.
���� ��������� CORS, ����������� ���-����������� � ������������� ������ ���������� � ������ API.
 � ������� ��� ��������� ������ ���� ������� � ������������� ������.
*/