using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class TareaRecurrente : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TareaRecurrente(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

            /*DateTime now = DateTime.Now;
            DateTime proximaEjecucion = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0); 

            if (now > proximaEjecucion)
            {
                proximaEjecucion = proximaEjecucion.AddDays(1); 
            }

            TimeSpan tiempoRestante = proximaEjecucion - now;

            await Task.Delay(tiempoRestante, stoppingToken);*/

            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                string url = "https://localhost:7027/Emailer"; 

                HttpResponseMessage response = await httpClient.GetAsync(url, stoppingToken);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Envio de correos correcto");
                }
                else
                {
                    Console.WriteLine("Envio de correos incorrecto papu");
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(50), stoppingToken); 
        }
    }
}

