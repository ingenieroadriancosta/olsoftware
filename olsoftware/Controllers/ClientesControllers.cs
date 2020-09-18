using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using olsoftware.Models;
using olsoftware.Models.AllModelsParams;


namespace olsoftware.Controllers
{
    public class ClientesController : Controller
    {
        [HttpPost("[action]"), FormatFilter]
        public IActionResult addclientes( ClientesParams clip )
        {
            if( db.Clientes.Where(c=>c.idcard==clip.idcard).FirstOrDefault()!=null ){
                res.msg = "El cliente ya existe!!!";
                return View( res );
            }
            db.Clientes.Add(clip);
            db.SaveChanges();
            if( db.Clientes.Where(c=>c.idcard==clip.idcard).FirstOrDefault().idcard==clip.idcard ){
                res.msg = "Cliente ingresado correctamente.";
            }else{
                res.msg = "Error ingresando el cliente!!!";
            }
            
            return View( res );
        }
        //
        public IActionResult Clientes(){
            string idstr = Request.Query["idcard"] + "";
            if( idstr.Length<1 ){
                return View(res);
            }
            long idcard;
            if( !long.TryParse( idstr, out idcard ) ){
                res.showmsg = true;
                res.msg = "El usuario " + idstr + " no existe";
                return View(res);
            }else{
            }
            res.cli = db.Clientes.Where( cl=>cl.idcard==idcard).FirstOrDefault();
            return View(res);
        }
        //
        private Models.OlSoftwareDbContext db;
        Responses res = new Responses();
        public ClientesController(Models.OlSoftwareDbContext context) {
            this.db = context;
        }
    }
}