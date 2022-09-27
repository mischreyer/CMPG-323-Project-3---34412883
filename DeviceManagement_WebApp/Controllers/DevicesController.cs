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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
    

        private readonly IDevicesRepository _devicesRepository;
        public DevicesController(IDevicesRepository devicesRepository)
        {
            _devicesRepository = devicesRepository;
        }

        //Get all devices
     public ActionResult Index()
        {
            return View(_devicesRepository.ViewDevice());
        }

        //Create new Device
        public ActionResult Create()
        {
            ViewData["CategoryId"] = _devicesRepository.devCat();
            ViewData["ZoneId"] = _devicesRepository.devZone();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Device device)
        {
            
            device.DeviceId = Guid.NewGuid();
            device.DateCreated = DateTime.Now;
            _devicesRepository.Add(device);

            return RedirectToAction("Index");
        }
        //Delete A Device
        public ActionResult Delete(Guid id)
        {
            Device device = _devicesRepository.GetById(id);
            Category cat = _devicesRepository.getDeviceCat(device.CategoryId);
            Zone zone = _devicesRepository.getDeviceZone(device.ZoneId);
            device.Zone = zone;
            device.Category = cat;
            return View(device);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Device device)
        {
            _devicesRepository.Remove(device);

            return RedirectToAction("Index");
        }

        //Edit device
        public ActionResult Edit(Guid id)
        {
            Device device = _devicesRepository.GetById(id);
            ViewData["CategoryId"] = _devicesRepository.devCat();
            ViewData["ZoneId"] = _devicesRepository.devZone();
            return View(device);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Device device)
        {
            _devicesRepository.Update(device);

            return RedirectToAction("Index");
        }

        //Get device Details
        public ActionResult Details(Guid id)
        {
            Device dev = _devicesRepository.GetById(id);
            Category cat = _devicesRepository.getDeviceCat(dev.CategoryId);
            Zone zone = _devicesRepository.getDeviceZone(dev.ZoneId);
            dev.Zone = zone;
            dev.Category = cat;
            return View(dev);
        }

    }
}
