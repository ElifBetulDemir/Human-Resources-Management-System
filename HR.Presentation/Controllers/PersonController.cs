﻿using AutoMapper;
using HR.Application.Features.People.Commands.PersonUpdate;
using HR.Application.Features.People.Queries.GetPerson;
using HR.Application.Features.People.ViewModels;
using HR.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Presentation.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PersonController(IMediator mediator, IMapper mapper , IWebHostEnvironment webHostEnvironment)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(GetPersonQuery query)
        {
            query.Id = Guid.Parse("78516AFA-1058-4808-8DA2-6B79DC0592FB");
            var result = await mediator.Send(query);
            return View(result);
        }

        public async Task<IActionResult> UpdatePerson(Guid id)
        {
            GetPersonQuery query = new GetPersonQuery() { Id = id };
            var result = await mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(PersonDetailVM personDetailVM)
        {
            GetPersonQuery query = new GetPersonQuery() { Id = personDetailVM.Id };
            var result = await mediator.Send(query);
            
            var updateResult = mapper.Map<PersonUpdateCommand>(result);
            updateResult.Id = personDetailVM.Id;
            updateResult.Photo = FileOperation.ReturnFileName(personDetailVM.PhotoFile, "photos", webHostEnvironment);
            updateResult.Address = personDetailVM.Address;
            updateResult.PhoneNumber = personDetailVM.PhoneNumber;
            
            await mediator.Send(updateResult);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            GetPersonQuery query = new GetPersonQuery() { Id = id };
            var result = await mediator.Send(query);
            return View(result);
        }

    }
}