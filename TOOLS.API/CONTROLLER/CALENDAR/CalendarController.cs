using APPLICATION.DOMAIN.DTOS.RESPONSE;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TOOLS.API.CONTROLLER.CALENDAR;

[Route("api/[controller]")]
[ApiController]
public class CalendarController : ControllerBase
{
    public CalendarController() { }

    /// <summary>
    /// Método responsavel por recuperar eventos do calendário.
    /// </summary>
    /// <returns></returns>
    [HttpGet("get/events")]
    [EnableCors("CorsPolicy")]
    [SwaggerOperation(Summary = "Recuperar eventos.", Description = "Método responsavel por recuperar eventos do calendário.")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<List<object>> GetEvents()
    {
        try
        {
            var events = new List<object>()
        {
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 8, 3, 0, 0),
                eventEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 8, 7, 0, 0),
                eventName = "⛱️ Relax for 2 at Marienbad",
                eventColor = "indigo"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 12, 10, 0, 0),
                eventEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 12, 11, 0, 0),
                eventName = "Team Catch-up",
                eventColor = "sky"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 18, 2, 0, 0),
                eventEnd = "",
                eventName = "✍️ New Project (2)",
                eventColor = "yellow"
            },
            // Current month
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 10, 0, 0),
                eventEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 11, 0, 0),
                eventName = "Meeting w/ Patrick Lin",
                eventColor = "sky"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 19, 0, 0),
                eventEnd = "",
                eventName = "Reservation at La Ginestre",
                eventColor = "indigo"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 3, 9, 0, 0),
                eventEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 3, 10, 0, 0),
                eventName = "✍️ New Project",
                eventColor = "yellow"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, 21, 0, 0),
                eventEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, 22, 0, 0),
                eventName = "⚽ 2021 - Semi-final",
                eventColor = "red"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 4, 9, 10, 0, 0),
                eventEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 9, 11, 0, 0),
                eventName = "Meeting w/Carolyn",
                eventColor = "sky"
            },
            new
            {
                eventStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 9, 13, 10, 0),
                eventEnd = "",
                eventName = "Pick up Marta at school",
                eventColor = "emerald"
            }
        };

            return events;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);

            return null;
        }

    }
}
