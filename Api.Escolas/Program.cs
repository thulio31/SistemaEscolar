using Aluno._01Services;
using Aluno._02Repository;
using Aluno._02Repository.data;
using Escola;
using Escola._01Services;
using Escola._01Services.Interfaces;
using Escola._02Repository;
using Escola._02Repository.Interfaces;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._02_Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Inicializadorbd.Inializador();
builder.Services.AddAutoMapper(typeof(MappingProfile)); //adicionando o Mapper

//Alunos
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoService, AlunoService>();

//Disciplina
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();

//Funcionario
builder.Services.AddScoped<IFuncionarioRepository, FuncionariosRepository>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

//Notas
builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddScoped<INotasService, NotasService>();

//Turma
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<ITurmaService, TurmaService>();

//Usuario

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
