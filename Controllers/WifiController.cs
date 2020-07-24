using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WifiApi.Models;
using WifiApi.Services;


namespace WifiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WifiController : ControllerBase
    {
        private readonly WifiService _wifiService;

        public WifiController(WifiService wifiService)
        {
            _wifiService = wifiService;
        }

        [HttpGet]
        public ActionResult<List<Wifi>> Get() =>
         _wifiService.GetAll();


        [HttpGet("{name:length(24)}", Name = "GetOne")]
        public ActionResult<Wifi> GetOne(string name)
        {
            var wifi = _wifiService.GetOne(name);

            if (wifi == null)
            {
                return NotFound();
            }

            return wifi;
        }

        [HttpGet]
        [Route("getNearest/{latitude}/{longitude}")]
        public ActionResult<Wifi> GetNearest(string latitude, string longitude)
        {
            var wifi = _wifiService.GetNearest(latitude, longitude);

            if (wifi == null)
            {
                return NotFound();
            }

            return wifi;
        }

        [HttpPost]
        [Route("createWifi/{wifi}")]
        public ActionResult<Wifi> Create([FromBody] Wifi wifi)
        {
            _wifiService.Create(wifi);

            return CreatedAtRoute("GetBook", new { id = wifi.Id.ToString() }, wifi);
        }

        [HttpPut("{id:length(24)}")]
        [Route("update/{wifi}")]
        public IActionResult Update(string id, Wifi wifi)
        {
            var existingWifi = _wifiService.GetOne(id);

            if (existingWifi == null)
            {
                return NotFound();
            }

            _wifiService.Update(id, wifi);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var wifi = _wifiService.GetOne(id);

            if (wifi == null)
            {
                return NotFound();
            }

            _wifiService.Remove(wifi.Id);

            return NoContent();
        }
    }
}
