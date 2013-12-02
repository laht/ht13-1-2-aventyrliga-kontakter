using AdventurousContacts.Models.Repository;
using AdventurousContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        //Dependency injected constructors
        public ContactController()
            :this(new Repository())
        {
            //empty
        }
        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Index/
        public ActionResult Index()
        {
            var contacts = _repository.GetLastContacts();
            return View("Index", contacts);
        }
        //
        // GET: /Create/
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        //
        // Post: /Create/
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ContactID")]Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Add(contact);
                    _repository.Save();
                    return View("Success");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontakten skulle sparas");
                }
            }

            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }
            return View("Delete", contact);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = _repository.GetContactById(id);
            try
            {
                _repository.Delete(contact);
                _repository.Save();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när en kontakt skulle tas bort");
            }
            return View();
        }
        public override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

        //Return edit page
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Edit", contact);
        }
        //Save edited contact and return success page
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(contact);
                    _repository.Save();

                    return View("Saved", contact);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontakten skulle redigeras");
                }
            }

            return View("Edit", contact);
        }
    }
}
