namespace MyLeasing.Api.Infrastructure.Mapper
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class GenericMapper<Rest, Dto>
    {
        public abstract Dto GetDto(Rest rest);

        public abstract Rest GetRest(Dto dto);

        public List<Dto> GetDto(List<Rest> rests) => rests.Select(this.GetDto).ToList();

        public List<Rest> GetRest(List<Dto> dtos) => dtos.Select(this.GetRest).ToList();
    }
}
