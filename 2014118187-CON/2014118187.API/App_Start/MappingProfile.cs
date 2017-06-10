using _2014118187_ENT.Entities;
using _2014118187_ENT.EntitiesDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2014118187.API.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile(){

            CreateMap<ATM, ATMDTO>();
            CreateMap<ATMDTO, ATM>();

            CreateMap<BasedeDatos, BasedeDatosDTO>();
            CreateMap<BasedeDatosDTO, BasedeDatos>();

            CreateMap<Cuenta, CuentaDTO>();
            CreateMap<CuentaDTO, Cuenta>();

            CreateMap<DispensadorEfectivo, DispensadorEfectivoDTO>();
            CreateMap<DispensadorEfectivoDTO, DispensadorEfectivo>();

            CreateMap<Pantalla, PantallaDTO>();
            CreateMap<PantallaDTO, Pantalla>();

            CreateMap<RanuraDeposito, RanuraDepositoDTO>();
            CreateMap<RanuraDepositoDTO, RanuraDeposito>();

            CreateMap<Retiro, RetiroDTO>();
            CreateMap<RetiroDTO, Retiro>();

            CreateMap<Teclado, TecladoDTO>();
            CreateMap<TecladoDTO, Teclado>();





        }
    }
}