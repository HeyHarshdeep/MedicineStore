using System.Collections.Generic;

namespace PSMedicine.ViewModel
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class MedicineViewModel
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string ExpiryDate { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
    }
    public class MedicinesViewModel
    {
        public List<MedicineViewModel> Medicines { get; set; }
    }


}
