using AutoMapper;
using IndiceAcademico.Infraestructure.Interfaces.Mapping;
using IndiceAcademico.Models;
using System.Collections.Generic;

namespace IndiceAcademico.Infraestructure.Dtos
{
    public class StudentIndexDto : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Student, StudentIndexDto>()
            .ForMember(dto => dto.ID, opt => opt.MapFrom(i => i.ID))
            .ForMember(dto => dto.Code, opt => opt.MapFrom(i => i.Code))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(dto => dto.Enrollments, opt => opt.MapFrom(i => i.Enrollments));
        }
    }
}