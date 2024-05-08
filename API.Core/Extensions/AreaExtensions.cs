using API.Core.DTOs;
using API.Core.Models;
using API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Extensions
{
    public static class AreaExtensions
    {
        public static AreaDTO ToDto(this Area document) =>
            new AreaDTO
            {
                Id = document.Id,
                Descripcion = document.Descripcion,
                IdDepartamento = document.IdDepartamento,
                IdEmpresa = document.IdEmpresa
            };

        public static AreaUpsert DtoToBase(this Area document) =>
            new AreaUpsert
            {
                Descripcion = document.Descripcion,
                IdDepartamento = document.IdDepartamento,
                IdEmpresa = document.IdEmpresa
            };        

        //public static List<PatientDto> ToDtos(this List<Patient> documents) =>
        //    documents.Select(x => x.ToDto()).ToList();

        //public static Patient DtoToPatient(this PatientDto document) =>
        //new Patient
        //{
        //    CognitoSub = document.CognitoSub,
        //    CreationDate = document.CreationDate,
        //    DateOfBirth = document.DateOfBirth,
        //    PatientPhoneNumber = document.PatientPhoneNumber,
        //    FirstName = document.FirstName,
        //    LastName = document.LastName,
        //    PreferredName = document.PreferredName,
        //    PrimaryClinicianId = document.PrimaryClinicianId,
        //    ProgramStatus = document.ProgramStatus,
        //    EmailAddress = document.EmailAddress,
        //};

    }
}
