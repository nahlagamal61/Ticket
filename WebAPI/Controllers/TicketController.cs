namespace WebAPI.Controllers
{
    using Application.Interfaces;
    using AutoMapper;
    using Azure;
    using Domains.Entities;
    using Domains.Enums;
    using Hangfire;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using WebAPI.DTOS;
    using WebAPI.Filter;
    using WebAPI.Wrapper;

    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _repo;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterPaging filterPaging )
        {
           var tickets = await _repo.GetAllAsync(filterPaging);
           var ticketsDto = _mapper.Map<ICollection<TickerResDTO>>(tickets);

           var response = new CustomResponse<ICollection<TickerResDTO>>(ticketsDto, "", (int)HttpStatusCode.OK);
           return Ok(response );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _repo.GetByIdAsync(id);
            if (ticket == null)
            {
                return BadRequest(new CustomResponse<Ticket>(ticket, "This ticket is not valid", (int)HttpStatusCode.BadRequest));
            }
            var ticketDto = _mapper.Map<TickerResDTO>(ticket);

            return Ok(new CustomResponse<TickerResDTO>(ticketDto, "", (int)HttpStatusCode.OK));
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketDto ticketDto)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("test" + ticketDto);
                var newTicket = _mapper.Map<Ticket>(ticketDto);
                var addedTicket = await _repo.AddTicketAsync(newTicket);

                //Console.WriteLine("test" + addedTicket.CreationDateTime);

                var jobId = BackgroundJob.Schedule(() => _repo.HandelTicketStatusAsync(addedTicket.ID, TicketStatus.Handled), TimeSpan.FromMinutes(60));
                var response = new CustomResponse<Ticket>(addedTicket, message: "ticket added successfully", (int)HttpStatusCode.OK);
                return Ok(response);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                var response = new CustomResponse<Ticket>(data: null,"", statusCode: (int)HttpStatusCode.BadRequest);
                response.Errors = (string[]) errors;
                return BadRequest(response);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicketStatus([FromQuery] int id, [FromQuery] TicketStatus status)
        {
            try
            {
                var ticket = await _repo.HandelTicketStatusAsync(id, status);

                return Ok(new CustomResponse<Ticket>(ticket , "Ticket status updated successfully.", (int)HttpStatusCode.OK));

            }
            catch (Exception ex)
            {
                return Ok(new CustomResponse<Ticket>(null, "Failed to update ticket status", (int)HttpStatusCode.BadRequest));

            }
        }
    }
}