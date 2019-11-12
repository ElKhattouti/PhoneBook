using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhoneBook_Models;
using PhoneBook_Web.Services;

namespace PhoneBook_Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApiService _api = ApiService.Api;

        // GET: Contact
        public ActionResult Index()
        {
            var contacts = _api.Get().Result;
            return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            var contact = _api.Get(id).Result;
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,TelephoneNumber")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            try
            {
                contact = _api.Post(contact).Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var contact = _api.Get(id).Result;
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ContactId,FirstName,LastName,TelephoneNumber")] Contact contact)
        {
            if (id != contact.ContactId)
                return View(contact);
            try
            {
                contact = _api.Put(contact).Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Contact/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Contact/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}