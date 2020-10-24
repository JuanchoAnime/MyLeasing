namespace MyLeasing.Api.Infrastructure.Mapper
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;

    public class OwnerMapper : GenericMapper<OwnerRest, OwnerDto>
    {
        public override OwnerDto GetDto(OwnerRest rest)
        {
            return new OwnerDto {
                Address = rest.Address,
                CellPhone = rest.CellPhone,
                Document = rest.Document,
                FirstName = rest.FirstName,
                FixedPhone = rest.FixedPhone,
                Id = rest.Id,
                LastName = rest.LastName
            };
        }

        public override OwnerRest GetRest(OwnerDto dto)
        {
            return new OwnerRest
            {
                Address = dto.Address,
                CellPhone = dto.CellPhone,
                Document = dto.Document,
                FirstName = dto.FirstName,
                FixedPhone = dto.FixedPhone,
                Id = dto.Id,
                LastName = dto.LastName
            };
        }
    }
}
