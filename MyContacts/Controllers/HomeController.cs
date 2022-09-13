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
        _contacts.Save();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateContact(ContactViewModel contact)
    {
        _contacts.Update(_mapper.Map<ContactViewModel, ContactDTO>(contact));
        _contacts.Save();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteContact(int contactId)
    {
        _contacts.Delete(contactId);
        _contacts.Save();
        return RedirectToAction("Index");
    }
}