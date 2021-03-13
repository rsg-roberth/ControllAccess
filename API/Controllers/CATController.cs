using System;
using System.Collections;
using Domain.Command;
using Domain.Command.CAT;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/CATS")]
    public class CATController: ControllerBase
    {
        [HttpGet]
        public IEnumerable GetAll([FromServices] ICATRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet("{id:Guid}")]
        public CAT GetById([FromServices] ICATRepository repository, Guid id)
        {
            return repository.GetById(id);
        }

        [HttpDelete("{id:Guid}")]
        public void Delete([FromServices] ICATRepository repository, Guid id)
        {
            repository.Delete(id);
        }

        [HttpPut("{id:Guid}")]
        public GenericCommandResult Update([FromBody] UpdateCATCommand command, [FromServices] CATHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateCATCommand command, [FromServices] CATHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }
    }    
}