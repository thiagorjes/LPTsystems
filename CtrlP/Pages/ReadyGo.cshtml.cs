using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CtrlP.Pages
{
    public class ReadyGoModel : PageModel
    {
        public void OnGet()
        {
            if( MedidoresModel.Medidores==null){
                new MedidoresModel().OnGet();
            }
        }
    }
}
