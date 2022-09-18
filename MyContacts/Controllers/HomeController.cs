using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyContacts_BAL.DTO;
using MyContacts_BAL.Interface;
using MyContacts.Models;

namespace MyContacts.Controllers;

public class HomeController : Controller
{
    private readonly IMapper _mapper;
    private readonly IService _contacts;

    public HomeController(IMapper mapper, IService contacts)
    {
        _mapper = mapper;
        _contacts = contacts;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var contacts = _mapper.Map<IEnumerable<ContactDTO>, IEnumerable<ContactViewModel>>(_contacts.GetAll());
        return View(contacts);
    }
    [HttpPost]
    public IActionResult AddContact(ContactViewModel contact)
    {
        _contacts.Create(_mapper.Map<ContactViewModel, ContactDTO>(contact));
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateContact(ContactViewModel contact)
    {
        _contacts.Update(_mapper.Map<ContactViewModel, ContactDTO>(contact));
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteContact(int? contactId)
    {
        if (contactId is null)
            return NotFound();
        
        _contacts.Delete(contactId.Value);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetModal(int? contactId)
    {
        ContactViewModel contact;
        
        if (contactId is null)
        {
            contact = new ContactViewModel() { toUpdate = false };
        }
        else
        {
            contact = _mapper.Map<ContactDTO, ContactViewModel>(_contacts.GetById(contactId.Value));
        }

        return PartialView("Components/_ModalForm", contact);
    }
}