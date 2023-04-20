//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System;
//using System.Diagnostics;
//using System.Web.Mvc;
//using FisioAPI.Models;
//using FisioAPI.Models.viewModels;
//using Fluent.Infrastructure.FluentModel;

//namespace FisioAPI.Controllers
//{
//    public class ReporteController : Controller
//    {
//        private readonly ApplicationDbContext _dbcontext;

//        public ReporteController(ApplicationDbContext context)
//        {
//            _dbcontext = context;
//        }


//        public IActionResult resumenCasosAbiertos()
//        {

//            DateTime FechaInicio = DateTime.Now;
//            FechaInicio = FechaInicio.AddDays(-5);

//            List<ReportesCA> Lista = (from tbCasosAbiertos in _dbcontext.CasosAbiertos
//                                      where tbCasosAbiertos.FechaRegistro.Value.Date >= FechaInicio.Date
//                                   group tbCasosAbiertos by tbCasosAbiertos.FechaRegistro.Value.Date into grupo
//                                   select new ReportesCA
//                                   {
//                                       fecha = grupo.Key.ToString("dd/MM/yyyy"),
//                                       cantidad = grupo.Count(),
//                                   }).ToList();



//            return HttpStatusCodeResult(StatusCodes.Status200OK, Lista);
//        }

//        private IActionResult HttpStatusCodeResult(int status200OK, List<ReportesCA> lista)
//        {
//            throw new NotImplementedException();
//        }

//        public IActionResult resumenCasosCerrados()
//        {


//            List<ReportesCC> Lista = (from tbCasosCerrados in _dbcontext.CasosCerrados
//                                      where tbCasosCerrados.FechaRegistro.Value.Date >= FechaInicio.Date
//                                      group tbCasosCerrados by tbCasosCerrados.FechaRegistro.Value.Date into grupo
//                                      select new ReportesCC
//                                      {
//                                          fecha = grupo.Key.ToString("dd/MM/yyyy"),
//                                          cantidad = grupo.Count(),
//                                      }).ToList();

//            return HttpStatusCodeResult(StatusCodes.Status200OK, Lista);

//        }

//        private IActionResult HttpStatusCodeResult(int status200OK, List<ReportesCC> lista)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}