using System;
using System.Collections.Generic;
using Domain.Command;
using Domain.Command.Access;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/accesses")]
    public class AccessController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Access> GetAll([FromServices] IAccessRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet("{id:Guid}")]
        public Access GetById([FromServices] IAccessRepository repository, Guid id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateAccessCommand command, [FromServices] AccessHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpPut("{id:Guid}")]
        public GenericCommandResult Update([FromBody] UpdateAccessCommand command, [FromServices] AccessHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpDelete("{id:Guid}")]
        public void Delete([FromServices] ICustomerRepository repository, Guid id)
        {
            repository.Delete(id);
        }

        
    }
    
}