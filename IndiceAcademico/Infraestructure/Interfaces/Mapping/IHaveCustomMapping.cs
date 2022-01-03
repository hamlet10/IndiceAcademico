using AutoMapper;

namespace IndiceAcademico.Infraestructure.Interfaces.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
