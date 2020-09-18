using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace olsoftware.Models.AllModelsParams
{
    // Parametros de los clientes.
    public class ClientesParams{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 0)]
        public long idcard{get;set;}
        //
        public string name{get;set;}
        //
        public string lastname{get;set;}
        //
        public long phone{get;set;}
        //
        public List<ProyectosParams> PPAR { get; set; }
        //
    }
    // Parametros de los proyectos.
    public class ProyectosParams{
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 0)]
        public int id{get;set;}

        public long iduser{get;set;}
        //
        public string name{get;set;}
        //
        public DateTime dinit{ get;set;}
        //
        public DateTime dend{ get;set;}
        //
        public int price{get;set;}
        //
        public int Nhours{get;set;}
        //
        public string lenguage{get;set;}
        public string level{get;set;}
        //
        public int state{get;set;}
        //
        public ClientesParams ClientesParams { get; set; }
        //
        public ProyectosParams()
        {
            this.dend = DateTime.UtcNow;
        }
        //
    }
    //
    /*
    REFERENCIAS ESTATICAS, TIPOS DE DATOS ENTRE OTROS.
    /*/
    //
    public class lngref{
        public string Lname;
        public string Llevel;
    }
    //
    public static class allstatics{
        //
        public static string proyectstate( int istate ){
            string[] strstate={ "Negociación", "Proceso", "Terminado", "Anulado" };
            return strstate[istate];
        }
        //
        static lngref[] AllLngs = null;
        //
        public static lngref[] alllng(){
            if( allstatics.AllLngs!=null ){
                return allstatics.AllLngs;
            }
            //
            string[] nln = {     "C#", "JAVA", "KOTLIN",      "C", "ASSEMBLER", "SQL",   "PHP", "PYTHON" };
            string[] tln = {   "ALTO", "ALTO",   "ALTO",  "MEDIO",      "BAJO", "ALTO", "ALTO",   "ALTO" };
            //
            allstatics.AllLngs = new lngref[nln.Length];
            for( int i=0; i<AllLngs.Length; i++ ){
                allstatics.AllLngs[i] = new lngref();
                allstatics.AllLngs[i].Lname = nln[i];
                allstatics.AllLngs[i].Llevel = tln[i];
            }
            return allstatics.AllLngs;
        }
        public static lngref progleng( int itype ){
            lngref[] alll = alllng();
            if( itype>=alll.Length || itype<0 ){
                throw new System.Exception("Error: tipo de lenguaje no aceptado.");
            }
            return alllng()[itype];
        }
    }


}
