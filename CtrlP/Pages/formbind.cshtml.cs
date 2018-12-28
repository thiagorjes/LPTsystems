using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CtrlP.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CtrlP.Pages
{

    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<double> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
    }
    public class FormbindModel : PageModel
    {
        [BindProperty]
        public SensorSettings Order { get; set; }
        public string Page_Title = "teste bind property";

        public void OnGet(){
            if(Order == null){
                Order = new SensorSettings();
                Order.HWID= "thiago";
                Order.CalibrationParameters = new List<double>();
                Order.CalibrationParameters.Add(0.1);
                Order.CalibrationParameters.Add(12.0);
            }
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)  
            {  
                 Page();  
            }  
            //metodo que altera o medidor
            try
            { 
                var temp = Order.CalibrationParameters.Count;
            }
            catch (System.Exception)
            {
                  NotFound();
            }
            //fim do metodo
             RedirectToPage("./Formbind");
        }
    }
}

