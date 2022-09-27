using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repositories
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        public Object ViewDevice();

        public SelectList devCat();

        public SelectList devZone();

        public Category getDeviceCat(Guid id);

        public Zone getDeviceZone(Guid id);

    }
  
}
