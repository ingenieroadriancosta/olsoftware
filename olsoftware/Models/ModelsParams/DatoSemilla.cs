using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using olsoftware.Models;
using olsoftware.Models.AllModelsParams;
namespace olsoftware.Models.DatosS
{
    // Parametros de los clientes.
    public class DatosSemilla{
        OlSoftwareDbContext db;
        public bool crear( OlSoftwareDbContext dbi ){
            db = dbi;
            if( db.Clientes.Where(ss=>ss.idcard==901293).FirstOrDefault()!=null  ){
                return false;
            }
            int idcI = 901293;
            int idc = idcI;
            int iphone = 9120334;
            addcliente( idc++, "Juan", "Perez", iphone );
            addcliente( idc++, "Carlos", "Payares", iphone+1521 );
            addcliente( idc++, "Lisa", "Palomino", iphone+1521 );
            addcliente( idc++, "Carmen", "Tellez", iphone+1521 );
            addcliente( idc++, "Alicia", "Keys", iphone+1521 );
            addcliente( idc++, "Jose", "Canales", iphone+1521 );
            addcliente( idc++, "Ivan", "ramirez", iphone+1521 );
            addcliente( idc++, "Luis", "Costa", iphone+1521 );
            addcliente( idc++, "Leonor", "Ospino", iphone+1521 );
            addcliente( idc++, "Juan", "Zuleta", iphone+1521 );
            //
            //
            int nhours = 1440;
            int price = 500000;
            addproyecto( idcI, "Frankester", price*( (nhours++)*price ), nhours );
            addproyecto( idcI++, "Chelser", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+3, "Bavarina", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+6, "Postal", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+4, "Ice&Fuits", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+1, "ShopCenter", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+8, "Friendsplus", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+7, "Matchs&more", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+6, "Clicks", price*( (nhours++)*price ), nhours );
            addproyecto( idcI+5, "meatnow", price*( (nhours++)*price ), nhours );
            //
            //
            db.SaveChanges();
            return true;
        }
        //
        //
        void addcliente( int idc, string name, string lastname, long phone  ){
            ClientesParams clipar   =  new ClientesParams();
            clipar.idcard = idc;
            clipar.name = name;
            clipar.lastname = lastname;
            clipar.phone = phone;
            db.Clientes.Add( clipar );
        }
        //
        //
        static int lbase = 0;
        static int lbase2 = 1;
        static int lstate = 0;
        void addproyecto( int idc, string name, int price, int nhours ){
            ProyectosParams proypar =  new ProyectosParams();
            proypar.iduser = idc;
            proypar.name = name;
            proypar.dinit = DateTime.Now;
            proypar.dend = DateTime.Now;
            proypar.price = price;
            proypar.Nhours = nhours;
            proypar.lenguage = allstatics.progleng( lbase ).Lname + ", " + 
                                allstatics.progleng( lbase2 ).Lname;
            proypar.level = allstatics.progleng( lbase ).Llevel + ", " + 
                                allstatics.progleng( lbase2 ).Llevel;
            proypar.state = lstate;
            db.Proyectos.Add( proypar );
            lbase = 7&(lbase + 1);
            lbase2 = 7&(lbase2 + 2);
            lstate = 3&(lstate + 1);
        }
    }
}

