using CqrsWithMediatR.Queries.CustomerQueries.GetCustomerDetails;
using CqrsWithMediatR.Queries.CustomerQueries.GetCustomersList;
using CqrsWithMediatR.Queries.CustomerQueries.IsCustomerExists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CqrsWithMediatR.Application.Commands.CustomerCommands.UpdateCustomer;
using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Application.Commands.CustomerCommands.CreateCustomer;
using CqrsWithMediatR.Application.Commands.CustomerCommands.DeleteCustomer;
using System;

namespace CqrsWithMediatR.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _mediator.Send(new GetCustomersListQuery());
            return View(customers);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Customer customer = await _mediator.Send(new GetCustomerDetailsQuery { CustomerId = id });
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand createCustomerCommand)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(createCustomerCommand);
                return RedirectToAction(nameof(Index));
            }
            return View(createCustomerCommand);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(long id)
        {

            Customer customer = await _mediator.Send(new GetCustomerDetailsQuery { CustomerId = id });
            if (customer == null)
            {
                return NotFound();
            }

            UpdateCustomerCommand updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customer);

            return View(updateCustomerCommand);
        }

        // POST: Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, UpdateCustomerCommand updateCustomerCommand)
        {
            if (updateCustomerCommand == null)
            {
                throw new ArgumentNullException(nameof(updateCustomerCommand));
            }

            if (id != updateCustomerCommand.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(updateCustomerCommand);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool isCustomerExistsQuery = await _mediator.Send(new IsCustomerExistsQuery() { CustomerId = id });
                    if (!isCustomerExistsQuery)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateCustomerCommand);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Customer customer = await _mediator.Send(new GetCustomerDetailsQuery() { CustomerId = id });
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Unit customer = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
