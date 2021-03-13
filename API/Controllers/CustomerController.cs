using System;
using System.Collections.Generic;
using Domain.Command;
using Domain.Command.Customer;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomerController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Customer> GetAll([FromServices] ICustomerRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet("{id:Guid}")]
        public Customer GetById([FromServices] ICustomerRepository repository, Guid id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateCustomerCommand command, [FromServices] CustomerHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpPut("{id:Guid}")]
        public GenericCommandResult Update([FromBody] UpdateCustomerCommand command, [FromServices] CustomerHandler handler)
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