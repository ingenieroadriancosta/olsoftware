using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using olsoftware.Models.AllModelsParams;

namespace olsoftware.Controllers
{
    // Parametros de los clientes.
    public class Responses{
        public bool assert;
        public string msg;
        public string tablestyle;
        public string thdstyle;
        public bool showmsg;
        public ClientesParams cli;
        public Responses(){
            tablestyle = "table table-striped .table-responsive-sm";
            thdstyle = "width:10%;border: 2px solid black;text-align: center; vertical-align: middle;";
        }
    }
}