﻿using FrontEnd;
using FrontEndEscola;
using System.Net.Http.Json;
using System.Text.Json;
HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7116/")
};
SistemaGlobal sistema = new SistemaGlobal(cliente);
sistema.IniciarSistema();


SistemaEstudante sistemaE = new SistemaEstudante(cliente);
sistema.IniciarSistemaEstudante();