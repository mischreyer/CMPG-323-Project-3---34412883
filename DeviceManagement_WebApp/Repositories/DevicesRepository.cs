using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repositories
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {

        }
        public Object ViewDevice()
        {
            var simp = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return simp;
        }
        public SelectList devCat()
        {
            var pop = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return pop;
        }
        public SelectList devZone()
        {
            var pop = new SelectList(_context.Zone, "ZoneId", "ZoneId");
            return pop;
        }
        public Category getDeviceCat(Guid id)
        {
          Category cat = _context.Category.Find(id);
            return cat;
        }

        public Zone getDeviceZone(Guid id)
        {
            Zone cat = _context.Zone.Find(id);
            return cat;
        }


    }
}
