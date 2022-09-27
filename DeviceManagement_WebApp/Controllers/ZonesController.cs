using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Controllers
{
    public class ZonesController : Controller
    {
        private readonly IZonesRepository _zonesRepository;
        public ZonesController(IZonesRepository zonesRepository)
        {
            _zonesRepository = zonesRepository;
        }

        //Get all Zones
        public ActionResult Index()
        {
            return View(_zonesRepository.GetAll());
        }
        //Create Zone
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            zone.DateCreated = DateTime.Now;
            _zonesRepository.Add(zone);
            return RedirectToAction("Index");
        }

        //Edit Zone
        public ActionResult Edit(Guid id)
        {
            Zone zone = _zonesRepository.GetById(id);
            return View(zone);  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Zone zone)
        {
            _zonesRepository.Update(zone);

            return RedirectToAction("Index");
        }

       //Delete Zone
       public ActionResult Delete(Guid id)
        {
            Zone zone = _zonesRepository.GetById(id);
            return View(zone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Zone zone)
        {
            _zonesRepository.Remove(zone);
            return RedirectToAction("Index");
        }
        
        //Get zone details
        public ActionResult Details(Guid id)
        {
            Zone zone = _zonesRepository.GetById(id);

            return View(zone);
        }
    }
}
