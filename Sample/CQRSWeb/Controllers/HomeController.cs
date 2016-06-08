﻿using System;
using System.Web.Mvc;
using CQRSCode.ReadModel;
using CQRSCode.WriteModel.Commands;
using CQRSlite.Commands;

namespace CQRSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public HomeController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        public ActionResult Index()
        {
            ViewData.Model = _readmodel.GetInventoryItems();
            return View();
        }

        public ActionResult Details(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            var id = Guid.NewGuid();
            _commandSender.Send(new CreateInventoryItem(id, name));
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult ChangeName(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult ChangeName(Guid id, string name, int version)
        {
            _commandSender.Send(new RenameInventoryItem(id, name, version));
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult Deactivate(Guid id, int version)
        {
            _commandSender.Send(new DeactivateInventoryItem(id, version));
            return RedirectToAction("Index");
        }

        public ActionResult CheckIn(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(Guid id, int number, int version)
        {
            _commandSender.Send(new CheckInItemsToInventory(id, number, version));
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult Remove(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult Remove(Guid id, int number, int version)
        {
            _commandSender.Send(new RemoveItemsFromInventory(id, number, version));
            return RedirectToAction("Details", new { id = id });
        }
    }
}
