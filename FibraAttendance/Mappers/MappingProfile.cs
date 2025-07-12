﻿using AutoMapper;
using FibraAttendance.DTOs;
using FibraAttendance.Models;
using FibraAttendance.Util;

namespace FibraAttendance.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Mapeo de IclockTerminal a TerminalInfoDto
            CreateMap<IclockTerminal, TerminalInfoDto>()
                .ForMember(dest => dest.IdTerminal,opt=> opt.MapFrom(src=>src.Id))
                .ForMember(dest => dest.NumeroDeSerie, opt => opt.MapFrom(src => src.Sn))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Alias))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area.AreaName)) // Mapeo desde la propiedad de navegación
                .ForMember(dest => dest.IpDispositivo, opt => opt.MapFrom(src => src.IpAddress))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.UltimaActividad, opt => opt.MapFrom(src => src.LastActivity))
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src.UserCount))
                .ForMember(dest => dest.Huella, opt => opt.MapFrom(src => src.FpCount))
                .ForMember(dest => dest.Rostro, opt => opt.MapFrom(src => src.FaceCount))
                .ForMember(dest => dest.Palma, opt => opt.MapFrom(src => src.PalmCount))
                .ForMember(dest => dest.Marcaciones, opt => opt.MapFrom(src => src.TransactionCount))
                .ForMember(dest => dest.Cmd, opt => opt.MapFrom(src => src.CaptureStamp)) // Asumiendo PushProtocol como el valor más cercano a Cmd
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.TerminalName));


            // Mapeo para las marcaciones 
            CreateMap<IclockTransaction, TransactionEmployeeDepartmentDto>()
                .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.EmpCode))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.PunchTime.Date)) // Obtiene solo la fecha
                .ForMember(dest => dest.Hora, opt => opt.MapFrom(src => src.PunchTime)) // Obtiene la fecha y hora completa
                .ForMember(dest => dest.EstadoMarcacion, opt => opt.MapFrom(src => src.VerifyType))
                .ForMember(dest => dest.ConMascarilla, opt => opt.MapFrom(src => src.IsMask))
                .ForMember(dest => dest.Temperatura, opt => opt.MapFrom(src => src.Temperature))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.AreaAlias))
                .ForMember(dest => dest.NumeroSerie, opt => opt.MapFrom(src => src.TerminalSn))
                .ForMember(dest => dest.NombreDispositivo, opt => opt.MapFrom(src => src.TerminalAlias))
                .ForMember(dest => dest.CargarHora, opt => opt.MapFrom(src => src.UploadTime))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Emp.FirstName)) // Accede a la propiedad de navegación 'Emp'
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Emp.LastName)) // Accede a la propiedad de navegación 'Emp'
                .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Emp.Department.DeptName))
                .ForMember(dest=>dest.Cargo,opt=>opt.MapFrom(src=>src.Emp.Position.PositionName)); // Accede a las propiedades de navegación 'Emp' y luego 'Department'

            CreateMap<AttTimeinterval, HorarioInfoDto>()
                .ForMember(dest => dest.IdHorio, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Alias))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.UseMode))
                .ForMember(dest => dest.HoraEntrada, opt => opt.MapFrom(src => ConvertirHoras.ExtraerHoras(src.InTime)))
                .ForMember(dest=>dest.HoraSalida,opt=>opt.MapFrom(src=>ConvertirHoras.AgregarMinutos(src.WorkTimeDuration,src.InTime)))

                .ForMember(dest => dest.HoraEntradaDesde, opt => opt.MapFrom(src => ConvertirHoras.RestarMinutos(src.InAheadMargin,src.InTime)))
                .ForMember(dest => dest.HoraEntradaHasta, opt => opt.MapFrom(src => ConvertirHoras.AgregarMinutos(src.InAboveMargin, src.InTime)))
                .ForMember(dest => dest.HoraSalidaDesde, opt => opt.MapFrom(src => ConvertirHoras.AgregarMinutos(src.WorkTimeDuration-src.OutAheadMargin, src.InTime)))
                .ForMember(dest => dest.HoraSalidaHasta, opt => opt.MapFrom(src => ConvertirHoras.AgregarMinutos(src.WorkTimeDuration+src.OutAboveMargin, src.InTime)))


                .ForMember(dest=>dest.TiempoTrabajo,opt=>opt.MapFrom(src=>src.WorkTimeDuration))
                .ForMember(dest => dest.Descanso, opt => opt.MapFrom(src => GetBreakDuration(src)))
                .ForMember(dest=>dest.DiasLaboral,opt=>opt.MapFrom(src=>src.WorkDay))
                .ForMember(dest => dest.TipoTrabajo, opt => opt.MapFrom(src =>GetWorkType(src.WorkType)))
                .ForMember(dest=>dest.EntradaTemprana,opt=>opt.MapFrom(src=>src.EarlyIn))
                .ForMember(dest=>dest.EntradaTarde,opt=>opt.MapFrom(src=>src.LateOut))
                .ForMember(dest=>dest.MinEntradaTemprana,opt=>opt.MapFrom(src=>src.MinEarlyIn))
                .ForMember(dest=>dest.MinSalidaTarde,opt=>opt.MapFrom(src=>src.MinLateOut))
                .ForMember(dest=>dest.Hnivel,opt=>opt.MapFrom(src=>src.OvertimeLv))
                .ForMember(dest => dest.HNivel1,opt=>opt.MapFrom(src=>src.OvertimeLv1))
                .ForMember(dest=> dest.HNivel2,opt=>opt.MapFrom(src=>src.OvertimeLv2))
                .ForMember(dest=>dest.HNivel3,opt=>opt.MapFrom(src=> src.OvertimeLv3))
                .ForMember(dest=>dest.MarcarEntrada,opt=>opt.MapFrom(src=>src.InRequired))
                .ForMember(dest=>dest.MarcarSalida,opt=>opt.MapFrom(src=>src.OutRequired))
                .ForMember(dest => dest.PLlegadaT, opt => opt.MapFrom(src => src.AllowLeaveEarly))
                .ForMember(dest => dest.PSalidaT, opt => opt.MapFrom(src => src.AllowLate))
                .ForMember(dest=>dest.TipoIntervalo,opt=>opt.MapFrom(src=>src.AvailableIntervalType))
                .ForMember(dest=>dest.PeriodoMarcacion,opt=>opt.MapFrom(src=>src.AvailableInterval))
                .ForMember(dest=>dest.HCambioDia,opt=>opt.MapFrom(src=>ConvertirHoras.ExtraerHoras(src.DayChange)))
                .ForMember(dest => dest.BasadoM, opt => opt.MapFrom(src => src.MultiplePunch))
                ;

            CreateMap<AttBreaktime, DescansoInfoDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Alias))
                .ForMember(dest=>dest.PeriodStart, opt => opt.MapFrom(src => ConvertirHoras.ExtraerHoras(src.PeriodStart)))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.FuncKey, opt => opt.MapFrom(src => src.FuncKey))
                .ForMember(dest => dest.AvailableInterval, opt => opt.MapFrom(src => src.AvailableInterval))
                .ForMember(dest => dest.AvailableIntervalType, opt => opt.MapFrom(src => src.AvailableIntervalType))
                .ForMember(dest => dest.MultiplePunch, opt => opt.MapFrom(src => src.MultiplePunch))
                .ForMember(dest => dest.CalcType, opt => opt.MapFrom(src => src.CalcType))
                .ForMember(dest => dest.MinimumDuration, opt => opt.MapFrom(src => src.MinimumDuration))
                .ForMember(dest=>dest.EarlyIn, opt => opt.MapFrom(src => src.EarlyIn))
                .ForMember(dest => dest.EndMargin, opt => opt.MapFrom(src => ConvertirHoras.AgregarMinutos(src.EndMargin,src.PeriodStart)))
                .ForMember(dest=>dest.LateIn, opt => opt.MapFrom(src => src.LateIn))
                .ForMember(dest=>dest.MinEarlyIn, opt => opt.MapFrom(src => src.MinEarlyIn))
                .ForMember(dest=>dest.MinLateIn, opt => opt.MapFrom(src => src.MinLateIn))
                ;


        }
        private string GetWorkType(int workType)
        {
            if (workType == 0)
            {
                return "Trabajo normal";
            }
            else if (workType == 1)
            {
                return "Día libre";
            }
            else
            {
                return "F.Semanal";
            }
        }
        private int GetBreakDuration(AttTimeinterval source)
        {
            var breakTime = source.AttTimeintervalBreakTimes.FirstOrDefault();
            return breakTime?.Breaktime?.Duration ?? 0;
        }
    }
}
