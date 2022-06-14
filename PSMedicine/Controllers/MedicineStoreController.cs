using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PSMedicine.ViewModel;
using PSMedicineAPI.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PSMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineStoreController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MedicineStoreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetMedicine")]
        public ActionResult GetMedicine()
        {
            MedicinesViewModel medicinesViewModel = new MedicinesViewModel();

            using (StreamReader r = new StreamReader("JsonData/MedicineStoreDB.json"))
            {
                string json = r.ReadToEnd();
                medicinesViewModel = JsonConvert.DeserializeObject<MedicinesViewModel>(json);
            }
            return Ok(new ResponseViewModel { Data = medicinesViewModel.Medicines, Message = "Here is your data", Status = true });
        }

        [HttpGet("Search")]
        public ActionResult Search(string search)
        {
            if (ModelState.IsValid)
            {
                MedicinesViewModel medicinesViewModel = new MedicinesViewModel();
                List<MedicineViewModel> result = new List<MedicineViewModel>();
                using (StreamReader r = new StreamReader("JsonData/MedicineStoreDB.json"))
                {
                    string json = r.ReadToEnd();
                    medicinesViewModel = JsonConvert.DeserializeObject<MedicinesViewModel>(json);
                   
                }

                if (!string.IsNullOrEmpty(search))
                {
                    result = medicinesViewModel.Medicines.Where(x => x.Name.Contains(search)).ToList();
                }
                else
                {
                    result = medicinesViewModel.Medicines;
                }



                return Ok(new ResponseViewModel { Data = result, Message = "Here is your data", Status = true });
            }
            else
            {
                return BadRequest(new ResponseViewModel { Message = "Please check your payload", Status = false });
            }
        }



    }
}
