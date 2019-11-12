using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PhoneBook_Models;

namespace PhoneBook_Web.Controllers
{
    public class ContactController : Controller
    {
		private static List<Contact> _contacts=new List<Contact>();

        // GET: Contact
        public ActionResult Index()
        {
            return View(_contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View(_contacts[id]);
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
				// TODO: Add create logic here
				_contacts.Add(contact);
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
            return View(_contacts[id]);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ContactId,FirstName,LastName,TelephoneNumber")] Contact contact)
        {
            if(id!=contact.ContactId)
                return View(contact);
            try
            {
				_contacts[id] = contact;
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